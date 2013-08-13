﻿#region Using directives

using System;

#endregion

namespace RLM.Construction.Entities
{	
	///<summary>
	/// An object representation of the 'Staff' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Staff : StaffBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Staff"/> instance.
		///</summary>
		public Staff():base(){}	
		
		#endregion

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
	}
}
