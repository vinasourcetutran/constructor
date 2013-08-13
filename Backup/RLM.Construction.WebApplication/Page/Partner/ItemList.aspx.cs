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
using System.Web.UI.HtmlControls;
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class ItemList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Partner> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Partner> items;
                if (ViewState["Items"] == null)
                {
                    items = GetItemFromRepository();
                    ViewState["Items"] = items;
                }
                else
                {
                    items = (DataSourceItem<RLM.Construction.Entities.Partner>)ViewState["Items"];
                }
                return items;
            }
            set
            {
                ViewState["Items"] = value;
            }
        }

        public bool IsPopup { get; set; }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.IsPopup = !string.IsNullOrEmpty(Request.Params["IsPopup"]);
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
                    int id = Convert.ToInt32(item.GetDataKeyValue("PartnerId"));

                   
                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = string.Format("~/Page/Partner/ItemAddNew.aspx?ItemId={0}&IsPopup={1}", id, this.IsPopup);
                        Response.Redirect(url, true);
                    }
                    if (e.CommandName == "Preview")
                    {
                        string url = string.Format("~/Page/Partner/PartnerView.aspx?ItemId={0}&IsPopup={1}", id, this.IsPopup);
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
                    RLM.Construction.Entities.Partner dataItem = (RLM.Construction.Entities.Partner)e.Item.DataItem;

                    Literal ltrOrderIndex = (Literal)e.Item.FindControl("ltrOrderIndex");
                    ltrOrderIndex.Text = (radItems.PageSize * radItems.CurrentPageIndex + e.Item.ItemIndex + 1).ToString();

                    HtmlAnchor lnkName = (HtmlAnchor)e.Item.FindControl("lnkName");
                    lnkName.InnerHtml = lnkName.Title = dataItem.Name;
                    if (this.IsPopup)
                    {
                        lnkName.Attributes.Add("onclick",string.Format("PopupHelper.onPartnerSelected('{0}','{1}','{2}');return false;",dataItem.PartnerId, dataItem.Name, dataItem.RepresentativeName));
                    }

                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    if (ltrGroupName != null)
                    {
                        Group group = ServiceRepository.GroupService.GetByGroupId((int)dataItem.GroupId);
                        ltrGroupName.Text = group != null ? group.Name : string.Empty;
                    }

                    //AddNewRelatedItemLink lnkDetail = (AddNewRelatedItemLink)e.Item.FindControl("lnkPartner");
                    //lnkDetail.ResourceId = dataItem.PartnerId;

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
                DataSourceItem<RLM.Construction.Entities.Partner> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Partner> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Partner> item = new DataSourceItem<RLM.Construction.Entities.Partner>(); ;
                int total;
                item.Items = ServiceRepository.PartnerService.GetPaged("", "LastModificationDate DESC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Partner>();
            }
        }
        #endregion
    }
}
