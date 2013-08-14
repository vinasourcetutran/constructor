function RadPanelBarHelper() { };
RadPanelBarHelper = {
    radPanelItemClicked: function(sender, args) {
        try {
            var item = args.get_item();
            if (item.get_isSeparator() || item.get_level() === 0) { return true; }
            var link = item.get_linkElement();
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
    }
};