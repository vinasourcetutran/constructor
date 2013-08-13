using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class UnitConvertorServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.UnitConvertor> GetListByFromUnitId(int fromUnitId)
        {
            return ServiceRepository.UnitConvertorService.GetByFromUnitId(fromUnitId);
            //string whereClause = string.Format("[FromUnitId]={0}",parentUnitId);
            //int total;
            //return ServiceRepository.UnitConvertorService.GetPaged(whereClause,UnitConvertorColumn.LastModificationDate +" DESC",0,0,out total);
        }

        public void Update(UnitConvertor item)
        {
            ServiceRepository.UnitConvertorService.Update(item);
        }

        public void Insert(UnitConvertor item)
        {
            ServiceRepository.UnitConvertorService.Insert(item);
        }

        public UnitConvertor GetByUnitConvertorId(int unitConvertorId)
        {
            return ServiceRepository.UnitConvertorService.GetByUnitConvertorId(unitConvertorId);
        }

        public void Delete(int unitConvertorId)
        {
            ServiceRepository.UnitConvertorService.Delete(unitConvertorId);
        }


        public UnitConvertor GetCurrentByUnit(int fromUnitId, int toUnitId)
        {
            return ServiceRepository.UnitConvertorService.GetCurrentByUnit(fromUnitId, toUnitId);
        }

        public TList<UnitConvertor> GetListByToUnitId(int toUnitId)
        {
            return ServiceRepository.UnitConvertorService.GetByToUnitId(toUnitId);
        }

        public TList<UnitConvertor> GetListByEffectDate(DateTime fromEffectDate, DateTime toEffectDate, UnitType unitType)
        {
            return ServiceRepository.UnitConvertorService.GetListByEffectDate(fromEffectDate, toEffectDate, unitType);
        }
    }
}
