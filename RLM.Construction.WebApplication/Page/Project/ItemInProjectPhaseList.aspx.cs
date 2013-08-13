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

namespace RLM.Construction.WebApplication.Page.Project
{
    using RLM.Configuration;

    public partial class ItemInProjectPhaseList : BaseListGridPage<ItemInProject>
    {
        #region Variables
        int projectPhaseId;
        long itemId;
        int quantity;
        decimal unitPrice;
        bool isActive;
        int exchangeRate;

        ProjectPhase projectPhase;
        RLM.Construction.Entities.Item item;

        ExportFileType exportType = ExportFileType.None;
        #endregion

        #region Override Properties
        public override string DataKeyName
        {
            get
            {
                return radItems.MasterTableView.DataKeyNames[0];
            }
            set
            {
                //base.DataKeyName = value;
            }
        }
        #endregion

        #region Override
        protected override void BindDataSourceToGrid(DataSourceItem<ItemInProject> dataSource)
        {
            radItems.DataSource = dataSource.Items;
            radItems.VirtualItemCount = dataSource.TotalItems;
            //radItems.DataBind();
        }

        protected override TList<ItemInProject> LoadDataFromRepository(out int totalRecords)
        {
            totalRecords = 0;
            try
            {
                return ServiceRepository.ItemInProjectService.GetPaged("", "[LastModificationDate] DESC", 0, 0, out totalRecords);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
                return new TList<ItemInProject>();
            }
        }

        protected override void OnItemDataBound(object source, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }

                RLM.Construction.Entities.ItemInProject dataItem = (RLM.Construction.Entities.ItemInProject)e.Item.DataItem;

                RLM.Construction.Entities.Project project = ServiceRepository.ProjectService.GetByProjectId(dataItem.ProjectId);
                if (project != null)
                {
                    Literal ltrProjectName = (Literal)e.Item.FindControl("ltrProjectName");
                    ltrProjectName.Text = project.Name;
                }

                RLM.Construction.Entities.ProjectPhase projectPhase = ServiceRepository.ProjectPhaseService.GetByProjectPhaseId((int)dataItem.ProjectPhaseId);
                if (projectPhase != null)
                {
                    Literal ltrProjectPhaseName = (Literal)e.Item.FindControl("ltrProjectPhaseName");
                    ltrProjectPhaseName.Text = projectPhase.Name;
                }

                RLM.Construction.Entities.Item item = ServiceRepository.ItemService.GetByItemId(dataItem.ItemId);
                if (item != null)
                {
                    Literal ltrItemName = (Literal)e.Item.FindControl("ltrItemName");
                    ltrItemName.Text = item.Name;
                }

