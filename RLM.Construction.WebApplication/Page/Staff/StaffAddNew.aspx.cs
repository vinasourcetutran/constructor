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
    public partial class StaffAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Staff item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();

                radBirthday.SelectedDate = radStartWorkingDate.SelectedDate = radWorkingDate.SelectedDate = DateTime.Now;
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
                ErrorPair error = ValidatePostedFile();
                if (error.ErrorType != ErrorType.None)
                {
                    RLMContext.ErrorMessage = error.ErrorMessage;
                    RLMContext.ErrorType = error.ErrorType;
                    return;
                }
                
                Save();
                //Response.Redirect(UrlBuilderHelper.GetUrl(this.item, NavigateAction.View), true);
                
            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (this.item == null)
            {
                Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Staff() { StaffId = 0 }, NavigateAction.List), true);
            }
            else
            {
                //Response.Redirect(UrlBuilderHelper.GetUrl(this.item, NavigateAction.View), true);
                Response.Redirect(string.Format("~/Page/Staff/StaffCommonInfo.aspx?ItemId={0}", this.itemId), true);
            }
            
        }
        #endregion

        #region Private methods
        private ErrorPair ValidatePostedFile()
        {
            ErrorPair error = new ErrorPair();
            if (fphoto == null || fphoto.PostedFile == null ||string.IsNullOrEmpty(fphoto.PostedFile.FileName) || fphoto.PostedFile.ContentLength<=0) { return error; }
            error.ErrorType = ErrorType.Error;
            error.ErrorMessage = Resources.Common.GenericException;
            try
            {
                if (string.IsNullOrEmpty(fphoto.PostedFile.FileName.Trim()) || fphoto.PostedFile.ContentLength == 0)
                {
                    error.ErrorMessage = GetLocalResourceObject("InvalidFileUpload") as string;
                    error.ErrorType = ErrorType.Error;
                    return error;
                }

                if (!StringHelper.IsMatch(RLMConfiguration.Setting.ImageFilePattern, fphoto.PostedFile.FileName))
                {
                    error.ErrorMessage = GetLocalResourceObject("InvalidFileUploadType") as string;
                    error.ErrorType = ErrorType.Error;
                    return error;
                }

                if (fphoto.PostedFile.ContentLength > RLMConfiguration.Setting.FileUploadMaxSize * 1024)
                {
                    error.ErrorMessage = string.Format(GetLocalResourceObject("InvalidFileUploadSize") as string, RLMConfiguration.Setting.FileUploadMaxSize);
                    error.ErrorType = ErrorType.Error;
                    return error;
                }
                error.ErrorType = ErrorType.None;
                error.ErrorMessage = string.Empty;
                return error;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return error;
        }

        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.Staff();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId=Utility.GetCurrentUserId();
            }
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.StaffCode = txtStaffCode.Text;// Request.Params[txtCode.UniqueID];
            this.item.FirstName = Request.Params[txtFullName.UniqueID];
            this.item.LastName = this.item.MiddleName = string.Empty;
            this.item.MagneticCardId=Request.Params[txtMagnetic.UniqueID];
            this.item.Sex = int.Parse(drpSex.SelectedValue);
            this.item.BirthDate = radBirthday.SelectedDate;
            this.item.BirthdayPlace = txtBirhtPlace.Text;
            this.item.BirthPlaceId = int.Parse(drpProvince.SelectedValue);
            this.item.PermanentAddress = txtPerAdress.Text;
            this.item.PermanentProvinceId = int.Parse(drpPerAddress.SelectedValue);
            this.item.CurrentAddress = txtTempAddress.Text;
            this.item.CurrentProvinceId = int.Parse(drpTempAddress.SelectedValue);
            this.item.PeopleId = int.Parse(drpPeople.SelectedValue);
            this.item.ReligiousId = int.Parse(drpReligous.SelectedValue);
            this.item.StartWorkingDate = radStartWorkingDate.SelectedDate;
            this.item.WorkingDate = radWorkingDate.SelectedDate;
            this.item.DeptId = int.Parse(drpDept.SelectedValue);
            this.item.JobTitleId = int.Parse(drpJobTitle.SelectedValue);
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;

            FileViewTypeInfo[] info = new FileViewTypeInfo[] { 
                    new FileViewTypeInfo(){Type=FileViewType.Thumnail,Width=RLMConfiguration.Setting.ImageThumbnailWidth,Height=RLMConfiguration.Setting.ImageThumbnailHeight},
                    new FileViewTypeInfo(){Type=FileViewType.Big,Width=RLMConfiguration.Setting.ImageBigWidth,Height=RLMConfiguration.Setting.ImageBigHeight}
                };
            string fileName = Utility.UploadFile(fphoto.PostedFile, info);
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(this.item.Photo))
            {
                string oldFile=Path.Combine(HttpContext.Current.Server.MapPath(RLMConfiguration.Storage.AttachFileFolderUrl), this.item.Photo);
                try
                {
                    File.Delete(oldFile);
                }
                catch (Exception)
                {
                }
                
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                this.item.Photo = fileName;
            }

            if (this.item.StaffId > 0)
            {
                ServiceRepositoryHelper.StaffServiceHelper.Update(this.item);
                Response.Redirect(string.Format("~/Page/Staff/StaffCommonInfo.aspx?ItemId={0}", this.itemId), true);
            }
            else
            {
                ServiceRepositoryHelper.StaffServiceHelper.Insert(this.item);
                Response.Redirect(UrlBuilderHelper.GetUrl(this.item, NavigateAction.View), true);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }

            txtStaffCode.Text = item.StaffCode;
            txtFullName.Text = this.item.FirstName;
            photo.ImageUrl = UrlBuilderHelper.GetUrl(this.item,NavigateAction.Thumnail);
            //fphoto.Attributes.Add("onchange","$('#"+photo.ClientID+"').attr('src',this.value);");

            txtMagnetic.Text = this.item.MagneticCardId;
            drpSex.SelectedValue = NumberHelper.GetValue<int>(this.item.Sex).ToString();
            radBirthday.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.BirthDate);
            txtBirhtPlace.Text = this.item.BirthdayPlace;
            drpProvince.SelectedValue = NumberHelper.GetValue<int>(this.item.ProvinceId).ToString();
            txtPerAdress.Text = this.item.PermanentAddress;
            drpPerAddress.SelectedValue = NumberHelper.GetValue<int>(this.item.PermanentProvinceId).ToString();
            txtTempAddress.Text = this.item.CurrentAddress;
            drpTempAddress.SelectedValue = NumberHelper.GetValue<int>(this.item.CurrentProvinceId).ToString();
            drpReligous.SelectedValue = NumberHelper.GetValue<int>(this.item.ReligiousId).ToString();
            drpPeople.SelectedValue = NumberHelper.GetValue<int>(this.item.PeopleId).ToString();
            radStartWorkingDate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.StartWorkingDate);
            radWorkingDate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.WorkingDate);
            drpDept.SelectedValue = NumberHelper.GetValue<int>(this.item.DeptId).ToString();
            drpJobTitle.SelectedValue = NumberHelper.GetValue<int>(this.item.JobTitleId).ToString();
            chkIsActive.Checked =NumberHelper.GetValue<bool>(this.item.IsActive);
            photo.ImageUrl = UrlBuilderHelper.GetUrl(this.item,NavigateAction.Thumnail);
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
               new PatternMatchedRule(
                   txtFullName,
                   Resources.ValidationRule.RequiredPattern,
                   Resources.ValidationRule.RequiredErrorMessage,
                   Resources.ValidationRule.RequiredErrorHint
               ));
            //validationManager.AddRule(
            //    new PatternMatchedRule(
            //        txtTempAddress,
            //        Resources.ValidationRule.RequiredPattern,
            //        Resources.ValidationRule.RequiredErrorMessage,
            //        Resources.ValidationRule.RequiredErrorHint
            //    ));
            //validationManager.AddRule(
            //    new PatternMatchedRule(
            //        txtPerAdress,
            //        Resources.ValidationRule.RequiredPattern,
            //        Resources.ValidationRule.RequiredErrorMessage,
            //        Resources.ValidationRule.RequiredErrorHint
            //    ));

            validationManager.Notifier = new BalloonNotifier();

            if (IsPostBack && !validationManager.Validate())
            {
                return;
            }
        }
        #endregion
    }
}
