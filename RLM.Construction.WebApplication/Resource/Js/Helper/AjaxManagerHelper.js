function AjaxManagerHelper() { };
AjaxManagerHelper = {
    onRequestStart: function(sender, args) {
        if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
            args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
            args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
            args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                args.set_enableAjax(false);
        }
    }
};