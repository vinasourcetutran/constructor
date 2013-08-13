	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using RLM.Construction.Entities;
using RLM.Construction.Entities.Validation;

using RLM.Construction.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;

#endregion

namespace RLM.Construction.Services
{		
	
	///<summary>
	/// An component type implementation of the 'ItemInProject' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ItemInProjectService : RLM.Construction.Services.ItemInProjectServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ItemInProjectService class.
		/// </summary>
		public ItemInProjectService() : base()
		{
		}


        public ItemInProject GetItemByProjectPhaseIdAnditemId(int projectPhaseId, long itemId)
        {
            try
            {
                string whereClause = string.Format("[ProjectPhaseId]={0} AND [ItemId]={1}",projectPhaseId,itemId);
                int total;
                TList<ItemInProject> items = ServiceRepository.ItemInProjectService.GetPaged(whereClause, "Quantity", 0, 0, out total);
                return items != null && items.Count > 0 ? items[0] : null;
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return null;
            }
        }

        public TList<ItemInProject> GetByProjectPhaseId(int projectPhaseId, string orderBy)
        {
            try
            {
                string whereClause = string.Format("[ProjectPhaseId]={0} ", projectPhaseId);
                int total;
                TList<ItemInProject> items = ServiceRepository.ItemInProjectService.GetPaged(whereClause, orderBy, 0, 0, out total);
                return items;
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return null;
            }
        }

        public TList<ItemInProject> GetByResource(ResourceType resourceType, int resourceId, bool isDetailItem)
        {
            try
            {
                TList<ItemInProject> items = null;
                if (resourceType == ResourceType.Contract)
                {
                    items = this.GetByContractId(resourceId);
                }
                if (resourceType == ResourceType.Project)
                {
                    items = this.GetByProjectId(resourceId);
                }
                if (resourceType == ResourceType.ProjectPhase)
                {
                    items = this.GetByProjectPhaseId(resourceId,ItemInProjectColumn.LastModificationDate.ToString()+ " DESC");
                }
                if (isDetailItem)
                {
                    items = this.GetDetailItem(items);
                }
                return items;
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return null;
            }
        }

        private TList<ItemInProject> GetDetailItem(TList<ItemInProject> items)
        {
            try
            {
                throw new Exception("Methods was not implemented");
                //TList<ItemInProject> result = new TList<ItemInProject>();
                //Unit unit=null;
                //Item item=null;
                //foreach (ItemInProject subItem in items)
                //{
                //    item=ServiceRepository.ItemService.GetByItemId(subItem.ItemId);
                //    if(item==null){ continue;}
                //    if (item.UsedUnitId != item.BaseUnitId)
                //    {
                //        double convertorWeight = UnitTree.Translate(NumberHelper.GetValue<int>(item.UsedUnitId),NumberHelper.GetValue<int>(item.BaseUnitId));
                //        subItem.Quantity *= convertorWeight;
                //    }
                //    TList<ItemInItem> childItems = ServiceRepository.ItemInItemService.GetByFromItemId(item.ItemId);
                //    if (childItems == null || childItems.Count == 0)
                //    {
                //        result.Add(subItem);
                //        continue;
                //    }
                //    TList<ItemInProject> convertItems = this.ConvertToItemInProject(subItem, childItems);
                //    result = RLM.Core.Framework.Utility.UtilityHelper.Merge<TList<ItemInProject>,ItemInProject>(result, convertItems);
                //}
                //return result;
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return items;
            }
            
        }

        //private TList<ItemInProject> ConvertToItemInProject(ItemInProject itemInProject, TList<ItemInItem> childItems)
        //{
        //    TList<ItemInProject> result = new TList<ItemInProject>();
        //    foreach (ItemInItem item in childItems)
        //    {
        //        ItemInProject subItem = new ItemInProject();
        //        subItem.ProjectId = itemInProject.ProjectId;
        //        subItem.ContractId = itemInProject.ContractId;
        //        subItem.ProjectPhaseId = itemInProject.ProjectPhaseId;

        //    }
        //}

        public TList<ItemInProject> GetItemInProjectPhase(string projectPhaseIds)
        {
            string whereClause = string.Format("ProjectPhaseId in ({0})", projectPhaseIds);
            int total;
            return this.GetPaged(whereClause,ItemInProjectColumn.PriceUnitId.ToString(),0,0,out total);
        }

        public ItemInProject GetByItemIdAndProjectPhaseId(long itemId, int projectPhaseId)
        {
            string whereClause = string.Format("[ItemId]={0} AND [ProjectPhaseId]={1}",itemId, projectPhaseId);
            int total;
            TList<ItemInProject> items = GetPaged(whereClause,ItemInProjectColumn.ItemId.ToString(),0,0,out total);
            return items != null && items.Count > 0 ? items[0] : null;
        }
    }//End Class


} // end namespace
