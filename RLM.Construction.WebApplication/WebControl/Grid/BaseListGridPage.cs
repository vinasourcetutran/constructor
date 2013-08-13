using System;
using System.Collections.Generic;

using System.Text;
using System.Web.UI;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;
using RLM.Construction.WebApplication.CommonLib;
using Telerik.Web.UI;

namespace RLM.Construction.WebApplication.WebControl.Grid
{
    public class BaseListGridPage<T>:System.Web.UI.Page where T:IEntity,new()
    {
        #region Properties
        protected virtual DataSourceItem<T> DataSource
        {
            get
            {
                DataSourceItem<T> items=GetItemFromRepository();
                //if (ViewState["Items"] == null)
                //{
                //    items = GetItemFromRepository();
                //    ViewState["Items"] = items;
                //}
                //else
                //{
                //    items = (DataSourceItem<T>)ViewState["Items"];
                //}
                return items;
            }
            set
            {
                ViewState["Items"] = value;
            }
        }

        public virtual string DataKeyName { get; set; }

        public virtual string  EditPageUrl { get; set; }

        public virtual bool IsReBindOnPostBack { get; set; }
        #endregion

        #region Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack && !IsReBindOnPostBack) { return; }
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
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericLoaDataSourceException;
            }
        }

        protected void radItems_OnItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                OnItemCommand(source, e);
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
                OnItemDataBound(source,e);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
       
        #endregion

        #region Virtual
        protected virtual void OnItemDataBound(object source, GridItemEventArgs e)
        {
        }
        protected virtual void OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                int id = Convert.ToInt32(item.GetDataKeyValue(this.DataKeyName));

                // Edit group items
                if (e.CommandName == "EditItem")
                {
                    string url = string.Format(this.EditPageUrl, id);
                    Response.Redirect(url, true);
                }
            }
        }

        protected virtual void BindDataSourceToGrid(DataSourceItem<T> dataSource)
        {
        }

        protected virtual TList<T> LoadDataFromRepository(out int totalRecords)
        {
            totalRecords = 0;
            return null;
        }
        #endregion

        #region Functions
        protected void BindData()
        {
            try
            {
                DataSourceItem<T> dataSource = this.DataSource;
                BindDataSourceToGrid(dataSource);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DataSourceItem<T> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<T> item = new DataSourceItem<T>(); ;
                int totalRecords;
                item.Items = LoadDataFromRepository(out totalRecords);// ServiceRepository.ItemService.GetPaged("", "LastModificationDate ASC", 0, 0, out total);
                item.TotalItems = totalRecords;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<T>();
            }
        }
        #endregion
    }
}
