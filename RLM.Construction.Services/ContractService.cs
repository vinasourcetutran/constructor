	

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
	/// An component type implementation of the 'Contract' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ContractService : RLM.Construction.Services.ContractServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ContractService class.
		/// </summary>
		public ContractService() : base()
		{
		}


        public TList<Contract> GetContractHaveNoProjectPaged(string whereClause, string orderBy,  int pageIndex,int pageSize, out int totalRecords)
        {
            try
            {
                string where = "([ContractId] NOT IN (SELECT DISTINCT [ContractId] FROM Project))";
                where += !string.IsNullOrEmpty(whereClause) ? " AND " + whereClause : where;
                return this.GetPaged(where, orderBy, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }//End Class


} // end namespace
