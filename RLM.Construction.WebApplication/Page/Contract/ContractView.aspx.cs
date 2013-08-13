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

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class ContractView : System.Web.UI.Page
    {
        #region Variables
        RLM.Construction.Entities.Contract item;
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
                    BindGuid();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Contract/ContractList.aspx", true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            lblContractNumber.Text = this.item.Number;

            taskList.ResourceId = this.item.ContractId;
            itemGraph.ResourceId = this.item.ContractId;
            grantChart.ResourceId = this.item.ContractId;

            advanceRequestList.ResourceId = files.ResourceId = this.itemId;
            advanceRequestList.PageTitle = files.PageTitle = this.item.Name;
            projectPhaseList.ContractId = this.item.ContractId;
            itemInProjectList.ContractId = this.item.ContractId;

            lblCode.Text = item.Code;
            lblName.Text = this.item.Name;

            lnkParner.ResourceId = NumberHelper.GetValue<int>(this.item.PartnerId);
            /*RLM.Construction.Entities.Partner partner = ServiceRepositoryHelper.PartnerServiceHelper.GetByPartnerId(NumberHelper.GetValue<int>(this.item.PartnerId));
            if (partner != null)
            {
                lnkParner.Title = lnkParner.Text = partner.Name;
                lnkParner.Url = UrlBuilderHelper.GetUrl(partner, NavigateAction.ClientView);
            }*/
            //lblToContact.Text = this.item.ToContactName;
            lblFromContact.Text = this.item.FromContactName;
            lnkToContactor.ResourceId = NumberHelper.GetValue<int>(this.item.ToContactorId);
            //lnkFromContactor.ResourceId = NumberHelper.GetValue<int>(this.item.FromContactorId);
            /*RLM.Construction.Entities.Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(this.item.FromContactorId));
            if (contactor != null)
            {
                lnkFromContactor.Title = lnkFromContactor.Text = contactor.Name;
                lnkFromContactor.Url = UrlBuilderHelper.GetUrl(contactor, NavigateAction.ClientView);
            }*/
            //lnkToContactor.ResourceId = NumberHelper.GetValue<int>(this.item.ToContactorId);
            /*RLM.Construction.Entities.Contactor toContactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(this.item.ToContactorId));
            if (toContactor != null)
            {
                lnkToContactor.Title = lnkToContactor.Text = toContactor.Name;
                lnkToContactor.Url = UrlBuilderHelper.GetUrl(toContactor, NavigateAction.ClientView);
            }*/

            ltrDescription.Text = this.item.Description;

            lblType.Text = Utility.GetEnumValue<ContractType>((ContractType)this.item.Type);
            spIsActive.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsActive) ? "OK" : "NotOK");
            spIsApprove.Attributes.Add("class", NumberHelper.GetValue<bool>(this.item.IsApprove) ? "OK" : "NotOK");
            if (this.item.LastModificationDate.HasValue)
            {
                spLastModificationDate.InnerHtml = item.LastModificationDate.Value.ToString(RLMConfiguration.Setting.LongDateTimeFormat);
            }

            RLM.Construction.Entities.Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.GroupId));
            if (group != null)
            {
                lblGroup.Text = group.Name;
            }

            RLM.Construction.Entities.Group constructGroup = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.ConstructDeptId));
            if (constructGroup != null)
            {
                lblConstructDept.Text = constructGroup.Name;
            }

            RLM.Construction.Entities.Group designGroup = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId(NumberHelper.GetValue<int>(this.item.DesignDeptId));
            if (designGroup != null)
            {
                lblDesignDept.Text = designGroup.Name;
            }


            string unitName = "(None)";
            RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(this.item.CurrencyUnitId));
            if (unit != null)
            {
                unitName = lblUnit.Text = unit.Name;
            }

            
            RLM.Construction.Entities.Project project = ServiceRepositoryHelper.ProjectServiceHelper.GetItemByContractId(this.item.ContractId);
            if (project != null)
            {
                lblProject.Text = project.Name;
                //lnkProject.ResourceId = project.ProjectId;
                //lnkProject.Text = lnkProject.Title = project.Name;
                //lnkProject.Url = UrlBuilderHelper.GetUrl(project, NavigateAction.ClientView);
            }

            int exchangeRate = NumberHelper.GetValue<int>(this.item.ExchangeRate);
            exchangeRate = exchangeRate>0 ? exchangeRate : 1;
            lblExchangeRate.Text = lblExchangeRate.ToolTip = string.Format("1 {0} = {1} VND", unitName, exchangeRate.ToString(RLMConfiguration.Setting.MoneyFormat));

            decimal initValue = NumberHelper.GetValue<decimal>(this.item.InitPrice);
            decimal lastValue = NumberHelper.GetValue<decimal>(this.item.LastPrice);

            lblStatus.Text = Utility.GetEnumValue<ContractStatus>((ContractStatus)this.item.Status);
            lblFirstPrice.Text =string.Format(
                "{0} {1} ({2} VND)", 
                initValue.ToString(RLMConfiguration.Setting.MoneyFormat), 
                unitName,
                (initValue*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                );
            lblLastPrice.Text = string.Format(
                "{0} {1} ({2} VND)", 
                lastValue.ToString(RLMConfiguration.Setting.MoneyFormat), 
                unitName,
                (lastValue*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                );

            lblTotalDays.Text = this.item.Days.ToString();
            lblRealTotalDays.Text = this.item.RealDays.ToString();

            decimal totalAmount=NumberHelper.GetValue<decimal>(this.item.LastPrice)* (1 + (decimal)NumberHelper.GetValue<double>(this.item.VATTax)/100);
            lblTotalAmount.Text = lblTotalAmount.ToolTip = string.Format(
                    "{0} {1} ({2} VND)", 
                    totalAmount.ToString(RLMConfiguration.Setting.MoneyFormat), 
                    unitName, 
                    (totalAmount*exchangeRate).ToString(RLMConfiguration.Setting.MoneyFormat)
                );

            double vat = NumberHelper.GetValue<double>(this.item.VATTax);
            lblVat.Text = StringHelper.Format("{0} ({1} VND)", vat, ((decimal)vat * lastValue * exchangeRate/100).ToString(RLMConfiguration.Setting.MoneyFormat));
            double pit = NumberHelper.GetValue<double>(this.item.PITTax);
            lblPit.Text = StringHelper.Format("{0} ({1} VND)", pit, ((decimal)pit * lastValue * exchangeRate/100).ToString(RLMConfiguration.Setting.MoneyFormat)); ;//NumberHelper.GetValue<double>(this.item.PITTax).ToString();
            //lblCit.Text = NumberHelper.GetValue<double>(this.item.CITTax).ToString();
            double cit = NumberHelper.GetValue<double>(this.item.CITTax);
            lblCit.Text = StringHelper.Format("{0} ({1} VND)", cit, ((decimal)cit * lastValue * exchangeRate/100).ToString(RLMConfiguration.Setting.MoneyFormat)); ;//NumberHelper.GetValue<double>(this.item.PITTax).ToString();

            if (this.item.SignedDate.HasValue)
            {
                lblSignedDate.Text = NumberHelper.GetValue<DateTime>(this.item.SignedDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            }
            if (this.item.FromDate.HasValue)
            {
                lblFromDate.Text = NumberHelper.GetValue<DateTime>(this.item.FromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            }
            if (this.item.ToDate.HasValue)
            {
                lblToDate.Text = NumberHelper.GetValue<DateTime>(this.item.ToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            }
            if (this.item.RealFromDate.HasValue)
            {
                lblRealFromDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealFromDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            }
            if (this.item.RealToDate.HasValue)
            {
                lblRealToDate.Text = NumberHelper.GetValue<DateTime>(this.item.RealToDate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);
            }

        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.ContractService.GetByContractId(this.itemId);
        }
        #endregion
    }
}
