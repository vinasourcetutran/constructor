function TabScriptHelper() { };
TabScriptHelper = {
    onClientTabSelected: function (sender, args) {
        try {
            var item = args.get_tab();
            //if (item.get_isSeparator() || item.get_level() === 0) { return true; }
            var link = item.get_element();
            var id = (link ? link.id : item.get_attributes().getAttribute('id')) + "_tabscript";

            var config = {
                title: item.get_text(),
                url: RLMConfig.WebBaseUrl + item.get_attributes().getAttribute('url'),
                id: id
            };
            WebPageHelper.addWebPage(config);
            return false;
        } catch (e) {
            UtilityHelper.errorProcess(e);
            return false;
        }
        /*try {
            var tab = eventArgs.get_tab();
            //alert(tab.get_value());
            var id=tab.get_value();
            if(!id){
                id='itemCateory_deefaultTab';
            }
            TabScriptHelper.addTab({ persist: true, id:id , title: tab.get_text() });

        } catch (e) {
            UtilityHelper.errorProcess(e);
        }*/
    },
    /*  config:{
    persist:true if persist state of object,optional,
    title:title of tab, required,
    id:unique if of tab, required,
    callback:function(tab, isExist), callback functon. optional
    }
    */
    addTab: function (config) {
        try {
            config = config || {};
            var persistChanges = config.persist && config.persist === true;
            var tabStrip = $find(RLMConfig.MainTabScriptId);

            if (persistChanges) { tabStrip.trackChanges(); }
            var tab = tabStrip.findTabByValue(config.id);
            var isExist = true;
            if (!tab || tab == undefined) {
                isExist = false;
                tab = new Telerik.Web.UI.RadTab();
                tabStrip.get_tabs().add(tab);
                tab.set_value(config.id);
                TabScriptHelper.attachImageToTab(tab);
            }
            tab.set_text(StringHelper.trim(config.title, RLMConfig.TabMaxTextLength));
            // set tooltip of tab
            tab.get_textElement().setAttribute('title', config.title);
            tab.set_selected(true);

            if (persistChanges) { tabStrip.commitChanges(); }
            // call back
            if (config.callback) { config.callback({ tab: tab, isExist: isExist, tabIndex: tab.get_index() }); }
            return true;
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    deleteTab: function (tab) {
        var tabStrip = $find(RLMConfig.MainTabScriptId);

        var tabToSelect = tab.get_nextTab();
        if (!tabToSelect)
            tabToSelect = tab.get_previousTab();

        var oldIndex = tab.get_index();
        var newIndex = tabToSelect.get_index();
        tabStrip.get_tabs().remove(tab);

        if (tabToSelect)
            tabToSelect.set_selected(true);

        MultiPageHelper.tabDeletedEvent(oldIndex, newIndex);
    },
    refreshTab: function (tab) {
        try {
            var multiPage = $find(RLMConfig.MainMultiPageViewId);
            var page = multiPage.get_pageViews().getPageView(tab.get_index());
            if (!page) { return; }
            var iframe = page.get_element().childNodes[0];

            if (!iframe) { return; }
            //alert(iframe.src);
            iframe.src = iframe.src;
            //page.set_contentUrl(page.get_contentUrl());
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    createImage: function (closeImageUrl, alt) {
        var closeImage = document.createElement("img");
        closeImage.src = closeImageUrl;
        closeImage.alt = alt;
        return closeImage;
    },
    attachImageToTab: function (tab) {
        var closeImageUrl = RLMConfig.ImageUrl + "Icon/Close.png";
        var closeImage = TabScriptHelper.createImage(closeImageUrl, 'Close');

        var refreshImageUrl = RLMConfig.ImageUrl + "Icon/refresh.png";
        var refreshImage = TabScriptHelper.createImage(refreshImageUrl, 'Close');
        closeImage.AssociatedTab = tab;
        refreshImage.AssociatedTab = tab;

        closeImage.onclick = function (e) {
            if (!e) e = event;
            if (!e.target) e = e.srcElement;

            TabScriptHelper.deleteTab(tab);

            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }

            return false;
        }

        refreshImage.onclick = function (e) {
            if (!e) e = event;
            if (!e.target) e = e.srcElement;

            TabScriptHelper.refreshTab(tab);

            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }

            return false;
        }
        tab.get_innerWrapElement().appendChild(closeImage);
        tab.get_innerWrapElement().insertBefore(refreshImage, tab.get_innerWrapElement().childNodes[0]);
    }
};