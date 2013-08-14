function RadGridHelper() { };
RadGridHelper = {
    groupRowItemClicked: function(grid, sender, event) {
        try {
            if (!grid) { return; }
            var items = grid.get_selectedItems();
            if (!items || items.length == 0) { return; }
            var item = items[0];
            var link = item.findElement();
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    filter: function(grid, column, args, operation) {
        try {
            var masterTable = $find(grid).get_masterTableView();
            if (args.get_item().get_value() == '' || args.get_item().get_value() == '0' || args.get_item().get_value() == 0) {
                masterTable.filter(column, "", Telerik.Web.UI.GridFilterFunction.NoFilter);
            } else {
                masterTable.filter(column, args.get_item().get_value(), Telerik.Web.UI.GridFilterFunction.EqualTo, true);
            }
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};