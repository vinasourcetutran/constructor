function InnerPageHelper() { }
InnerPageHelper = {
    addPageFromDOM: function(item) {
        try {
            window.top.window.WebPageHelper.addPageFromDOM(item);
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};