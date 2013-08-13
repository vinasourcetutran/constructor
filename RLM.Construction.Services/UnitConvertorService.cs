

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

#endregion

namespace RLM.Construction.Services
{

    ///<summary>
    /// An component type implementation of the 'UnitConvertor' table.
    ///</summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class UnitConvertorService : RLM.Construction.Services.UnitConvertorServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the UnitConvertorService class.
        /// </summary>
        public UnitConvertorService()
            : base()
        {
        }


        public UnitConvertor GetCurrentByUnit(int fromUnitId, int toUnitId)
        {
            TList<UnitConvertor> items = this.GetByUnitConvertor(fromUnitId, toUnitId, true);
            return items != null && items.Count > 0 ? items[0] : null;
        }

        private TList<UnitConvertor> GetByUnitConvertor(int fromUnitId, int toUnitId, bool isActive)
        {
            string whereClause = string.Format("[FromUnitId]={0} AND [ToUnitId]={1} AND ([IsActive]={2} OR {2}=0)", fromUnitId, toUnitId, isActive ? "1" : "0");
            int total;
            return this.GetPaged(whereClause, UnitConvertorColumn.EffectFrom.ToString() + " DESC", 0, 0, out total);
        }


        public TList<UnitConvertor> GetListByEffectDate(DateTime fromEffectDate, DateTime toEffectDate,UnitType unitType)
        {
            string whereClause = string.Format("[EffectFrom] BETWEEN '{0}' AND '{1}' AND ([IsActive]=1) AND (([FromUnitId] IN (SELECT UnitId from Unit where [Type]={2})) OR ([ToUnitId] IN (SELECT UnitId from Unit where [Type]={2})))", fromEffectDate, toEffectDate, (int)unitType);
            int total;
            return this.GetPaged(whereClause, UnitConvertorColumn.EffectFrom.ToString() + " DESC", 0, 0, out total);
        }
    }//End Class


} // end namespace
