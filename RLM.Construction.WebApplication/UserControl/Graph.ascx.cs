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
    public partial class Graph : System.Web.UI.UserControl
    {
        #region Properties
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string GraphCanvasId { get; set; }
        public IList<GraphDataItem> DataSource;
        public GraphType GraphType { get; set; }
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
                string js = string.Format(script,GraphType.ToString(),graphCanvas.ClientID,graphData, graphConfig);
                ltrScript.Text = js;
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
            int index=0;
            foreach (GraphDataItem item in this.DataSource)
            {
                index++;
                js += StringHelper.Format(
                        "{ label: '{0}', value: {1} }{2}",
                        item.Label,
                        item.Value.ToString("#0.00"),
                        index<this.DataSource.Count?",":""
                    );
            }
            return StringHelper.Format("[{0}]", js);
        }

        private string CreateGraphConfig()
        {
            return StringHelper.Format(
                "{width: {0}, height: {1}, title: '{2}'}",
                this.Width,
                this.Height,
                this.Title
                );
        }
        #endregion
    }
}