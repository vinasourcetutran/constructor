using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Configuration;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class AdvanceRequestAddNew : System.Web.UI.Page
    {
        #region Variables
        AdvanceRequest item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();
                if (this.IsPostBack) { return; }
                BindGuid();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                Response.Redirect("~/Page/Contract/AdvanceRequestList.aspx", true);
            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
                Logger.Error(ex);
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Contract/AdvanceRequestList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new AdvanceRequest();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.RequestDate = this.item.ResponseDate = DateTime.Now;
                
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModifidationUserId = Utility.GetCurrentUserId();
            item.ContractId = int.Parse(drpContract.SelectedValue);
            item.RequestContactorId = int.Parse(drpContactor.SelectedValue);
            item.RequestAmount = decimal.Parse(txtAmount.Text);
            item.CurrencyUnitId = int.Parse(drpUnitId.SelectedValue);
            item.Status = int.Parse(drpStatus.SelectedValue);
            item.RequestComment = txtRequestComment.Text;

            if (this.item.AdvanceRequestId <= 0)
            {
                ServiceRepositoryHelper.AdvanceRequestServiceHelper.Insert(this.item);
            }
            else
            {
                ServiceRepositoryHelper.AdvanceRequestServiceHelper.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            drpContract.SelectedValue = NumberHelper.GetValue<int>(this.item.ContractId).ToString();
            drpContactor.SelectedValue = this.item.RequestContactorId.ToString();
            txtAmount.Text = NumberHelper.GetValue<decimal>(this.item.RequestAmount).ToString(RLM.Configuration.RLMConfiguration.Setting.MoneyFormat);
            drpUnitId.SelectedValue = NumberHelper.GetValue<int>(this.item.CurrencyUnitId).ToString();
            spRequestDate.InnerHtml = NumberHelper.GetValue<DateTime>(this.item.RequestDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            drpStatus.SelectedValue = NumberHelper.GetValue<int>(this.item.Status).ToString();
            txtRequestComment.Text = this.item.RequestComment;
            files.ResourceId = this.item.AdvanceRequestId;
            files.PageTitle = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(this.item.RequestContactorId)).Name;
            files.Visible = true;
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.AdvanceRequestService.GetByAdvanceRequestId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtAmount,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtAmount,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.NumberErrorMessage,
                    Resources.ValidationRule.NumberErrorHint
                ));

            validationManager.AddRule(
               new PatternMatchedRule(
                   txtRequestComment,
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
