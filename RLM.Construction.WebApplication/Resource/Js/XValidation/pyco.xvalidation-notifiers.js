/*
    The Xtreme Validation Framework.
    Copyright (c) Pyramid Consulting. All rights reserved.

    XVALIDATION-NOTIFIERS: Extended Notifiers

    $Id: pyco.xvalidation-notifiers.js,v 1.2 2007/01/16 07:10:57 thanh.an Exp $
*/
//-----------------------------------------------------------------------------------------------
// @requirements: common-dom
if (!window.PYCO_COMMON_DOM) {
    alert("Reference Error:\n" +
            "Pyramid Common DOM is required.\n" +
            "(Please make sure that you have pyco.common-dom.js in your include path.)");
}

// Reference definition
if (window.PYCO_XVALIDATION_NOTIFIERS) {
    window.PYCO_XVALIDATION_NOTIFIERS.count ++;
    alert("Reference Error:\n" +
            "Duplicated references of Pyco XValidation Notifiers found. Ref. count = " + (window.PYCO_XVALIDATION_NOTIFIERS.count));
} else {
    window.PYCO_XVALIDATION_NOTIFIERS = new Object();
    window.PYCO_XVALIDATION_NOTIFIERS.count = 1;
}
//-----------------------------------------------------------------------------------------------
// @class: BalloonNotifier
function BalloonNotifier() {
};
// @static fields:
BalloonNotifier.ALERT_POST_TRIES = ["BT:LL", "BT:CC", "BT:RR", "TT:LR", "MM:LR", "BB:LR", "TB:LL", "TB:CC", "TB:RR", "TT:RL", "MM:RL", "BB:RL"];

// @static init:
BalloonNotifier.handleWindowOnload = function (systemEvent) {
    if (BalloonNotifier.alertBox) {
        return;
    }
    var div = document.createElement("div");
    div.innerHTML = "<div id=\"alertBox\" class=\"MM LR MMxLR\">\n" +
                    "    <div>\n" +
                    "        <input type=\"button\" onclick=\"BalloonNotifier.closeAlert(); return false;\" title=\"Close\"/>\n" +
                    "        <h3 id=\"alertBoxTitle\">Error title goes here</h3>\n" +
                    "        <p id=\"alertBoxBody\">Correct guide provided by developers is shown here</p>\n" +
                    "    </div>\n" +
                    "</div>";
    Dom.getTag("body").appendChild(div);

    BalloonNotifier.alertBox = Dom.get("alertBox");
    BalloonNotifier.title = Dom.get("alertBoxTitle");
    BalloonNotifier.body = Dom.get("alertBoxBody");

};
Dom.registerEvent(window, "load", BalloonNotifier.handleWindowOnload);

BalloonNotifier.closeAlert = function () {
    BalloonNotifier.alertBox.style.display = "none";
};

