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

namespace RLM.Construction.WebApplication.Page.Item
{
    public partial class ItemList : System.Web.UI.Page
    {
        #region Properties
        protected DataSourceItem<RLM.Construction.Entities.Item> DataSource
        {
            get
            {
                DataSourceItem<RLM.Construction.Entities.Item> items = GetItemFromRepository();
                //if (ViewState["Items"] == null)
                //{
                //    items = 
                //    ViewState["Items"] = items;
                //}
                //else
                //{
                //    items = (DataSourceItem<RLM.Construction.Entities.Item>)ViewState["Items"];
                //}
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
                if (e.IsFromDetailTable) { return; }
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
                if (e.Item.ItemType == GridItemType.FilteringItem)
                {
                    BindFilterControl(e.Item as Telerik.Web.UI.GridFilteringItem);
                }
                if (e.Item.OwnerTableView.Name == "SubItem")
                {
                    radItem_OnSubItemCommand(source,e);
                    return;
                }
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("ItemId"));

                    // Edit group items
                    if (e.CommandName == "EditItem")
                    {
                        string url = string.Format("~/Page/Item/ItemAddNew.aspx?ItemId={0}", id);
                        Response.Redirect(url, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItem_OnSubItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                    int id = Convert.ToInt32(item.GetDataKeyValue("ItemInItemId"));

                    ServiceRepositoryHelper.ItemInItemServiceHelper.DeleteItemInItem(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnItemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.FilteringItem)
                {
                    BindFilterControl(e.Item as Telerik.Web.UI.GridFilteringItem);
                }
                if (e.Item.OwnerTableView.Name == "SubItem")
                {
                    radItems_OnSubItemDataBound(source, e);
                    return;
                }
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    RLM.Construction.Entities.Item dataItem = (RLM.Construction.Entities.Item)e.Item.DataItem;

                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrGroupName");
                    if (ltrGroupName != null)
                    {
                        Group group = ServiceRepository.GroupService.GetByGroupId((int)dataItem.GroupId);
                        ltrGroupName.Text = group != null ? group.Name : string.Empty;
                    }

                    Literal ltrUnitName = (Literal)e.Item.FindControl("ltrUnitName");
                    if (ltrUnitName != null)
                    {
                        RLM.Construction.Entities.Unit unit = ServiceRepository.UnitService.GetByUnitId((int)dataItem.BaseUnitId);
                        ltrUnitName.Text = unit != null ?string.Format("{0} ({1})", unit.Name,unit.Description) : string.Empty;
                    }

                    AddNewRelatedItemLink lnkPreView = (AddNewRelatedItemLink)e.Item.FindControl("lnkPreView");
                    lnkPreView.ResourceId = (int)dataItem.ItemId;
                    lnkPreView.ResourceType = RLM.Construction.Entities.ResourceType.Item;
                    lnkPreView.CssClass = "Preview";
                    lnkPreView.Action = NavigateAction.ClientView;
                    //lnkPreView.Text = string.Empty;
                    //lnkPreView.Title = string.Format("Item: {0}",dataItem.Name);
                    //lnkPreView.Url = UrlBuilderHelper.GetUrl(dataItem,NavigateAction.ClientView);


                    Image itemPhoto = (Image)e.Item.FindControl("itemPhoto");
                    itemPhoto.AlternateText = dataItem.Name;
                    itemPhoto.ImageUrl = UrlBuilderHelper.GetUrl(dataItem,NavigateAction.Thumnail);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnDetailTableBinding(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            try
            {
                GridDataItem parentItem = e.DetailTableView.ParentItem as GridDataItem;
                // edit mode
                if (parentItem.Edit || e.DetailTableView.Name!="SubItem") { return; }
                long parentId = long.Parse(parentItem["ItemId"].Text);

                TList<ItemInItem> items = ServiceRepositoryHelper.ItemInItemServiceHelper.GetListByFromItemId(parentId);
                e.DetailTableView.DataSource = items;
                e.DetailTableView.VirtualItemCount = items.Count;
                //e.DetailTableView.Rebind();
                //e.DetailTableView.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnSubItemDataBound(object source, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType != GridItemType.AlternatingItem && e.Item.ItemType != GridItemType.Item) { return; }
                RLM.Construction.Entities.ItemInItem dataItem = (RLM.Construction.Entities.ItemInItem)e.Item.DataItem;
                RLM.Construction.Entities.Item item = ServiceRepositoryHelper.ItemServiceHelper.GetItemByItemId(dataItem.ToItemId);
                if (item == null) { return; }
                Group group = ServiceRepositoryHelper.GroupServiceHelper.GetByGroupId((int)item.GroupId);
                if (group != null)
                {
                    Literal ltrGroupName = (Literal)e.Item.FindControl("ltrSubGroupName");
                    ltrGroupName.Text = group.Name;
                }

                //Literal ltrCode = (Literal)e.Item.FindControl("ltrSubCode");
                //ltrCode.Text = item.Code;

                Literal ltrName = (Literal)e.Item.FindControl("ltrSubName");
                ltrName.Text = item.Name;

                RLM.Construction.Entities.Unit unit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId((int)dataItem.UnitId);
                if (group != null)
                {
                    Literal ltrUnitName = (Literal)e.Item.FindControl("ltrSubUnitName");
                    ltrUnitName.Text = unit.Name;
                }
                Image itemPhoto = (Image)e.Item.FindControl("itemPhoto");
                itemPhoto.AlternateText = item.Name;
                itemPhoto.ImageUrl = UrlBuilderHelper.GetUrl(item, NavigateAction.Thumnail);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (!(e.Item is GridEditableItem) || !e.Item.IsInEditMode) { return; }
            
            GroupComboBox list = (e.Item as GridEditableItem)["GroupId"].Controls[1] as GroupComboBox;
            //attach SelectedIndexChanged event for the drodown control
            list.AutoPostBack = true;
            list.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.ItemGroup_SelectedIndexChanged);
        }

        protected void ItemGroup_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                GroupComboBox group = sender as GroupComboBox;
                GridEditableItem editedItem = group.NamingContainer as GridEditableItem;
                ItemComboBox item = editedItem["Name"].Controls[1] as ItemComboBox;

                int groupId = 0;
                if (group.SelectedValue != "" && group.SelectedValue != "0")
                {
                    groupId = int.Parse(group.SelectedValue);
                }

                int total;
                item.DataSource = ServiceRepositoryHelper.ItemServiceHelper.GetListByGroupId(groupId,true,ItemColumn.Name.ToString(),0,0,out total);
                item.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected void radItems_OnUpdateCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem parentItem = e.Item.OwnerTableView.ParentItem;
                if (!e.Item.IsInEditMode || parentItem == null) { return; }
                long parentId = (long)parentItem.OwnerTableView.DataKeyValues[parentItem.ItemIndex]["ItemId"];

                GridEditableItem dataItem = (GridEditableItem)e.Item;
                int itemInItemId = int.Parse(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ItemInItemId"].ToString());

                ItemComboBox itemCombobox = dataItem["Name"].Controls[1] as ItemComboBox;
                int itemId;
                // select no item
                if (!int.TryParse(itemCombobox.SelectedValue, out itemId) || itemId == 0) { return; }

                UnitComboBox unitCombobox = dataItem["UnitId"].Controls[1] as UnitComboBox;
                string quantity = (dataItem["Quantity"].Controls[0] as RadNumericTextBox).Text;

                ItemInItem itemInItem = new ItemInItem();
                itemInItem.LastModificationDate= itemInItem.CreationDate = DateTime.Now;
                itemInItem.LastModificationUserId= itemInItem.CreationUserId = Utility.GetCurrentUserId();
                itemInItem.ToItemId = parentId;
                itemInItem.FromItemId = itemId;
                itemInItem.Quantity = double.Parse(quantity);
                itemInItem.UnitId = int.Parse(unitCombobox.SelectedValue);
                itemInItem.Total = 0;
                itemInItem.ItemInItemId = itemInItemId;

                ErrorPair errorValidate=ServiceRepositoryHelper.ItemInItemServiceHelper.IsValidate(itemInItem);
                if (errorValidate.ErrorType==ErrorType.None)
                {
                    ServiceRepositoryHelper.ItemInItemServiceHelper.InsertOrUpdate(itemInItem);
                }
                // show error here
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveFail");
            }
        }

        protected void radItems_OnInsertCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem parentItem = e.Item.OwnerTableView.ParentItem;
                if (!e.Item.IsInEditMode || parentItem==null) { return; }
                long parentId = (long)parentItem.OwnerTableView.DataKeyValues[parentItem.ItemIndex]["ItemId"];

                GridEditableItem dataItem = (GridEditableItem)e.Item;

                ItemComboBox itemCombobox = dataItem["Name"].Controls[1] as ItemComboBox;
                int itemId;
                // select no item
                if (!int.TryParse(itemCombobox.SelectedValue, out itemId) || itemId == 0) { return; }

                UnitComboBox unitCombobox = dataItem["UnitId"].Controls[1] as UnitComboBox;
                string quantity = (dataItem["Quantity"].Controls[0] as RadNumericTextBox).Text;

                ItemInItem itemInItem = new ItemInItem();
                itemInItem.LastModificationDate = itemInItem.CreationDate = DateTime.Now;
                itemInItem.LastModificationUserId = itemInItem.CreationUserId = Utility.GetCurrentUserId();
                itemInItem.ToItemId = itemId;
                itemInItem.FromItemId = parentId;
                itemInItem.Quantity = double.Parse(quantity);
                itemInItem.UnitId = int.Parse(unitCombobox.SelectedValue);
                itemInItem.Total = 0;

                ErrorPair errorValidate = ServiceRepositoryHelper.ItemInItemServiceHelper.IsValidate(itemInItem);
                if (errorValidate.ErrorType == ErrorType.None)
                {
                    ServiceRepositoryHelper.ItemInItemServiceHelper.InsertOrUpdate(itemInItem);
                }
                // show error here
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                RLMContext.ErrorType = ErrorType.Error;
                RLMContext.ErrorMessage = (string)GetLocalResourceObject("ItemInProjectSaveFail");
            }
        }
        #endregion

