using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.Services;
using RLM.Configuration;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class RoleAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Role item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();

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
                Response.Redirect(UrlBuilderHelper.GetUrl(new Role(),NavigateAction.List), true);
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
            Response.Redirect(UrlBuilderHelper.GetUrl(new Role(), NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Role();
                this.item.CreationDate = DateTime.Now;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.Code = Request.Params[txtCode.UniqueID];
            this.item.Type = Convert.ToInt32(drpRoleType.SelectedValue);
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;


            if (this.item.RoleId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.RoleId.ToString().PadLeft(5, '0'); }
                ServiceRepository.RoleService.Update(this.item);
            }
            else
            {
                ServiceRepository.RoleService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.RoleId.ToString().PadLeft(5, '0'); }
                ServiceRepository.RoleService.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            
            txtName.Text = this.item.Name;
            txtCode.Text = this.item.Code;
            drpRoleType.SelectedValue =NumberHelper.GetValue<int>(this.item.Type).ToString();
            chkIsActive.Checked = (bool)this.item.IsActive;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.RoleService.GetByRoleId(this.itemId);
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
