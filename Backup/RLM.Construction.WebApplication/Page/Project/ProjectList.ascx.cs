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


namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectList1 : System.Web.UI.UserControl
    {
        #region Properties
        public int PatnerId { get; set; }
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
                RLM.Construction.Entities.Project item = (RLM.Construction.Entities.Project)e.Item.DataItem;


                Literal ltrName = (Literal)e.Item.FindControl("ltrName");
                ltrName.Text = item.Name;

                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(item.GroupId);
                if (group != null)
                {
                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    ltrGroupName.Text = group.Name;
                }

                string unitName = "(None)";
                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.CurrencyUnitId));
                if (unit != null)
                {
                    Literal ltrCurrencyUnit = (Literal)e.Item.FindControl("ltrCurrencyUnit");
                    unitName = ltrCurrencyUnit.Text = unit.Name;
                }

                int exchangeRate = NumberHelper.GetValue<int>(item.ExchangeRate);
                exchangeRate = exchangeRate > 0 ? exchangeRate : 1;
                Literal ltrExchangeRate = (Literal)e.Item.FindControl("ltrExchangeRate");
                ltrExchangeRate.Text = exchangeRate.ToString(RLMConfiguration.Setting.MoneyFormat);

                Decimal designedPrice = NumberHelper.GetValue<decimal>(item.DesignedPrice);
                Literal ltrDesignedPrice = (Literal)e.Item.FindControl("ltrDesignedPrice");
                ltrDesignedPrice.Text =string.Format(
                        "{0} {1} ({2} VND)",
                        designedPrice.ToString(RLMConfiguration.Setting.MoneyFormat),
                        unitName,
                        (exchangeRate*designedPrice).ToString(RLMConfiguration.Setting.MoneyFormat)
                    );

                decimal actualPrice = NumberHelper.GetValue<decimal>(item.AuctualPrice);
                Literal ltrActualPrice = (Literal)e.Item.FindControl("ltrActualPrice");
                ltrActualPrice.Text =string.Format( 
                        "{0} {1} ({2} VND)",
                        actualPrice.ToString(RLMConfiguration.Setting.MoneyFormat),
                        unitName,
                        (actualPrice*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                    );

                

                ProjectPhase currentPhase = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetCurrentPhaseByProjectId(item.ProjectId);
                if (currentPhase != null)
                {
                    RLM.Construction.WebApplication.UserControl.AddNewRelatedItemLink lnkProjectPhase = (RLM.Construction.WebApplication.UserControl.AddNewRelatedItemLink)e.Item.FindControl("lnkProjectPhase");
                    lnkProjectPhase.Title = lnkProjectPhase.Text = currentPhase.Name;
                    lnkProjectPhase.Url = UrlBuilderHelper.GetUrl(currentPhase,NavigateAction.ClientView);
                }


                HtmlGenericControl spIsAtive = (HtmlGenericControl)e.Item.FindControl("spIsActive");
                spIsAtive.Attributes.Add("class", NumberHelper.GetValue<bool>(item.IsActive) ? "OK" : "NotOK");

                Literal ltrLastModificationDate = (Literal)e.Item.FindControl("ltrLastModificationDate");
                ltrLastModificationDate.Text = NumberHelper.GetValue<DateTime>(item.LastModificationDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

                ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                btnPreview.Attributes.Add("url", UrlBuilderHelper.GetUrl(item,NavigateAction.ClientView));
                btnPreview.Attributes.Add("title", item.Name);
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
                TList<RLM.Construction.Entities.Project> items = null;
                if (this.PatnerId > 0)
                {
                    items = ServiceRepositoryHelper.ProjectServiceHelper.GetByPartnerId(this.PatnerId,ProjectColumn.LastModificationDate.ToString()+" DESC");
                }
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