BalloonNotifier.prototype.notify = function (form, errors) {
    //throw new JFException("not yet implemented :-s");
    if (this.lastAlertedField) {
        this.lastAlertedField.focus();
        this.lastAlertedField.className = this.lastAlertedField.oldClassName;
        this.oldClassName = null;
        this.lastAlertedField = null;
    }
    var error = errors.getFirstError();

    var field = error.field;
    try {
        field.focus();
        field.select();
    } catch (e) {}

    //positioning
    this.lastAlertedField = field;
    field.oldClassName = field.className;
    field.className += " Highlighted";

    var fX = Dom.getOffsetLeft(field);
    var fY = Dom.getOffsetTop(field);
    var fW = Dom.getOffsetWidth(field);
    var fH = Dom.getOffsetHeight(field);

    var alertBox = BalloonNotifier.alertBox;
    var title = BalloonNotifier.title;
    var body = BalloonNotifier.body;

    // Modified by Hung.Le -- Date : June 29 2007
    if (alertBox == undefined) {
        return;
    }
    alertBox.style.display = "block";
    alertBox.style.visibility = "hidden";

    Dom.setInnerText(title, error.message);
    Dom.setInnerText(body, error.hint);

    var align = "BT:LL";
    var xAlign = "LL";
    var yAlign = "BT";
    var re = /^(TT|TB|MM|BT|BB):(LL|LR|CC|RL|RR)$/;

    var scrollLeft = Dom.getScrollLeft();
    var scrollTop = Dom.getScrollTop();
    var maxX = Dom.getWindowWidth() + scrollLeft;
    var maxY = Dom.getWindowHeight() + scrollTop;

    var bestX = 0;
    var bestY = 0;
    var bestClass = "";
    var bestArea = 0;
    var found = false;
    for (var i = 0; i < BalloonNotifier.ALERT_POST_TRIES.length; i++) {
        align = BalloonNotifier.ALERT_POST_TRIES[i];
        align.match(re)
        xAlign = RegExp.$2;
        yAlign = RegExp.$1;


        var cssClass = xAlign + " " + yAlign + " " + yAlign + "x" + xAlign;

        alertBox.className = cssClass;

        var aW = Dom.getOffsetWidth(alertBox);
        var aH = Dom.getOffsetHeight(alertBox);

        var x = 0;
        var y = 0;

        switch (xAlign) {
            case "LL": x = fX;
                break;
            case "LR": x = fX + fW;
                break;
            case "CC": x = fX + ((fW - aW) / 2);
                break;
            case "RL": x = fX - aW;
                break;
            case "RR": x = fX + fW - aW;
                break;
        }
        switch (yAlign) {
            case "TT": y = fY;
                break;
            case "TB": y = fY + fH;
                break;
            case "MM": y = fY + ((fH - aH) / 2);
                break;
            case "BT": y = fY - aH;
                break;
            case "BB": y = fY + fH - aH;
                break;
        }

        if (x > scrollLeft && y > scrollTop && (x + aW) < maxX && (y + aH) < maxY) {
            found = true;
            break;
        }

        var w = aW;
        var h = aH;

        if (x <= scrollLeft) {
            w -= scrollLeft - x;
        }
        if (y <= scrollTop) {
            h -= scrollTop - y;
        }
        if (x + aW >= maxX) {
            w -= x + aW - maxX;
        }
        if (y + aH >= maxY) {
            h -= y + aH - maxY;
        }
        var newArea = w * h;
        if (newArea > bestArea) {
            //alert("better Area:" + newArea);
            bestArea = newArea;
            bestClass = cssClass;
            bestX = x;
            bestY = y;
        }
    }
    //alert(found);
    if (!found) {
        x = bestX;
        y = bestY;
        alertBox.className = bestClass;
    }
    //set the position
    alertBox.style.left = "" + x + "px";
    alertBox.style.top = "" + y + "px";
    alertBox.style.visibility = "visible";
};

// @class: InlineNotifier
function InlineNotifier() {
    this.generateErrorMessage = true;
    this.placeHolderIdPattern = "${id}Error";
    this.messageSpans = [];
}
InlineNotifier.ERROR_MESSAGE_CLASS_NAME = "ErrorMessage";
InlineNotifier.MESSAGE_CLASS_NAME = "Message";
InlineNotifier.HINT_CLASS_NAME = "Hint";
InlineNotifier.prototype.prepare = function () {
    for (var i = 0; i < this.messageSpans.length; i ++) {
        var span = this.messageSpans[i];
        Dom.addClass(span, "NotAvailable");
    }
    this.messageSpans = [];
};
InlineNotifier.prototype.getErrorMessageSpan = function (field) {
    var doc = field.ownerDocument;
    var span = null;
    if (this.generateErrorMessage) {    
        if (!field._messageSpan) {
            span = doc.createElement("span");        
            Dom.appendAfter(span, field);
            field._messageSpan = span;
        } else {
            span = field._messageSpan;
        }
    } else {
        var id = ValidationUtil.evalAgainstObject(this.placeHolderIdPattern, field);
        span = doc.getElementById(id);
    }
    if (!span._initialized) {
        var message = doc.createElement("span");
        var hint = doc.createElement("span");
        span.appendChild(message);
        span.appendChild(hint);
        
        span.className = InlineNotifier.ERROR_MESSAGE_CLASS_NAME;
        message.className = InlineNotifier.MESSAGE_CLASS_NAME;
        hint.className = InlineNotifier.HINT_CLASS_NAME;
        
        span._messageSpan = message;
        span._hintSpan = hint;
        
        span._initialized = true;
    }
    Dom.removeClass(span, "NotAvailable");
    this.messageSpans.push(span);
    return span;
    
};
InlineNotifier.prototype.notify = function (form, errors) {
    for (var i = 0; i < errors.errors.length; i++) {
        var error = errors.errors[i];
        try {
            var span = this.getErrorMessageSpan(error.field);
            Dom.setInnerText(span._messageSpan, error.message);
            
            if (!error.hint) {
                Dom.addClass(span._hintSpan, "NotAvailable");
            } else {
                Dom.removeClass(span._hintSpan, "NotAvailable");
                Dom.setInnerText(span._hintSpan, error.hint);
            }
            
        } catch (e) {
            throw e;
        }
        try {
            errors.getFirstError().field.focus();
        } catch (e) {}
    }
};