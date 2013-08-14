function UtilityHelper() { };
UtilityHelper = {
    setDefaultFormat: function () {
        var items = $('.CustomFormat');
        if (!items || items.length <= 0) { return; }
        for (var index = 0; index < items.length; index++) {
            try {
                var item = $(items[index]);
                var defaultSetting = { thousandsSeparator:',',centsSeparator:'.',centsLimit:0,prefix: '', clearPrefix: true };
                if (!StringHelper.isNullOrEmpty(item.attr("customFormat"))) {
                    defaultSetting = eval('(' + item.attr("customFormat") + ')');
                }
                item.priceFormat(defaultSetting);
            } catch (e) {
                UtilityHelper.errorProcess(ex);
            }
        }
    },
    errorProcess: function (e) {
        alert(e.message);
    },
    toggle: function (itemId) {
        try {
            var item = $('#' + itemId);
            if (!item) { return; }
            if (item.attr("class") == "HideItem") {
                item.attr("class", "");
                item.show();
            } else {
                item.hide();
                item.attr("class", "HideItem");
            }
        } catch (e) {
            UtilityHelper.errorProcess(ex);
        }
    },
    format: function (string, arr) {
        try {
            if (!arr) { return string; }
            for (var index = 0; index < arr.length; index++) {
                string = string.replace("{" + index + "}", arr[index]);
            }
            return string;
        } catch (e) {
            throw e;
        }
    },
    apply: function (o, c, defaults) {
        if (defaults) {
            // no "this" reference for friendly out of scope calls
            Ext.apply(o, defaults);
        }
        if (o && c && typeof c == 'object') {
            for (var p in c) {
                o[p] = c[p];
            }
        }
        return o;
    },
    override: function (origclass, overrides) {
        if (overrides) {
            var p = origclass.prototype;
            for (var method in overrides) {
                p[method] = overrides[method];
            }
        }
    },
    extend: function () {
        // inline overrides
        var io = function (o) {
            for (var m in o) {
                this[m] = o[m];
            }
        };
        var oc = Object.prototype.constructor;

        return function (sb, sp, overrides) {
            if (typeof sp == 'object') {
                overrides = sp;
                sp = sb;
                sb = overrides.constructor != oc ? overrides.constructor : function () { sp.apply(this, arguments); };
            }
            var F = function () { }, sbp, spp = sp.prototype;
            F.prototype = spp;
            sbp = sb.prototype = new F();
            sbp.constructor = sb;
            sb.superclass = spp;
            if (spp.constructor == oc) {
                spp.constructor = sp;
            }
            sb.override = function (o) {
                Utility.override(sb, o);
            };
            sbp.override = io;
            Utility.override(sb, overrides);
            sb.extend = function (o) { Utility.extend(sb, o); };
            return sb;
        };
    } ()
}