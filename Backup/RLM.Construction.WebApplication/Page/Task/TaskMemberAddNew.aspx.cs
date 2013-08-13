using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.Entities;
using RLM.Configuration;
using RLM.Construction.WebApplication.CommonLib;
using System.IO;
using RLM.Core.Framework.Utility;
using System.Threading;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class TaskMemberAddNew : System.Web.UI.Page
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
                radToDate.SelectedDate = radFromDate.SelectedDate = radRealFromDate.SelectedDate = radRealToDate.SelectedDate = DateTime.Now;
                string resourceName = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                lblResource.Text = string.Format("{0}: {1}",Utility.GetEnumValue<ResourceType>(this.ResourceType), resourceName);
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

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.TaskMember() { ResourceId=this.ResourceId,ResourceType=(int)this.ResourceType},NavigateAction.List), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.TaskMember() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.List), true);
        }

        public void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                ServiceRepositoryHelper.TaskMemberServiceHelper.Delete(this.itemId);
                Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.TaskMember() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.List), true);
            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
                RLMContext.ErrorType = ErrorType.Error;
            }
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.TaskMember();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.RealFromDate = this.item.RealToDate = this.item.FromDate = this.item.ToDate = DateTime.Now;
                this.item.ResourceType = (int)this.ResourceType;
                this.item.ResourceId = this.ResourceId;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId=Utility.GetCurrentUserId();

            this.item.StaffId = int.Parse(staff.SelectedValue);
            this.item.RoleId =int.Parse(role.SelectedValue);
            
            this.item.FromDate = radFromDate.SelectedDate;
            this.item.ToDate = radToDate.SelectedDate;
            this.item.RealFromDate = radRealFromDate.SelectedDate;
            this.item.RealToDate = radRealToDate.SelectedDate;
            this.item.Comment = txtComment.Text;

            this.item.Status = int.Parse(status.SelectedValue);
            
            if (this.item.TaskMemberId > 0)
            {
                ServiceRepositoryHelper.TaskMemberServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.TaskMemberServiceHelper.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            staff.Enabled = false;
            btnDelete.Visible = true;
            staff.SelectedValue = this.item.StaffId.ToString();
            role.SelectedValue = this.item.RoleId.ToString();
            status.SelectedValue = NumberHelper.GetValue<int>(this.item.Status).ToString();
            radFromDate.SelectedDate = this.item.FromDate;
            radToDate.SelectedDate = this.item.ToDate;
            radRealFromDate.SelectedDate = this.item.RealFromDate;
            radRealToDate.SelectedDate = this.item.RealToDate;
            txtComment.Text = this.item.Comment;

            lblLastModificationDate.Text = NumberHelper.GetValue<DateTime>(this.item.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId))
            {
                this.ResourceId = int.Parse(Request.Params["ResourceId"]);
                this.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), Request.Params["ResourceType"]);
                return;
            }
            this.item = ServiceRepositoryHelper.TaskMemberServiceHelper.GetByTaskMemberId(this.itemId);
            this.ResourceType = (ResourceType)NumberHelper.GetValue<int>(this.item.ResourceType);
            this.ResourceId = NumberHelper.GetValue<int>(this.item.ResourceId);
        }
        #endregion
    }
}
