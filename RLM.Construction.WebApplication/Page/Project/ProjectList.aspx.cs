using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using RLM.Construction.WebApplication.CommonLib;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectList : System.Web.UI.Page
    {

        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Project> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Project> items;
                if (ViewState["Items"] == null)
                {
                    items = GetItemFromRepository();
                    ViewState["Items"] = items;
                }
                else
                {
                    items = (DataSourceItem<RLM.Construction.Entities.Project>)ViewState["Items"];
                }
                return items;
            }
            set
            {
                ViewState["Items"] = value;
            }
        }

        string filterExpression = string.Empty;
        #endregion

        #region Handlers
        protected void radItem_OnPreRender(object sender, EventArgs e)
        {
            filterExpression = radItems.MasterTableView.FilterExpression.ToString();
            radItems.MasterTableView.Rebind();
        }

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
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("ProjectId"));

                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = string.Format("~/Page/Project/ProjectAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }

                    if (e.CommandName == "Preview")
                    {
                        string url = string.Format("~/Page/Project/ProjectView.aspx?ItemId={0}", id);
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
                    RLM.Construction.Entities.Project dataItem = (RLM.Construction.Entities.Project)e.Item.DataItem;

                    Literal ltrOrderIndex = (Literal)e.Item.FindControl("ltrOrderIndex");
                    ltrOrderIndex.Text = (radItems.PageSize * radItems.CurrentPageIndex + e.Item.ItemIndex + 1).ToString();

                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    if (ltrGroupName != null)
                    {
                        Group group = ServiceRepository.GroupService.GetByGroupId((int)dataItem.GroupId);
                        ltrGroupName.Text = group != null ? group.Name : string.Empty;
                    }

                    
                    RLM.Construction.Entities.Contract contract = ServiceRepository.ContractService.GetByContractId(dataItem.ContractId);
                    if (contract != null)
                    {
                        HtmlAnchor lnkContract = (HtmlAnchor)e.Item.FindControl("lnkContract");   
                        lnkContract.InnerHtml = lnkContract.Title = contract.Name;
                        lnkContract.HRef = UrlBuilderHelper.GetUrl(contract, NavigateAction.Detail);
                    }


                    RLM.Construction.Entities.Unit currentcy = ServiceRepository.UnitService.GetByUnitId(dataItem.CurrencyUnitId.Value);
                    if (currentcy != null)
                    {
                        System.Web.UI.WebControls.Literal ltrCurrentcy = (System.Web.UI.WebControls.Literal)e.Item.FindControl("ltrCurrentcy");
                        ltrCurrentcy.Text = currentcy.Name;
                    }
                    //Literal ltrStatusName = (Literal)e.Item.FindControl("ltrStatusName");
                    //if (ltrStatusName != null)
                    //{
                    //    ltrStatusName.Text = Resources.Enumeration.ResourceManager.GetString("ProjectStatus_" + (ProjectStatus)dataItem.Status);
                    //}
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
                DataSourceItem<RLM.Construction.Entities.Project> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Project> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Project> item = new DataSourceItem<RLM.Construction.Entities.Project>(); ;
                int total;
                item.Items = ServiceRepository.ProjectService.GetPaged("", "LastModificationDate ASC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Project>();
            }
        }
        #endregion
    }
}
