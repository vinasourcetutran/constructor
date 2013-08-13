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

namespace RLM.Construction.WebApplication.Page.Project
{
    public partial class ProjectView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Project item;
        int itemId;
        int contractId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LoadData();
                if (!this.IsPostBack)
                {
                    BindGuid();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(UrlBuilderHelper.GetUrl(new RLM.Construction.Entities.Project(),NavigateAction.List), true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }

            taskList.ResourceId = this.item.ProjectId;
            itemGraph.ResourceId = this.item.ProjectId;
            grantChart.ResourceId=this.item.ProjectId;

            lnkContract.ResourceId = this.item.ContractId;
            /*RLM.Construction.Entities.Contract contract = ServiceRepositoryHelper.ContractServiceHelper.Get(this.item.ContractId);
            if (contract != null)
            {
                lnkContract.Title = lnkContract.Text = contract.Name;
                lnkContract.Url = UrlBuilderHelper.GetUrl(contract,NavigateAction.ClientView);
            }*/

            RLM.Construction.Entities.Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(this.item.GroupId);
            if (group != null)
            {
                lblGroup.ToolTip = lblGroup.Text = group.Name;
            }

            lblCode.Text = lblCode.ToolTip = this.item.Code;
            lblName.Text = lblName.ToolTip = this.item.Name;

            ProjectPhase projectPhase = ServiceRepositoryHelper.ProjectPhaseServiceHelper.GetCurrentPhaseByProjectId(this.item.ProjectId);
            if (projectPhase != null)
            {
                lnkProjectPhase.ResourceId = projectPhase.ProjectPhaseId;
                //lnkProjectPhase.Title = lnkProjectPhase.Text = projectPhase.Name;
                //lnkProjectPhase.Url = UrlBuilderHelper.GetUrl(projectPhase, NavigateAction.ClientView);
            }

            RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(this.item.CurrencyUnitId));
            string unitName = "(None)";
            if (unit != null)
            {
                unitName = unit.Name;
                //lblCurrency.ToolTip = lblCurrency.Text = unit.Name;
            }
            int exchangeRate = NumberHelper.GetValue<int>(this.item.ExchangeRate);
            exchangeRate = exchangeRate > 0 ? exchangeRate : 1;

            lblExchangeRate.Text = string.Format("1 {0} = {1} VND", unitName,exchangeRate.ToString(RLMConfiguration.Setting.MoneyFormat));

            decimal designedPrice = NumberHelper.GetValue<decimal>(this.item.DesignedPrice);
            decimal actualPrice = NumberHelper.GetValue<decimal>(this.item.AuctualPrice);

            ltrDescription.Text = this.item.Description;
            lblFirstPrice.Text = lblFirstPrice.ToolTip = string.Format(
                "{0} {1} ({2} VND)", 
                designedPrice.ToString(RLMConfiguration.Setting.MoneyFormat), 
                unitName,
                (designedPrice*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                );
            lblLastPrice.Text = lblLastPrice.ToolTip = string.Format(
                "{0} {1} ({2} VND)", 
                NumberHelper.GetValue<decimal>(this.item.AuctualPrice).ToString(RLMConfiguration.Setting.MoneyFormat), 
                unitName,
                (actualPrice*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                );
            
            

            spIsActive.Attributes.Add("class",NumberHelper.GetValue<bool>(this.item.IsActive)?"OK":"NotOK");
            spIsApprove.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsApprove) ? "OK" : "NotOK");

            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }
            files.ResourceId = this.item.ProjectId;
            files.PageTitle = this.item.Name;

            projectPhases.ProjectId = this.item.ProjectId;

            itemInProject.ProjectId = this.item.ProjectId;
        }

        private void LoadData()
        {
            int.TryParse(Request.Params["ContractId"], out this.contractId);
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ProjectService.GetByProjectId(this.itemId);
        }
        #endregion
    }
}
