using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Construction.WebApplication.CommonLib;
using Telerik.Web.UI;
using RLM.Core.Framework.Utility;
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class RoleList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Role> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Role> items = GetItemFromRepository();
                return items;
            }
            set
            {
                ViewState["Items"] = value;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Role> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Role> item = new DataSourceItem<RLM.Construction.Entities.Role>(); ;
                int total;
                item.Items = ServiceRepository.RoleService.GetPaged("", "LastModificationDate DESC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Role>();
            }
        }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void radItems_OnNeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericLoaDataSourceException;
            }
        }

        protected void radItems_OnItemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
            RLM.Construction.Entities.Role dataItem = (RLM.Construction.Entities.Role)e.Item.DataItem;


            Literal ltrRoleType = (Literal)e.Item.FindControl("ltrRoleType");
            ltrRoleType.Text = Utility.GetEnumValue<RoleType>((RoleType)NumberHelper.GetValue<int>(dataItem.Type));


            AddNewRelatedItemLink lnkPreview = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
            lnkPreview.ResourceId = dataItem.RoleId;
            lnkPreview.ResourceType = RLM.Construction.Entities.ResourceType.Role;
            lnkPreview.Action = NavigateAction.ClientView;

            AddNewRelatedItemLink lnkEdit = (AddNewRelatedItemLink)e.Item.FindControl("lnkEdit");
            lnkEdit.ResourceId = dataItem.RoleId;
            lnkEdit.ResourceType = RLM.Construction.Entities.ResourceType.Role;
            lnkEdit.Action = NavigateAction.ClientEdit;
        }

        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Role> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        #endregion
    }
}
