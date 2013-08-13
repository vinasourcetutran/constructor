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

namespace RLM.Construction.WebApplication.Page.SystemSetting
{
    public partial class AppConfigList : BaseListGridPage<RLM.Construction.Entities.AppConfig>
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
        protected override void BindDataSourceToGrid(DataSourceItem<AppConfig> dataSource)
        {
            radItems.DataSource = dataSource.Items;
            radItems.VirtualItemCount = dataSource.TotalItems;
            //radItems.DataBind();
        }

        protected override TList<AppConfig> LoadDataFromRepository(out int totalRecords)
        {
            totalRecords = 0;
            try
            {
                return ServiceRepositoryHelper.AppConfigServiceHelper.GetPaged("", "[LastModificationDate] DESC", 0, 0, out totalRecords);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
                return new TList<AppConfig>();
            }
        }

        protected override void OnItemDataBound(object source, GridItemEventArgs e)
        {
            try
            {
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

                // Edit group items
                if (e.CommandName == "Delete")
                {
                    ServiceRepositoryHelper.AppConfigServiceHelper.Delete(id);
                }

                if (e.CommandName == "Edit")
                {
                    string url = string.Format("~/Page/System/AppConfigAddNew.aspx?itemId={0}",id);
                    Response.Redirect(url, true);
                }
            }
        }
        #endregion

        #region Event handler
        protected void radItems_OnItemUpdate(object source, GridCommandEventArgs e)
        {
            try
            {

                if (!e.Item.IsInEditMode) { return; }
                GridEditableItem dataItem = (GridEditableItem)e.Item;
                int itemId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex][this.DataKeyName].ToString());

                string name = (dataItem["AppConfigName"].Controls[0] as RadTextBox).Text;
                string value = (dataItem["AppConfigValue"].Controls[0] as RadTextBox).Text;
                bool isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;

                AppConfig item = ServiceRepositoryHelper.AppConfigServiceHelper.Get(itemId);
                item.AppConfigName = name;
                item.AppConfigValue = value;
                item.AppConfigId = 0;
                item.IsActive = isActive;
                item.IsDeletable = true;
                item.LastModificationUserId = Utility.GetCurrentUserId();
                item.LastModificationDate = DateTime.Now;

                ServiceRepositoryHelper.AppConfigServiceHelper.Update(item);

                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.MessageItemSaveSuccessful;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }
        }

        protected void radItems_OnItemInsert(object source, GridCommandEventArgs e)
        {
            try
            {
                if (!e.Item.IsInEditMode) { return; }
                GridEditableItem dataItem = (GridEditableItem)e.Item;
                string name = (dataItem["AppConfigName"].Controls[0] as RadTextBox).Text;
                string value = (dataItem["AppConfigValue"].Controls[0] as RadTextBox).Text;
                bool isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;

                ErrorPair validateResult = ValidateAppConfig(name);
                if (validateResult.ErrorType != ErrorType.None)
                {
                    RLMContext.ErrorType = validateResult.ErrorType;
                    RLMContext.ErrorMessage = validateResult.ErrorMessage;
                    return;
                }

                AppConfig item = new AppConfig();
                item.AppConfigName = name;
                item.AppConfigValue = value;
                item.AppConfigId = 0;
                item.IsActive = isActive;
                item.IsDeletable = true;
                item.CreationUserId = item.LastModificationUserId = Utility.GetCurrentUserId();
                item.CreationDate = item.LastModificationDate = DateTime.Now;

                ServiceRepositoryHelper.AppConfigServiceHelper.Insert(item);

                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.MessageItemSaveSuccessful;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericSaveException;
            }
        }


        #endregion

        #region Private
        private ErrorPair ValidateAppConfig(string name)
        {
            ErrorPair validateResult = new ErrorPair();
            validateResult.ErrorType = ErrorType.None;
            try
            {
                AppConfig config = ServiceRepositoryHelper.AppConfigServiceHelper.GetByAppConfigName(name);
                if (config != null)
                {
                    validateResult.ErrorType = ErrorType.Error;
                    validateResult.ErrorMessage = string.Format(Resources.Common.MessageDupplicateItem, name);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                validateResult.ErrorMessage = Resources.Common.GenericException;
                validateResult.ErrorType = ErrorType.Error;
            }
            return validateResult;
        }
        #endregion
    }
}
