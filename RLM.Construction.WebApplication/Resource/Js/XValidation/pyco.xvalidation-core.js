/*
    The Xtreme Validation Framework.
    Copyright (c) Pyramid Consulting. All rights reserved.

    XVALIDATION-CORE: Core classes of the validation framework.

    $Id: pyco.xvalidation-core.js,v 1.4 2007/01/16 07:10:57 thanh.an Exp $
*/
//-----------------------------------------------------------------------------------------------
// @requirements: common-dom
if (!window.PYCO_COMMON_DOM) {
    alert("Reference Error:\n" +
            "Pyramid Common DOM is required.\n" +
            "(Please make sure that you have pyco.common-dom.js in your include path.)");
}

// Reference definition
if (window.PYCO_XVALIDATION_CORE) {
    window.PYCO_XVALIDATION_CORE.count ++;
    alert("Reference Error:\n" +
            "Duplicated references of Pyco XValidation Core found. Ref. count = " + (window.PYCO_XVALIDATION_CORE.count));
} else {
    window.PYCO_XVALIDATION_CORE = new Object();
    window.PYCO_XVALIDATION_CORE.count = 1;
}
//-----------------------------------------------------------------------------------------------
// @class: ValidationException
function ValidationException(message, cause) {
    this.message = message;
    this.cause = cause ? cause : null;
}

ValidationException.prototype.toString = function () {
    var s = this.message;
    if (this.cause && this.cause.toString) {
        s += "\n\t" + this.cause.toString();
    }

    return s;
};

//-----------------------------------------------------------------------------------------------
// @class: ValidationError
function ValidationError(field, message, hint, rule) {
    this.field = field;
    this.message = message;
    this.hint = hint;
    this.rule = rule;
}
function ValidationErrors() {
    this.errors = [];
};
ValidationErrors.prototype.add = function (validationError) {
    this.errors[this.errors.length] = validationError;
};
ValidationErrors.prototype.addAll = function (validationErrors) {
    for (var i = 0; i < validationErrors.errors.length; i++) {
        this.add(validationErrors.errors[i]);
    }
};
ValidationErrors.prototype.addWhenError = function (validationError) {
    if (validationError) {
        this.add(validationError);
    }
};
ValidationErrors.prototype.hasError = function () {
    return this.errors.length > 0;
};
ValidationErrors.prototype.getFirstError = function () {
    return this.errors[0];
};

//-----------------------------------------------------------------------------------------------
// @class: ValidationContext
function ValidationContext(form, ruleSet) {
    this.form = form;
    this.ruleSet = ruleSet;

    //@ private:
    this.sharedObjects = new Object();
};

ValidationContext.OBJECT_NAME_PREFIX = "shared_";

ValidationContext.prototype.get = function (name) {
    if (this.sharedObjects[ValidationContext.OBJECT_NAME_PREFIX + name]) {
        return this.sharedObjects[ValidationContext.OBJECT_NAME_PREFIX + name];
    }
    return null;
};
ValidationContext.prototype.put = function (name, object) {
    this.sharedObjects[ValidationContext.OBJECT_NAME_PREFIX + name] = object;
};
ValidationContext.prototype.getField = function (name) {
    return this.form.elements[name];
};
//-----------------------------------------------------------------------------------------------
// @class: AlertNotifier implements INotifier
function AlertNotifier() {
}
AlertNotifier.prototype.notify = function (form, errors) {
    var error = errors.getFirstError();
    alert(error.message + (error.hint ? ("\n--------------------------\n" + error.hint) : ""));
    try {
        error.field.focus();
    } catch (e) {}
};
//-----------------------------------------------------------------------------------------------
// @class: ValidationBehavior
function ValidationBehavior () {
    this.stopAtFirstError = true;
    this.stopAtFirstFailedRuleSet = true;

    this.notifier = new AlertNotifier();
    this.formValidationListeners = [];
};
ValidationBehavior.defaultBehavior = new ValidationBehavior();
ValidationBehavior.prototype.apply = function (form) {
    form._validationBehavior = this;
};
ValidationBehavior.prototype.addFormValidationListener = function (listener) {
    this.formValidationListeners.push(listener);
}

//-----------------------------------------------------------------------------------------------
// @class: RuleSet
function RuleSet() {
    this.rules = [];
}
RuleSet.prototype.add = function (rule) {
    this.rules[this.rules.length] = rule;
};
RuleSet.prototype.install = function (form) {
    if (!form._ruleSets) {
        form._ruleSets = [];
        Dom.registerEvent(form, "submit", ValidationManager.handleFormSubmission);
    }
    form._ruleSets[form._ruleSets.length] = this;
};

//-----------------------------------------------------------------------------------------------
// @class: ValidationEvent
function ValidationEvent(form) {
    this.form = form;
    this.canceled = false;
    this.allowPropagation = true;
}
ValidationEvent.prototype.cancel = function () {
    this.canceled = true;
};
ValidationEvent.prototype.stopPropagation = function () {
    this.allowPropagation = false;
};

