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
using Telerik.Web.UI;

namespace RLM.Construction.WebApplication.Page.Repository
{
    public partial class ItemIOTicketAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ItemIOTicket item;
        int itemId;
        int relatedTicketId = 0;
        #endregion

        #region Event Handler
        protected void drpType_OnSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ItemIOTicketType type = (ItemIOTicketType)int.Parse(e.Value);
            rowReceiver.Visible = type == ItemIOTicketType.Output;
            rowSender.Visible = type == ItemIOTicketType.Input;
            rowFromRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Input;
            rowToRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Output;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Validation();
                LoadData();
                radIODate.SelectedDate  = DateTime.Now;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(this.item, NavigateAction.View), true);
            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
                Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.ItemIOTicket() { IOTicketId = 0 }, NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            //return;
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.ItemIOTicket();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsNeedApproved = false;
                this.item.ApprovedDate = DateTime.Now;
                this.item.IOType = int.Parse(drpType.SelectedValue);
            }
            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            this.item.UnitId = int.Parse(drpUnitId.SelectedValue);
            this.item.TotalAmount = decimal.Parse(txtTotalAmount.Text);
            this.item.RelatedTicketId = this.relatedTicketId;
            this.item.Name = txtName.Text;// Request.Params[txtCode.UniqueID];
            this.item.Receiver = txtReceiver.Text;
            this.item.Sender = txtSender.Text;
            int repositoryId;
            int.TryParse(drpFromRepository.SelectedValue, out repositoryId);
            this.item.FromRepositoryId = repositoryId;

            int.TryParse(drpToRepository.SelectedValue, out repositoryId);
            this.item.ToRepositoryId = repositoryId;

            this.item.StaffId = int.Parse(drpStaff.SelectedValue);
            this.item.ProjectId = int.Parse(drpProject.SelectedValue);
            this.item.IODate = radIODate.SelectedDate;
            this.item.TaxPercent = double.Parse(txtTax.Text);
            this.item.Comment = txtComment.Text;
            this.item.Status = int.Parse(drpStatus.SelectedValue);
            
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;

            if (this.item.IOTicketId > 0)
            {
                ServiceRepositoryHelper.ItemIOTicketServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.ItemIOTicketServiceHelper.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            drpType.Enabled = false;
            drpType.SelectedValue = NumberHelper.GetValue<int>(this.item.IOType).ToString();


            ItemIOTicketType type = (ItemIOTicketType)NumberHelper.GetValue<int>(this.item.IOType);
            rowReceiver.Visible = type == ItemIOTicketType.Output;
            rowSender.Visible = type == ItemIOTicketType.Input;
            rowFromRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Output;
            rowToRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Input;



            txtName.Text = item.Name;
            drpStaff.SelectedValue = this.item.StaffId.ToString();
            txtReceiver.Text = this.item.Receiver;
            txtSender.Text = this.item.Sender;
            drpFromRepository.SelectedValue = NumberHelper.GetValue<int>(this.item.FromRepositoryId).ToString();
            drpToRepository.SelectedValue = NumberHelper.GetValue<int>(this.item.ToRepositoryId).ToString();
            drpUnitId.SelectedValue = NumberHelper.GetValue<int>(this.item.UnitId).ToString();
            txtTotalAmount.Text = NumberHelper.GetValue<decimal>(this.item.TotalAmount).ToString();
            drpProject.SelectedValue = NumberHelper.GetValue<int>(this.item.ProjectId).ToString();
            radIODate.SelectedDate = NumberHelper.GetValue<DateTime>(this.item.IODate);
            txtTax.Text = NumberHelper.GetValue<double>(this.item.TaxPercent).ToString();
            txtComment.Text = this.item.Comment;
            drpStatus.SelectedValue = NumberHelper.GetValue<int>(this.item.Status).ToString();
            chkIsActive.Checked = NumberHelper.GetValue<bool>(this.item.IsActive);
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["RelatedTicketId"], out this.relatedTicketId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetByIOTicketId(this.itemId);
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
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtTax,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtTax,
                    Resources.ValidationRule.DecimalPattern,
                    Resources.ValidationRule.DecimalErrorMessage,
                    Resources.ValidationRule.DecimalErrorHint
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
