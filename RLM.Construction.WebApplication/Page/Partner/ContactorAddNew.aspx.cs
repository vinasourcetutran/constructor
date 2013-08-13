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

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class ContactorAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Contactor item;
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
                Response.Redirect("~/Page/Partner/ContactorList.aspx", true);
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
            Response.Redirect("~/Page/Partner/ContactorList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Contactor();
                this.item.CreationDate = DateTime.Now;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.GroupId = int.Parse(drpGroup.SelectedValue);
            //this.item.Code = Request.Params[txtCode.UniqueID];
            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.JobTitle = Request.Params[txtJobTitle.UniqueID];
            this.item.Phone = Request.Params[txtPhone.UniqueID];
            this.item.Mobile = Request.Params[txtMobile.UniqueID];
            this.item.Email = Request.Params[txtEmail.UniqueID];
            this.item.Comment = Request.Params[txtComment.UniqueID];
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;


            if (this.item.ContactorId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ContactorId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ContactorService.Update(this.item);
            }
            else
            {
                ServiceRepository.ContactorService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ContactorId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ContactorService.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            drpGroup.SelectedValue = ((int)this.item.GroupId).ToString();
            txtName.Text = this.item.Name;
            txtJobTitle.Text = this.item.JobTitle;
            txtPhone.Text = this.item.Phone;
            txtMobile.Text = this.item.Mobile;
            txtEmail.Text = this.item.Email;
            txtComment.Text = this.item.Comment;
            chkIsActive.Checked = (bool)this.item.IsActive;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ContactorService.GetByContactorId(this.itemId);
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
                    txtPhone,
                    Resources.ValidationRule.PhonePattern,
                    Resources.ValidationRule.PhoneErrorMessage,
                    Resources.ValidationRule.PhoneErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtMobile,
                    Resources.ValidationRule.PhonePattern,
                    Resources.ValidationRule.PhoneErrorMessage,
                    Resources.ValidationRule.PhoneErrorHint
                ));

            validationManager.AddRule(
                new PatternMatchedRule(
                    txtEmail,
                    Resources.ValidationRule.EmailPattern,
                    Resources.ValidationRule.EmailErrorMessage,
                    Resources.ValidationRule.EmailErrorHint
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
