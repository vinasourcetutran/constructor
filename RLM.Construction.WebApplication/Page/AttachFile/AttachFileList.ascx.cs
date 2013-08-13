using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.Entities;
using System.Web.UI.HtmlControls;
using RLM.Construction.WebApplication.CommonLib;

namespace RLM.Construction.WebApplication.Page.AttachFile
{
    public partial class AttachFileList : System.Web.UI.UserControl
    {
        #region Properties
        public ViewMode ViewMode { get; set; }
        public ResourceType ResourceType { get; set; }

        public int ResourceId { get; set; }

        public bool IsShowAddNewFileLink { get; set; }

        public string  PageTitle { get; set; }

        public bool IsShowDeleteButton { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                lnkAddNewFile.Visible = IsShowAddNewFileLink;
                string addNewUrl = string.Format("Page/AttachFile/AttachFiles.aspx?ResourceId={0}&ResourceType={1}&PageTitle={2}",this.ResourceId, this.ResourceType,this.PageTitle);
                //lnkAddNewFile.ResourceId = this.ResourceId;
                lnkAddNewFile.ResourceType = RLM.Construction.Entities.ResourceType.AttachFile;
                lnkAddNewFile.Action = NavigateAction.AddNew;
                lnkAddNewFile.Url = addNewUrl;

                BindFiles();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void rptFiles_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName != "Delete") { return; }
                int fileId = int.Parse(e.CommandArgument.ToString());
                ServiceRepositoryHelper.AttachFileServiceHelper.Delete(fileId);

                RLMContext.ErrorType = ErrorType.Info;
                RLMContext.ErrorMessage = GetLocalResourceObject("DeleteAttachFileSuccess") as string;
                BindFiles();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
            }
        }

        protected void rptFiles_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                RLM.Construction.Entities.AttachFile file = (RLM.Construction.Entities.AttachFile)e.Item.DataItem;
                Literal ltrName = (Literal)e.Item.FindControl("ltrName");
                LinkButton lnkImage = (LinkButton)e.Item.FindControl("lnkImage");
                lnkImage.Attributes.Add("href",Page.ResolveUrl(ServiceRepositoryHelper.AttachFileServiceHelper.GetFilePath(file, FileViewType.Full)));
                lnkImage.ToolTip = file.Name;
                lnkImage.Attributes.Add("target","_blank");

                Image img=(Image)e.Item.FindControl("img");
                img.ImageUrl = ServiceRepositoryHelper.AttachFileServiceHelper.GetFilePath(file, FileViewType.Thumnail);
                img.AlternateText=file.Name;

                ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
                btnDelete.CommandArgument = file.AttachFileId.ToString();
                btnDelete.Visible = this.IsShowDeleteButton;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Methods
        public void BindFiles()
        {
            try
            {
                TList<RLM.Construction.Entities.AttachFile> items = ServiceRepositoryHelper.AttachFileServiceHelper.GetList(this.ResourceId, this.ResourceType);
                this.Visible = this.ViewMode != Entities.ViewMode.View || items.Count > 0;
                rptFiles.DataSource = items;
                rptFiles.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}