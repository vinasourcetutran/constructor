using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class TaskMemberView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.TaskMember item;
        int itemId;
        public ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string resourceName = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                lblResource.Text = string.Format("{0}: {1}", Utility.GetEnumValue<ResourceType>(this.ResourceType), resourceName);
                if (!this.IsPostBack)
                {
                    BindGuid();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.TaskMember() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.List), true);
        }

        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            RLM.Construction.Entities.Staff staff = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(this.item.StaffId);
            if (staff != null)
            {
                lnkStaff.Url = UrlBuilderHelper.GetUrl(staff, NavigateAction.ClientView);
                lnkStaff.Text = staff.FullName;
                lnkStaff.Title = "Staff: " + staff.FullName;
            }

            Role role = ServiceRepositoryHelper.RoleServiceHelper.GetByRoleId(this.item.RoleId);
            if (role != null)
            {
                lblRole.Text = role.Name;
            }
            lblStatus.Text = Utility.GetEnumValue<TaskMemberStatus>((TaskMemberStatus)NumberHelper.GetValue<int>(this.item.Status));
            lblFromDate.Text =NumberHelper.GetValue<DateTime>(this.item.FromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblToDate.Text = NumberHelper.GetValue<DateTime>(this.item.ToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblRealFromDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealFromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblRealToDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

            ltrComment.Text = this.item.Comment;
            lblLastModificationDate.Text = NumberHelper.GetValue<DateTime>(this.item.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)){return;}
            this.item = ServiceRepositoryHelper.TaskMemberServiceHelper.GetByTaskMemberId(this.itemId);
            this.ResourceType = (ResourceType)NumberHelper.GetValue<int>(this.item.ResourceType);
            this.ResourceId = NumberHelper.GetValue<int>(this.item.ResourceId);
        }
        #endregion
    }
}
