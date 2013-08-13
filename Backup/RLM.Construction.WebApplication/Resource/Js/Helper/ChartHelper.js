function ChartHelper() { };
ChartHelper = {
    drawChart: function(type, id, chartData, chartConfig) {
        try {
            switch (type) {
                case "Grant":
                    ChartHelper.grantChart(id, chartData, chartConfig);
                    break;
                case "Pie":
                default:
                    ChartHelper.pieChart(id, chartData, chartConfig);
                    break;
            }
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    grantChart: function(id, chartData) {
        try {
            // make sure chartData is not null
            chartData = chartData || [];
            // create instance of grant chart
            var g = new Gantt(document.getElementById(id));
            for (var index = 0; index < chartData.length; index++) {
                var item = chartData[index];
                g.AddTaskDetail(new Task(item.fromDate, item.toDate, item.name, item.member, item.percentComplete));
            }
            g.Draw();
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    },
    pieChart: function(id, chartData, chartConfig) {
        try {
            chartConfig = chartConfig || { width: 400, height: 400, title: 'Chart title' }
            chartData = chartData || [];

            var bluffGraph = new Bluff.Pie(id, chartConfig.width + 'x' + chartConfig.height);
            bluffGraph.theme_37signals();
            bluffGraph.title = chartConfig.title;

            for (var index = 0; index < chartData.length; index++) {
                var item = chartData[index];
                bluffGraph.data(item.label, item.value);
            }
            bluffGraph.draw();
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};