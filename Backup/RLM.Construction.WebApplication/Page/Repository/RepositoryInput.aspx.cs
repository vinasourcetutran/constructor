using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Construction.Services;
using RLM.Core.Framework.Enum;
using RLM.Core.Framework.Log;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.Web.UI.Combobox;
using RLM.Construction.WebApplication.UserControl;
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.Repository
{
    public partial class RepositoryInput : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.ItemIOTicket> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.ItemIOTicket> items = GetItemFromRepository();
                return items;
            }
        }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) { return; }
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

        protected void radItems_OnNeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericLoaDataSourceException;
            }
        }

        protected void radItems_OnItemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
                RLM.Construction.Entities.ItemIOTicket dataItem = (RLM.Construction.Entities.ItemIOTicket)e.Item.DataItem;


                //Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                //imgPhoto.AlternateText = dataItem.FullName;
                //imgPhoto.ImageUrl = UrlBuilderHelper.GetUrl(dataItem, NavigateAction.Thumnail);
                AddNewRelatedItemLink lnkStaff = (AddNewRelatedItemLink)e.Item.FindControl("lnkStaff");
                lnkStaff.ResourceId = dataItem.StaffId;

                //AddNewRelatedItemLink lnkProject = (AddNewRelatedItemLink)e.Item.FindControl("lnkProject");
                //lnkProject.ResourceId = NumberHelper.GetValue<int>(dataItem.ProjectId);
                Literal ltrType = (Literal)e.Item.FindControl("ltrType");
                ltrType.Text = Utility.GetEnumValue<ItemIOTicketType>((ItemIOTicketType)NumberHelper.GetValue<int>(dataItem.IOType));

                Literal ltrIODate = (Literal)e.Item.FindControl("ltrIODate");
                ltrIODate.Text = NumberHelper.GetValue<DateTime>(dataItem.IODate).ToString(RLMConfiguration.Setting.ShortDateTimeFormat);

                Literal ltrTax = (Literal)e.Item.FindControl("ltrTax");
                ltrTax.Text = NumberHelper.GetValue<double>(dataItem.TaxPercent).ToString();

                Literal ltrStatus = (Literal)e.Item.FindControl("ltrStatus");
                ltrStatus.Text = Utility.GetEnumValue<ItemIOTicketStatus>((ItemIOTicketStatus)NumberHelper.GetValue<int>(dataItem.Status));

                AddNewRelatedItemLink lnkPreView = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreView");
                lnkPreView.ResourceId = dataItem.IOTicketId;

                AddNewRelatedItemLink lnkEdit = (AddNewRelatedItemLink)e.Item.FindControl("lnkEdit");
                lnkEdit.ResourceId = dataItem.IOTicketId;

                Literal ltrUnitId = (Literal)e.Item.FindControl("ltrUnitId");
                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.UnitId));
                ltrUnitId.Text = string.Format("{0} ({1})", NumberHelper.GetValue<decimal>(dataItem.TotalAmount).ToString(RLMConfiguration.Setting.MoneyFormat), unit.Name);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
       
        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.ItemIOTicket> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                //radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.ItemIOTicket> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.ItemIOTicket> item = new DataSourceItem<RLM.Construction.Entities.ItemIOTicket>(); ;
                item.Items = ServiceRepositoryHelper.ItemIOTicketServiceHelper.GetAll();
                item.TotalItems = item.Items.Count;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.ItemIOTicket>();
            }
        }
        #endregion
    }
}
