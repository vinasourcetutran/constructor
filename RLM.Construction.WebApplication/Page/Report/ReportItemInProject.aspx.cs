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
using RLM.Configuration;
using RLM.Construction.WebApplication.UserControl;

namespace RLM.Construction.WebApplication.Page.Report
{
    public partial class ReportItemInProject : BaseListGridPage<ItemInProject>
    {
        #region Variables
        int projectPhaseId;
        long itemId;
        int quantity;
        decimal unitPrice;
        bool isActive;

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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                unitConvertor.ToUnitId = RLMConfiguration.Setting.VndUnitId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.Error = ex;
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = Resources.Common.GenericException;
            }
        }

        protected override void BindDataSourceToGrid(DataSourceItem<ItemInProject> dataSource)
        {
            radItems.DataSource = dataSource.Items;
            radItems.VirtualItemCount = dataSource.TotalItems;
            radItems.DataBind();
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

                AddNewRelatedItemLink lnkProject = (AddNewRelatedItemLink)e.Item.FindControl("lnkProject");
                lnkProject.ResourceType = RLM.Construction.Entities.ResourceType.Project;
                lnkProject.Action = NavigateAction.ClientView;
                lnkProject.ResourceId = dataItem.ProjectId;
                //ltrProjectName.Text = project.Name;

                AddNewRelatedItemLink lnkProjectPhase = (AddNewRelatedItemLink)e.Item.FindControl("lnkProjectPhase");
                lnkProjectPhase.ResourceType = RLM.Construction.Entities.ResourceType.ProjectPhase;
                lnkProjectPhase.Action = NavigateAction.ClientView;
                lnkProjectPhase.ResourceId = NumberHelper.GetValue<int>(dataItem.ProjectPhaseId);

                AddNewRelatedItemLink lnkItem = (AddNewRelatedItemLink)e.Item.FindControl("lnkItem");
                lnkItem.ResourceType = RLM.Construction.Entities.ResourceType.Item;
                lnkItem.Action = NavigateAction.ClientView;
                lnkItem.ResourceId = (int)dataItem.ItemId;

                Label lblQuantity = (Label)e.Item.FindControl("lblQuantity");
                lblQuantity.Text = dataItem.Quantity.ToString();

                if (item != null)
                {
                    RLM.Construction.Entities.Unit usedUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(item.UsedUnitId));
                    if (usedUnit != null)
                    {
                        lblQuantity.ToolTip = string.Format("{0} ({1})", usedUnit.Name, usedUnit.Description);
                    }
                }

                Label lblUnitPrice = (Label)e.Item.FindControl("lblUnitPrice");
                lblUnitPrice.Text = dataItem.UnitPrice.ToString(RLMConfiguration.Setting.MoneyFormat);
                decimal total = dataItem.UnitPrice * (decimal)dataItem.Quantity;
                RLM.Construction.Entities.Unit priceUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(NumberHelper.GetValue<int>(dataItem.PriceUnitId));
                if (priceUnit != null)
                {
                    lblUnitPrice.Text += "/ " + priceUnit.Name;
                    lblUnitPrice.ToolTip = string.Format("{0} ({1})",total.ToString(RLMConfiguration.Setting.MoneyFormat),priceUnit.Name);
                }

                double vndWeight=UnitTree.Translate(priceUnit.UnitId,RLMConfiguration.Setting.VndUnitId);
                Label lblTotalPrice = (Label)e.Item.FindControl("lblTotalPrice");
                dataItem.Total = (total * ((decimal)vndWeight));
                lblTotalPrice.Text = (total * ((decimal)vndWeight)).ToString(RLMConfiguration.Setting.MoneyFormat);
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

                string quantity = (dataItem["Quantity"].Controls[0] as RadNumericTextBox).Text;
                string unitPrice = (dataItem["UnitPrice"].Controls[0] as RadNumericTextBox).Text;
                this.isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;

                ErrorPair validateResult = ValidateItemInProjectPhase(quantity, unitPrice, this.projectPhaseId, this.itemId);
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

                string quantity = (dataItem["Quantity"].Controls[0] as RadNumericTextBox).Text;
                string unitPrice = (dataItem["UnitPrice"].Controls[0] as RadNumericTextBox).Text;
                this.isActive = (dataItem["IsActive"].Controls[1] as HtmlInputCheckBox).Checked;

                ErrorPair validateResult = ValidateItemInProjectPhase(quantity, unitPrice, this.projectPhaseId, this.itemId);
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
            //if (!(e.Item is GridEditableItem) || !e.Item.IsInEditMode) { return; }
            //ProjectComboBox list = (e.Item as GridEditableItem)["ProjectId"].Controls[1] as ProjectComboBox;
            ////attach SelectedIndexChanged event for the drodown control
            //list.AutoPostBack = true;
            //list.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.project_SelectedIndexChanged);

            //ItemComboBox items = (e.Item as GridEditableItem)["ItemId"].Controls[1] as ItemComboBox;
            ////attach SelectedIndexChanged event for the drodown control
            //items.AutoPostBack = true;
            //items.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.item_SelectedIndexChanged);
        }
        #endregion

        #region Private
        private void ApplyStyleOnExport(GridItemEventArgs e)
        {
            e.Item.Style[HtmlTextWriterStyle.FontFamily] = "Segoe UI,Arial,sans-serif";
            e.Item.Style[HtmlTextWriterStyle.BorderColor] = "black";
            if (e.Item.ItemIndex == 0) { e.Item.Visible = false; }
        }

        private ErrorPair ValidateItemInProjectPhase(string quantity, string unitPrice, int projectPhaseId, long itemId)
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
            return validateResult;
        }
        #endregion
    }
}
