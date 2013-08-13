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

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectPhaseAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ProjectPhase item;
        int itemId;
        int projectId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                Validation();
                
                if (!this.IsPostBack)
                {
                    drpUnit.SelectedValue = RLMConfiguration.Setting.VndUnitId.ToString();// ((int)this.item.CurrencyUnitId).ToString();
                    this.radFromDate.SelectedDate = this.radRealFromDate.SelectedDate = this.radRealToDate.SelectedDate = this.radToDate.SelectedDate = DateTime.Now;
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
                Response.Redirect("~/Page/Project/ProjectPhaseList.aspx", true);
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Project/ProjectPhaseList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.ProjectPhase();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsApprove = true;
                
                int projectId;
                if (int.TryParse(drpProject.SelectedValue, out projectId))
                {
                    RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetByProjectId(projectId);
                    this.item.ProjectId = project.ProjectId;
                    this.item.ContractId = project.ContractId;
                }
            }
            this.item.CurrencyUnitId = int.Parse(drpUnit.SelectedValue);

            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            
            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.Description=Request.Params[txtDescription.UniqueID];
            this.item.DesignPrice = decimal.Parse(Request.Params[txtFirstPrice.UniqueID]);
            this.item.AuctualPrice = decimal.Parse(Request.Params[txtLastPrice.UniqueID]);
            this.item.ExchangeRate = int.Parse(Request.Params[txtExchangRate.UniqueID]);
            this.item.FromDate = radFromDate.SelectedDate;
            this.item.ToDate = radToDate.SelectedDate;
            this.item.RealFromDate = radRealFromDate.SelectedDate;
            this.item.RealToDate = radToDate.SelectedDate;

            this.item.IsBillable = Request.Params[chkIsBillable.UniqueID] != null;


            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            item.IsCurrentProjectPhase = Request.Params[chkIsCurrentProjectPhase.UniqueID] != null;
            item.Type = int.Parse(drpProjectPhaseType.SelectedValue);
            item.Status = int.Parse(drpProjectPhaseStatus.SelectedValue);
            
            if (this.item.ProjectPhaseId > 0)
            {
                ServiceRepository.ProjectPhaseService.Update(this.item);
            }
            else
            {
                ServiceRepository.ProjectPhaseService.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetByProjectId(this.projectId);

            if (project != null)
            {
                drpProject.SelectedValue = this.projectId.ToString();
                drpUnit.SelectedValue = project.CurrencyUnitId.ToString();
                
            }
            if (this.item == null){return;}
            files.Visible = true;
            files.ResourceId = this.itemId;
            files.PageTitle = this.item.Name;

            drpProject.Visible = false;
            drpProject.SelectedValue = this.item.ProjectId.ToString();
            project= ServiceRepository.ProjectService.GetByProjectId(this.item.ProjectId);
            if (project != null)
            {
                lnkProject.InnerHtml = lnkProject.Title = project.Name;
                lnkProject.HRef = UrlBuilderHelper.GetUrl(project, NavigateAction.Detail);
                addNewProjectLink.Visible = false;
            }
            txtName.Text = this.item.Name;
            // add reference to active project phase
            txtDescription.Text = this.item.Description;
            txtFirstPrice.Text = this.item.DesignPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
            txtLastPrice.Text = this.item.AuctualPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);

            radFromDate.SelectedDate = (DateTime)this.item.FromDate;
            radToDate.SelectedDate = (DateTime)this.item.ToDate;
            radRealFromDate.SelectedDate = (DateTime)this.item.RealFromDate;
            radRealToDate.SelectedDate = (DateTime)this.item.RealToDate;

            txtExchangRate.Text = NumberHelper.GetValue<int>(this.item.ExchangeRate).ToString();

            drpUnit.SelectedValue = ((int)this.item.CurrencyUnitId).ToString();
            //drpUnit.Enabled = false;
            chkIsBillable.Checked = NumberHelper.GetValue<bool>(this.item.IsBillable);
            chkIsActive.Checked = (bool)this.item.IsActive;
            chkIsCurrentProjectPhase.Checked = (bool)this.item.IsCurrentProjectPhase;
            drpProjectPhaseStatus.SelectedValue = ((int)this.item.Status).ToString();
            drpProjectPhaseType.SelectedValue = this.item.Type.HasValue?this.item.Type.Value.ToString():"0";
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }

            
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["ProjectId"], out this.projectId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ProjectPhaseService.GetByProjectPhaseId(this.itemId);
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

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFirstPrice,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFirstPrice,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtLastPrice,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtLastPrice,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtExchangRate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtExchangRate,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
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
