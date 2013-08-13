	

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
using RLM.Construction.Data.Bases;

#endregion

namespace RLM.Construction.Services
{		
	
	///<summary>
	/// An component type implementation of the 'ItemIOItem' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ItemIOItemService : RLM.Construction.Services.ItemIOItemServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ItemIOItemService class.
		/// </summary>
		public ItemIOItemService() : base()
		{
		}


        public TList<ItemIOItem> GetByItemIOTicketId(int itemIOTicketId)
        {
            string whereClause = string.Format("[IOTicketId]={0}",itemIOTicketId);
            int total;
            return this.GetPaged(whereClause, ItemIOItemColumn.LastModificationDate + " DESC", 0, 0, out total);
        }

        public ItemIOItem GetByTicketIdAndItemId(int ticketId, int itemId)
        {
            string whereClause = string.Format("[ItemId]={0} AND [IOTicketId]={1}", itemId, ticketId);
            int total;
            TList<ItemIOItem> items = this.GetPaged(whereClause, ItemIOItemColumn.ItemId.ToString(),0,0,out total);
            return items != null && items.Count > 0 ? items[0] : null;
        }

        public TList<ItemIOItem> GetByItemIdAndType(int itemId, ItemIOTicketType ioType, int pageSize, int pageIndex, out int totalRecords)
        {
            // throws security exception if not authorized
            SecurityContext.IsAuthorized("GetByItemIdAndType");

            // get this data
            TList<ItemIOItem> list = null;
            totalRecords = -1;
            TransactionManager transactionManager = null;

            try
            {
                //since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
                transactionManager = ConnectionScope.ValidateOrCreateTransaction(false);
                NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;

                //Access repository
                list = dataProvider.ItemIOItemProvider.GetByItemIdAndType(transactionManager, itemId, ioType, pageSize, pageIndex, out totalRecords);

                //if borrowed tran, leave open for next call
            }
            catch (Exception exc)
            {
                //if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen)
                    transactionManager.Rollback();
            }
            return list;
        }
    }//End Class


} // end namespace
