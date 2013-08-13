	

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
	/// An component type implementation of the 'Department' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class DepartmentService : RLM.Construction.Services.DepartmentServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the DepartmentService class.
		/// </summary>
		public DepartmentService() : base()
		{
		}
		
	}//End Class


} // end namespace
