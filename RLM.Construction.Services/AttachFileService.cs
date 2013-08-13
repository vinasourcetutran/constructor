	

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
	/// An component type implementation of the 'AttachFile' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AttachFileService : RLM.Construction.Services.AttachFileServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the AttachFileService class.
		/// </summary>
		public AttachFileService() : base()
		{
		}


        public AttachFile GetItemByResourceIdAndType(int resourceId, ResourceType resourceType)
        {
            try
            {
                int total;
                string whereClause = string.Format("[ResourceType]={0} AND [ResourceId]={1}",(int)resourceType,resourceId);
                TList<AttachFile> files = this.GetPaged(whereClause, AttachFileColumn.AttachFileId.ToString(), 0, 0, out total);
                return files != null && files.Count > 0 ? files[0] : null;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return null;
        }
    }//End Class


} // end namespace
