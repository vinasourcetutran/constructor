	

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
	/// An component type implementation of the 'TaskMember' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class TaskMemberService : RLM.Construction.Services.TaskMemberServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the TaskMemberService class.
		/// </summary>
		public TaskMemberService() : base()
		{
		}


        public TList<TaskMember> GetByResource(ResourceType resourceType, int resourceId)
        {
            string whereClause = string.Format("[ResourceType]={0} AND [ResourceId]={1}",(int)resourceType,resourceId);
            int total;
            return this.GetPaged(whereClause, TaskMemberColumn.LastModificationDate.ToString() + " DESC", 0, 0, out total);
        }
    }//End Class


} // end namespace
