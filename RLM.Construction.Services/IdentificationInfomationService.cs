	

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
	/// An component type implementation of the 'IdentificationInfomation' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class IdentificationInfomationService : RLM.Construction.Services.IdentificationInfomationServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationService class.
		/// </summary>
		public IdentificationInfomationService() : base()
		{
		}
		
	}//End Class


} // end namespace