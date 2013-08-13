using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class RoleServiceHelper
    {
        public RLM.Construction.Entities.Role GetByRoleId(int roleId)
        {
            return ServiceRepository.RoleService.GetByRoleId(roleId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Role> GetRoleByType(RoleType roleType,bool isActiveOnly)
        {
            return ServiceRepository.RoleService.GetByRoleType(roleType, isActiveOnly);
        }
    }
}
