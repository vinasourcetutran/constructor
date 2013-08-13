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
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Construction.WebApplication.UserControl;


namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectPhaseList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.ProjectPhase> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.ProjectPhase> items = GetItemFromRepository();
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
                    int id = Convert.ToInt32(item.GetDataKeyValue("ProjectPhaseId"));

                    // Edit group items
                    if (e.CommandName == "Edit")
                    {
                        string url = string.Format("~/Page/Project/ProjectPhaseAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }

                    // preview
                    if (e.CommandName == "Preview")
                    {
                        string url = string.Format("~/Page/Project/ProjectPhaseView.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }
                    // preview
                    if (e.CommandName == "Compare")
                    {
                        ProjectPhase projectPhase = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetByProjectPhaseId(id);
                        string url = UrlBuilderHelper.GetUrl(projectPhase,NavigateAction.Compare);
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
                    RLM.Construction.Entities.ProjectPhase dataItem = (RLM.Construction.Entities.ProjectPhase)e.Item.DataItem;


                    RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetByProjectId(dataItem.ProjectId);
                    if (project != null)
                    {
                        HtmlAnchor lnkProject = (HtmlAnchor)e.Item.FindControl("lnkProject");
                        lnkProject.InnerHtml = lnkProject.Title = project.Name;
                        lnkProject.Attributes.Add("url", string.Format("Page/Project/ProjectAddNew.aspx?ItemId={0}", project.ProjectId));
                    }

                    Literal ltrType = (Literal)e.Item.FindControl("ltrType");
                    ltrType.Text = Resources.Enumeration.ResourceManager.GetString("ProjectPhaseType_" + ((ProjectPhaseType)dataItem.Type).ToString());

                    RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.CurrencyUnitId));
                    if (unit != null)
                    {
                        Literal ltrCurrentcy = (Literal)e.Item.FindControl("ltrCurrentcy");
                        ltrCurrentcy.Text = unit.Name;
                    }

                    AddNewRelatedItemLink lnkPreview = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
                    lnkPreview.ResourceId = dataItem.ProjectPhaseId;
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
                DataSourceItem<RLM.Construction.Entities.ProjectPhase> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.ProjectPhase> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.ProjectPhase> item = new DataSourceItem<RLM.Construction.Entities.ProjectPhase>(); ;
                int total;
                item.Items = ServiceRepository.ProjectPhaseService.GetPaged("", "LastModificationDate DESC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.ProjectPhase>();
            }
        }
        #endregion
    }
}
