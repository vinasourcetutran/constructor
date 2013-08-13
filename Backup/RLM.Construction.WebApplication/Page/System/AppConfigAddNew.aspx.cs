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

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class AppConfigAddNew : System.Web.UI.Page
    {
        #region Variables
        AppConfig item;
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
                Response.Redirect(this.GetGroupListUrl(), true);
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
            Response.Redirect(this.GetGroupListUrl(), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new AppConfig();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsDeletable = true;
                this.item.IsActive = true;
                item.AppConfigName = Request.Params[txtName.UniqueID];
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();
            item.AppConfigValue = Request.Params[txtValue.UniqueID];
            this.item.ApplicationId = null;
            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            if (this.item.AppConfigId <= 0)
            {
                ServiceRepositoryHelper.AppConfigServiceHelper.Insert(this.item);
            }
            else
            {
                ServiceRepositoryHelper.AppConfigServiceHelper.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            txtName.Text = this.item.AppConfigName;
            txtName.Enabled = false;
            txtValue.Text = this.item.AppConfigValue;
            chkIsActive.Checked = (bool)this.item.IsActive;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.AppConfigService.GetByAppConfigId(this.itemId);
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
            return "~/Page/System/AppConfigList.aspx";
        }
        #endregion
    }
}
