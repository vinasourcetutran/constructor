function WebPageHelper() { };
WebPageHelper = {
    /*
    config:{
    persist: optional, to persist state of control,
    title:required, title of tab,
    id:required, Uniq id of tab,
    url:required, url of content of page,
    }
    */
    addWebPage: function (config) {
        try {
            config = config || {};
            var tabScripConfig = { title: config.title, id: config.id };
            var pageViewConfig = { url: config.url };
            if (config.persist) {
                pageViewConfig.persist = tabScripConfig.persist = config.persist;
            }
            //callback when tab was created
            tabScripConfig.callback = function (tabConfig) {
                try {
                    //If tab has pageview
                    //var pageView = tabConfig.tab.get_pageView();
                    //acive and return
                    //if (pageView) { pageView.set_selected(true); return; }
                    //create new one
                    pageViewConfig.index = tabConfig.tab.get_index();
                    // callback when page was created
                    pageViewConfig.callback = function (pageConfig) {
                        //reassign pageid to tab
                        tabConfig.tab.set_pageViewID(pageConfig.page.get_id());
                        //tabConfig.tab.set_multiPageID(RLMConfig.MainMultiPageViewId);
                    };

                    MultiPageHelper.addPage(pageViewConfig);
                } catch (e1) {
                    UtilityHelper.errorProcess(e1);
                }
            };
            TabScriptHelper.addTab(tabScripConfig);
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    addPageFromDOM: function (item) {
        try {
            if (!item) { return; }
            var config = {
                id: item.attr("tabId") + "_tabscript",
                title: item.attr('title'),
                url: item.attr('url')
            };
            WebPageHelper.addWebPage(config);
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};