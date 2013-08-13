using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.WebApplication.UserControl;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectPhaseCompare : System.Web.UI.Page
    {
        #region Properties
        public int FromProjectPhaseId { get; set; }

        public int FromProjectId { get; set; }

        public int ToProjectPhaseId { get; set; }

        public int ToProjectId { get; set; }
        #endregion

        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnProject_OnChangeSelectedIndex(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int projectId = int.Parse(e.Value);
            drpProjectPhase.ProjectId = projectId;
            drpProjectPhase.Bind();
        }

        protected void btnCompare_OnClick(object sender, EventArgs e)
        {
            try
            {
                int toProjectPhaseId;
                int toProjectId;
                if (!int.TryParse(drpProjectPhase.SelectedValue, out toProjectPhaseId) || !int.TryParse(drpProject.SelectedValue, out toProjectId))
                {
                    RLMContext.ErrorType = ErrorType.Error;
                    RLMContext.ErrorMessage = GetLocalResourceObject("InvalidProjectPhaseId") as string;
                    return;
                }
                this.ToProjectPhaseId = toProjectPhaseId;
                this.ToProjectId = toProjectId;
                TList<RLM.Construction.Entities.Item> items = ServiceRepositoryHelper.ItemServiceHelper.GetByProjectPhaseIds(string.Format("{0},{1}", this.FromProjectPhaseId, this.ToProjectPhaseId));
                rptItems.DataSource = items;
                rptItems.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void rptItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Header)
                {
                    AddNewRelatedItemLink lnkFromProjectPhase = (AddNewRelatedItemLink)e.Item.FindControl("lnkFromProjectPhase");
                    lnkFromProjectPhase.ResourceId = this.FromProjectPhaseId;

                    AddNewRelatedItemLink lnkToProjectPhase = (AddNewRelatedItemLink)e.Item.FindControl("lnkToProjectPhase");
                    lnkToProjectPhase.ResourceId = this.ToProjectPhaseId;
                    return;
                }
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }
                RLM.Construction.Entities.Item dataItem = (RLM.Construction.Entities.Item)e.Item.DataItem;

                RLM.Construction.WebApplication.UserControl.AddNewRelatedItemLink lnkItem = (RLM.Construction.WebApplication.UserControl.AddNewRelatedItemLink)e.Item.FindControl("lnkItem");
                lnkItem.ResourceId = (int)dataItem.ItemId;

                ItemInProject fromItem = null;
                fromItem = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByItemIdAndProjectPhaseId(dataItem.ItemId, this.FromProjectPhaseId);
                fromItem = fromItem != null && NumberHelper.GetValue<bool>(fromItem.IsActive) ? fromItem : null;

                ItemInProject toItem = null;
                toItem = ServiceRepositoryHelper.ItemInProjectServiceHelper.GetByItemIdAndProjectPhaseId(dataItem.ItemId, this.ToProjectPhaseId);
                toItem = toItem != null && NumberHelper.GetValue<bool>(toItem.IsActive) ? toItem : null;


                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.UsedUnitId));
                string unitName = "None";
                if (unit != null)
                {
                    unitName = unit.Name;
                }

                decimal fromTotal = 0;
                decimal fromTotalVND = 0;
                double fromQuantity = 0;
                int fromUnitId = 0;
                decimal fromUnitPriceValue = 0;
                RLM.Construction.Entities.Unit fromUnitPrice=null;
                if (fromItem != null)
                {
                    fromQuantity = fromItem.Quantity;
                    Literal ltrFromQuantity = (Literal)e.Item.FindControl("ltrFromQuantity");
                    ltrFromQuantity.Text = string.Format("{0} ({1})", fromItem.Quantity, unitName);

                    fromUnitPrice = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(fromItem.PriceUnitId));
                    Literal ltrFromUnitPrice = (Literal)e.Item.FindControl("ltrFromUnitPrice");
                    ltrFromUnitPrice.Text = string.Format("{0} ({1})", fromItem.UnitPrice.ToString(RLMConfiguration.Setting.MoneyFormat), fromUnitPrice != null ? fromUnitPrice.Name : "(None)");
                    fromUnitPriceValue = NumberHelper.GetValue<decimal>(fromItem.UnitPrice);

                    fromTotal = (decimal)fromItem.Quantity * NumberHelper.GetValue<decimal>(fromItem.UnitPrice);
                    Literal ltrFromTotal = (Literal)e.Item.FindControl("ltrFromTotal");
                    ltrFromTotal.Text = string.Format("{0} ({1})", fromTotal.ToString(RLMConfiguration.Setting.MoneyFormat), fromUnitPrice != null ? fromUnitPrice.Name : "(None)");

                    int fromExchangeRate = NumberHelper.GetValue<int>(fromItem.ExchangeRate);
                    fromExchangeRate = fromExchangeRate > 0 ? fromExchangeRate : 1;

                    fromTotalVND = (decimal)fromExchangeRate * fromTotal;
                    Literal ltrFromTotalVND = (Literal)e.Item.FindControl("ltrFromTotalVND");
                    ltrFromTotalVND.Text = fromTotalVND.ToString(RLMConfiguration.Setting.MoneyFormat);
                    fromQuantity = fromItem.Quantity;
                    fromUnitId = fromUnitPrice.UnitId;
                }

                decimal toTotal = 0;
                decimal toTotalVND = 0;
                double toQuatity = 0;
                int toUnitId = 0;
                string toUnitName = "None";
                decimal toUnitPriceValue = 0;
                RLM.Construction.Entities.Unit toUnitPrice=null;
                if (toItem != null)
                {
                    toQuatity = toItem.Quantity;
                    Literal ltrToQuantity = (Literal)e.Item.FindControl("ltrToQuantity");
                    ltrToQuantity.Text = string.Format("{0} ({1})", toItem.Quantity, unitName);

                    toUnitPrice = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(toItem.PriceUnitId));
                    Literal ltrToUnitPrice = (Literal)e.Item.FindControl("ltrToUnitPrice");
                    ltrToUnitPrice.Text = string.Format("{0} ({1})", toItem.UnitPrice.ToString(RLMConfiguration.Setting.MoneyFormat), toUnitPrice != null ? toUnitPrice.Name : "(None)");
                    toUnitPriceValue = NumberHelper.GetValue<decimal>(toItem.UnitPrice);

                    toTotal = (decimal)toItem.Quantity * NumberHelper.GetValue<decimal>(toItem.UnitPrice);
                    Literal ltrToTotal = (Literal)e.Item.FindControl("ltrToTotal");
                    ltrToTotal.Text = string.Format("{0} ({1})", toTotal.ToString(RLMConfiguration.Setting.MoneyFormat), toUnitPrice != null ? toUnitPrice.Name : "(None)");

                    int toExchangeRate = NumberHelper.GetValue<int>(toItem.ExchangeRate);
                    toExchangeRate = toExchangeRate > 0 ? toExchangeRate : 1;

                    toTotalVND = (decimal)toExchangeRate * toTotal;
                    Literal ltrToTotalVND = (Literal)e.Item.FindControl("ltrToTotalVND");
                    ltrToTotalVND.Text = toTotalVND.ToString(RLMConfiguration.Setting.MoneyFormat);
                    toQuatity = toItem.Quantity;
                    toUnitId = toUnitPrice.UnitId;
                    toUnitName = toUnitPrice.Name;
                }



                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = string.Format("{0} ({1})", (fromQuantity - toQuatity), unitName);

                double differUnitPrice = 1;
                if (fromUnitId != toUnitId)
                {
                    differUnitPrice = UnitTree.Translate(fromUnitId, toUnitId);
                    
                }

                Literal ltrUnitPrice = (Literal)e.Item.FindControl("ltrUnitPrice");
                ltrUnitPrice.Text = string.Format("{0} ({1})",(fromUnitPriceValue*((decimal)differUnitPrice)-toUnitPriceValue).ToString(RLMConfiguration.Setting.MoneyFormat), toUnitName);

                Literal ltrTotal = (Literal)e.Item.FindControl("ltrTotal");
                ltrTotal.Text = (fromTotalVND - toTotalVND).ToString(RLMConfiguration.Setting.MoneyFormat);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Private
        private void BindData()
        {
            if (this.FromProjectPhaseId <= 0)
            {
                btnCompare.Enabled = false;
                return;
            }
            lnkTopFromProjectPhase.ResourceType = RLM.Construction.Entities.ResourceType.ProjectPhase;
            lnkTopFromProjectPhase.ResourceId = this.FromProjectPhaseId;
            lnkTopFromProjectPhase.Action = NavigateAction.ClientView;

            lnkTopFromProject.ResourceType = RLM.Construction.Entities.ResourceType.Project;
            lnkTopFromProject.ResourceId = this.FromProjectId = this.FromProjectId;
            lnkTopFromProject.Action = NavigateAction.ClientView;

        }

        private void GetData()
        {
            int temp;
            if (int.TryParse(Request.Params["FromProjectPhaseId"], out temp))
            {
                this.FromProjectPhaseId = temp;
            }

            if (int.TryParse(Request.Params["FromProjectId"], out temp))
            {
                this.FromProjectId = temp;
            }
        }
        #endregion
    }
}
