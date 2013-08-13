using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.Entities;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Log;
using RLM.Configuration;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Utility;
using System.Web.UI.HtmlControls;
using RLM.Core.Web.UI;

namespace RLM.Construction.WebApplication.Page.Task
{
    public partial class CommentList : System.Web.UI.UserControl
    {
        #region Variable
        bool allowPostComment = true;
        #endregion

        #region Properties
        public int ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }

        public bool AllowPostComment
        {
            get
            {
                return this.allowPostComment;
            } 
            set
            {
                this.allowPostComment = value;
            }
        }
        #endregion

        #region Event handler

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divCommentPostWrapper.Visible = this.AllowPostComment;
                pager.PageSize = RLMConfiguration.Setting.DefaultPageSize;
                radComment.EditModes = Telerik.Web.UI.EditModes.Design ^ Telerik.Web.UI.EditModes.Preview;
                if (this.IsPostBack) { return; }
                LoadData();
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
                RLMContext.ErrorType = ErrorType.Error;
            }
        }

        protected void rptItems_OnItemDatabound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                if (e.Item.ItemIndex == 0)
                {
                    HtmlTableRow trrow = (HtmlTableRow)e.Item.FindControl("trrow");
                    trrow.Attributes.Add("class", "TableListFirstRow");
                }

                Comment item = (Comment)e.Item.DataItem;

                RLM.Construction.Entities.Staff staff = ServiceRepositoryHelper.StaffServiceHelper.GetByStaffId(NumberHelper.GetValue<int>(item.CreationUserId));

                if (staff == null) { return; }

                HtmlAnchor lnkStaff = (HtmlAnchor)e.Item.FindControl("lnkStaffInfo");
                lnkStaff.Attributes.Add("url", UrlBuilderHelper.GetUrl(staff,NavigateAction.ClientView));
                lnkStaff.Title = "Staff: " + staff.FirstName;

                HtmlImage imgPhoto = (HtmlImage)e.Item.FindControl("imgStaffPhoto");
                imgPhoto.Alt = staff.FullName;
                imgPhoto.Src = UrlBuilderHelper.GetUrl(staff,NavigateAction.Thumnail);

                HtmlAnchor lnkStaffName = (HtmlAnchor)e.Item.FindControl("lnkStaffName");
                lnkStaffName.Attributes.Add("url", UrlBuilderHelper.GetUrl(staff, NavigateAction.ClientView));
                lnkStaffName.Title = "Staff: " + staff.FirstName;
                lnkStaffName.InnerHtml = staff.FirstName;

                Literal ltrDate = (Literal)e.Item.FindControl("ltrDate");
                ltrDate.Text = NumberHelper.GetValue<DateTime>(item.CreationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                Literal ltrCommentContent = (Literal)e.Item.FindControl("ltrCommentContent");
                ltrCommentContent.Text = item.Content;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }


        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            try
            {
                Comment comment = new Comment();
                comment.CreationUserId = Utility.GetCurrentUserId();
                comment.CreationDate = DateTime.Now;
                comment.ResourceId = this.ResourceId;
                comment.ResourceType = (int)this.ResourceType;
                comment.Content = radComment.Content;

                ServiceRepositoryHelper.CommentServiceHelper.Insert(comment);

                LoadData();

                radComment.Content = string.Empty;
            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                RLMContext.ErrorType = RLM.Construction.Entities.ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }
        }

        #endregion

        #region Private
        private void LoadData()
        {
            int totalRecords = 0;
            TList<Comment> items = ServiceRepositoryHelper.CommentServiceHelper.GetByResource(this.ResourceType, this.ResourceId, CommentColumn.CreationDate + " " + OrderDirection.DESC, pager.PageIndex, pager.PageSize, out totalRecords);
            rptItems.DataSource = items;
            rptItems.DataBind();
            pager.TotalRecords = totalRecords;
        }
        #endregion
    }
}