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
using RLM.Construction.ServiceHelpers;

namespace RLM.Construction.WebApplication.Page.Staff
{
    public partial class StaffIidentifycationAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ResourceData item;
        int itemId;
        int staffId;
        #endregion

        #region Event Handler
        protected void drpCountry_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            drpProvince.ParentId = int.Parse(e.Value);
            drpProvince.ReBindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                radExpiredDate.SelectedDate = radIssuedDate.SelectedDate = DateTime.Now;
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
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericException, ex);
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffIdentifycation), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffIdentifycation), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffIdentifycation), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.ResourceData();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.ResourceId = this.staffId;
                this.item.ResourceType = (int)ResourceType.Staff;
                this.item.ContentType = (int)ResourceDataContentType.StaffIdentifycation;
                this.item.IsActive = true;
            }
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.Content = txtID.Text;// Request.Params[txtCode.UniqueID];
            this.item.SubContentType = int.Parse(drpType.SelectedValue);

            XmlHash xmlHash = new XmlHash();
            xmlHash.Set(PersonalIdentityField.Country.ToString(), drpCountry.SelectedValue);
            xmlHash.Set(PersonalIdentityField.Province.ToString(), drpProvince.SelectedValue);
            xmlHash.Set(PersonalIdentityField.IssuedPlace.ToString(), txtIssuePlace.Text);
            xmlHash.Set(PersonalIdentityField.IssuedPerson.ToString(), txtIssuePerson.Text);
            xmlHash.Set(PersonalIdentityField.IssuedDate.ToString(), radIssuedDate.SelectedDate);
            xmlHash.Set(PersonalIdentityField.ExpiredDate.ToString(), radExpiredDate.SelectedDate);
            xmlHash.Set(PersonalIdentityField.Comment.ToString(), txtComment.Text);
            xmlHash.Set(PersonalIdentityField.ID.ToString(), txtID.Text);
            xmlHash.Set(PersonalIdentityField.Type.ToString(), drpType.SelectedValue);
            xmlHash.RootTag = ResourceDataContentType.StaffIdentifycation.ToString();
            this.item.XMLContent = xmlHash.ToString();

            if (this.item.ResourceDataId > 0)
            {
                ServiceRepositoryHelper.ResourceDataServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.ResourceDataServiceHelper.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            btnDelete.Visible = true;
            drpType.SelectedValue = NumberHelper.GetValue<int>(this.item.SubContentType).ToString();
            XmlHash xmlhash = new XmlHash(this.item.XMLContent);
            try
            {
                drpCountry.SelectedValue = xmlhash.GetKeyFromHash(PersonalIdentityField.Country.ToString());
                drpProvince.ParentId = int.Parse(drpCountry.SelectedValue);
                drpProvince.ReBindData();
            }
            catch (Exception) { }
            try
            {
                drpProvince.SelectedValue = xmlhash.GetKeyFromHash(PersonalIdentityField.Province.ToString());
            }
            catch (Exception ex)
            {
            }

            txtIssuePlace.Text = xmlhash.GetKeyFromHash(PersonalIdentityField.IssuedPlace.ToString());
            txtIssuePerson.Text = xmlhash.GetKeyFromHash(PersonalIdentityField.IssuedPerson.ToString());

            try
            {
                radIssuedDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(PersonalIdentityField.IssuedDate.ToString()));
                radExpiredDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(PersonalIdentityField.ExpiredDate.ToString()));
            }
            catch (Exception)
            {
            }
            txtComment.Text = xmlhash.GetKeyFromHash(PersonalIdentityField.Comment.ToString());

            txtID.Text = this.item.Content;
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["ResourceId"], out this.staffId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.ResourceDataServiceHelper.GetByResourceDataId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
               new PatternMatchedRule(
                   txtID,
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
