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
    public partial class StaffRewardAddNew : System.Web.UI.Page
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
                radIssueDate.SelectedDate = radEffectFrom.SelectedDate = DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffReward), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffReward), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffReward), true);
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
            xmlHash.Set(RewardField.IssueId.ToString(), txtIssuedId.Text);
            xmlHash.Set(RewardField.AssigedDate.ToString(), radIssueDate.SelectedDate);
            xmlHash.Set(RewardField.EffectFrom.ToString(), radEffectFrom.SelectedDate);
            xmlHash.Set(RewardField.RewardForm.ToString(), drpForm.SelectedValue);
            xmlHash.Set(RewardField.Money.ToString(), txtFormValue.Text);
            xmlHash.Set(RewardField.MoneyUnit.ToString(), drpUnit.SelectedValue);
            xmlHash.Set(RewardField.IssuePerson.ToString(), txtIssuePerson.Text);
            xmlHash.Set(RewardField.Reason.ToString(), txtReason.Text);
            xmlHash.Set(RewardField.Comment.ToString(), txtComment.Text);
            xmlHash.Set(RewardField.IsActive.ToString(), chkIsActive.Checked.ToString());
            xmlHash.Set(RewardField.IssuedLevel.ToString(), drpIsueLevel.SelectedValue);

            FileViewTypeInfo[] info = new FileViewTypeInfo[0];
            string fileName = Utility.UploadFile(fphoto.PostedFile, info);
            if (!string.IsNullOrEmpty(fileName))
            {
                xmlHash.Set(RewardField.AttachFileUrl.ToString(), fileName);
                xmlHash.Set(RewardField.AttachFileName.ToString(),Path.GetFileName(fileName));
            }

            xmlHash.RootTag = ResourceDataContentType.StaffReward.ToString();
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
                txtIssuedId.Text = xmlhash.GetKeyFromHash(RewardField.IssueId.ToString());
                radIssueDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(RewardField.AssigedDate.ToString()));
                radEffectFrom.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(RewardField.EffectFrom.ToString()));
                drpForm.SelectedValue = xmlhash.GetKeyFromHash(RewardField.RewardForm.ToString());
                txtFormValue.Text = xmlhash.GetKeyFromHash(RewardField.Money.ToString());
                drpUnit.SelectedValue = xmlhash.GetKeyFromHash(RewardField.MoneyUnit.ToString());
                txtIssuePerson.Text = xmlhash.GetKeyFromHash(RewardField.IssuePerson.ToString());
                txtReason.Text = xmlhash.GetKeyFromHash(RewardField.Reason.ToString());
                txtComment.Text = xmlhash.GetKeyFromHash(RewardField.Comment.ToString());
                chkIsActive.Checked =Convert.ToBoolean(xmlhash.GetKeyFromHash(RewardField.IsActive.ToString()));
                drpIsueLevel.SelectedValue = xmlhash.GetKeyFromHash(RewardField.IssuedLevel.ToString());
                if (!string.IsNullOrEmpty(xmlhash.GetKeyFromHash(RewardField.AttachFileUrl.ToString())))
                {
                    string url =  Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, xmlhash.GetKeyFromHash(RewardField.AttachFileUrl.ToString()));
                    lnkAttachFile.HRef = url;
                    lnkAttachFile.InnerHtml = xmlhash.GetKeyFromHash(RewardField.AttachFileName.ToString());
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