//-----------------------------------------------------------------------------------------------
// @class: ValidationManager
function ValidationManager() {
};
ValidationManager.fireFormValidationEvent = function (listeners, eventName, eventData) {
    if (!eventData) eventData = new Object();
    eventData.type = eventName;
    eventData.time = new Date();
    
    for (var i = 0; i < listeners.length; i ++) {
        if (!eventData.allowPropagation) break;
        
        var listener = listeners[i];
        if (!listener) continue;
        var f = listener[eventName];
        if (!f || typeof(f) != "function") continue;
        
        try {
            f(eventData);
        } catch (e) {
            //alert(e);
        }
    }
};
ValidationManager.EVENT_TYPE_VALIDATION_STARTED = "onValidationStarted";
ValidationManager.EVENT_TYPE_VALIDATION_DONE = "onValidationSucceeded";
ValidationManager.EVENT_TYPE_VALIDATION_FAILED = "onValidationFailed";
ValidationManager.handleFormSubmission = function (systemEvent) {
    var ev = Dom.getEvent(systemEvent);
    var target = Dom.getTarget(systemEvent);    
    var form = Dom.findParentByTagName(target, "form");

    if (!form._ruleSets) {
        alert("Bad call to the validation manager");
        return;
    }

    if (!form._validationBehavior) {
        form._validationBehavior = ValidationBehavior.defaultBehavior;
    }

    var behavior = form._validationBehavior;
    
    var notifier = behavior.notifier;
    if (notifier.prepare) {
        notifier.prepare();
    }
    
    var errors = new ValidationErrors();
    
    var validationEvent = new ValidationEvent(form);
    ValidationManager.fireFormValidationEvent(behavior.formValidationListeners, 
                                                ValidationManager.EVENT_TYPE_VALIDATION_STARTED,
                                                validationEvent);
    
    try {
        for (var i = 0; i < form._ruleSets.length; i++) {
            var ruleSet = form._ruleSets[i];
            errors.addAll(ValidationManager.validationForm(form, ruleSet, behavior));

            if (behavior.stopAtFirstFailedRuleSet && errors.hasError()) break;
        }
    } catch (ex) {
        alert("An unexpected exception raised while validating the form:\n" + ex +
                "\nThe validation process is now terminated. Form submission aborted.");
        Dom.cancelEvent(ev);
        return;
    }
    
    
    if (errors.hasError()) {
        Dom.cancelEvent(ev);
        notifier.notify(form, errors);
        
        validationEvent = new ValidationEvent(form);
        validationEvent.errorSet = errors;
        ValidationManager.fireFormValidationEvent(behavior.formValidationListeners, 
                                                    ValidationManager.EVENT_TYPE_VALIDATION_FAILED,
                                                    validationEvent);
                                                    
    } else {
        validationEvent = new ValidationEvent(form);
        ValidationManager.fireFormValidationEvent(behavior.formValidationListeners, 
                                                    ValidationManager.EVENT_TYPE_VALIDATION_DONE,
                                                    validationEvent);
                                                    
        if (validationEvent.canceled) {
            Dom.cancelEvent(ev);
        }                                                    
    }
};
ValidationManager.validationForm = function (form, ruleSet, behavior) {
    var context = new ValidationContext(form, ruleSet);

    var errors = new ValidationErrors();
    for (var i = 0; i < ruleSet.rules.length; i++) {
        var rule = ruleSet.rules[i];
        try {
            rule.ensure(context);
        } catch (ex) {
            if (ex.constructor == ValidationError) {
                errors.add(ex);
                if (behavior.stopAtFirstError) break;
            } else {
                throw ex;
            }
        }
    }

    return errors;
};

//-----------------------------------------------------------------------------------------------
// @class: ConditionUtil
function ConditionUtil() {
}
ConditionUtil.evaluate = function (condition, context) {
    if (!condition.valueEvaluated || condition.cachedContext != context) {
        condition.cachedContext = context;
        condition.cachedValue = condition.evaluate(context);
        condition.valueEvaluated = true;
    }
    return condition.cachedValue;
};
// @class: NotCondition implements IValidationCondition
function NotCondition(condition) {
    this.condition = condition;
}
NotCondition.prototype.evaluate = function (context) {
    var value = ConditionUtil.evaluate(this.condition, context);
    return !value;
};
// @class: AndCondition implements IValidationCondition
function AndCondition(leftCondition, rightCondition) {
    this.leftCondition = leftCondition;
    this.rightCondition = rightCondition;
}
AndCondition.prototype.evaluate = function (context) {
    var value1 = ConditionUtil.evaluate(this.leftCondition, context);
    var value2 = ConditionUtil.evaluate(this.leftCondition, context);
    return value1 && value2;
};
// @class: OrCondition implements IValidationCondition
function OrCondition(leftCondition, rightCondition) {
    this.leftCondition = leftCondition;
    this.rightCondition = rightCondition;
}
OrCondition.prototype.evaluate = function (context) {
    var value1 = ConditionUtil.evaluate(this.leftCondition, context);
    var value2 = ConditionUtil.evaluate(this.leftCondition, context);
    return value1 || value2;
};
//-----------------------------------------------------------------------------------------------
// @class: ConditionalRule implements IValidationRule
function ConditionalRule(wrappedRule, condition) {
    this.wrappedRule = wrappedRule;
    this.condition = condition;
}
ConditionalRule.prototype.ensure = function (context) {
    if (ConditionUtil.evaluate(this.condition, context)) {
        return this.wrappedRule.ensure(context);
    }
};
function ValidationUtil () {
}
ValidationUtil.FIELD_VALUE_REF_RE = /\$\{([^\}]+)\}/g;
ValidationUtil.targetObject = null;
ValidationUtil.evaluate = function (zero, one) {
    return "" + ValidationUtil.targetObject[one];
};
ValidationUtil.evalAgainstObject = function (code, object) {
    ValidationUtil.targetObject = object;
    return code.replace(ValidationUtil.FIELD_VALUE_REF_RE, ValidationUtil.evaluate);
}
