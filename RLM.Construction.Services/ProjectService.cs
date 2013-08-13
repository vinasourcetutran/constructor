	

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
	/// An component type implementation of the 'Project' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ProjectService : RLM.Construction.Services.ProjectServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ProjectService class.
		/// </summary>
		public ProjectService() : base()
		{
		}


        public Project GetItemByContractId(int contractId)
        {
            TList<Project> items = this.GetByContractId(contractId);
            return items != null && items.Count > 0 ? items[0] : null;
        }

        public TList<Project> GetByPartnerId(int partnerId, string orderBy)
        {
            string whereClause = string.Format("[ContractId] in (SELECT [ContractId] FROM Contract WHERE [PartnerId]='{0}')",partnerId);
            int total;
            return ServiceRepository.ProjectService.GetPaged(whereClause, orderBy, 0, 0, out total);
        }
    }//End Class


} // end namespace