        #region Functions
        private void BindFilterControl(GridFilteringItem e)
        {
            Telerik.Web.UI.GridFilteringItem item = e;// e.Item as Telerik.Web.UI.GridFilteringItem;
            int total;

            RadComboBox radUnit = (RadComboBox)item.FindControl("radUnit");
            if (radUnit != null)
            {
                radUnit.DataSource = ServiceRepository.UnitService.GetAll();
                radUnit.DataBind();
            }

            RadComboBox radGroup = (RadComboBox)item.FindControl("radGroup");
            if (radGroup != null)
            {
                string groupWhereClause = string.Format("[Type]={0}", (int)GroupType.Item);
                radGroup.DataSource = ServiceRepository.GroupService.GetPaged(groupWhereClause, "[Name] DESC", 0, 0, out total);
                radGroup.DataBind();
            }
        }

        protected void BindData()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Item> dataSource = this.DataSource;
                radItems.DataSource = DataSource.Items;
                radItems.VirtualItemCount = dataSource.TotalItems;
                //radItems.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataSourceItem<RLM.Construction.Entities.Item> GetItemFromRepository()
        {
            try
            {
                DataSourceItem<RLM.Construction.Entities.Item> item = new DataSourceItem<RLM.Construction.Entities.Item>(); ;
                int total;
                item.Items = ServiceRepository.ItemService.GetPaged("", "LastModificationDate ASC", 0, 0, out total);
                item.TotalItems = total;
                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new DataSourceItem<RLM.Construction.Entities.Item>();
            }
        }
        #endregion
    }
}
