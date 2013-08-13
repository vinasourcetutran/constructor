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
using RLM.Construction.WebApplication.UserControl;
using RLM.Core.Framework.Utility;
using RLM.Construction.ServiceHelpers;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class ContractList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Contract> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Contract> items = GetItemFromRepository();
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
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void radItems_OnItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                //if (e.Item.ItemType == GridItemType.FilteringItem)
                //{
                //    BindFilterControl(e.Item as Telerik.Web.UI.GridFilteringItem);
                //}
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("ContractId"));

                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = string.Format("~/Page/Contract/ContractAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }
                    //// delete groupitem
                    if (e.CommandName == "Preview")
                    {
                        string url = string.Format("~/Page/Contract/ContractView.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }
                    //ImageButton editLinkBtn = (ImageButton)e.Item.FindControl("editLinkBtn");
                    //if (editLinkBtn != null)
                    //{
                    //    editLinkBtn.PostBackUrl = string.Format("ItemAddNew.aspx?ItemId={0}", id);
                    //}
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
                //if (e.Item.ItemType == GridItemType.FilteringItem)
                //{
                //    BindFilterControl(e.Item as Telerik.Web.UI.GridFilteringItem);
                //}

                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    RLM.Construction.Entities.Contract dataItem = (RLM.Construction.Entities.Contract)e.Item.DataItem;

                    Literal ltrOrderIndex = (Literal)e.Item.FindControl("ltrOrderIndex");
                    ltrOrderIndex.Text = (radItems.PageSize * radItems.CurrentPageIndex + e.Item.ItemIndex + 1).ToString();

                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    if (ltrGroupName != null)
                    {
                        Group group = ServiceRepository.GroupService.GetByGroupId((int)dataItem.GroupId);
                        ltrGroupName.Text = group != null ? group.Name : string.Empty;
                    }
                    string unitName = "(None)";
                    RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.CurrencyUnitId));
                    if (unit != null)
                    {
                        unitName = unit.Name;
                    }
                    Label lblInitPrice = (Label)e.Item.FindControl("lblInitPrice");
                    lblInitPrice.Text = string.Format("{0} ({1})",NumberHelper.GetValue<decimal>(dataItem.InitPrice).ToString(RLMConfiguration.Setting.MoneyFormat),unitName);

                    Label lblLastPrice = (Label)e.Item.FindControl("lblLastPrice");
                    lblLastPrice.Text = string.Format("{0} ({1})", NumberHelper.GetValue<decimal>(dataItem.LastPrice).ToString(RLMConfiguration.Setting.MoneyFormat), unitName);

                    Literal ltrStatusName = (Literal)e.Item.FindControl("ltrStatusName");
                    if (ltrStatusName != null)
                    {
                        ltrStatusName.Text = Resources.Enumeration.ResourceManager.GetString("ContractStatus_"+(ContractStatus)dataItem.Status);
                    }

                    AddNewRelatedItemLink lnkAddNew = (AddNewRelatedItemLink)e.Item.FindControl("lnkPartner");
                    lnkAddNew.ResourceId =NumberHelper.GetValue<int>(dataItem.PartnerId);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Functions
        //private void BindFilterControl(GridFilteringItem e)
        //{
        //    Telerik.Web.UI.GridFilteringItem item = e;// e.Item as Telerik.Web.UI.GridFilteringItem;
        //    int total;

        //    RadComboBox radStatus = (RadComboBox)item.FindControl("radStatus");
        //    if (radStatus != null)
        //    {
        //        radStatus.DataSource = Utility.GetContractStatus(true);
        //        radStatus.DataBind();

        //    }

        //    RadComboBox radGroup = (RadComboBox)item.FindControl("radGroup");
        //    if (radGroup != null)
        //    {
        //        string groupWhereClause = string.Format("[Type]={0}", (int)GroupType.Contract);
        //        radGroup.DataSource = ServiceRepository.GroupService.GetPaged(groupWhereClause, "[Name] DESC", 0, 0, out total);
        //        radGroup.DataBind();
        //    }
        //}

        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Contract> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                //throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Contract> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Contract> item = new DataSourceItem<RLM.Construction.Entities.Contract>(); ;
                int total;
                item.Items = ServiceRepository.ContractService.GetPaged("", "LastModificationDate DESC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Contract>();
            }
        }
        #endregion
    }
}
