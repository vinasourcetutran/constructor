	

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
	/// An component type implementation of the 'Task' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class TaskService : RLM.Construction.Services.TaskServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the TaskService class.
		/// </summary>
		public TaskService() : base()
		{
		}


        public TList<Task> GetByResource(ResourceType resourceType, int resourceId, bool isActiveOnly)
        {
            string whereCluase = string.Empty;
            if (resourceType != ResourceType.Project && resourceType != ResourceType.ProjectPhase && resourceType != ResourceType.Contract)
            {
                whereCluase = string.Format("[ResourceId]={0} AND ResourceType={1}",resourceId,(int)resourceType);
            }
            if (resourceType == ResourceType.Project)
            {
                whereCluase = string.Format("[ProjectId]={0} AND ResourceType={1}", resourceId, (int)resourceType);
            }

            if (resourceType == ResourceType.Contract)
            {
                whereCluase = string.Format("[ContractId]={0} AND ResourceType={1}", resourceId, (int)resourceType);
            }

            if (resourceType == ResourceType.ProjectPhase)
            {
                whereCluase = string.Format("[ProjectPhaseId]={0} AND ResourceType={1}", resourceId, (int)resourceType);
            }
            whereCluase = string.Format("{0} AND ([IsActive]={1} OR {1}=0)", whereCluase,isActiveOnly?"1":"0");
            int total;
            return this.GetPaged(whereCluase,TaskColumn.LastModificationDate.ToString()+" DESC",0,0,out total);
        }
    }//End Class


} // end namespace
