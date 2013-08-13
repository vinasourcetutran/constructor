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
using RLM.Core.Framework.Utility;
using RLM.Configuration;

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class UnitList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Unit> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Unit> items = GetItemFromRepository();
                return items;
            }
            set
            {
                ViewState["Items"] = value;
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
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericLoaDataSourceException;
            }
        }

        protected void radItems_OnItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("UnitId"));

                    // Edit group items
                    if (e.CommandName == "EditItem")
                    {
                        string url = string.Format("~/Page/System/UnitAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnOtemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    RLM.Construction.Entities.Unit dataItem = (RLM.Construction.Entities.Unit)e.Item.DataItem;

                    Literal ltrTypeName = (Literal)e.Item.FindControl("ltrTypeName");
                    ltrTypeName.Text = Resources.Enumeration.ResourceManager.GetString("UnitType_" + ((RLM.Construction.Entities.UnitType)dataItem.Type).ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        //private void radItems_OnSubItemDataBound(object source, GridItemEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
        //        RLM.Construction.Entities.UnitConvertor dataItem = (RLM.Construction.Entities.UnitConvertor)e.Item.DataItem;
        //        RLM.Construction.Entities.Unit toUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(dataItem.ToUnitId);
        //        if (toUnit == null) { return; }

        //        Literal ltrName = (Literal)e.Item.FindControl("ltrName");
        //        ltrName.Text = toUnit.Name;

        //        Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
        //        ltrQuantity.Text = NumberHelper.GetValue<double>(dataItem.Quantity).ToString();

        //        Literal ltrAffectFromDate = (Literal)e.Item.FindControl("ltrAffectFromDate");
        //        ltrAffectFromDate.Text = NumberHelper.GetValue<DateTime>(dataItem.EffectFrom).ToString(RLMConfiguration.Setting.LongDateTimeFormat);

        //        Literal ltrTypeName = (Literal)e.Item.FindControl("ltrTypeName");
        //        ltrTypeName.Text = Resources.Enumeration.ResourceManager.GetString("UnitType_" + ((RLM.Construction.Entities.UnitType)toUnit.Type).ToString());

        //        Literal ltrDescription = (Literal)e.Item.FindControl("ltrDescription");
        //        ltrDescription.Text = toUnit.Description;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //    }
        //}

        //protected void radItems_OnDetailTableBinding(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        //{
        //    try
        //    {
        //        GridDataItem parentItem = e.DetailTableView.ParentItem as GridDataItem;
        //        // edit mode
        //        if (parentItem.Edit || e.DetailTableView.Name != "SubItem") { return; }
        //        long parentId = long.Parse(parentItem["UnitId"].Text);

        //        TList<UnitConvertor> items = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetListByFromUnitId(parentId);
        //        e.DetailTableView.DataSource = items;
        //        e.DetailTableView.VirtualItemCount = items.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //    }
        //}
        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Unit> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                //radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Unit> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Unit> item = new DataSourceItem<RLM.Construction.Entities.Unit>(); ;
                int total;
                item.Items = ServiceRepository.UnitService.GetPaged("", "LastModificationDate DESC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Unit>();
            }
        }
        #endregion
    }
}
