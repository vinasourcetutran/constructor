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
using RLM.Core.Framework.Utility;
using RLM.Construction.ServiceHelpers;


namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class TaskList1 : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Task> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Task> items=GetItemFromRepository();
                return items;
            }
            set
            {
                ViewState["Items"] = value;
            }
        }

        public RLM.Construction.Entities.ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        #endregion

        #region Handlers
        protected void radItem_OnPreRender(object sender, EventArgs e)
        {
            //filterExpression = radItems.MasterTableView.FilterExpression.ToString();
            //radItems.MasterTableView.Rebind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
                string name = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                lnkResource.ResourceType=this.ResourceType;// .Text =string.Format("{0}: {1}", Utility.GetEnumValue<RLM.Construction.Entities.ResourceType>(this.ResourceType), name);
                lnkResource.ResourceId=this.ResourceId;// .Title = string.Format("{0}: {1}",this.ResourceType.ToString(), name);
                //lnkResource.TabId = string.Format("{0}_View",this.ResourceType.ToString());
                //lnkResource.Url = UrlBuilderHelper.GetUrl(this.ResourceType, this.ResourceId, NavigateAction.ClientView);
                grantChart.ResourceType = this.ResourceType;
                grantChart.ResourceId = this.ResourceId;

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
                    int id = Convert.ToInt32(item.GetDataKeyValue("TaskId"));

                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { TaskId = id }, NavigateAction.Edit);
                        Response.Redirect(url, true);
                    }

                    if (e.CommandName == "Preview")
                    {
                        string url = UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { TaskId = id }, NavigateAction.View);
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
                    RLM.Construction.Entities.Task dataItem = (RLM.Construction.Entities.Task)e.Item.DataItem;

                    Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                    ltrStatus.Text = Utility.GetEnumValue<TaskStatus>((TaskStatus)NumberHelper.GetValue<int>(dataItem.Status));


                    Literal ltrPercentComplete = (Literal)e.Item.FindControl("ltrPercentComplete");
                    ltrPercentComplete.Text = NumberHelper.GetValue<double>(dataItem.PercentComplete).ToString();


                    RLM.Construction.Entities.User creator = ServiceRepositoryHelper.UserServiceHelper.GetByUserId(NumberHelper.GetValue<int>(dataItem.CreationUserId));
                    if (creator != null)
                    {
                        Literal ltrCreationUserId = (Literal)e.Item.FindControl("ltrCreationUserId");
                        ltrCreationUserId.Text = creator.FullName;
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
                DataSourceItem<RLM.Construction.Entities.Task> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Task> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Task> item = new DataSourceItem<RLM.Construction.Entities.Task>();
                item.Items = ServiceRepositoryHelper.TaskServiceHelper.GetByResource(this.ResourceType, this.ResourceId, false);
                item.TotalItems = item.Items != null ? item.Items.Count : 0;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Task>();
            }
        }

        private void GetData()
        {
            if (!string.IsNullOrEmpty(Request.Params["ResourceType"]))
            {
                this.ResourceType = (RLM.Construction.Entities.ResourceType)Enum.Parse(typeof(RLM.Construction.Entities.ResourceType), Request.Params["ResourceType"]);
            }
            int temp;
            if (!int.TryParse(Request.Params["ResourceId"],out temp) || temp <= 0)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            this.ResourceId = temp;
        }
        #endregion
    }
}
