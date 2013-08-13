	

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
	/// An component type implementation of the 'ResourceData' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ResourceDataService : RLM.Construction.Services.ResourceDataServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ResourceDataService class.
		/// </summary>
		public ResourceDataService() : base()
		{
		}


        public TList<ResourceData> GetByResource(int resourceId, ResourceType resourceType, ResourceDataContentType contentType)
        {
            string whereClause = string.Format(
                "[ResourceId]={0} AND ResourceType={1} AND ContentType={2}",
                resourceId,
                (int)resourceType, 
                (int)contentType
                );
            int temp = 0;
            return this.GetPaged(whereClause, ResourceDataColumn.Title + " ASC", 0, 0, out temp);
        }
    }//End Class


} // end namespace
