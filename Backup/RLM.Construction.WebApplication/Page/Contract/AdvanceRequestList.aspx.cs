using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using RLM.Construction.WebApplication.CommonLib;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RLM.Construction.WebApplication.WebControl.Grid;
using RLM.Construction.Web.UI.Combobox;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.WebApplication.Page.Contract
{
    public partial class AdvanceRequestList : BaseListGridPage<RLM.Construction.Entities.AdvanceRequest>
    {
        #region Override Properties
        public override string DataKeyName
        {
            get
            {
                return radItems.MasterTableView.DataKeyNames[0];
            }
            set
            {
            }
        }
        #endregion

        #region Override
        protected override void BindDataSourceToGrid(DataSourceItem<AdvanceRequest> dataSource)
        {
            radItems.DataSource = dataSource.Items;
            radItems.VirtualItemCount = dataSource.TotalItems;
        }

        protected override TList<AdvanceRequest> LoadDataFromRepository(out int totalRecords)
        {
            totalRecords = 0;
            try
            {
                return ServiceRepositoryHelper.AdvanceRequestServiceHelper.GetPaged("", "[RequestDate] DESC", 0, 0, out totalRecords);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
                return new TList<AdvanceRequest>();
            }
        }

        protected override void OnItemDataBound(object source, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.Item && e.Item.ItemType != GridItemType.AlternatingItem) { return; }
                AdvanceRequest item = (AdvanceRequest)e.Item.DataItem;

                RLM.Construction.Entities.Contract contract = ServiceRepositoryHelper.ContractServiceHelper.Get(NumberHelper.GetValue<int>(item.ContractId));
                if (contract != null)
                {
                    Literal ltrContract = (Literal)e.Item.FindControl("ltrContractName");
                    ltrContract.Text = contract.Name;
                }

                RLM.Construction.Entities.Contactor contactor = ServiceRepositoryHelper.ContactorServiceHelper.Get(NumberHelper.GetValue<int>(item.RequestContactorId));
                if (contactor!= null)
                {
                    Literal ltrContactor = (Literal)e.Item.FindControl("ltrRequestContactorName");
                    ltrContactor.Text = contactor.Name;
                }

                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.CurrencyUnitId));
                if (unit != null)
                {
                    Literal ltrCurrencyUnitName = (Literal)e.Item.FindControl("ltrCurrencyUnitName");
                    ltrCurrencyUnitName.Text = unit.Name;
                }

                Literal ltrStatusName = (Literal)e.Item.FindControl("ltrStatusName");
                ltrStatusName.Text = Utility.GetEnumValue<AdvanceRequestStatus>((AdvanceRequestStatus)NumberHelper.GetValue<int>(item.Status));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected override void OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                int id = Convert.ToInt32(item.GetDataKeyValue(this.DataKeyName));

                if (e.CommandName == "Edit")
                {
                    string url = string.Format("~/Page/Contract/AdvanceRequestAddNew.aspx?itemId={0}", id);
                    Response.Redirect(url, true);
                }
                if (e.CommandName == "Preview")
                {
                    string url = string.Format("~/Page/Contract/AdvanceRequestView.aspx?ItemId={0}", id);
                    Response.Redirect(url, true);
                }
            }
        }
        #endregion
    }
}
