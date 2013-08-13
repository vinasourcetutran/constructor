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
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.Page.Partner
{
    public partial class ContactorView : System.Web.UI.Page
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

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new Contactor(),NavigateAction.List) , true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            RLM.Construction.Entities.Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.GroupId));
            if (group != null)
            {
                lblGroup.Text = group.Name;
            }
            
            lblName.Text = this.item.Name;
            lblJobTitle.Text = this.item.JobTitle;
            lblPhone.Text = this.item.Phone;
            lblMobile.Text = this.item.Mobile;
            lblEmail.Text = this.item.Email;
            ltrComment.Text = this.item.Comment;
            spIsActive.Attributes.Add("class",NumberHelper.GetValue<bool>(this.item.IsActive)?"OK":"NotOK");
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
        #endregion
    }
}
