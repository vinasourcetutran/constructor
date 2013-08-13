	

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
	/// An component type implementation of the 'Comment' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CommentService : RLM.Construction.Services.CommentServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the CommentService class.
		/// </summary>
		public CommentService() : base()
		{
		}


        public TList<Comment> GetByResource(ResourceType resourceType, int resourceId, string orderBy, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                string whereClause = string.Format("[ResourceType]={0} AND [ResourceId]={1}", (int)resourceType, resourceId);
                return this.GetPaged(whereClause, orderBy, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                RLM.Core.Framework.Log.Logger.Info(ex);
                totalRecords = 0;
                return null;
            }
        }
    }//End Class


} // end namespace
