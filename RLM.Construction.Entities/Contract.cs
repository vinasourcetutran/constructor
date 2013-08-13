#region Using directives

using System;

#endregion

namespace RLM.Construction.Entities
{	
	///<summary>
	/// An object representation of the 'Contract' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Contract : ContractBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Contract"/> instance.
		///</summary>
		public Contract():base(){}	
		
		#endregion


        #region Properties
        public int Days { get; set; }
        public int RealDays { get; set; }
        #endregion
    }
}
