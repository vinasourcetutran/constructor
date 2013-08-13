	

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
	/// An component type implementation of the 'ItemInItem' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ItemInItemService : RLM.Construction.Services.ItemInItemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ItemInItemService class.
		/// </summary>
		public ItemInItemService() : base()
		{
		}


        public ItemInItem GetItemByFromItemAndToItem(long fromItemId, long toItemId)
        {
            string whereClause = string.Format("[FromItemId]={0} AND [ToItemId]={1}",fromItemId, toItemId);
            int total;
            TList<ItemInItem> items = this.GetPaged(whereClause, ItemInItemColumn.LastModificationDate.ToString(), 0, 0, out total);
            return items != null && items.Count > 0 ? items[0] : null;
        }
    }//End Class


} // end namespace
