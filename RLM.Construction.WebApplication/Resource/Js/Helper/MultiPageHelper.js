function MultiPageHelper() { };
MultiPageHelper = {
    //fire when window was resized
    onWindowResize: function () {
        try {
            var multiPageViews = $find(RLMConfig.MainMultiPageViewId);
            if (!multiPageViews) { return; }
            for (var index = 0; index < multiPageViews.get_pageViews().get_count(); index++) {
                var pageView = multiPageViews.get_pageViews().getPageView(index);
                if (!pageView) { continue; }
                pageView.get_element().style.height = ($(document).height() - 69) + "px";
            }
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    /*  config:{
    persist:true if persist state of object,optional,
    url:url to content of pageview, required,
    index:index of pageview, required,
    callback:function(tab, isExist), callback functon. optional
    }
    */
    addPage: function (config) {
        try {

            config = config || {};
            var persistChanges = true; // config.persist && config.persist === true;
            var multiPage = $find(RLMConfig.MainMultiPageViewId);

            if (persistChanges) { multiPage.trackChanges(); }

            var pageView = multiPage.get_pageViews().getPageView(config.index);
            var isExist = true;
            //create new pageview
            if (!pageView || pageView == undefined) {
                isExist = false;
                pageView = new Telerik.Web.UI.RadPageView();
                pageView.set_id("pageView_"+ config.index);
                //pageView.set_selected(true);
                // add page 
                multiPage.get_pageViews().add(pageView);
                // set style
                pageView.get_element().style.height = ($(document).height() - 69) + "px";

                pageView.get_element().innerHTML = "<iframe id='iframeContent_" + config.index + "' onload=\"$(this).removeClass('PageViewLoading');\" class='PageViewLoading' src='" + config.url + "' width='100%' height='100%' frameborder='0' scrolling='scroll_y'></iframe>";
            }
            pageView.set_selected(true);
            multiPage.set_visible(true);
            
            //pageView.show();

            //store state
            if (persistChanges) { multiPage.commitChanges(); }
            // call back
            if (config.callback) { config.callback({ page: pageView, isExist: isExist }); }
            return false;
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    tabDeletedEvent: function (oldIndex, newIndex) {
        try {
            var multiPage = $find(RLMConfig.MainMultiPageViewId);
            var newpage = multiPage.get_pageViews().getPageView(newIndex);
            multiPage.get_pageViews().removeAt(oldIndex);
            newpage.set_selected(true);
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};