	

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
	/// An component type implementation of the 'Role' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class RoleService : RLM.Construction.Services.RoleServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the RoleService class.
		/// </summary>
		public RoleService() : base()
		{
		}


        public TList<Role> GetByRoleType(RoleType roleType, bool isActiveOnly)
        {
            string whereClause = string.Format("[Type]={0} AND ([IsActive]={1} OR {1}=0)", (int)roleType, isActiveOnly ? "1" : "0");
            int total;
            return this.GetPaged(whereClause,RoleColumn.Name.ToString(),0,0, out total);
        }
    }//End Class


} // end namespace
