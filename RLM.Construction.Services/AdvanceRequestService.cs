	

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
	/// An component type implementation of the 'AdvanceRequest' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AdvanceRequestService : RLM.Construction.Services.AdvanceRequestServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the AdvanceRequestService class.
		/// </summary>
		public AdvanceRequestService() : base()
		{
		}


        public TList<AdvanceRequest> GetPaged(int resourceId, AdvanceRequestType resourceType)
        {
            string whereClause = string.Format("[ContractId]={0}",resourceId);
            int total;
            return this.GetPaged(whereClause,"RequestDate DESC",0,0, out total);
        }
    }//End Class


} // end namespace
