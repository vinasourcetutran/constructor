using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Configuration;
using System.Web.UI.HtmlControls;
using RLM.Construction.Services;
using RLM.Construction.WebApplication.Page.Item;
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ItemInProjectGraph : System.Web.UI.UserControl
    {
        #region Properties
        public int ResourceId { get; set; }
        public bool IsDetailItem { get; set; }
        public ResourceType ResourceType { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                BindItems();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Methods
        public void BindItems()
        {
            try
            {
                TList<RLM.Construction.Entities.ItemInProject> items = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByResource(this.ResourceType, this.ResourceId, this.IsDetailItem);
                IList<GraphDataItem> graphQuantityItem = GraphServiceHelper.GetGraphDataItems(items,GraphDataItemType.Quantity);
                IList<GraphDataItem> graphPriceItem = GraphServiceHelper.GetGraphDataItems(items, GraphDataItemType.Price);
                graphQuantity.DataSource = graphQuantityItem;
                graphPrice.DataSource = graphPriceItem;
                this.Visible = graphPriceItem.Count > 0 || graphQuantityItem.Count > 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}