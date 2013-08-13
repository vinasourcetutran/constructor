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


namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class TaskList : System.Web.UI.UserControl
    {
        #region Properties
        public bool IsAllowEdit { get; set; }
        public string TitleText { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        public bool IsActiveOnly { get; set; }
        public bool IsShowAddNewLink { get; set; }

        public string AddNewText { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                BindItems();
                if (!string.IsNullOrEmpty(this.TitleText))
                {
                    legend.InnerHtml = this.TitleText;
                }
                lnkAddNewTask.Visible = this.IsShowAddNewLink;
                lnkAddNewTask.TabId = string.Format("{0}_Task", this.ResourceType.ToString());
                lnkAddNewTask.Url = UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.ClientAddNew);
                if (!string.IsNullOrEmpty(this.AddNewText))
                {
                    lnkAddNewTask.Title = lnkAddNewTask.Text = this.AddNewText;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void rptItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                RLM.Construction.Entities.Task itemData = (RLM.Construction.Entities.Task)e.Item.DataItem;


                //Literal ltrName = (Literal)e.Item.FindControl("ltrName");
                //ltrName.Text =StringHelper.Truncat(itemData.Name,60);
                Label lblName = (Label)e.Item.FindControl("lblName");
                lblName.Text = StringHelper.Truncat(itemData.Name, 60);
                lblName.ToolTip = itemData.Name;

                Literal ltrPercentComplete = (Literal)e.Item.FindControl("ltrPercentComplete");
                ltrPercentComplete.Text = NumberHelper.GetValue<double>(itemData.PercentComplete).ToString();

                HtmlGenericControl spIsActive = (HtmlGenericControl)e.Item.FindControl("spIsActive");
                spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(itemData.IsActive) ? "OK" : "NotOK");

                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<TaskStatus>((TaskStatus)NumberHelper.GetValue<int>(itemData.Status));

                User creatorUser = ServiceRepositoryHelper.UserServiceHelper.GetByUserId(NumberHelper.GetValue<int>(itemData.CreationUserId));
                if (creatorUser != null)
                {
                    Literal ltrCreatorUserId = (Literal)e.Item.FindControl("ltrCreatorUserId");
                    ltrCreatorUserId.Text = creatorUser.FullName;
                }

                Literal ltrFromDate = (Literal)e.Item.FindControl("ltrFromDate");
                ltrFromDate.Text = NumberHelper.GetValue<DateTime>(itemData.EstimationFromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrCreationDate = (Literal)e.Item.FindControl("ltrCreationDate");
                ltrCreationDate.Text = NumberHelper.GetValue<DateTime>(itemData.CreationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                btnPreview.Attributes.Add("tabid", string.Format("{0}_Task", this.ResourceType.ToString()));
                btnPreview.Attributes.Add("url", UrlBuilderHelper.GetUrl(itemData, NavigateAction.ClientView));
                btnPreview.Attributes.Add("title", itemData.Name);

                ImageButton btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                btnEdit.Attributes.Add("tabid", string.Format("{0}_TaskEdit", this.ResourceType.ToString()));
                btnEdit.Attributes.Add("url", UrlBuilderHelper.GetUrl(itemData, NavigateAction.ClientEdit));
                btnEdit.Attributes.Add("title", "Edit: " + itemData.Name);
                btnEdit.Visible = this.IsAllowEdit;
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
                TList<RLM.Construction.Entities.Task> items = ServiceRepositoryHelper.TaskServiceHelper.GetByResource(this.ResourceType, this.ResourceId, this.IsActiveOnly);
                rptItems.DataSource = items;
                rptItems.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}