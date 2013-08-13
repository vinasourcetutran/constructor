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
    public partial class PartnerView : System.Web.UI.Page
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

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Partner/ItemList.aspx?IsPopup=" + this.IsPopup, true);
            //Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Partner(),NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            //RLM.Construction.Entities.Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.GroupId));
            //if (group != null)
            //{
            //    lblGroup.Text = group.Name;
            //}

            //RLM.Construction.Entities.Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(this.item.ContactorId));
            //if (contactor != null)
            //{
            //    lnkContactor.Title = lnkContactor.Text = contactor.Name;
            //    lnkContactor.Url = UrlBuilderHelper.GetUrl(contactor, NavigateAction.ClientView);
            //}
            lnkContactor.ResourceId = NumberHelper.GetValue<int>(this.item.ContactorId);
            lblTaxCode.Text = this.item.TaxCode;
            lblName.Text = this.item.Name;
            lblShortName.Text = this.item.NameInEng;
            lblAddress.Text = this.item.Address;
            
            lblPhone.Text = this.item.Phone;
            lblFax.Text = this.item.Fax;
            lblEmail.Text = this.item.Email;
            lnkWebsite.HRef = lnkWebsite.InnerHtml = this.item.Website;
            ltrComment.Text = this.item.Comment;
            spIsActive.Attributes.Add("class",NumberHelper.GetValue<bool>(this.item.IsActive)?"OK":"NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }

            projectList.PatnerId = this.item.PartnerId;
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.PartnerService.GetByPartnerId(this.itemId);
        }

        #endregion
    }
}
