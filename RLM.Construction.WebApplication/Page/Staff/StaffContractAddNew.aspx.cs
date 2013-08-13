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
    public partial class StaffContractAddNew : System.Web.UI.Page
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
                radFromDate.SelectedDate = radToDate.SelectedDate =  DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffContract), true);

            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffContract), true);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            ServiceRepositoryHelper.ResourceDataServiceHelper.Delete(this.itemId);
            Response.Redirect(UrlBuilderHelper.GetUrl(new ResourceData() { ResourceId = this.staffId }, NavigateAction.List, ResourceDataContentType.StaffContract), true);
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
                this.item.ContentType = (int)ResourceDataContentType.StaffContract;
                this.item.IsActive = true;
            }


            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.SubContentType = int.Parse(drpType.SelectedValue);

            XmlHash xmlHash = new XmlHash(this.item.XMLContent);
            xmlHash.Set(ContractField.Type.ToString(), drpType.Text);
            xmlHash.Set(ContractField.FromDate.ToString(), radFromDate.SelectedDate);
            xmlHash.Set(ContractField.ToDate.ToString(), radToDate.SelectedDate);
            xmlHash.Set(ContractField.IsCurrentJob.ToString(), chkIsCurentJob.Checked.ToString());
            xmlHash.Set(ContractField.Comment.ToString(), txtComment.Text);

            FileViewTypeInfo[] info = new FileViewTypeInfo[0];
            string fileName = Utility.UploadFile(fContractFile.PostedFile, info);
            if (!string.IsNullOrEmpty(fileName))
            {
                xmlHash.Set(ContractField.ContractFile.ToString(), fileName);
                xmlHash.Set(ContractField.ContractFileName.ToString(), Path.GetFileName(fileName));
            }


            info = new FileViewTypeInfo[0];
            fileName = Utility.UploadFile(fJobDescriptionFile.PostedFile, info);
            if (!string.IsNullOrEmpty(fileName))
            {
                xmlHash.Set(ContractField.JobDescriptionFile.ToString(), fileName);
                xmlHash.Set(ContractField.JobDescriptionFileName.ToString(), Path.GetFileName(fileName));
            }
            xmlHash.RootTag = ResourceDataContentType.StaffContract.ToString();
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
                radFromDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(ContractField.FromDate.ToString()));
                radToDate.SelectedDate = DateTime.Parse(xmlhash.GetKeyFromHash(ContractField.ToDate.ToString()));
                chkIsCurentJob.Checked = Convert.ToBoolean(xmlhash.GetKeyFromHash(ContractField.IsCurrentJob.ToString()));

                if (!string.IsNullOrEmpty(xmlhash.GetKeyFromHash(ContractField.ContractFile.ToString())))
                {
                    string url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, xmlhash.GetKeyFromHash(ContractField.ContractFile.ToString()));
                    lnkContractFile.HRef = url;
                    lnkContractFile.InnerHtml = xmlhash.GetKeyFromHash(ContractField.ContractFileName.ToString());
                }

                if (!string.IsNullOrEmpty(xmlhash.GetKeyFromHash(ContractField.JobDescriptionFile.ToString())))
                {
                    string url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, xmlhash.GetKeyFromHash(ContractField.JobDescriptionFile.ToString()));
                    lnkJobDescriptionFile.HRef = url;
                    lnkJobDescriptionFile.InnerHtml = xmlhash.GetKeyFromHash(ContractField.JobDescriptionFileName.ToString());
                }

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
        }
        #endregion
    }
}
