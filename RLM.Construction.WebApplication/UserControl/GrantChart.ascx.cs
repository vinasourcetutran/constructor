using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.UserControl
{
    public partial class GrantChart : System.Web.UI.UserControl
    {
        #region Properties
        public string Title { get; set; }
        public IList<GraphGrantChartDataItem> DataSource;
        private string script = "ChartHelper.drawChart('{0}','{1}',{2},{3});";
        #endregion

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (DataSource == null || DataSource.Count == 0) { return; }
                string graphConfig = this.CreateGraphConfig();
                string graphData = this.CreateGraphData();
                string js = string.Format(script, GraphType.Grant.ToString(), divGrantChart.ClientID, graphData, graphConfig);
                ltrGrant.Text = js;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Private
        private string CreateGraphData()
        {
            string js = string.Empty;
            int index = 0;
            foreach (GraphGrantChartDataItem item in this.DataSource)
            {
                index++;
                js += StringHelper.Format(
                        "{ fromDate: '{0}', toDate: '{1}',name:'{2}',member:'{3}',percentComplete:'{4}' }{5}",
                        item.FromDate.ToShortDateString(),
                        item.ToDate.ToShortDateString(),
                        item.Name,
                        item.Member,
                        item.PercentComplete,
                        index < this.DataSource.Count ? "," : ""
                    );
            }
            return StringHelper.Format("[{0}]", js);
        }

        private string CreateGraphConfig()
        {
            return "{}";
        }
        #endregion
    }
}