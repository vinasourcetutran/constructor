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
    public partial class StaffPunishAddNew : System.Web.UI.Page
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
                radIssueDate.SelectedDate = radEffectFrom.SelectedDate = radEffectTo.SelectedDate = DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffPunish), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffPunish), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffPunish), true);
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
                this.item.ContentType = (int)ResourceDataContentType.StaffReward;
                this.item.IsActive = true;
            }


            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.SubContentType = int.Parse(drpType.SelectedValue);

            XmlHash xmlHash = new XmlHash(this.item.XMLContent);
            xmlHash.Set(PunishField.IssueId.ToString(), txtIssuedId.Text);
            xmlHash.Set(PunishField.AssigedDate.ToString(), radIssueDate.SelectedDate);
            xmlHash.Set(PunishField.FromDate.ToString(), radEffectFrom.SelectedDate);
            xmlHash.Set(PunishField.ToDate.ToString(), radEffectTo.SelectedDate);
            xmlHash.Set(PunishField.PunishForm.ToString(), drpForm.SelectedValue);
            xmlHash.Set(PunishField.Money.ToString(), txtFormValue.Text);
            xmlHash.Set(PunishField.MoneyUnit.ToString(), drpUnit.SelectedValue);
            xmlHash.Set(PunishField.IssuePerson.ToString(), txtIssuePerson.Text);
            xmlHash.Set(PunishField.Reason.ToString(), txtReason.Text);
            xmlHash.Set(PunishField.Comment.ToString(), txtComment.Text);
            xmlHash.Set(PunishField.IsActive.ToString(), chkIsActive.Checked.ToString());
            xmlHash.Set(PunishField.IssuedLevel.ToString(), drpIsueLevel.SelectedValue);

            FileViewTypeInfo[] info = new FileViewTypeInfo[0];
            string fileName = Utility.UploadFile(fphoto.PostedFile, info);
            if (!string.IsNullOrEmpty(fileName))
            {
                xmlHash.Set(PunishField.AttachFileUrl.ToString(), fileName);
                xmlHash.Set(PunishField.AttachFileName.ToString(), Path.GetFileName(fileName));
            }

            xmlHash.RootTag = ResourceDataContentType.StaffPunish.ToString();
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
                txtIssuedId.Text = xmlhash.GetKeyFromHash(PunishField.IssueId.ToString());
                radIssueDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(PunishField.AssigedDate.ToString()));
                radEffectFrom.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(PunishField.FromDate.ToString()));
                radEffectTo.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(PunishField.ToDate.ToString()));
                drpForm.SelectedValue = xmlhash.GetKeyFromHash(PunishField.PunishForm.ToString());
                txtFormValue.Text = xmlhash.GetKeyFromHash(PunishField.Money.ToString());
                drpUnit.SelectedValue = xmlhash.GetKeyFromHash(PunishField.MoneyUnit.ToString());
                txtIssuePerson.Text = xmlhash.GetKeyFromHash(PunishField.IssuePerson.ToString());
                txtReason.Text = xmlhash.GetKeyFromHash(PunishField.Reason.ToString());
                txtComment.Text = xmlhash.GetKeyFromHash(PunishField.Comment.ToString());
                chkIsActive.Checked = Convert.ToBoolean(xmlhash.GetKeyFromHash(PunishField.IsActive.ToString()));
                drpIsueLevel.SelectedValue = xmlhash.GetKeyFromHash(PunishField.IssuedLevel.ToString());
                if (!string.IsNullOrEmpty(xmlhash.GetKeyFromHash(PunishField.AttachFileUrl.ToString())))
                {
                    string url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, xmlhash.GetKeyFromHash(PunishField.AttachFileUrl.ToString()));
                    lnkAttachFile.HRef = url;
                    lnkAttachFile.InnerHtml = xmlhash.GetKeyFromHash(PunishField.AttachFileName.ToString());
                }
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
            //validationManager.AddRule(
            //   new PatternMatchedRule(
            //       txtContent,
            //       Resources.ValidationRule.RequiredPattern,
            //       Resources.ValidationRule.RequiredErrorMessage,
            //       Resources.ValidationRule.RequiredErrorHint
            //   ));

            //validationManager.Notifier = new BalloonNotifier();

            //if (IsPostBack && !validationManager.Validate())
            //{
            //    return;
            //}
        }
        #endregion
    }
}
