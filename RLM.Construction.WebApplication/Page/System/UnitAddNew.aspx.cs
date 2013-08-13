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

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class UnitAddNew : System.Web.UI.Page
    {
        #region Variables
        Unit item;
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
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                Response.Redirect(this.GetGroupListUrl(), true);
            }
            catch (Exception ex)
            {
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.Error = ex;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
                Logger.Error(ex);
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                ServiceRepository.GroupService.Delete(this.itemId);
                Response.Redirect(this.GetGroupListUrl(), true);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.Error = ex;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.GetGroupListUrl(), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new Unit();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsDeletable = true;
                this.item.IsBaseUnit = false;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();
            item.Name = Request.Params[txtName.UniqueID];
            item.Description = Request.Params[txtDescription.UniqueID];
            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            item.IsBaseUnit = Request.Params[chkIsBaseUnit.UniqueID] != null;
            this.item.Type= int.Parse(drpUnitType.SelectedValue);
            if (this.item.UnitId > 0)
            {
                ServiceRepository.UnitService.Update(this.item);
            }
            else
            {
                ServiceRepository.UnitService.Insert(this.item);
            }
        }

        private void BindGuid()     
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewGroup" : "UpdateGroup").ToString();
            if (this.item == null) { return; }
            convertor.Visible = true;
            convertor.FromUnitId = this.item.UnitId;

            drpUnitType.SelectedValue = this.item.Type.ToString();
            txtName.Text = this.item.Name;
            txtDescription.Text = this.item.Description;
            chkIsActive.Checked = (bool)this.item.IsActive;
            chkIsBaseUnit.Checked = NumberHelper.GetValue<bool>(this.item.IsBaseUnit);
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.UnitService.GetByUnitId(this.itemId);
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

        private string GetGroupListUrl()
        {
            return "~/Page/System/UnitList.aspx";
        }
        #endregion
    }
}
