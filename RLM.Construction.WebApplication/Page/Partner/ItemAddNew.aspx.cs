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
using RLM.Core.Framework.Utility;
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class ItemAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Partner item;
        int itemId;
        public bool IsPopup { get; set; }
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();
                this.IsPopup = !string.IsNullOrEmpty(Request.Params["IsPopup"]);
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
                if (this.item ==null && IsExistPartnerByTaxCode())
                {
                    RLMContext.ErrorType = ErrorType.Error;
                    RLMContext.ErrorMessage = string.Format((string)this.GetLocalResourceObject("TaxtCodeDuplicate"), Request.Params[txtTaxCode.UniqueID]);
                    return;
                }
                Save();
                Response.Redirect("~/Page/Partner/ItemList.aspx?IsPopup="+this.IsPopup, true);
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
            Response.Redirect("~/Page/Partner/ItemList.aspx?IsPopup="+ this.IsPopup, true);
        }
        #endregion

        #region Private methods
        private void Save()
        {

            if (this.item == null)
            {
                
                this.item = new RLM.Construction.Entities.Partner();
                this.item.CreationDate = DateTime.Now;
                this.item.IsDeletable = true;
                this.item.ContactorId = 0;

            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.GroupId = int.Parse(drpGroup.SelectedValue);
            this.item.ContactorId = int.Parse(drpContactor.SelectedValue);
            this.item.Code = StringHelper.GetGuid(5);
            this.item.Name = Request.Params[txtName.UniqueID];
            this.item.NameInEng = Request.Params[txtNameInEnglish.UniqueID];
            this.item.Address = Request.Params[txtAddress.UniqueID];
            this.item.TaxCode = Request.Params[txtTaxCode.UniqueID];
            this.item.Phone = Request.Params[txtPhone.UniqueID];
            this.item.Fax = Request.Params[txtFax.UniqueID];
            this.item.Email = Request.Params[txtEmail.UniqueID];
            this.item.Website=Request.Params[txtWebsite.UniqueID];
            this.item.Comment = Request.Params[txtComment.UniqueID];
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            this.item.ContactName = Request.Params[txtContactor.UniqueID];
            this.item.RepresentativeName = Request.Params[txtRepresentative.UniqueID];


            if (this.item.PartnerId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.PartnerId.ToString().PadLeft(5, '0'); }
                ServiceRepository.PartnerService.Update(this.item);
            }
            else
            {
                ServiceRepository.PartnerService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.PartnerId.ToString().PadLeft(5, '0'); }
                ServiceRepository.PartnerService.Update(this.item);
            }
        }

        private bool IsExistPartnerByTaxCode()
        {
            string taxCode = Request.Params[txtTaxCode.UniqueID];
            RLM.Construction.Entities.Partner partner = ServiceRepositoryHelper.PartnerServiceHelper.GetPartnerByTaxtCode(taxCode);
            return partner != null;
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            //txtCode.Text = item.Code;
            txtName.Text = this.item.Name;
            txtNameInEnglish.Text = this.item.NameInEng;
            drpGroup.SelectedValue = ((int)this.item.GroupId).ToString();
            txtTaxCode.Text = this.item.TaxCode;
            txtPhone.Text = this.item.Phone;
            txtFax.Text = this.item.Fax;
            txtEmail.Text = this.item.Email;
            txtComment.Text = this.item.Comment;
            chkIsActive.Checked = (bool)this.item.IsActive;
            txtContactor.Text = this.item.ContactName;
            this.txtRepresentative.Text = this.item.RepresentativeName;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.PartnerService.GetByPartnerId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtTaxCode,
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
                    txtPhone,
                    Resources.ValidationRule.PhonePattern,
                    Resources.ValidationRule.PhoneErrorMessage,
                    Resources.ValidationRule.PhoneErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtFax,
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
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtRepresentative,
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
