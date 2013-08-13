using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Configuration;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.UserControl
{
    public partial class GroupAddNew : System.Web.UI.UserControl
    {
        #region Variables
        Group item;
        int itemId;
        #endregion

        #region Properties
        public bool IsShowParentGroup { get; set; }

        public GroupType GroupType { get; set; }

        public GroupType ParentGroupType { get; set; }

        public string GroupListUrl { get; set; }
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
                    //BindParentCategory();
                    drpParent.Type = this.ParentGroupType;
                    drpParent.ReBindData();
                    BindGuid();
                }
                
            }
            catch (Exception ex)
            {
                //Response.Redirect(this.GetGroupListUrl(),true);
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
                Response.Redirect(this.GetGroupListUrl(), true);
            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
                Logger.Error(ex);
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                ServiceRepository.GroupService.Delete(this.itemId);
                Response.Redirect(this.GetGroupListUrl(), true);

            }
            catch (Exception ex)
            {
                RLMContext.Error = ex;
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericDeleteException;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.GetGroupListUrl(), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new Group();
                this.item.CreationDate = DateTime.Now;
                this.item.Type = (int)this.GroupType;
                this.item.IsDeletable = true;
                this.item.ParentGroupId = 0;
            }
            this.item.LastModificationDate = DateTime.Now;
            item.Code = Request.Params[txtCode.UniqueID];
            item.Name = Request.Params[txtName.UniqueID];
            item.Description = Request.Params[txtDescription.UniqueID];
            item.IsActive = Request.Params[chkIsActive.UniqueID]!=null;
            if (this.IsShowParentGroup)
            {
                this.item.ParentGroupId = int.Parse(drpParent.SelectedValue);
            }
            if (this.item.GroupId > 0)
            {
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.GroupId.ToString().PadLeft(5, '0'); }
                ServiceRepository.GroupService.Update(this.item);
            }
            else
            {
                ServiceRepository.GroupService.Insert(this.item);
                if (string.IsNullOrEmpty(this.item.Code)) { this.item.Code = this.item.GroupId.ToString().PadLeft(5, '0'); }
                ServiceRepository.GroupService.Update(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item==null?"AddNewGroup":"UpdateGroup").ToString();
            divParentId.Visible = this.IsShowParentGroup;
            btnDelete.Visible = this.item != null && (bool)this.item.IsDeletable;
            if (this.item == null) { return; }
            btnCancel.Visible = true;
            txtCode.Text = item.Code;
            txtName.Text = this.item.Name;
            txtDescription.Text = this.item.Description;
            chkIsActive.Checked = (bool)this.item.IsActive;
            spIsDeletable.Attributes.Add("Class",(bool)this.item.IsDeletable?"OK":"NotOK");
            drpParent.SelectedValue = NumberHelper.GetValue<int>(this.item.ParentGroupId).ToString();
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            if (this.IsShowParentGroup)
            {
                drpParent.SelectedValue = this.item.ParentGroupId.ToString();
            }
        }

        private void BindParentCategory()
        {
            //string whereClause = "([ParentGroupId] IS NULL OR [ParentGroupId]=0) AND [GroupId]<>"+this.itemId;
            //int total;
            //drpParent.DataSource = ServiceRepository.GroupService.GetPaged(whereClause,GroupColumn.Name +" ASC",0,0,out total);
            //drpParent.DataBind();
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.GroupService.GetByGroupId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtName,
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

        private string GetGroupListUrl()
        {
            if (!string.IsNullOrEmpty(this.GroupListUrl)) { return this.GroupListUrl; }
            return string.Format("~/Page/{0}/CategoryList.aspx", this.GroupType.ToString());
        }
        #endregion
    }
}