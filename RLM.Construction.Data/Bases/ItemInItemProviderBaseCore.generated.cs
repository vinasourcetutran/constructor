#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using RLM.Construction.Entities;
using RLM.Construction.Data;

#endregion

namespace RLM.Construction.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ItemInItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemInItemProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemInItem, RLM.Construction.Entities.ItemInItemKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemInItemKey key)
		{
			return Delete(transactionManager, key.ItemInItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="itemInItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 itemInItemId)
		{
			return Delete(null, itemInItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 itemInItemId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		FK_ItemInItem_Item Description: 
		/// </summary>
		/// <param name="fromItemId">Detail item id</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(System.Int64 fromItemId)
		{
			int count = -1;
			return GetByFromItemId(fromItemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		FK_ItemInItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromItemId">Detail item id</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(TransactionManager transactionManager, System.Int64 fromItemId)
		{
			int count = -1;
			return GetByFromItemId(transactionManager, fromItemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		FK_ItemInItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromItemId">Detail item id</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(TransactionManager transactionManager, System.Int64 fromItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromItemId(transactionManager, fromItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		fKItemInItemItem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromItemId">Detail item id</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(System.Int64 fromItemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromItemId(null, fromItemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		fKItemInItemItem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromItemId">Detail item id</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(System.Int64 fromItemId, int start, int pageLength,out int count)
		{
			return GetByFromItemId(null, fromItemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item key.
		///		FK_ItemInItem_Item Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromItemId">Detail item id</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInItem> GetByFromItemId(TransactionManager transactionManager, System.Int64 fromItemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		FK_ItemInItem_Item1 Description: 
		/// </summary>
		/// <param name="toItemId">master item id</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(System.Int64 toItemId)
		{
			int count = -1;
			return GetByToItemId(toItemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		FK_ItemInItem_Item1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toItemId">master item id</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(TransactionManager transactionManager, System.Int64 toItemId)
		{
			int count = -1;
			return GetByToItemId(transactionManager, toItemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		FK_ItemInItem_Item1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toItemId">master item id</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(TransactionManager transactionManager, System.Int64 toItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByToItemId(transactionManager, toItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		fKItemInItemItem1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toItemId">master item id</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(System.Int64 toItemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByToItemId(null, toItemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		fKItemInItemItem1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toItemId">master item id</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(System.Int64 toItemId, int start, int pageLength,out int count)
		{
			return GetByToItemId(null, toItemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInItem_Item1 key.
		///		FK_ItemInItem_Item1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toItemId">master item id</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInItem objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInItem> GetByToItemId(TransactionManager transactionManager, System.Int64 toItemId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override RLM.Construction.Entities.ItemInItem Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemInItemKey key, int start, int pageLength)
		{
			return GetByItemInItemId(transactionManager, key.ItemInItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemInItem index.
		/// </summary>
		/// <param name="itemInItemId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public RLM.Construction.Entities.ItemInItem GetByItemInItemId(System.Int32 itemInItemId)
		{
			int count = -1;
			return GetByItemInItemId(null,itemInItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInItem index.
		/// </summary>
		/// <param name="itemInItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public RLM.Construction.Entities.ItemInItem GetByItemInItemId(System.Int32 itemInItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemInItemId(null, itemInItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInItemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public RLM.Construction.Entities.ItemInItem GetByItemInItemId(TransactionManager transactionManager, System.Int32 itemInItemId)
		{
			int count = -1;
			return GetByItemInItemId(transactionManager, itemInItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public RLM.Construction.Entities.ItemInItem GetByItemInItemId(TransactionManager transactionManager, System.Int32 itemInItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemInItemId(transactionManager, itemInItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInItem index.
		/// </summary>
		/// <param name="itemInItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public RLM.Construction.Entities.ItemInItem GetByItemInItemId(System.Int32 itemInItemId, int start, int pageLength, out int count)
		{
			return GetByItemInItemId(null, itemInItemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInItem"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemInItem GetByItemInItemId(TransactionManager transactionManager, System.Int32 itemInItemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemInItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemInItem&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemInItem> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemInItem> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				RLM.Construction.Entities.ItemInItem c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemInItem" 
							+ (reader.IsDBNull(reader.GetOrdinal("ItemInItemId"))?(int)0:(System.Int32)reader["ItemInItemId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemInItem>(
						key.ToString(), // EntityTrackingKey 
						"ItemInItem",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemInItem();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ItemInItemId = (System.Int32)reader["ItemInItemId"];
					c.FromItemId = (System.Int64)reader["FromItemId"];
					c.ToItemId = (System.Int64)reader["ToItemId"];
					c.UnitId = (reader.IsDBNull(reader.GetOrdinal("UnitId")))?null:(System.Int32?)reader["UnitId"];
					c.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Double?)reader["Quantity"];
					c.UnitPrice = (reader.IsDBNull(reader.GetOrdinal("UnitPrice")))?null:(System.Decimal?)reader["UnitPrice"];
					c.Total = (reader.IsDBNull(reader.GetOrdinal("Total")))?null:(System.Decimal?)reader["Total"];
					c.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemInItem entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemInItemId = (System.Int32)reader["ItemInItemId"];
			entity.FromItemId = (System.Int64)reader["FromItemId"];
			entity.ToItemId = (System.Int64)reader["ToItemId"];
			entity.UnitId = (reader.IsDBNull(reader.GetOrdinal("UnitId")))?null:(System.Int32?)reader["UnitId"];
			entity.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Double?)reader["Quantity"];
			entity.UnitPrice = (reader.IsDBNull(reader.GetOrdinal("UnitPrice")))?null:(System.Decimal?)reader["UnitPrice"];
			entity.Total = (reader.IsDBNull(reader.GetOrdinal("Total")))?null:(System.Decimal?)reader["Total"];
			entity.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemInItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemInItemId = (System.Int32)dataRow["ItemInItemId"];
			entity.FromItemId = (System.Int64)dataRow["FromItemId"];
			entity.ToItemId = (System.Int64)dataRow["ToItemId"];
			entity.UnitId = (Convert.IsDBNull(dataRow["UnitId"]))?null:(System.Int32?)dataRow["UnitId"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?null:(System.Double?)dataRow["Quantity"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?null:(System.Decimal?)dataRow["UnitPrice"];
			entity.Total = (Convert.IsDBNull(dataRow["Total"]))?null:(System.Decimal?)dataRow["Total"];
			entity.ParentPath = (Convert.IsDBNull(dataRow["ParentPath"]))?null:(System.String)dataRow["ParentPath"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemInItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region FromItemIdSource	
			if (CanDeepLoad(entity, "Item", "FromItemIdSource", deepLoadType, innerList) 
				&& entity.FromItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FromItemId;
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromItemIdSource = tmpEntity;
				else
					entity.FromItemIdSource = DataRepository.ItemProvider.GetByItemId(entity.FromItemId);
			
				if (deep && entity.FromItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.FromItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion FromItemIdSource

			#region ToItemIdSource	
			if (CanDeepLoad(entity, "Item", "ToItemIdSource", deepLoadType, innerList) 
				&& entity.ToItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ToItemId;
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToItemIdSource = tmpEntity;
				else
					entity.ToItemIdSource = DataRepository.ItemProvider.GetByItemId(entity.ToItemId);
			
				if (deep && entity.ToItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ToItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ToItemIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemInItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemInItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemInItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FromItemIdSource
			if (CanDeepSave(entity, "Item", "FromItemIdSource", deepSaveType, innerList) 
				&& entity.FromItemIdSource != null)
			{
				DataRepository.ItemProvider.Save(transactionManager, entity.FromItemIdSource);
				entity.FromItemId = entity.FromItemIdSource.ItemId;
			}
			#endregion 
			
			#region ToItemIdSource
			if (CanDeepSave(entity, "Item", "ToItemIdSource", deepSaveType, innerList) 
				&& entity.ToItemIdSource != null)
			{
				DataRepository.ItemProvider.Save(transactionManager, entity.ToItemIdSource);
				entity.ToItemId = entity.ToItemIdSource.ItemId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ItemInItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemInItem</c>
	///</summary>
	public enum ItemInItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Item</c> at FromItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
		}
	
	#endregion ItemInItemChildEntityTypes
	
	#region ItemInItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInItemFilterBuilder : SqlFilterBuilder<ItemInItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInItemFilterBuilder class.
		/// </summary>
		public ItemInItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInItemFilterBuilder
	
	#region ItemInItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInItemParameterBuilder : ParameterizedSqlFilterBuilder<ItemInItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInItemParameterBuilder class.
		/// </summary>
		public ItemInItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInItemParameterBuilder
} // end namespace
