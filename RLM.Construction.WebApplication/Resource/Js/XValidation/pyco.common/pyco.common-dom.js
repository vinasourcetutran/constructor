/*
    Pyramid Commons DOM
    Copyright (c) Pyramid Consulting. All rights reserved.

    $Id: pyco.common-dom.js,v 1.3 2007/01/16 07:10:57 thanh.an Exp $
*/

/*
    @dependencies: <none>
*/

/*
    Reference Definition
*/

if (window.PYCO_COMMON_DOM) {
    window.PYCO_COMMON_DOM.count ++;
    alert("Reference Error:\n" +
            "Duplicated references of Pyco Common Dom found. Ref. count = " + (window.PYCO_COMMON_DOM.count));
} else {
    window.PYCO_COMMON_DOM = new Object();
    window.PYCO_COMMON_DOM.count = 1;
}


function Dom() {
}

Dom.registerEvent = function (target, event, handler, capture) {
    var useCapture = false;
    if (capture) {
        useCapture = true;
    }
    if (target.addEventListener) {
        target.addEventListener(event, handler, useCapture);
    } else if (target.attachEvent) {
        target.attachEvent("on" + event, handler);
    }
};

Dom.getEvent = function (e) {
    return window.event ? window.event : e;
};

Dom.getTarget = function (e) {
    var event = Dom.getEvent(e);
    return event.srcElement ? event.srcElement : event.originalTarget;
};

Dom.cancelEvent = function (e) {
    var event = Dom.getEvent(e);
    if (event.preventDefault) event.preventDefault();
    else event.returnValue = false;
};
Dom.addClass = function (node, className) {
    if ((" " + node.className + " ").indexOf(" " + className + " ") >= 0) return;
    node.className += " " + className;
};
Dom.removeClass = function (node, className) {
    var re = new RegExp("(^" + className + " )|( " + className + " )|( " + className + "$)", "g");
    var reBlank = /(^[ ]+)|([ ]+$)/g;
    node.className = node.className.replace(re, " ").replace(reBlank, "");
};


Dom.getOffsetLeft = function (control) {
    var offset = control.offsetLeft;
    var parent = control.offsetParent;
    if (parent) if (parent != control) return offset + Dom.getOffsetLeft(parent);
    return offset;
};

Dom.getOffsetTop = function (control) {
    var offset = control.offsetTop;
    var parent = control.offsetParent;
    if (parent) if (parent != control) return offset + Dom.getOffsetTop(parent);
    return offset;
};

Dom.getOffsetHeight = function (control) {
    return control.offsetHeight;
};

Dom.getOffsetWidth = function (control) {
    return control.offsetWidth;
};

Dom.getWindowHeight = function () {
  if ( typeof( window.innerWidth ) == 'number' ) {
    return window.innerHeight;
  } else if ( document.documentElement &&
      ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) {
    return document.documentElement.clientHeight;
  } else if ( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) {
    return document.body.clientHeight;
  }
  return 0;
};

Dom.getWindowWidth = function () {
  if ( typeof( window.innerWidth ) == 'number' ) {
    return window.innerWidth;
  } else if ( document.documentElement &&
      ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) {
    return document.documentElement.clientWidth;
  } else if ( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) {
    return document.body.clientWidth;
  }
  return 0;
};

Dom.getScrollTop = function () {
  if ( typeof( window.pageYOffset ) == 'number' ) {
    //Netscape compliant
    return window.pageYOffset;
  } else if ( document.body && ( document.body.scrollLeft || document.body.scrollTop ) ) {
    //DOM compliant
    return  document.body.scrollTop;
  } else if ( document.documentElement &&
      ( document.documentElement.scrollLeft || document.documentElement.scrollTop ) ) {
    //IE6 standards compliant mode
    return  document.documentElement.scrollTop;
  }
  return 0;
};

