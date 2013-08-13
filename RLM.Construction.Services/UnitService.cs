	

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
	/// An component type implementation of the 'Unit' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class UnitService : RLM.Construction.Services.UnitServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the UnitService class.
		/// </summary>
		public UnitService() : base()
		{
		}

        public TList<Unit> GetByType(UnitType type, bool isActiveOnly)
        {
            int total;
            string whereClause = string.Format("[Type]={0} AND ([IsActive]={1} OR {1}=0)", (int)type,isActiveOnly?"1":"0");
            return this.GetPaged(whereClause, "[Name] ASC", 0, 0, out total);
        }

        public TList<Unit> GetByParentId(int parentUnitId, bool isActive)
        {
            int total;
            string whereClause = string.Format("[UnitId] IN (SELECT [ToUnitId] FROM UnitConvertor WHERE [FromUnitId]={0} AND ([IsActive]={1} OR {1}=0)) AND ([IsActive]={1} OR {1}=0)", parentUnitId, isActive ? "1" : "0");
            return this.GetPaged(whereClause, "[Name] ASC", 0, 0, out total);
        }
    }//End Class


} // end namespace
