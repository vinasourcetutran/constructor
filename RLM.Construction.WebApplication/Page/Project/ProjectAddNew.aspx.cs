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
    public partial class ProjectAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Project item;
        int itemId;
        int contractId;
        #endregion

        #region Event Handler
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadData();
            drpContract.ShowContractHaveNoProjectOnly = this.item == null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                
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
                Response.Redirect("~/Page/Project/ProjectList.aspx", true);
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
            Response.Redirect("~/Page/Project/ProjectList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Project();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsApprove = true;
                
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();


            this.item.Code = Request.Params[txtCode.UniqueID];
            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.DesignedPrice = decimal.Parse(Request.Params[txtFirstPrice.UniqueID]);
            this.item.AuctualPrice = decimal.Parse(Request.Params[txtLastPrice.UniqueID]);
            this.item.ExchangeRate = int.Parse(Request.Params[txtExchangeRate.UniqueID]);
            this.item.CurrencyUnitId = int.Parse(drpUnit.SelectedValue);

            this.item.Description = Request.Params[txtDescription.UniqueID];
            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            //item.IsApprove = Request.Params[chkIsApprove.UniqueID] != null;

            int parentId;
            if (int.TryParse(drpGroup.SelectedValue, out parentId))
            {
                this.item.GroupId = parentId;
            }

            if (int.TryParse(drpContract.SelectedValue, out parentId))
            {
                this.item.ContractId = parentId;
            }

            if (this.item.ProjectId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ProjectId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ProjectService.Update(this.item);
            }
            else
            {
                ServiceRepository.ProjectService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ProjectId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ProjectService.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) {
                RLM.Construction.Entities.Contract fromContract = ServiceRepository.ContractService.GetByContractId(this.contractId);
                if (fromContract != null)
                {
                    txtCode.Text = fromContract.Code;
                    txtName.Text = fromContract.Name;
                    drpContract.SelectedValue = this.contractId.ToString();
                    txtFirstPrice.Text = fromContract.InitPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
                    txtLastPrice.Text = fromContract.LastPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
                }
                return; 
            }
            btnCancel.Visible = true;

            files.Visible = true;
            files.ResourceId = this.itemId;
            files.PageTitle = this.item.Name;

            drpContract.Visible = false;
            drpContract.SelectedValue = this.item.ContractId.ToString();
            RLM.Construction.Entities.Contract contract = ServiceRepository.ContractService.GetByContractId(this.item.ContractId);
            if (contract != null)
            {
                lnkContract.InnerHtml = lnkContract.Title = contract.Name;
                lnkContract.HRef = UrlBuilderHelper.GetUrl(contract, NavigateAction.Detail);
                drpGroup.SelectedValue = this.item.GroupId.ToString();
                addNewContractLink.Visible = false;
            }
            txtCode.Text = this.item.Code;
            txtName.Text = this.item.Name;
            ProjectPhase projectPhase = ServiceRepository.ProjectPhaseService.GetCurrentPhaseByProjectId(this.item.ProjectId);
            if (projectPhase != null)
            {
                lnkProjectPhase.InnerHtml = lnkProjectPhase.Title = projectPhase.Name;
                lnkProjectPhase.HRef = UrlBuilderHelper.GetUrl(projectPhase, NavigateAction.Detail);
                lnkAddNewProjectPhase.Url = string.Format("Page/Project/ProjectPhaseAddNew.aspx?ProjectId={0}",this.item.ProjectId);
            }
            // add reference to active project phase
            txtDescription.Text = this.item.Description;
            txtFirstPrice.Text = this.item.DesignedPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
            txtLastPrice.Text = this.item.AuctualPrice.Value.ToString(RLMConfiguration.Setting.MoneyFormat);
            drpUnit.SelectedValue = ((int)this.item.CurrencyUnitId).ToString();
            //drpUnit.Enabled = false;
            chkIsActive.Checked = (bool)this.item.IsActive;
            chkIsApprove.Checked = (bool)this.item.IsApprove;
            chkIsApprove.Visible = true;
            spIsApprove.Visible = false;
            txtExchangeRate.Text = NumberHelper.GetValue<int>(this.item.ExchangeRate).ToString();
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["ContractId"], out this.contractId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ProjectService.GetByProjectId(this.itemId);
        }

        private void Validation()
        {
            //validationManager.AddRule(
            //   new PatternMatchedRule(
            //       drpPartner,
            //       Resources.ValidationRule.RequiredPattern,
            //       Resources.ValidationRule.RequiredErrorMessage,
            //       Resources.ValidationRule.RequiredErrorHint
            //   ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtCode,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
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
                    txtExchangeRate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtExchangeRate,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
                ));

            //validationManager.AddRule(
            //    new PatternMatchedRule(
            //        radFromDate,
            //        Resources.ValidationRule.RequiredPattern,
            //        Resources.ValidationRule.RequiredErrorMessage,
            //        Resources.ValidationRule.RequiredErrorHint
            //    ));

            //validationManager.AddRule(
            //    new PatternMatchedRule(
            //        radToDate,
            //        Resources.ValidationRule.RequiredPattern,
            //        Resources.ValidationRule.RequiredErrorMessage,
            //        Resources.ValidationRule.RequiredErrorHint
            //    ));

            validationManager.Notifier = new BalloonNotifier();

            if (IsPostBack && !validationManager.Validate())
            {
                return;
            }
        }
        #endregion
    }
}
