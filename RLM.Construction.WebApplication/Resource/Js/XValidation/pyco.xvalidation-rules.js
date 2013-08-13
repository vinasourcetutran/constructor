/*
    $Id: pyco.xvalidation-rules.js,v 1.5 2007/01/16 07:10:57 thanh.an Exp $
*/
//-----------------------------------------------------------------------------------------------
// @requirements: common-dom, xvalidation-core
if (!window.PYCO_COMMON_DOM) {
    alert("Reference Error:\n" +
            "Common DOM is required.\n" +
            "(Please make sure that you have pyco.common-dom.js in your include path.)");
}
if (!window.PYCO_XVALIDATION_CORE) {
    alert("Reference Error:\n" +
            "Validation Core is required.\n" +
            "(Please make sure that you have pyco.xvalidation-core.js in your include path.)");
}

// Reference definition
if (window.PYCO_XVALIDATION_RULES) {
    window.PYCO_XVALIDATION_RULES.count ++;
    alert("Reference Error:\n" +
            "Duplicated references of Pyco XValidation Rules found. Ref. count = " + (window.PYCO_XVALIDATION_RULES.count));
} else {
    window.PYCO_XVALIDATION_RULES = new Object();
    window.PYCO_XVALIDATION_RULES.count = 1;
}
//-----------------------------------------------------------------------------------------------
// @class: AbstractRule implements IValidationRule
function AbstractRule (options) {
    this.options = options;
};
AbstractRule.prototype.ensure = function (context) {
    try {
        this.ensureImpl(context);
    } catch (e) {
        if (e.constructor == ValidationError) {
            throw e;
        } else {
            throw new ValidationException("Error in executing rule againts '" + this.getFieldName() + "'", e);
        }
    }
};
AbstractRule.prototype.getFieldName = function () {
    return this.options.field;
};
AbstractRule.prototype.getField = function (context) {
    return context.getField(this.getFieldName());
};
AbstractRule.prototype.getMessage = function () {
    return this.options.message ? this.options.message : (this.defaultMessage ? this.defaultMessage : null);
};
AbstractRule.prototype.getHint = function () {
    return this.options.hint ? this.options.hint : (this.defaultHint ? this.defaultHint : null);
};
AbstractRule.prototype.throwValidationError = function(context) {
    throw new ValidationError(this.getField(context), this.getMessage(), this.getHint(), this);
};
//-----------------------------------------------------------------------------------------------
// @class: ValueRequiredRule implements IValidationRule
function ValueRequiredRule(options) {
    this.options = options;
    this.defaultMessage = "The '" + this.options.field + "' field is required.";

    this.allowsAllSpaces = (options && options.allowsAllSpaces);

    this.ensureImpl = function (context) {
        var field = this.getField(context);
        var s = field.value;

        if ((this.allowsAllSpaces && s.length == 0) || s.match(/^[ \t]*$/)) {
            this.throwValidationError(context);
        }
    };
};
ValueRequiredRule.prototype = new AbstractRule();

//-----------------------------------------------------------------------------------------------
// @class: PatternMatchedRule implements IValidationRule
function PatternMatchedRule(options) {
    this.options = options;

    if (!options || !options.pattern) {
        throw ValidationException("A PatternMatchedRule requires a valid pattern to be specified in the options");
    }
    this.pattern = options.pattern;
    this.defaultMessage = "The field '" + this.options.field + "' must be in the pattern of '" + this.pattern + "'";

    this.ensureImpl = function (context) {
        var field = this.getField(context);
        if (!field.value.match(this.pattern)) {
            this.throwValidationError(context);
        }
    };
}
PatternMatchedRule.prototype = new AbstractRule();
//-----------------------------------------------------------------------------------------------
// @class: RangedIntegerRule implements IValidationCondition
function RangedIntegerRule(options) {
    this.options = options;
    this.min = options.min ? options.min : null;
    this.max = options.max ? options.max : null;
    this.minInclusive = options.minInclusive ? options.minInclusive : false;
    this.maxInclusive = options.maxInclusive ? options.maxInclusive : false;

    if (this.min == null && this.max == null) {
        throw new ValidationException("At least min or max must be specified in a RangedIntegerRule.");
    }

    this.defaultMessage = "'" + this.options.field + "' must be in a valid range.";

    this.ensureImpl = function (context) {
        //alert("called: " + this.min);
        var field = this.getField(context);
        var s = field.value;

        var intValue = 0;

        try {
            intValue = parseInt(s, 10);
        } catch (e) {
            this.throwValidationError(context);
        }
        if (isNaN(intValue)) {
            this.throwValidationError(context);
        }
        if (this.min != null) {
            if (this.minInclusive && intValue < this.min) {
                this.throwValidationError(context);
            }
            if (!this.minInclusive && intValue <= this.min) {
                this.throwValidationError(context);
            }
        }
        if (this.max != null) {
            if (this.maxInclusive && intValue > this.max) {
                this.throwValidationError(context);
            }
            if (!this.maxInclusive && intValue >= this.max) {
                this.throwValidationError(context);
            }
        }

    };
}
RangedIntegerRule.prototype = new AbstractRule();


//-----------------------------------------------------------------------------------------------
// @class: SelectedCondition implements IValidationCondition
function ValueIsCondition(options) {
    this.name = options.field;
    this.value = options.value;
}
ValueIsCondition.prototype.evaluate = function (context) {
    try {
        var field = context.getField(this.name);

        return field.value == this.value;
    } catch (e) {
        throw new ValidationException("Error in executing ValueIsCondition againts '" + this.name + "'", e);
    }
};
