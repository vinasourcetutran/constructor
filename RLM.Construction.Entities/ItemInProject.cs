#region Using directives

using System;

#endregion

namespace RLM.Construction.Entities
{	
	///<summary>
	/// An object representation of the 'ItemInProject' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ItemInProject : ItemInProjectBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="ItemInProject"/> instance.
		///</summary>
		public ItemInProject():base(){}	
		
		#endregion

        #region Variables
        GraphDataItemType dataItemType=GraphDataItemType.Quantity;
        #endregion
    }
}
