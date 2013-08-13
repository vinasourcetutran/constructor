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
    public partial class StaffFamilyAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ResourceData item;
        int itemId;
        int staffId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                radBirtday.SelectedDate = DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffFamily), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffFamily), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffFamily), true);
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
                this.item.ContentType = (int)ResourceDataContentType.StaffFamily;
                this.item.IsActive = true;
            }
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.Content = txtContent.Text;// Request.Params[txtCode.UniqueID];
            this.item.SubContentType = int.Parse(drpType.SelectedValue);

            XmlHash xmlHash = new XmlHash();
            xmlHash.Set(FamilyField.Side.ToString(), drpSide.SelectedValue);
            xmlHash.Set(FamilyField.FullName.ToString(), txtContent.Text);
            xmlHash.Set(FamilyField.PID.ToString(), txtPID.Text);
            xmlHash.Set(FamilyField.Sex.ToString(), drpSex.SelectedValue);
            xmlHash.Set(FamilyField.Birhday.ToString(), radBirtday.SelectedDate);
            xmlHash.Set(FamilyField.Comment.ToString(), txtComment.Text);
            xmlHash.Set(FamilyField.Type.ToString(), drpType.SelectedValue);
            xmlHash.RootTag = ResourceDataContentType.StaffFamily.ToString();
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
            txtContent.Text = this.item.Content;
            XmlHash xmlhash = new XmlHash(this.item.XMLContent);
            try
            {
                drpSide.SelectedValue = xmlhash.GetKeyFromHash(FamilyField.Side.ToString());
                drpSex.SelectedValue = xmlhash.GetKeyFromHash(FamilyField.Sex.ToString());
            }
            catch (Exception) { }
            txtPID.Text = xmlhash.GetKeyFromHash(FamilyField.PID.ToString());
            try
            {
                radBirtday.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(FamilyField.Birhday.ToString()));
            }
            catch (Exception){}
            txtComment.Text = xmlhash.GetKeyFromHash(FamilyField.Comment.ToString());

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
                   txtContent,
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
