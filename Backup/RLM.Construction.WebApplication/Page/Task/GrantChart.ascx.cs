using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class GrantChart : System.Web.UI.UserControl
    {
        #region Properties
        public int ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Title { get; set; }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TList<RLM.Construction.Entities.Task> items = ServiceRepositoryHelper.TaskServiceHelper.GetByResource(this.ResourceType, this.ResourceId, true);
                if (items == null || items.Count == 0) { this.Visible = false; return; }

                IList<GraphGrantChartDataItem> grantData = ServiceRepositoryHelper.GraphServiceHelper.ToGrantChartDataItem(items);
                grantChart.DataSource = grantData;
                if (!string.IsNullOrEmpty(this.Title))
                {
                    legend.InnerHtml = this.Title;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }
        #endregion
    }
}