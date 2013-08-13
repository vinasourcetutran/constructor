using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class GroupServiceHelper
    {
        public RLM.Construction.Entities.Group GetByGroupId(int groupId)
        {
            return ServiceRepository.GroupService.GetByGroupId(groupId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Group> GetByType(int parentId, RLM.Construction.Entities.GroupType type, bool isActive)
        {
            return ServiceRepository.GroupService.GetByType(parentId,type,isActive);
        }
    }
}
