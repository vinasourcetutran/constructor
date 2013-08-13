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
    public partial class StaffResponsibilityAddNew : System.Web.UI.Page
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
                radFromDate.SelectedDate = radToDate.SelectedDate = DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffResponsibility), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffResponsibility), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffResponsibility), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {

            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.ResourceData();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.ResourceId = this.staffId;
                this.item.ResourceType = (int)ResourceType.Staff;
                this.item.ContentType = (int)ResourceDataContentType.StaffResponsibility;
                this.item.IsActive = true;
            }
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();

            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.Content = txtTitle.Text;

            XmlHash xmlHash = new XmlHash(this.item.XMLContent);
            xmlHash.Set(ResponsibilityField.Title.ToString(), txtTitle.Text);
            xmlHash.Set(ResponsibilityField.FromDate.ToString(), radFromDate.SelectedDate);
            xmlHash.Set(ResponsibilityField.ToDate.ToString(), radToDate.SelectedDate);
            xmlHash.Set(ResponsibilityField.IsCurrentJob.ToString(), chkIsCurentJob.Checked.ToString());
            xmlHash.Set(ResponsibilityField.Comment.ToString(), txtComment.Text);

            xmlHash.RootTag = ResourceDataContentType.StaffResponsibility.ToString();
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
            txtTitle.Text = this.item.Content;
            XmlHash xmlhash = new XmlHash(this.item.XMLContent);
            try
            {
                radFromDate.SelectedDate = Convert.ToDateTime(xmlhash.GetKeyFromHash(ResponsibilityField.FromDate.ToString()));
                radToDate.SelectedDate =Convert.ToDateTime(xmlhash.GetKeyFromHash(ResponsibilityField.ToDate.ToString()));
                chkIsCurentJob.Checked = Convert.ToBoolean(xmlhash.GetKeyFromHash(ResponsibilityField.IsCurrentJob.ToString()));

                txtComment.Text = xmlhash.GetKeyFromHash(ContractField.Comment.ToString());
            }
            catch (Exception) { }
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
                   txtTitle,
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
