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
using RLM.Core.Framework.Utility;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class UnitConvertor : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.UnitConvertor item;
        int itemId;
        int fromUnitId;

        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();
                if (this.IsPostBack) { return; }
                radEffectDate.SelectedDate = DateTime.Now;
                btnCancel.Attributes.Add("onclick", string.Format("document.location='{0}';return false;", Page.ResolveClientUrl("~/Page/System/UnitAddNew.aspx?ItemId=" + this.fromUnitId)));
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
                ErrorPair error = this.Save();
                if (error.ErrorType != ErrorType.None)
                {
                    RLMContext.ErrorType = error.ErrorType;
                    RLMContext.ErrorMessage = error.ErrorMessage;
                    return;
                }
                Response.Redirect(string.Format("~/Page/System/UnitAddnew.aspx?itemid={0}", this.fromUnitId), true);
            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
                Logger.Error(ex);
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                ServiceRepository.GroupService.Delete(this.itemId);
                Response.Redirect(string.Format("~/Page/System/UnitAddnew.aspx?itemid={0}", this.fromUnitId), true);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.GetGroupListUrl(), true);
        }
        #endregion

        #region Private methods
        private ErrorPair Save()
        {
            ErrorPair error = new ErrorPair();
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.UnitConvertor();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsDeletable = true;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();
            this.item.ToUnitId = int.Parse(drpUnit.SelectedValue);
            this.item.Quantity = double.Parse(txtQuantity.Text);
            this.item.EffectFrom = radEffectDate.SelectedDate;
            this.item.FromUnitId = this.fromUnitId;
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;

            if (NumberHelper.GetValue<DateTime>(this.item.EffectFrom).Date < DateTime.Now.Date)
            {
                error.ErrorMessage = GetLocalResourceObject("InvalidEffectDate") as string;
                error.ErrorType = ErrorType.Error;
                return error;
            }
            if (this.item.FromUnitId == this.item.ToUnitId)
            {
                error.ErrorMessage = GetLocalResourceObject("InvalidSeftReference") as string;
                error.ErrorType= ErrorType.Error;
                return error;
            }
            if (this.item.UnitConvertorId > 0)
            {
                ServiceRepositoryHelper.UnitConvertorServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.UnitConvertorServiceHelper.Insert(this.item);
            }
            return error;
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNew" : "Update").ToString();
            RLM.Construction.Entities.Unit fromUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(this.fromUnitId);
            if (fromUnit != null)
            {
                lblFromUnit.Text = string.Format("{0} ({1})", fromUnit.Name,fromUnit.Description);
            }
                // invalid unit
            else
            {
                Response.Redirect(string.Format("~/Page/System/UnitAddNew.aspx?itemId={0}", this.fromUnitId), true);
            }
            if (this.item == null) { return; }
            if (this.item.EffectFrom <= DateTime.Now)
            {
                Response.Redirect(string.Format("~/Page/System/UnitAddNew.aspx?itemId={0}", this.fromUnitId),true);
            }
            drpUnit.SelectedValue = this.item.ToUnitId.ToString();
            txtQuantity.Text =NumberHelper.GetValue<double>(this.item.Quantity).ToString();
            radEffectDate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.EffectFrom);
            chkIsActive.Checked =NumberHelper.GetValue<bool>(this.item.IsActive);
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            this.fromUnitId = int.Parse(Request.Params["FromUnit"]);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetByUnitConvertorId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtQuantity,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtQuantity,
                    Resources.ValidationRule.DecimalPattern,
                    Resources.ValidationRule.DecimalErrorMessage,
                    Resources.ValidationRule.DecimalErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    radEffectDate,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));

            //validationManager.AddRule(
            //    new DateTimeInRangeMatchedRule(
            //        radEffectDate,
            //        DateTime.Now, 
            //        DateTime.MaxValue,
            //        Resources.ValidationRule.DateTimeInRangeErrorMessage,
            //        Resources.ValidationRule.DateTimeInRangeErrorHint
            //    ));
            validationManager.Notifier = new BalloonNotifier();

            if (IsPostBack && !validationManager.Validate())
            {
                return;
            }
        }

        private string GetGroupListUrl()
        {
            return "~/Page/System/UnitList.aspx";
        }
        #endregion
    }
}
