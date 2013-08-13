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


namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ItemInProjectList : System.Web.UI.UserControl
    {
        #region Properties
        public int ProjectPhaseId { get; set; }
        public int ProjectId { get; set; }
        public int ContractId { get; set; }
        public bool IsDetailItem { get; set; }
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
                RLM.Construction.Entities.ItemInProject itemData = (RLM.Construction.Entities.ItemInProject)e.Item.DataItem;
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    if (this.footerQuantity == 0)
                    {
                        HtmlTableRow trFooter = (HtmlTableRow)e.Item.FindControl("trFooter");
                        trFooter.Visible = false;
                    }
                    Literal ltrFooterQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                    ltrFooterQuantity.Text = this.footerQuantity.ToString();

                    //Literal ltrFooterTotal = (Literal)e.Item.FindControl("ltrTotal");
                    //ltrFooterTotal.Text = this.footerTotal.ToString(RLMConfiguration.Setting.MoneyFormat);

                    Literal ltrFooterTotalVND = (Literal)e.Item.FindControl("ltrTotalVND");
                    ltrFooterTotalVND.Text = this.footerTotalVnd.ToString(RLMConfiguration.Setting.MoneyFormat);
                }
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                //RLM.Construction.Entities.ItemInProject itemData = (RLM.Construction.Entities.ItemInProject)e.Item.DataItem;

                RLM.Construction.Entities.Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(itemData.ItemId);
                if (item == null) { return; }

                HtmlAnchor lnkName = (HtmlAnchor)e.Item.FindControl("lnkName");
                lnkName.InnerHtml = lnkName.Title = item.Name;

                HtmlTableRow trChild = (HtmlTableRow)e.Item.FindControl("trChild");

                lnkName.Attributes.Add("onclick", string.Format("UtilityHelper.toggle('{0}');return false;", trChild.ClientID));

                SubItemList subItemList = (SubItemList)e.Item.FindControl("subItemList");
                subItemList.ItemId = itemData.ItemId;

                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(item.GroupId));
                if (group != null)
                {
                    Literal ltrGroup = (Literal)e.Item.FindControl("ltrGroup");
                    ltrGroup.Text = group.Name;
                }
                string qtyUnitName = "(None)";
                RLM.Construction.Entities.Unit qtyUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.UsedUnitId));
                if (qtyUnit != null)
                {
                    qtyUnitName = qtyUnit.Name;
                }
                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = string.Format("{0} ({1})", itemData.Quantity.ToString(), qtyUnitName);

                string priceUnitName = "(None)";
                RLM.Construction.Entities.Unit priceUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(itemData.PriceUnitId));
                if (priceUnit != null)
                {
                    priceUnitName = priceUnit.Name;
                }

                decimal unitPrice = itemData.UnitPrice;
                Literal ltrUnitPrice = (Literal)e.Item.FindControl("ltrUnitPrice");
                ltrUnitPrice.Text = string.Format("{0} ({1})", unitPrice.ToString(RLMConfiguration.Setting.MoneyFormat), priceUnitName);

                int exchangeRate = NumberHelper.GetValue<int>(itemData.ExchangeRate);
                exchangeRate = exchangeRate > 0 ? exchangeRate : 1;
                Literal ltrExchangeRate = (Literal)e.Item.FindControl("ltrExchangeRate");
                ltrExchangeRate.Text = exchangeRate.ToString(RLMConfiguration.Setting.MoneyFormat);

                decimal total = (decimal)itemData.Quantity * itemData.UnitPrice;
                Literal ltrTotal = (Literal)e.Item.FindControl("ltrTotal");
                ltrTotal.Text = string.Format("{0} ({1})", total.ToString(RLMConfiguration.Setting.MoneyFormat), priceUnitName);
                this.footerTotal += total;
                this.footerQuantity += itemData.Quantity;

                //double vndTranslateWeight = UnitTree.Translate(NumberHelper.GetValue<int>(itemData.PriceUnitId), RLMConfiguration.Setting.VndUnitId);
                total *= (decimal)exchangeRate;
                Literal ltrTotalVND = (Literal)e.Item.FindControl("ltrTotalVND");
                ltrTotalVND.Text = total.ToString(RLMConfiguration.Setting.MoneyFormat);
                this.footerTotalVnd += total;

                HtmlGenericControl spIsActive = (HtmlGenericControl)e.Item.FindControl("spIsActive");
                spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(itemData.IsActive) ? "OK" : "NotOK");

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(itemData.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                AddNewRelatedItemLink lnkView = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
                //lnkView.Text = item.Name;
                //lnkView.Url = UrlBuilderHelper.GetUrl(item, NavigateAction.ClientView);
                //lnkView.Title = string.Format("Item: {0}",item.Name);
                lnkView.ResourceId = (int)item.ItemId;
                lnkView.ResourceType = ResourceType.Item;
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
                TList<RLM.Construction.Entities.ItemInProject> items = null;
                ResourceType resourceType = ResourceType.ProjectPhase;
                int resourceId = this.ProjectPhaseId;

                if (this.ProjectPhaseId > 0)
                {
                    resourceType = ResourceType.ProjectPhase;
                    resourceId = this.ProjectPhaseId;
                    //items = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByProjectPhaseId(this.ProjectPhaseId, ItemInProjectColumn.LastModificationDate.ToString() + " DESC");
                }
                else if (this.ProjectId > 0)
                {
                    resourceType = ResourceType.Project;
                    resourceId = this.ProjectId;
                    //items = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByProjectId(this.ProjectId);
                }
                else
                {
                    resourceType = ResourceType.Contract;
                    resourceId = this.ContractId;
                    //items = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByContractId(this.ContractId);
                }

                items = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByResource(resourceType, resourceId, this.IsDetailItem);
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