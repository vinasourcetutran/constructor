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
    public partial class ProjectPhaseList1 : System.Web.UI.UserControl
    {
        #region Properties
        public int ProjectId { get; set; }

        public int ContractId { get; set; }

        public bool IsShowAddNewLink { get; set; }

        public string PageTitle { get; set; }

        public string IgnoreId { get; set; }

        public string TitleResourceKey { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
                lnkAddNew.Visible = this.IsShowAddNewLink;
                string addNewUrl = string.Format("Page/Project/ProjectPhaseAddNew.aspx?ProjectId={0}", this.ProjectId);
                lnkAddNew.Url = addNewUrl;
                BindItems();
                if (!string.IsNullOrEmpty(this.TitleResourceKey))
                {
                    legend.InnerHtml = GetLocalResourceObject(this.TitleResourceKey) as string;
                }
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
                RLM.Construction.Entities.ProjectPhase item = (RLM.Construction.Entities.ProjectPhase)e.Item.DataItem;


                HtmlAnchor lnkName = (HtmlAnchor)e.Item.FindControl("lnkName");
                lnkName.InnerHtml = lnkName.Title = item.Name;
                HtmlTableRow itemsWrapperId = (HtmlTableRow)e.Item.FindControl("itemsWrapperId");
                lnkName.Attributes.Add("onclick", string.Format("UtilityHelper.toggle('{0}');return false;", itemsWrapperId.ClientID));

                string unitName = "(None)";
                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.CurrencyUnitId));
                if (unit != null)
                {
                    Literal ltrCurrencyUnit = (Literal)e.Item.FindControl("ltrCurrencyUnit");
                    unitName = ltrCurrencyUnit.Text = unit.Name;
                }

                RLM.Construction.Entities.Project project = ServiceRepositoryHelper.ProjectServiceHelper.GetByProjectId(NumberHelper.GetValue<int>(item.ProjectId));
                if(project!=null)
                {
                    Literal ltrProject = (Literal)e.Item.FindControl("ltrProject");
                    ltrProject.Text = project.Name;
                }

                int exchangeRate = NumberHelper.GetValue<int>(item.ExchangeRate);
                exchangeRate = exchangeRate > 0 ? exchangeRate : 1;
                Literal ltrExchangeRate = (Literal)e.Item.FindControl("ltrExchangeRate");
                ltrExchangeRate.Text = exchangeRate.ToString(RLMConfiguration.Setting.MoneyFormat);

                decimal designedPrice = NumberHelper.GetValue<decimal>(item.DesignPrice);
                decimal actualPrice = NumberHelper.GetValue<decimal>(item.AuctualPrice);

                Literal ltrDesignedPrice = (Literal)e.Item.FindControl("ltrDesignedPrice");
                ltrDesignedPrice.Text = string.Format(
                    "{0} {1} ({2} VND)",
                    designedPrice.ToString(RLMConfiguration.Setting.MoneyFormat),
                    unitName,
                    (designedPrice*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                    );

                Literal ltrActualPrice = (Literal)e.Item.FindControl("ltrActualPrice");
                ltrActualPrice.Text = string.Format(
                    "{0} {1} ({2} VND)",
                    actualPrice.ToString(RLMConfiguration.Setting.MoneyFormat),
                    unitName,
                    (actualPrice * exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                    );
                

                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<ProjectPhaseStatus>((ProjectPhaseStatus)item.Status);

                HtmlGenericControl spIsBillable = (HtmlGenericControl)e.Item.FindControl("spIsBillable");
                spIsBillable.Attributes.Add("class", NumberHelper.GetValue<bool>(item.IsBillable) ? "OK" : "NotOK");

                HtmlGenericControl spIsAtive = (HtmlGenericControl)e.Item.FindControl("spIsActive");
                spIsAtive.Attributes.Add("class", NumberHelper.GetValue<bool>(item.IsActive) ? "OK" : "NotOK");

                HtmlGenericControl spIsApprove = (HtmlGenericControl)e.Item.FindControl("spIsApprove");
                spIsApprove.Attributes.Add("class", NumberHelper.GetValue<bool>(item.IsApprove) ? "OK" : "NotOK");

                Literal ltrFromDate = (Literal)e.Item.FindControl("ltrFromDate");
                ltrFromDate.Text = NumberHelper.GetValue<DateTime>(item.FromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                ImageButton btnPreview = (ImageButton)e.Item.FindControl("btnPreview");
                string url = string.Format("Page/Project/ProjectPhaseView.aspx?itemId={0}", item.ProjectPhaseId);
                btnPreview.Attributes.Add("url", url);
                btnPreview.Attributes.Add("title", item.Name as string);

                ItemInProjectList items = (ItemInProjectList)e.Item.FindControl("items");
                items.ProjectPhaseId = item.ProjectPhaseId;
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
                TList<RLM.Construction.Entities.ProjectPhase> items = null;
                if (this.ProjectId > 0)
                {
                    items = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetByProjectId(this.ProjectId,this.IgnoreId);
                }
                else if (this.ContractId > 0)
                {
                    items = items = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetByContractId(this.ContractId,this.IgnoreId);
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