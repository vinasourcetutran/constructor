	

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
	/// An component type implementation of the 'ProjectPhase' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ProjectPhaseService : RLM.Construction.Services.ProjectPhaseServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ProjectPhaseService class.
		/// </summary>
		public ProjectPhaseService() : base()
		{
		}


        public ProjectPhase GetCurrentPhaseByProjectId(int projectId)
        {
            try
            {
                int total;
                string whereClause = string.Format("[ProjectId]={0} AND [IsCurrentProjectPhase]=1",projectId);
                TList<ProjectPhase> items = this.GetPaged(whereClause, ProjectPhaseColumn.Name.ToString(), 0, 0, out total);
                return items != null && items.Count > 0 ? items[0] : null;

            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Error(ex);
                return null;
            }
        }

        public TList<ProjectPhase> GetByProjectId(int projectId, string ignoreId)
        {
            if (string.IsNullOrEmpty(ignoreId))
            {
                return this.GetByProjectId(projectId);
            }
            int total;
            string whereClause = string.Format("[ProjectId]={0} AND [ProjectPhaseId] NOT IN ({1})", projectId, ignoreId);
            return this.GetPaged(whereClause, ProjectPhaseColumn.Name.ToString(), 0, 0, out total);
        }

        public TList<ProjectPhase> GetByContractId(int contractId, string ignoreId)
        {
            if (string.IsNullOrEmpty(ignoreId))
            {
                return this.GetByContractId(contractId);
            }
            int total;
            string whereClause = string.Format("[ContractId]={0} AND [ProjectPhaseId] NOT IN ({1})", contractId, ignoreId);
            return this.GetPaged(whereClause, ProjectPhaseColumn.Name.ToString(), 0, 0, out total);
        }
    }//End Class


} // end namespace
