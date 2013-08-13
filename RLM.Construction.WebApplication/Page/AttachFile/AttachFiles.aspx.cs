using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.Entities;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.AttachFile
{
    public partial class AttachFiles : System.Web.UI.Page
    {
        #region Properties
        public ResourceType ResourceType { get; set; }
        public int ResourceId { get; set; }
        public string PageTitle { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (this.IsPostBack) { return; }

                GetInput();
                files.ResourceId = this.ResourceId;
                files.ResourceType = this.ResourceType;
                ltrResourceType.Text = Utility.GetEnumValue<ResourceType>(this.ResourceType);
                ltrPageTitle.Text = this.PageTitle;
                if (string.IsNullOrEmpty(this.PageTitle))
                {
                    ltrPageTitle.Text = Utility.GetResourceName(this.ResourceType, this.ResourceId);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
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
                FileViewTypeInfo[] info = new FileViewTypeInfo[] { 
                    new FileViewTypeInfo(){Type=FileViewType.Thumnail,Width=RLMConfiguration.Setting.ImageThumbnailWidth,Height=RLMConfiguration.Setting.ImageThumbnailHeight},
                    new FileViewTypeInfo(){Type=FileViewType.Big,Width=RLMConfiguration.Setting.ImageBigWidth,Height=RLMConfiguration.Setting.ImageBigHeight}
                };
                Utility.UploadFile(fFile.PostedFile, this.ResourceId, this.ResourceType,true,info);

                files.BindFiles();

                RLMContext.ErrorMessage = GetLocalResourceObject("FileUploadSuccess") as string;
                RLMContext.ErrorType = ErrorType.Info;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        private ErrorPair ValidatePostedFile()
        {
            ErrorPair error = new ErrorPair();
            error.ErrorType = ErrorType.Error;
            error.ErrorMessage = Resources.Common.GenericException;
            try
            {
                if (fFile.PostedFile == null || string.IsNullOrEmpty(fFile.PostedFile.FileName.Trim()) || fFile.PostedFile.ContentLength == 0)
                {
                    error.ErrorMessage = GetLocalResourceObject("InvalidFileUpload") as string;
                    error.ErrorType = ErrorType.Error;
                    return error;
                }

                if (!StringHelper.IsMatch(RLMConfiguration.Setting.FileUploadAllowedFileType, fFile.PostedFile.FileName))
                {
                    error.ErrorMessage = GetLocalResourceObject("InvalidFileUploadType") as string;
                    error.ErrorType = ErrorType.Error;
                    return error;
                }

                if (fFile.PostedFile.ContentLength > RLMConfiguration.Setting.FileUploadMaxSize * 1024)
                {
                    error.ErrorMessage =string.Format(GetLocalResourceObject("InvalidFileUploadSize") as string, RLMConfiguration.Setting.FileUploadMaxSize);
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
        #endregion

        #region Methods
        private void GetInput()
        {
            this.ResourceId=int.Parse(Request.Params["ResourceId"]);
            this.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType),Request.Params["ResourceType"]);
            this.PageTitle = Request.Params["PageTitle"];
        }
        #endregion
    }
}
