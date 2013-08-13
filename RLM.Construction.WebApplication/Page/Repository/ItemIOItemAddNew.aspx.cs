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

namespace RLM.Construction.WebApplication.Page.Repository
{
    public partial class ItemIOItemAddNew : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ItemIOItem item;
        int itemId;
        int ticketId = 0;
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
                Response.Redirect(UrlBuilderHelper.GetUrl(this.item, NavigateAction.List), true);
            }
            catch (Exception ex)
            {
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericSaveException, ex);
            }


        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.ItemIOItem() { IOTicketId = this.ticketId }, NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void Save()
        {
            
            if (this.item == null)
            {
                this.item = new RLM.Construction.Entities.ItemIOItem();
                this.item.CreationDate = DateTime.Now;
                this.item.CreationUserId = Utility.GetCurrentUserId();
                this.item.IsNeedAppred = false;
                this.item.ApprovedDate = DateTime.Now;
                this.item.IOType = (int)ItemIOTicketType.Input;
                this.item.IOTicketId = this.ticketId;
            }
            this.item.ItemId = int.Parse(drpItem.SelectedValue);

            ItemIOItem oldItem = ServiceRepositoryHelper.ItemIOItemServiceHelper.GetByTicketIdAndItemId(this.ticketId, this.item.ItemId);
            if (oldItem != null)
            {
                this.item = oldItem;
            }

            this.item.LastModificationDate = DateTime.Now;
            this.item.LastModificationUserId = Utility.GetCurrentUserId();

            
            this.item.Quantity = double.Parse(txtQuantity.Text)+this.item.Quantity;
            this.item.UnitId = int.Parse(drpUnitId.SelectedValue);
            this.item.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            this.item.PriceUnitId = int.Parse(drpPriceUnitId.SelectedValue);
            this.item.Comment = txtComment.Text;
            this.item.IsActive = Request.Params[chkIsActive.UniqueID] != null;

            

            if (this.item.ItemIOItemId > 0)
            {
                ServiceRepositoryHelper.ItemIOItemServiceHelper.Update(this.item);
            }
            else
            {
                ServiceRepositoryHelper.ItemIOItemServiceHelper.Insert(this.item);
            }
        }

        private void BindGuid()
        {
            legend.InnerHtml = GetLocalResourceObject(this.item == null ? "AddNewItem" : "UpdateItem").ToString();
            if (this.item == null) { return; }
            drpItem.Enabled = false;
            drpItem.SelectedValue = NumberHelper.GetValue<int>(this.item.ItemId).ToString();
            txtQuantity.Text =NumberHelper.GetValue<double>(item.Quantity).ToString();
            drpUnitId.SelectedValue = NumberHelper.GetValue<int>(this.item.UnitId).ToString();
            txtUnitPrice.Text =NumberHelper.GetValue<decimal>(this.item.UnitPrice).ToString();
            drpPriceUnitId.SelectedValue = NumberHelper.GetValue<int>(this.item.PriceUnitId).ToString();
            txtComment.Text = this.item.Comment;
            chkIsActive.Checked = NumberHelper.GetValue<bool>(this.item.IsActive);
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["TicketId"], out this.ticketId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.ItemIOItemServiceHelper.ItemIOItemId(this.itemId);
        }

        private void Validation()
        {
            validationManager.AddRule(
               new PatternMatchedRule(
                   txtQuantity,
                   Resources.ValidationRule.RequiredPattern,
                   Resources.ValidationRule.RequiredErrorMessage,
                   Resources.ValidationRule.RequiredErrorHint
               ));
            validationManager.AddRule(
               new PatternMatchedRule(
                   txtQuantity,
                   Resources.ValidationRule.DecimalPattern,
                   Resources.ValidationRule.DecimalErrorMessage,
                   Resources.ValidationRule.DecimalErrorHint
               ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtUnitPrice,
                    Resources.ValidationRule.RequiredPattern,
                    Resources.ValidationRule.RequiredErrorMessage,
                    Resources.ValidationRule.RequiredErrorHint
                ));
            validationManager.AddRule(
                new PatternMatchedRule(
                    txtUnitPrice,
                    Resources.ValidationRule.MoneyPattern,
                    Resources.ValidationRule.MoneyErrorMessage,
                    Resources.ValidationRule.MoneyErrorHint
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
