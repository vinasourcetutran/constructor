using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Configuration;
using System.Web.UI.HtmlControls;
using RLM.Construction.Services;
using RLM.Construction.WebApplication.Page.Item;
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class ItemIO : System.Web.UI.UserControl
    {
        #region Properties
        public int ItemId { get; set; }
        public ItemIOTicketType Type;
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                BindItems();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void rptItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                RLM.Construction.Entities.ItemIOItem itemData = (RLM.Construction.Entities.ItemIOItem)e.Item.DataItem;

                AddNewRelatedItemLink lnkTicket = (AddNewRelatedItemLink)e.Item.FindControl("lnkTicket");
                lnkTicket.ResourceId = itemData.IOTicketId;

                ItemIOTicket ticket=ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetByIOTicketId(itemData.IOTicketId);
                AddNewRelatedItemLink lnkReceiver = (AddNewRelatedItemLink)e.Item.FindControl("lnkReceiver");
                AddNewRelatedItemLink lnkSender = (AddNewRelatedItemLink)e.Item.FindControl("lnkSender");
                Literal ltrSender = (Literal)e.Item.FindControl("ltrSender");
                Literal ltrReceiver = (Literal)e.Item.FindControl("ltrReceiver");
                HtmlTableCell tdToRepository = (HtmlTableCell)e.Item.FindControl("tdToRepository");
                HtmlTableCell tdFromRepository = (HtmlTableCell)e.Item.FindControl("tdFromRepository");
                Literal ltrFromRepository = (Literal)e.Item.FindControl("ltrFromRepository");
                Literal ltrToRepository = (Literal)e.Item.FindControl("ltrToRepository");

                if (this.Type == ItemIOTicketType.Input)
                {
                    lnkReceiver.ResourceId = ticket.StaffId;
                    ltrSender.Text = ticket.Sender;
                    tdToRepository.Visible = true;
                }
                if (this.Type == ItemIOTicketType.Output)
                {
                    lnkSender.ResourceId = ticket.StaffId;
                    ltrReceiver.Text = ticket.Receiver;
                    tdFromRepository.Visible = true;
                }
                if (this.Type == ItemIOTicketType.Movement)
                {
                    lnkReceiver.ResourceId =NumberHelper.GetValue<int>(ticket.ToStaffId);
                    lnkSender.ResourceId = NumberHelper.GetValue<int>(ticket.FromStaffId);
                    tdFromRepository.Visible = true;
                    tdToRepository.Visible = true;
                }

                Group repository = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(ticket.ToRepositoryId));
                if (repository != null)
                {
                    ltrToRepository.Text = repository.Name;
                }
                repository = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(ticket.FromRepositoryId));
                if (repository != null)
                {
                    ltrFromRepository.Text = repository.Name;
                }


                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<ItemIOTicketStatus>((ItemIOTicketStatus)NumberHelper.GetValue<int>(ticket.Status));

                string qtyUnitName = "(None)";
                RLM.Construction.Entities.Unit qtyUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(itemData.UnitId));
                if (qtyUnit != null)
                {
                    qtyUnitName = qtyUnit.Name;
                }
                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = string.Format("{0} / {1}", itemData.Quantity.ToString(), qtyUnitName);

                string priceUnitName = "(None)";
                RLM.Construction.Entities.Unit priceUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(itemData.PriceUnitId));
                if (priceUnit != null)
                {
                    priceUnitName = priceUnit.Name;
                }
                Literal ltrUnitPrice = (Literal)e.Item.FindControl("ltrUnitPrice");
                ltrUnitPrice.Text = string.Format("{0} / {1}", itemData.UnitPrice.ToString(RLMConfiguration.Setting.MoneyFormat), priceUnitName);

                decimal total = (decimal)itemData.Quantity * itemData.UnitPrice;
                Literal ltrTotal = (Literal)e.Item.FindControl("ltrTotal");
                ltrTotal.Text = string.Format("{0} ({1})", total.ToString(RLMConfiguration.Setting.MoneyFormat), priceUnitName);

                double vndTranslateWeight = UnitTree.Translate(NumberHelper.GetValue<int>(itemData.PriceUnitId), RLMConfiguration.Setting.VndUnitId);
                total *= (decimal)vndTranslateWeight;
                Literal ltrTotalVND = (Literal)e.Item.FindControl("ltrTotalVND");
                ltrTotalVND.Text = total.ToString(RLMConfiguration.Setting.MoneyFormat);

                

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(ticket.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Methods
        public void BindItems()
        {
            try
            {
                int total;
                TList<RLM.Construction.Entities.ItemIOItem> items = ServiceRepositoryHelper.ItemIOItemServiceHelper.GetByItemIdAndType(this.ItemId, this.Type,0,0, out total);
                rptItems.DataSource = items;
                rptItems.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}