                string unitName = "(None)";
                if (item != null)
                {
                    RLM.Construction.Entities.Unit usedUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.UsedUnitId));
                    if (usedUnit != null)
                    {
                        unitName = usedUnit.Name;
                    }
                }
                Literal ltrQuantity = (Literal)e.Item.FindControl("ltrQuantity");
                ltrQuantity.Text = string.Format("{0} {1}",dataItem.Quantity.ToString(RLMConfiguration.Setting.MoneyFormat),unitName);

                RLM.Construction.Entities.Unit priceUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.PriceUnitId));
                if (priceUnit != null)
                {
                    Literal ltrPriceUnitName = (Literal)e.Item.FindControl("ltrPriceUnitName");
                    ltrPriceUnitName.Text = priceUnit.Name;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected override void OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
            {
                this.exportType = ExportFileType.Excel;
            }
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
            {
                this.exportType = ExportFileType.Csv;
            }
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
            {
                this.exportType = ExportFileType.Pdf;
            }
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName)
            {
                this.exportType = ExportFileType.Word;
            }

            if (this.exportType != ExportFileType.None)
            {
                radItems.GridLines = GridLines.Both;
                radItems.MasterTableView.GetColumn("DeleteColumn").Visible = radItems.MasterTableView.GetColumn("EditColumn").Visible = false;
                radItems.AllowFilteringByColumn = radItems.MasterTableView.AllowFilteringByColumn = false;
            }
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                int id = Convert.ToInt32(item.GetDataKeyValue(this.DataKeyName));

                // Edit group items
                if (e.CommandName == "Delete")
                {
                    ServiceRepository.ItemInProjectService.Delete(id);
                }
            }
        }
        #endregion

        #region Event handler
        protected void btnExportToPdf_ExportToPdf(object sender, EventArgs e)
        {
            try
            {
                radItems.MasterTableView.ExportToPdf();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void btnExportToWord_ExportToWord(object sender, EventArgs e)
        {
            try
            {
                radItems.MasterTableView.ExportToWord();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void btnExportToExcel_ExportToExcel(object sender, EventArgs e)
        {
            try
            {
                radItems.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnItemUpdate(object source, GridCommandEventArgs e)
        {
            try
            {

                if (!e.Item.IsInEditMode) { return; }
                GridEditableItem dataItem = (GridEditableItem)e.Item;
                int itemInProjectPhaseId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ItemInProjectId"].ToString());

                ProjectPhaseComboBox drpProjectPhase = dataItem["ProjectPhaseId"].Controls[1] as ProjectPhaseComboBox;
                this.projectPhaseId = int.Parse(drpProjectPhase.SelectedValue);
                ItemComboBox drpItem = dataItem["ItemId"].Controls[1] as ItemComboBox;
                this.itemId = long.Parse(drpItem.SelectedValue);

                string quantity = (dataItem["Quantity"].Controls[1] as TextBox).Text;
                string unitPrice = (dataItem["UnitPrice"].Controls[0] as RadNumericTextBox).Text;
                this.isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;
                string exchangeRate = (dataItem["ExchangeRate"].Controls[0] as RadNumericTextBox).Text;

                ErrorPair validateResult = ValidateItemInProjectPhase(exchangeRate, quantity, unitPrice, this.projectPhaseId, this.itemId);
                if (validateResult.ErrorType != ErrorType.None)
                {
                    RLMContext.ErrorType = validateResult.ErrorType;
                    RLMContext.ErrorMessage = validateResult.ErrorMessage;
                    return;
                }

                ItemInProject itemInProject = ServiceRepository.ItemInProjectService.GetItemByProjectPhaseIdAnditemId(this.projectPhaseId, this.itemId);
                if (itemInProject == null)
                {
                    itemInProject = ServiceRepository.ItemInProjectService.GetByItemInProjectId(itemInProjectPhaseId);
                }

                itemInProject.ProjectId = this.projectPhase.ProjectId;
                itemInProject.ContractId = (int)this.projectPhase.ContractId;
                itemInProject.ProjectPhaseId = this.projectPhase.ProjectPhaseId;
                itemInProject.ItemId = this.item.ItemId;
                itemInProject.LastModificationDate = DateTime.Now;
                itemInProject.LastModificationUserId = Utility.GetCurrentUserId();
                itemInProject.Quantity = (itemInProject.ItemInProjectId != itemInProjectPhaseId) ? (itemInProject.Quantity + this.quantity) : this.quantity;

                itemInProject.UnitPrice = this.unitPrice;
                UnitComboBox drpPriceUnit = dataItem["PriceUnitId"].Controls[1] as UnitComboBox;
                itemInProject.PriceUnitId = int.Parse(drpPriceUnit.SelectedValue);

                itemInProject.ExchangeRate = this.exchangeRate;

                itemInProject.Total = (decimal)itemInProject.Quantity * itemInProject.UnitPrice;
                itemInProject.IsActive = this.isActive;

                ServiceRepository.ItemInProjectService.Update(itemInProject);

                if (itemInProject.ItemInProjectId != itemInProjectPhaseId)
                {
                    ServiceRepository.ItemInProjectService.Delete(itemInProjectPhaseId);
                }

                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveSuccessful");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveFail");
            }
        }

        protected void radItems_OnItemInsert(object source, GridCommandEventArgs e)
        {
            try
            {
                if (!e.Item.IsInEditMode) { return; }
                GridEditableItem dataItem = (GridEditableItem)e.Item;

                //ProjectComboBox project = dataItem["ProjectId"].Controls[1] as ProjectComboBox;
                ProjectPhaseComboBox drpProjectPhase = dataItem["ProjectPhaseId"].Controls[1] as ProjectPhaseComboBox;
                this.projectPhaseId = int.Parse(drpProjectPhase.SelectedValue);
                ItemComboBox drpItem = dataItem["ItemId"].Controls[1] as ItemComboBox;
                this.itemId = long.Parse(drpItem.SelectedValue);

                string quantity = (dataItem["Quantity"].Controls[1] as TextBox).Text;
                string unitPrice = (dataItem["UnitPrice"].Controls[0] as RadNumericTextBox).Text;
                string exchangeRate = (dataItem["ExchangeRate"].Controls[0] as RadNumericTextBox).Text;
                this.isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;

                ErrorPair validateResult = ValidateItemInProjectPhase(exchangeRate, quantity, unitPrice, this.projectPhaseId, this.itemId);
                if (validateResult.ErrorType != ErrorType.None)
                {
                    RLMContext.ErrorType = validateResult.ErrorType;
                    RLMContext.ErrorMessage = validateResult.ErrorMessage;
                    return;
                }

                ItemInProject itemInProject = ServiceRepository.ItemInProjectService.GetItemByProjectPhaseIdAnditemId(this.projectPhaseId, this.itemId);
                if (itemInProject == null)
                {
                    itemInProject = new ItemInProject();
                    itemInProject.CreationDate = DateTime.Now;
                    itemInProject.CreationUserId = Utility.GetCurrentUserId();
                    itemInProject.IsApprove = true;
                    itemInProject.ProjectId = this.projectPhase.ProjectId;
                    itemInProject.ContractId = (int)this.projectPhase.ContractId;
                    itemInProject.ProjectPhaseId = this.projectPhase.ProjectPhaseId;
                    itemInProject.ItemId = this.item.ItemId;
                }

                itemInProject.LastModificationDate = DateTime.Now;
                itemInProject.LastModificationUserId = Utility.GetCurrentUserId();
                itemInProject.Quantity += this.quantity;

                itemInProject.UnitPrice = this.unitPrice;
                UnitComboBox drpPriceUnit = dataItem["PriceUnitId"].Controls[1] as UnitComboBox;
                itemInProject.PriceUnitId = int.Parse(drpPriceUnit.SelectedValue);
                
                itemInProject.ExchangeRate = this.exchangeRate;

                itemInProject.Total = (decimal)itemInProject.Quantity * itemInProject.UnitPrice;
                itemInProject.IsActive = this.isActive;

                if (itemInProject.ItemInProjectId == 0)
                {
                    ServiceRepository.ItemInProjectService.Insert(itemInProject);
                }
                else
                {
                    ServiceRepository.ItemInProjectService.Update(itemInProject);
                }

                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveSuccessful");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveFail");
            }
        }

        protected void radItems_OnItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (this.exportType == ExportFileType.Pdf || this.exportType == ExportFileType.Word)
            {
                ApplyStyleOnExport(e);

            }
            if (!(e.Item is GridEditableItem) || !e.Item.IsInEditMode) { return; }

            ItemInProject itemInProject = null;// (ItemInProject)e.Item.DataItem;
            if (e.Item.DataItem != null && e.Item.DataItem is ItemInProject)
            {
                itemInProject = (ItemInProject)e.Item.DataItem;
            }

            ProjectComboBox list = (e.Item as GridEditableItem)["ProjectId"].Controls[1] as ProjectComboBox;
            //attach SelectedIndexChanged event for the drodown control
            list.AutoPostBack = true;
            list.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.project_SelectedIndexChanged);

            ItemComboBox items = (e.Item as GridEditableItem)["ItemId"].Controls[1] as ItemComboBox;
            //attach SelectedIndexChanged event for the drodown control
            items.AutoPostBack = true;
            items.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.item_SelectedIndexChanged);
            item_SelectedIndexChanged(items, null);

            RadNumericTextBox unitPrice = (e.Item as GridEditableItem)["UnitPrice"].Controls[0] as RadNumericTextBox;
            unitPrice.CssClass += " CustomFormat";

            RadNumericTextBox exchangeRate = (e.Item as GridEditableItem)["ExchangeRate"].Controls[0] as RadNumericTextBox;
            exchangeRate.CssClass += " CustomFormat";
            exchangeRate.Attributes.Add("onload","alert('aaa');");
            
            if (itemInProject != null)
            {
                list.SelectedValue = itemInProject.ProjectId.ToString();

                items.SelectedValue = itemInProject.ItemId.ToString();

                HtmlInputCheckBox chkIsActive = (e.Item as GridEditableItem)["IsActive"].Controls[1] as HtmlInputCheckBox;
                chkIsActive.Checked = NumberHelper.GetValue<bool>(itemInProject.IsActive);


                UnitComboBox unit = (e.Item as GridEditableItem)["PriceUnitId"].Controls[1] as UnitComboBox;
                unit.SelectedValue = NumberHelper.GetValue<int>(itemInProject.PriceUnitId).ToString();

                ProjectPhaseComboBox projectPhase = (e.Item as GridEditableItem)["ProjectPhaseId"].Controls[1] as ProjectPhaseComboBox;
                projectPhase.SelectedValue = NumberHelper.GetValue<int>(itemInProject.ProjectPhaseId).ToString();

                TextBox txtQuantity = (e.Item as GridEditableItem)["Quantity"].Controls[1] as TextBox;
                txtQuantity.Text = itemInProject.Quantity.ToString();

                

                Literal ltrQuantityUnitName = (e.Item as GridEditableItem)["Quantity"].FindControl("ltrQuantityUnitName") as Literal;
                RLM.Construction.Entities.Item quantityItem = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(itemInProject.ItemId);
                RLM.Construction.Entities.Unit quantityUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(quantityItem.UsedUnitId));
                if (quantityUnit != null)
                {
                    ltrQuantityUnitName.Text = quantityUnit.Name;
                }
            }
            
        }

        protected void project_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                ProjectComboBox project = sender as ProjectComboBox;
                GridEditableItem editedItem = project.NamingContainer as GridEditableItem;
                ProjectPhaseComboBox projectPhaseCombo = editedItem["ProjectPhaseId"].Controls[1] as ProjectPhaseComboBox;

                string whereClause = "";
                if (project.SelectedValue != "" && project.SelectedValue != "0")
                {
                    whereClause = string.Format("[ProjectId]={0} AND [IsActive]=1", project.SelectedValue);
                }

                projectPhaseCombo.BindToDataSource(whereClause);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void item_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                ItemComboBox itemCombo = sender as ItemComboBox;
                GridEditableItem editedItem = itemCombo.NamingContainer as GridEditableItem;
                Literal ltrUnitName = editedItem["Quantity"].Controls[3] as Literal;

                long itemId;
                if (!long.TryParse(itemCombo.SelectedValue, out itemId)) { return; }

                RLM.Construction.Entities.Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(itemId);
                if (item == null) { return; }

                RLM.Construction.Entities.Unit usedUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.UsedUnitId));
                if (usedUnit == null) { return; }
                ltrUnitName.Text = usedUnit.Name;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        #region Private
        private void ApplyStyleOnExport(GridItemEventArgs e)
        {
            e.Item.Style[HtmlTextWriterStyle.FontFamily] = "Segoe UI,Arial,sans-serif";
            e.Item.Style[HtmlTextWriterStyle.BorderColor] = "black";
            if (e.Item.ItemIndex == 0) { e.Item.Visible = false; }
        }

        private ErrorPair ValidateItemInProjectPhase(string exchangeRate, string quantity, string unitPrice, int projectPhaseId, long itemId)
        {
            ErrorPair validateResult = new ErrorPair();
            this.projectPhase = ServiceRepository.ProjectPhaseService.GetByProjectPhaseId(projectPhaseId);
            if (this.projectPhase == null)
            {
                validateResult.ErrorType = ErrorType.Error;
                validateResult.ErrorMessage = Resources.CommonError.InvalidProjectPhaseValue;
                return validateResult;
            }

            this.item = ServiceRepository.ItemService.GetByItemId(this.itemId);
            if (this.item == null)
            {
                validateResult.ErrorType = ErrorType.Error;
                validateResult.ErrorMessage = Resources.CommonError.InvalidItemValue;
                return validateResult;
            }

            if (!int.TryParse(quantity, out this.quantity) || this.quantity <= 0)
            {
                validateResult.ErrorType = ErrorType.Error;
                validateResult.ErrorMessage = Resources.CommonError.InvalidQuantityValue;
                return validateResult;
            }

            if (!decimal.TryParse(unitPrice, out this.unitPrice) || this.unitPrice < 0)
            {
                validateResult.ErrorType = ErrorType.Error;
                validateResult.ErrorMessage = Resources.CommonError.InvalidUnitPriceValue;
                return validateResult;
            }

            if (!int.TryParse(exchangeRate, out this.exchangeRate) || this.exchangeRate < 0)
            {
                validateResult.ErrorType = ErrorType.Error;
                validateResult.ErrorMessage = Resources.CommonError.InvalidItemValue;
                return validateResult;
            }

            this.exchangeRate = this.exchangeRate > 0 ? this.exchangeRate : 1;

            return validateResult;
        }
        #endregion
    }
}
