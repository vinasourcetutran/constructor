	

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
using RLM.Construction.ServiceHelpers;

#endregion

namespace RLM.Construction.Services
{		
	
	///<summary>
	/// An component type implementation of the 'Item' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ItemService : RLM.Construction.Services.ItemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ItemService class.
		/// </summary>
		public ItemService() : base()
		{
		}


        internal decimal GetItemPrice(ItemInProject item, int unitId)
        {
            if (item.PriceUnitId == unitId) { return item.UnitPrice; }
            double unitWeight = UnitTree.Translate(item.PriceUnitId.Value, unitId);
            return (decimal)unitWeight * item.UnitPrice;
        }

        public TList<Item> GetByProjectPhaseIds(string projectPhaseIds)
        {
            string whereClause = string.Format("ItemId in (Select ItemId from ItemInProject where ProjectPhaseId in ({0}))",projectPhaseIds);
            int total;
            return this.GetPaged(whereClause, ItemColumn.Name.ToString(), 0, 0, out total);
        }
    }//End Class


} // end namespace
