using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using RLM.Construction.WebApplication.CommonLib;

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class ContactorList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Contactor> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Contactor> items;
                if (ViewState["Items"] == null)
                {
                    items = GetItemFromRepository();
                    ViewState["Items"] = items;
                }
                else
                {
                    items = (DataSourceItem<RLM.Construction.Entities.Contactor>)ViewState["Items"];
                }
                return items;
            }
            set
            {
                ViewState["Items"] = value;
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

        protected void radItems_OnItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("ContactorId"));

                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = string.Format("~/Page/Partner/ContactorAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }

                    if (e.CommandName == "Preview")
                    {
                        string url = string.Format("~/Page/Partner/ContactorView.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnOtemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    RLM.Construction.Entities.Contactor dataItem = (RLM.Construction.Entities.Contactor)e.Item.DataItem;

                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    if (ltrGroupName != null)
                    {
                        Group group = ServiceRepository.GroupService.GetByGroupId((int)dataItem.GroupId);
                        ltrGroupName.Text = group != null ? group.Name : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Contactor> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Contactor> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Contactor> item = new DataSourceItem<RLM.Construction.Entities.Contactor>(); ;
                int total;
                item.Items = ServiceRepository.ContactorService.GetPaged("", "LastModificationDate ASC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Contactor>();
            }
        }
        #endregion
    }
}
