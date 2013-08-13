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
    public partial class TaskMember : System.Web.UI.UserControl
    {
        #region Properties
        public string TitleText { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        public bool IsShowAddNewLink { get; set; }
        public string AddNewText { get; set; }
        public bool IsAllowEdit { get; set; }
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
                lnkAddMember.Visible = this.IsShowAddNewLink;
                //lnkAddMember.TabId = string.Format("{0}_TaskMember", this.ResourceType.ToString());
                lnkAddMember.Url = UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.TaskMember() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.ClientAddNew);
                if (!string.IsNullOrEmpty(this.AddNewText))
                {
                    lnkAddMember.Title = lnkAddMember.Text = this.AddNewText;
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
                RLM.Construction.Entities.TaskMember itemData = (RLM.Construction.Entities.TaskMember)e.Item.DataItem;
                RLM.Construction.Entities.Staff staff = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(itemData.StaffId);
                if (staff == null) { return; }

                Literal ltrFullName = (Literal)e.Item.FindControl("ltrFullName");
                ltrFullName.Text = staff.FullName;


                Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(itemData.RoleId);
                if (role != null)
                {
                    Literal ltrRoleName = (Literal)e.Item.FindControl("ltrRoleName");
                    ltrRoleName.Text = role.Name;
                }

                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<TaskMemberStatus>((TaskMemberStatus)NumberHelper.GetValue<int>(itemData.Status));

                Literal ltrFromDate = (Literal)e.Item.FindControl("ltrFromDate");
                ltrFromDate.Text = NumberHelper.GetValue<DateTime>(itemData.FromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrToDate = (Literal)e.Item.FindControl("ltrToDate");
                ltrToDate.Text = NumberHelper.GetValue<DateTime>(itemData.ToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(itemData.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);


                ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                btnPreview.Attributes.Add("tabid", string.Format("{0}_TaskMemberView", this.ResourceType.ToString()));
                btnPreview.Attributes.Add("url", UrlBuilderHelper.GetUrl(itemData, NavigateAction.ClientView));
                btnPreview.Attributes.Add("title", "TaskMember: " + staff.FullName);

                ImageButton btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                btnEdit.Attributes.Add("tabid", string.Format("{0}_TaskMemberEdit", this.ResourceType.ToString()));
                btnEdit.Attributes.Add("url", UrlBuilderHelper.GetUrl(itemData, NavigateAction.ClientEdit));
                btnEdit.Attributes.Add("title", "Edit:" + staff.FullName);
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
                TList<RLM.Construction.Entities.TaskMember> items = ServiceRepositoryHelper.TaskMemberServiceHelper.GetByResource(this.ResourceType, this.ResourceId);
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