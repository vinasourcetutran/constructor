	

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
	/// An component type implementation of the 'Group' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class GroupService : RLM.Construction.Services.GroupServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the GroupService class.
		/// </summary>
		public GroupService() : base()
		{
		}


        public TList<Group> GetByType(GroupType type)
        {
            int total;
            string whereClause = string.Format("[Type]={0}", (int)type);
            return this.GetPaged(whereClause, "[Name] ASC", 0, 0, out total);
        }

        public TList<Group> GetByType(int parentId, GroupType type, bool isActive)
        {
            string whereCause = string.Format(
                    "([ParentGroupId]={0} OR {0}=0) AND [Type]={1} AND ([IsActive]={2} OR {2}=0)",
                    parentId,
                    (int)type,
                    isActive?"1":"0"
                );
            int temp;
            return this.GetPaged(whereCause,GroupColumn.Priority +" DESC,"+ GroupColumn.Name+" ASC",0,0, out temp);
        }
    }//End Class


} // end namespace
