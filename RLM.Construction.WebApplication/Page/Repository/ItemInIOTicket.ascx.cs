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


namespace RLM.Construction.WebApplication.Page.Repository
{
    public partial class ItemInIOTicket : System.Web.UI.UserControl
    {
        #region Properties
        public int ItemIOTicketId { get; set; }
        public ItemIOTicket Item { get; set; }
        decimal footerTotal = 0;
        decimal footerTotalVnd = 0;
        double footerQuantity = 0;
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                this.Item = ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetByIOTicketId(this.ItemIOTicketId);
                lnkAddNew.HRef = UrlBuilderHelper.GetUrl(new ItemIOItem() { IOTicketId = this.ItemIOTicketId }, NavigateAction.AddNew);
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
                RLM.Construction.Entities.ItemIOItem itemData = (RLM.Construction.Entities.ItemIOItem)e.Item.DataItem;
                if (e.Item.ItemType == ListItemType.Header)
                {
                    if (this.Item.IOType == (int)ItemIOTicketType.Input)
                    {
                        Literal ltrRepositoryHeader = (Literal)e.Item.FindControl("ltrRepositoryHeader");
                        ltrRepositoryHeader.Text = GetLocalResourceObject("InputToRepository.Text") as string;
                    }
                    return;
                }
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    if (this.footerQuantity == 0)
                    {
                        HtmlTableRow trFooter = (HtmlTableRow)e.Item.FindControl("trFooter");
                        trFooter.Visible = false;
                    }
                    Literal ltrFooterQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                    ltrFooterQuantity.Text = this.footerQuantity.ToString();

                    Literal ltrFooterTotal = (Literal)e.Item.FindControl("ltrTotal");
                    ltrFooterTotal.Text = this.footerTotal.ToString(RLMConfiguration.Setting.MoneyFormat);

                    Literal ltrFooterTotalVND = (Literal)e.Item.FindControl("ltrTotalVND");
                    ltrFooterTotalVND.Text = this.footerTotalVnd.ToString(RLMConfiguration.Setting.MoneyFormat);
                    return;
                }
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                //RLM.Construction.Entities.ItemInProject itemData = (RLM.Construction.Entities.ItemInProject)e.Item.DataItem;

                RLM.Construction.Entities.Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(itemData.ItemId);
                if (item == null) { return; }

                HtmlAnchor lnkPhoto = (HtmlAnchor)e.Item.FindControl("lnkPhoto");
                lnkPhoto.Title = item.Name;
                lnkPhoto.HRef = UrlBuilderHelper.GetUrl(item, NavigateAction.OriginalFile);

                HtmlImage imgPhoto = (HtmlImage)e.Item.FindControl("imgPhoto");
                imgPhoto.Alt = item.Name;
                imgPhoto.Src = UrlBuilderHelper.GetUrl(item, NavigateAction.Thumnail);


                Literal ltrName = (Literal)e.Item.FindControl("ltrName");
                ltrName.Text = item.Name;

                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(item.GroupId));
                if (group != null)
                {
                    Literal ltrGroup = (Literal)e.Item.FindControl("ltrGroup");
                    ltrGroup.Text = group.Name;
                }


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
                this.footerTotal += total;
                this.footerQuantity += itemData.Quantity;

                double vndTranslateWeight = UnitTree.Translate(NumberHelper.GetValue<int>(itemData.PriceUnitId), RLMConfiguration.Setting.VndUnitId);
                total *= (decimal)vndTranslateWeight;
                Literal ltrTotalVND = (Literal)e.Item.FindControl("ltrTotalVND");
                ltrTotalVND.Text = total.ToString(RLMConfiguration.Setting.MoneyFormat);
                this.footerTotalVnd += total;

                int repositoryId = NumberHelper.GetValue<int>(itemData.FromRepositoryId);
                if (this.Item.IOType == (int)ItemIOTicketType.Input)
                {
                    repositoryId = NumberHelper.GetValue<int>(itemData.ToRepositoryId);
                }
                Group repository = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(repositoryId);
                if (repository != null)
                {
                    Literal ltrRepository = (Literal)e.Item.FindControl("ltrRepository");
                    ltrRepository.Text = repository.Name;
                }

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(itemData.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                AddNewRelatedItemLink lnkView = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
                lnkView.ResourceId = (int)item.ItemId;

                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                lnkEdit.HRef = UrlBuilderHelper.GetUrl(itemData, NavigateAction.Edit);
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
                TList<RLM.Construction.Entities.ItemIOItem> items = ServiceRepositoryHelper.ItemIOItemServiceHelper.GetByItemIOTicketId(this.ItemIOTicketId);
                //this.Visible = items.Count > 0;
                rptItems.DataSource = items;
                rptItems.DataBind();
                this.footerTotal = this.footerTotalVnd = 0;
                this.footerQuantity = 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion
    }
}