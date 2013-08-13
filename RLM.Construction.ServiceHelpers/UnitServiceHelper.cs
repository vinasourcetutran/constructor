using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class UnitServiceHelper
    {
        public RLM.Construction.Entities.Unit GetByUnitId(int unitId)
        {
            return ServiceRepository.UnitService.GetByUnitId(unitId);
        }


        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Unit> GetByParentUnitId(int parentUnitId, bool isActive)
        {
            return ServiceRepository.UnitService.GetByParentId(parentUnitId,isActive);
        }
    }
}
