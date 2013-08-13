using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Configuration;
using RLM.Core.Web.UI;
using RLM.Core.Web.UI.Notifier;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;


namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class AdvanceRequestView : System.Web.UI.Page
    {
        #region Variables
        AdvanceRequest item;
        int itemId;
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (this.IsPostBack) { return; }
                BindGuid();
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
            Response.Redirect("~/Page/Contract/AdvanceRequestList.aspx", true);
        }
        #endregion

        #region Private methods
        private void BindGuid()
        {
            if (this.item == null) { return; }
            RLM.Construction.Entities.Contract contract = ServiceRepositoryHelper.ContractServiceHelper.Get(NumberHelper.GetValue<int>(item.ContractId));
            if (contract != null)
            {
                lblContract.Text = contract.Name;
            }

            RLM.Construction.Entities.Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(item.RequestContactorId));
            if (contactor != null)
            {
                lblRequestContactor.Text = contactor.Name;
            }

            ltrRequestComment.Text = item.RequestComment;


            lblAmount.Text = NumberHelper.GetValue<decimal>(item.RequestAmount).ToString(RLMConfiguration.Setting.MoneyFormat);

            RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.CurrencyUnitId));
            if (unit != null)
            {
                lblUnit.Text = unit.Name;
            }


            lblStatus.Text = Utility.GetEnumValue<AdvanceRequestStatus>((AdvanceRequestStatus)item.Status);

            lblRequestDate.Text = NumberHelper.GetValue<DateTime>(item.RequestDate).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

            files.ResourceId = item.AdvanceRequestId;
        }

        private void LoadData()
        {
            if (!int.TryParse(Request.Params["ItemId"], out this.itemId)) { return; }
            this.item = ServiceRepository.AdvanceRequestService.GetByAdvanceRequestId(this.itemId);
        }

        #endregion
    }
}
