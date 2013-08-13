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
    public partial class TaskView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Task item;
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

                string name = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                lnkResource.ResourceId = this.ResourceId;
                lnkResource.ResourceType = this.ResourceType;
                lnkResource.Action = NavigateAction.ClientView;

                /*lnkResource.Text = string.Format("{0}: {1}", Utility.GetEnumValue<RLM.Construction.Entities.ResourceType>(this.ResourceType), name);
                lnkResource.Title = string.Format("{0}: {1}", this.ResourceType.ToString(), name);
                lnkResource.TabId = string.Format("{0}_View", this.ResourceType.ToString());
                lnkResource.Url = UrlBuilderHelper.GetUrl(this.ResourceType, this.ResourceId, NavigateAction.ClientView);*/

                if (!this.IsPostBack)
                {
                    BindGuid();
                }
                if (this.item != null)
                {
                    comments.ResourceId = this.item.TaskId;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { ResourceType=(int)this.ResourceType,ResourceId=this.ResourceId},NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            this.ResourceType = (ResourceType)NumberHelper.GetValue<int>(this.item.ResourceType);
            this.ResourceId =NumberHelper.GetValue<int>(this.item.ResourceId);

            files.ResourceId = this.item.TaskId;
            members.ResourceId = this.item.TaskId;

            lblName.Text = this.item.Name;
            ltrDescription.Text = this.item.Description;
            lblPercentComplete.Text = NumberHelper.GetValue<double>(this.item.PercentComplete).ToString();

            lblFromDate.Text = NumberHelper.GetValue<DateTime>(this.item.EstimationFromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblToDate.Text = NumberHelper.GetValue<DateTime>(this.item.EstimationToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            spIsActive.Attributes.Add("class",NumberHelper.GetValue<bool>(this.item.IsActive)?"OK":"NotOK");

            lblRealFromDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealFromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            lblRealToDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            spIsApprove.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsApproved) ? "OK" : "NotOK");

            TaskStatus taskStatus = (TaskStatus)this.item.Status;
            lblStatus.Text = Utility.GetEnumValue<TaskStatus>(taskStatus);
            comments.AllowPostComment = taskStatus == TaskStatus.Discussing;

            RLM.Construction.Entities.User creator = ServiceRepositoryHelper.UserServiceHelper.GetByUserId(NumberHelper.GetValue<int>(this.item.CreationUserId));
            if (creator != null)
            {
                lblCreator.ToolTip = lblCreator.Text = creator.FullName;
            }

            spLastModificationDate.InnerHtml = NumberHelper.GetValue<DateTime>(this.item.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);


        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.TaskServiceHelper.GetByTaskId(this.itemId);
            this.ResourceId = NumberHelper.GetValue<int>(this.item.ResourceId);
            this.ResourceType = (RLM.Construction.Entities.ResourceType)NumberHelper.GetValue<int>(this.item.ResourceType);
        }
        #endregion
    }
}
