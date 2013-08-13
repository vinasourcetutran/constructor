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
using System.IO;

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class ItemAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Item item;
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
                    //drpParent.DataSource = ServiceRepository.GroupService.GetByType(GroupType.Item);
                    //drpParent.DataBind();

                    //drpUsedUnit.DataSource = ServiceRepository.UnitService.GetAll();
                    //drpUsedUnit.DataBind();
                    BindGuid();
                }
               
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Page/Item/ItemList.aspx", true);
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
                Response.Redirect(UrlBuilderHelper.GetUrl(this.item,NavigateAction.View),true);
                //Response.Redirect("~/Page/Item/ItemList.aspx", true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }
           

        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                ServiceRepository.ItemService.Delete(this.itemId);
                Response.Redirect("~/Page/Item/ItemList.aspx", true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Item/ItemList.aspx", true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Item();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.LastComputeDate = DateTime.Now;
                this.item.IsDeletable = false;
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            item.Code = Request.Params[txtCode.UniqueID];
            item.Name = Request.Params[txtName.UniqueID];
            item.Description = Request.Params[txtDescription.UniqueID];
            item.IsActive = Request.Params[chkIsActive.UniqueID] != null;
            int parentId;
            if (int.TryParse(drpParent.SelectedValue, out parentId))
            {
                this.item.GroupId = parentId;
            }

            if (int.TryParse(drpUsedUnit.SelectedValue, out parentId))
            {
                this.item.UsedUnitId = parentId;
            }

            if (int.TryParse(drpBasedUnit.SelectedValue, out parentId))
            {
                this.item.BaseUnitId = parentId;
            }

            this.item.Density = float.Parse(txtRatio.Text);
            if (this.item.ItemId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ItemId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ItemService.Update(this.item);
            }
            else
            {
                ServiceRepository.ItemService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.ItemId.ToString().PadLeft(5, '0'); }
                ServiceRepository.ItemService.Update(this.item);
            }

            SavePhotoFile();
        }

        private void SavePhotoFile()
        {
            try
            {
                if (fphoto.PostedFile == null || string.IsNullOrEmpty(fphoto.PostedFile.FileName) || fphoto.PostedFile.ContentLength == 0) { return; }
                FileViewTypeInfo[] info = new FileViewTypeInfo[]{
                     new FileViewTypeInfo(){Type=FileViewType.Thumnail,Width=RLMConfiguration.Setting.ItemPhotoThumnailWidth,Height=RLMConfiguration.Setting.ItemPhotoThumnailHeight},
                     new FileViewTypeInfo(){Type=FileViewType.Big,Width=RLMConfiguration.Setting.ItemPhotoWidth,Height=RLMConfiguration.Setting.ItemPhotoHeight}
                };

                
                string fileName = Utility.UploadFile(fphoto.PostedFile, info);
                if (!string.IsNullOrEmpty(fileName))
                {
                    RLM.Construction.Entities.AttachFile currentFile = ServiceRepositoryHelper.AttachFileServiceHelper.GetByResource((int)this.item.ItemId, ResourceType.Item);
                    if (currentFile != null)
                    {
                        try
                        {
                            File.Delete(Path.Combine(MapPath(RLMConfiguration.Storage.AttachFileFolderUrl), currentFile.FilePath));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        currentFile = new RLM.Construction.Entities.AttachFile();
                        currentFile.CreationDate = DateTime.Now;
                        currentFile.CreationUserId = Utility.GetCurrentUserId();
                        currentFile.ResourceId = (int)this.item.ItemId;
                        currentFile.ResourceType = (int)ResourceType.Item;
                    }

                    currentFile.LastModificationDate = DateTime.Now;
                    currentFile.LastModificationUserId = Utility.GetCurrentUserId();
                    currentFile.FilePath = fileName;
                    currentFile.Name = Path.GetFileName(fileName);

                    if (currentFile.AttachFileId > 0)
                    {
                        ServiceRepositoryHelper.AttachFileServiceHelper.Update(currentFile);
                    }
                    else
                    {
                        ServiceRepositoryHelper.AttachFileServiceHelper.Insert(currentFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            //btnDelete.Visible = this.item != null && this.item.IsDeletable.HasValue && this.item.IsDeletable.Value;
            if (this.item == null) { return; }
            txtCode.Text = item.Code;
            txtName.Text = this.item.Name;
            txtDescription.Text = this.item.Description;
            chkIsActive.Checked = (bool)this.item.IsActive;
            spIsDeletable.Attributes.Add("Class", (bool)this.item.IsDeletable.HasValue && this.item.IsDeletable.Value ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            try
            {
                drpParent.SelectedValue = this.item.GroupId.ToString();
                drpBasedUnit.SelectedValue = this.item.BaseUnitId.ToString();
                drpUsedUnit.SelectedValue = this.item.UsedUnitId.ToString();
                txtRatio.Text = this.item.Density.ToString();
            }
            catch (Exception) { }

            RLM.Construction.Entities.AttachFile file = ServiceRepositoryHelper.AttachFileServiceHelper.GetByResource((int)this.item.ItemId,ResourceType.Item);
            if (file !=null)
            {
                string url = Path.Combine(RLMConfiguration.Storage.AttachFileFolderUrl, file.FilePath);
                lnkAttachFile.HRef = url;
                lnkAttachFile.InnerHtml =Path.GetFileName(file.FilePath);
            }

        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ItemService.GetByItemId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtCode,
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
                   txtRatio,
                   Resources.ValidationRule.NumberPattern,
                   Resources.ValidationRule.NumberErrorMessage,
                   Resources.ValidationRule.NumberErrorHint
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
