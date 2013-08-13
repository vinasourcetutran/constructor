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
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class SubItemList : System.Web.UI.UserControl
    {
        #region Properties
        public long ItemId { get; set; }
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
                RLM.Construction.Entities.ItemInItem itemData = (RLM.Construction.Entities.ItemInItem)e.Item.DataItem;


                RLM.Construction.Entities.Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(itemData.ToItemId);
                if (item == null) { return; }
                HtmlTableRow trChild = (HtmlTableRow)e.Item.FindControl("trChild");

                HtmlAnchor lnkName = (HtmlAnchor)e.Item.FindControl("lnkName");
                lnkName.InnerHtml=lnkName.Title = item.Name;
                lnkName.Attributes.Add("onclick",string.Format("UtilityHelper.toggle('{0}');return false;",trChild.ClientID));

                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(item.GroupId));
                if (group != null)
                {
                    Literal ltrGroup = (Literal)e.Item.FindControl("ltrGroup");
                    ltrGroup.Text = group.Name;
                }

                RLM.Construction.Entities.Unit qtyUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(itemData.UnitId));
                if (qtyUnit != null)
                {
                    Literal ltrUnit = (Literal)e.Item.FindControl("lblUnit");
                    ltrUnit.Text = qtyUnit.Name;
                }
                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = NumberHelper.GetValue<double>(itemData.Quantity).ToString();// string.Format("{0} / {1}", itemData.Quantity.ToString(), qtyUnitName);

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(itemData.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                //ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                //btnPreview.CommandArgument = itemData.ToItemId.ToString();

                AddNewRelatedItemLink lnkView = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreview");
                //lnkView.Text = item.Name;
                lnkView.Url = UrlBuilderHelper.GetUrl(item, NavigateAction.ClientView);
                lnkView.Title = string.Format("Item: {0}", item.Name);


                PlaceHolder childItem = (PlaceHolder)e.Item.FindControl("childItem");
                SubItemList control = (SubItemList)LoadControl("~/Page/Item/SubItemList.ascx");
                control.ItemId = itemData.ToItemId;
                childItem.Controls.Add(control);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void rptItems_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Preview")
            {
                long itemId = long.Parse(e.CommandArgument.ToString());
                Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Item() { ItemId=itemId},NavigateAction.View),true);
            }
        }
        #endregion

        #region Methods
        public void BindItems()
        {
            try
            {
                TList<RLM.Construction.Entities.ItemInItem> items = null;

                items = ServiceRepositoryHelper.ItemInItemServiceHelper.GetListByFromItemId(this.ItemId);
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