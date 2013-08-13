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
    public partial class ItemIOTicketView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.ItemIOTicket item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (!this.IsPostBack)
                {
                    itemInTicket.ItemIOTicketId = this.itemId;
                    BindGuid();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Utility.ShowMessage(ErrorType.Error, Resources.Common.GenericException, ex);
            }
        }
        protected void btnList_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.ItemIOTicket() { IOTicketId = 0 }, NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            ltrType.Text = Utility.GetEnumValue<ItemIOTicketType>((ItemIOTicketType)NumberHelper.GetValue<int>(this.item.IOType));
            ltrName.Text = item.Name;
            lnkStaff.ResourceId = this.item.StaffId;
            ltrReceiver.Text = this.item.Receiver;
            ltrSender.Text = this.item.Sender;
            lnkProject.ResourceId = NumberHelper.GetValue<int>(this.item.ProjectId);
            ltrIODate.Text = NumberHelper.GetValue<DateTime>(this.item.IODate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            ltrTax.Text = NumberHelper.GetValue<double>(this.item.TaxPercent).ToString();

            RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(this.item.UnitId));
            ltrTotalAmount.Text = string.Format("{0} ({1})", NumberHelper.GetValue<decimal>(this.item.TotalAmount).ToString(RLMConfiguration.Setting.MoneyFormat), unit.Name);

            Group repository = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.FromRepositoryId));
            if (repository != null)
            {
                ltrFromRepository.Text = repository.Name;
            }

            repository = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.ToRepositoryId));
            if (repository != null)
            {
                ltrToRepository.Text = repository.Name;
            }

            ltrComment.Text = this.item.Comment;
            ltrStatus.Text = Utility.GetEnumValue<ItemIOTicketStatus>((ItemIOTicketStatus)NumberHelper.GetValue<int>(this.item.Status));
            if (NumberHelper.GetValue<bool>(this.item.IsActive))
            {
                spIsActive.Attributes.Add("class","OK");
            }
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = this.item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }

            ItemIOTicketType type = (ItemIOTicketType)NumberHelper.GetValue<int>(this.item.IOType);
            rowReceiver.Visible = type == ItemIOTicketType.Output;
            rowSender.Visible = type == ItemIOTicketType.Input;
            rowFromRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Output;
            rowToRepository.Visible = type == ItemIOTicketType.Movement || type == ItemIOTicketType.Input;
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetByIOTicketId(this.itemId);
        }
        #endregion
    }
}
