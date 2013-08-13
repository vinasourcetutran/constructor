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
    public partial class TaskAddNew : System.Web.UI.Page
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
                Validation();
                LoadData();
                radToDate.SelectedDate = radFromDate.SelectedDate = radRealFromDate.SelectedDate = radRealToDate.SelectedDate = DateTime.Now;
                string resourceName = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                lblResource.InnerHtml = string.Format("{0}:{1}",Utility.GetEnumValue<ResourceType>(this.ResourceType), resourceName);
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
                Response.Redirect(UrlBuilderHelper.GetUrl(this.item,NavigateAction.View));
                //Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { ResourceId=this.ResourceId,ResourceType=(int)this.ResourceType},NavigateAction.List), true);
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
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Task() { ResourceId = this.ResourceId, ResourceType = (int)this.ResourceType }, NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Task();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.RealFromDate = this.item.RealToDate = this.item.EstimationFromDate = this.item.EstimationToDate = DateTime.Now;
                this.item.ResourceType = (int)this.ResourceType;
                this.item.ResourceId = this.ResourceId;
                if (this.ResourceType == ResourceType.ProjectPhase)
                {
                    this.item.ProjectPhaseId = this.ResourceId;
                }
                if (this.ResourceType == ResourceType.Project)
                {
                    this.item.ProjectId = this.ResourceId;
                }
                if (this.ResourceType == ResourceType.Contract)
                {
                    this.item.ContractId = this.ResourceId;
                }
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId=Utility.GetCurrentUserId();

            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.Description = radDescription.Content;
            this.item.PercentComplete = (double)radPercentComplete.Value;
            this.item.EstimationFromDate = DateTime.Parse(Request.Params[radFromDate.UniqueID]);
            this.item.EstimationToDate = DateTime.Parse(Request.Params[radToDate.UniqueID]);
            this.item.RealFromDate = DateTime.Parse(Request.Params[radRealFromDate.UniqueID]);
            this.item.RealToDate = DateTime.Parse(Request.Params[radRealToDate.UniqueID]);


            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            this.item.IsApproved = Request.Params[chkIsApprove.UniqueID] != null;
            this.item.Status = int.Parse(drpStatus.SelectedValue);
            
            if (this.item.TaskId > 0)
            {
                ServiceRepositoryHelper.TaskServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.TaskServiceHelper.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }

            members.ResourceId = this.item.TaskId;
            members.Visible = true;
            files.ResourceId = this.item.TaskId;
            files.Visible = true;

            txtName.Text = this.item.Name;
            radDescription.Content = this.item.Description;
            radPercentComplete.Value = (decimal)this.item.PercentComplete;

            radFromDate.SelectedDate = this.item.EstimationFromDate;
            radToDate.SelectedDate = this.item.EstimationToDate;
            radRealFromDate.SelectedDate = this.item.RealFromDate;
            radRealToDate.SelectedDate = this.item.RealToDate;

            chkIsActive.Checked = NumberHelper.GetValue<bool>(this.item.IsActive);
            chkIsApprove.Checked = NumberHelper.GetValue<bool>(this.item.IsApproved);

            drpStatus.SelectedValue = NumberHelper.GetValue<int>(this.item.Status).ToString();
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId))
            {
                this.ResourceId = int.Parse(Request.Params["ResourceId"]);
                this.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType),Request.Params["ResourceType"]);
                return;
            }
            this.item = ServiceRepositoryHelper.TaskServiceHelper.GetByTaskId(this.itemId);
            this.ResourceType =(ResourceType)NumberHelper.GetValue<int>(this.item.ResourceType);
            this.ResourceId = NumberHelper.GetValue<int>(this.item.ResourceId);
        }

        private void Validation()
        {
            validationManager.AddRule(
               new PatternMatchedRule(
                   txtName,
                   Resources.ValidationRule.RequiredPattern,
                   Resources.ValidationRule.RequiredErrorMessage,
                   Resources.ValidationRule.RequiredErrorHint
               ));

            validationManager.Notifier = new BalloonNotifier();

            if (IsPostBack && !validationManager.Validate())
            {
                return;
            }
        }
        #endregion
    }
}