Dom.getScrollLeft = function () {
  if ( typeof( window.pageXOffset ) == 'number' ) {
    //Netscape compliant
    return window.pageXOffset;
  } else if ( document.body && ( document.body.scrollLeft || document.body.scrollTop ) ) {
    //DOM compliant
    return  document.body.scrollLeft;
  } else if ( document.documentElement &&
      ( document.documentElement.scrollLeft || document.documentElement.scrollTop ) ) {
    //IE6 standards compliant mode
    return  document.documentElement.scrollLeft;
  }
  return 0;
};
Dom.reformHTML = function (node) {
    try {
        var html = node.innerHTML;
        node.innerHTML = "";
        node.innerHTML = html;
    } catch (e) {
        //ignore
    }
};
Dom.appendAfter = function (fragment, node) {
    if (!node.parentNode) {
        return;
    }
    if (node.nextSibling) {
        node.parentNode.insertBefore(fragment, node.nextSibling);
    } else {
        node.parentNode.appendChild(fragment);
    }
    //Dom.reformHTML(node.parentNode);
};
Dom.insertBefore = function (fragment, node) {
    if (!node.parentNode) {
        return;
    }
    node.parentNode.insertBefore(fragment, node);
    Dom.reformHTML(node.parentNode);
};
Dom.appendParent = function (fragment, node) {
    if (!node.parentNode) {
        return;
    }
    node.parentNode.appendChild(fragment);
    Dom.reformHTML(node.parentNode);
};
Dom.prependParent = function (fragment, node) {
    if (!node.parentNode) {
        return;
    }
    if (node.parentNode.childNodes.length > 0) {
        node.parentNode.insertBefore(fragment, node.parentNode.childNodes[0]);
    } else {
        node.parentNode.appendChild(fragment);
    }
    Dom.reformHTML(node.parentNode);
};
Dom.append = function (fragment, node) {
    node.appendChild(fragment);
    Dom.reformHTML(node);
};
Dom.prepend = function (fragment, node) {
    if (node.childNodes.length > 0) {
        node.insertBefore(fragment, node.childNodes[0]);
    } else node.appendChild(fragment);
    Dom.reformHTML(node);
};
Dom.replace = function (fragment, node) {
    if (!node.parentNode) {
        return;
    }
    node.parentNode.replaceChild(fragment, node);
    Dom.reformHTML(node.parentNode);
};
Dom.xmlToFragment = function (xml) {
    var doc = null;
    var wrappedXml = "<root>" + xml + "</root>";
    if (document.implementation.createDocument) {
        var parser = new DOMParser();
        doc = parser.parseFromString(wrappedXml, "text/xml");
    } else {
        doc = new ActiveXObject("Microsoft.XMLDOM");
        doc.loadXML(wrappedXml);
    }
    var fragment = doc.createDocumentFragment();
    var root = doc.documentElement;
    for(var i = 0; i < root.childNodes.length; i++) {
        fragment.appendChild(root.childNodes[i].cloneNode(true));
    }
    return fragment;

};
Dom.importNode = function (doc, node, importChildren) {
    if (doc.importNode) return doc.importNode(node, importChildren);
    var i = 0;
    switch (node.nodeType) {
        case 11: // DOCUMENT FRAGMENT
            var newNode = doc.createDocumentFragment();
            if (importChildren) {
                for(i = 0; i < node.childNodes.length; i++) {
                    var clonedChild = Dom.importNode(doc, node.childNodes[i], true);
                    if (clonedChild) newNode.appendChild(clonedChild);
                }
            }
            return newNode;
        case 1: // ELEMENT
            var newNode = doc.createElement(node.nodeName);
            for(i = 0; i < node.attributes.length; i++){
                newNode.setAttribute(node.attributes[i].name, node.attributes[i].value);
            }
            if (importChildren) {
                for(i = 0; i < node.childNodes.length; i++) {
                    var clonedChild = Dom.importNode(doc, node.childNodes[i], true);
                    if (clonedChild) newNode.appendChild(clonedChild);
                }
            }
            return newNode;
        case 3: // TEXT
            return doc.createTextNode(node.nodeValue);
    }
    return null;
};
Dom.get = function (id, doc) {
    var targetDocument = doc ? doc : document;
    return targetDocument.getElementById(id);
};
Dom.getTags = function (tag, doc) {
    var targetDocument = doc ? doc : document;
    return targetDocument.getElementsByTagName(tag);
};
Dom.getTag = function (tag, doc) {
    var targetDocument = doc ? doc : document;
    return targetDocument.getElementsByTagName(tag)[0];
};
Dom.isChildOf = function (parent, child) {
    if (!parent || !child) {
        return false;
    }
    if (parent == child) {
        return true;
    }
    return Dom.isChildOf(parent, child.parentNode);
};
Dom.findUpward = function (node, evaluator) {
    if (node == null) {
        return null;
    }
    if (evaluator.eval(node)) {
        return node;
    }
    return Dom.findUpward(node.parentNode, evaluator);
};
Dom.findParentWithClass = function (node, className) {
    return Dom.findUpward(node, {
        className: className,
        eval: function (node) {
            return (" " + node.className + " ").indexOf(" " + this.className + " ") >= 0;
        }
    });
};
Dom.findParentByTagName = function (node, tagName) {
    return Dom.findUpward(node, {
        tagName: tagName.toUpperCase(),
        eval: function (node) {
            return node.tagName.toUpperCase() == this.tagName;
        }
    });
}
Dom.findParentWithProperty = function (node, property) {
    if (node == null) {
        return null;
    }
    if (typeof(node[property]) != "undefined") {
        return node;
    }
    return Dom.findParentWithProperty(node.parentNode, property);
};
Dom.findParentWithAttribute = function (node, attName, attValue) {
    if (node == null) {
        return null;
    }
    //alert(node);
    if (node.getAttribute) {
        var value = node.getAttribute(attName);
        if (value) {
            if (!attValue) return node;
            if (attValue == value) return node;
        }
    }
    return Dom.findParentWithAttribute(node.parentNode, attName, attValue);
};
Dom.findNonEditableParent = function (node) {
    if (node == null) {
        return null;
    }
    return Dom.findNonEditableParent(node.parentNode);
};
Dom.getDocumentBody = function () {
    return document.getElementsByTagName("body")[0];
};
Dom.htmlEncode = function (s) {
    if (!Dom.htmlEncodePlaceHolder) {
        Dom.htmlEncodePlaceHolder = document.createElement("div");
    }
    Dom.htmlEncodePlaceHolder.innerHTML = "";
    Dom.htmlEncodePlaceHolder.appendChild(document.createTextNode(s));
    return Dom.htmlEncodePlaceHolder.innerHTML;
};

Dom.setInnerText = function (node, text) {
    node.innerHTML = "";
    node.appendChild(node.ownerDocument.createTextNode(text));
};