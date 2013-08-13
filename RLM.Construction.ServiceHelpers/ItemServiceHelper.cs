using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Entities;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ItemServiceHelper
    {
        public TList<Item> GetListByParentItemId(long parentItemId, string orderBy, int pageSize, int pageIndex, out int totalRecords)
        {
            string whereClause=string.Format("[ParentItemId]={0}",parentItemId);
            return ServiceRepository.ItemService.GetPaged(whereClause, orderBy, pageSize, pageIndex, out totalRecords);
        }

        public Item GetItemByItemId(long itemId)
        {
            return ServiceRepository.ItemService.GetByItemId(itemId);
        }

        public object GetListByGroupId(int groupId, bool isActive, string orderBy, int pageSize, int pageIndex, out int totalRecords)
        {
            string whereClause = string.Format("[GroupId]={0} AND ([IsActive]={1} OR {1}=0)", groupId,isActive?"1":"0");
            return ServiceRepository.ItemService.GetPaged(whereClause, orderBy, pageSize, pageIndex, out totalRecords);
        }

        public TList<Item> GetByProjectPhaseIds(string projectPhaseIds)
        {
            return ServiceRepository.ItemService.GetByProjectPhaseIds(projectPhaseIds);
        }
    }
}
