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
	/// This class is the base class for any <see cref="ItemMovementProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemMovementProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemMovement, RLM.Construction.Entities.ItemMovementKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemMovementKey key)
		{
			return Delete(transactionManager, key.RepositoryMovementId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="repositoryMovementId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 repositoryMovementId)
		{
			return Delete(null, repositoryMovementId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryMovementId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 repositoryMovementId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		FK_ItemMovements_Items Description: 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByItemId(System.Int64? itemId)
		{
			int count = -1;
			return GetByItemId(itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		FK_ItemMovements_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemMovement> GetByItemId(TransactionManager transactionManager, System.Int64? itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		FK_ItemMovements_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByItemId(TransactionManager transactionManager, System.Int64? itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		fKItemMovementsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByItemId(System.Int64? itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		fKItemMovementsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByItemId(System.Int64? itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Items key.
		///		FK_ItemMovements_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemMovement> GetByItemId(TransactionManager transactionManager, System.Int64? itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		FK_ItemMovements_Repositories Description: 
		/// </summary>
		/// <param name="fromRepositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(System.Int32? fromRepositoryId)
		{
			int count = -1;
			return GetByFromRepositoryId(fromRepositoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		FK_ItemMovements_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromRepositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(TransactionManager transactionManager, System.Int32? fromRepositoryId)
		{
			int count = -1;
			return GetByFromRepositoryId(transactionManager, fromRepositoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		FK_ItemMovements_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromRepositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(TransactionManager transactionManager, System.Int32? fromRepositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromRepositoryId(transactionManager, fromRepositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		fKItemMovementsRepositories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromRepositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(System.Int32? fromRepositoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromRepositoryId(null, fromRepositoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		fKItemMovementsRepositories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromRepositoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(System.Int32? fromRepositoryId, int start, int pageLength,out int count)
		{
			return GetByFromRepositoryId(null, fromRepositoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories key.
		///		FK_ItemMovements_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromRepositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemMovement> GetByFromRepositoryId(TransactionManager transactionManager, System.Int32? fromRepositoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		FK_ItemMovements_Repositories1 Description: 
		/// </summary>
		/// <param name="toRepositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(System.Int32? toRepositoryId)
		{
			int count = -1;
			return GetByToRepositoryId(toRepositoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		FK_ItemMovements_Repositories1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toRepositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(TransactionManager transactionManager, System.Int32? toRepositoryId)
		{
			int count = -1;
			return GetByToRepositoryId(transactionManager, toRepositoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		FK_ItemMovements_Repositories1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toRepositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(TransactionManager transactionManager, System.Int32? toRepositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByToRepositoryId(transactionManager, toRepositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		fKItemMovementsRepositories1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toRepositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(System.Int32? toRepositoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByToRepositoryId(null, toRepositoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		fKItemMovementsRepositories1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toRepositoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(System.Int32? toRepositoryId, int start, int pageLength,out int count)
		{
			return GetByToRepositoryId(null, toRepositoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemMovements_Repositories1 key.
		///		FK_ItemMovements_Repositories1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toRepositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemMovement objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemMovement> GetByToRepositoryId(TransactionManager transactionManager, System.Int32? toRepositoryId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.ItemMovement Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemMovementKey key, int start, int pageLength)
		{
			return GetByRepositoryMovementId(transactionManager, key.RepositoryMovementId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemMovements index.
		/// </summary>
		/// <param name="repositoryMovementId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(System.Int32 repositoryMovementId)
		{
			int count = -1;
			return GetByRepositoryMovementId(null,repositoryMovementId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemMovements index.
		/// </summary>
		/// <param name="repositoryMovementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(System.Int32 repositoryMovementId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryMovementId(null, repositoryMovementId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemMovements index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryMovementId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(TransactionManager transactionManager, System.Int32 repositoryMovementId)
		{
			int count = -1;
			return GetByRepositoryMovementId(transactionManager, repositoryMovementId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemMovements index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryMovementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(TransactionManager transactionManager, System.Int32 repositoryMovementId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryMovementId(transactionManager, repositoryMovementId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemMovements index.
		/// </summary>
		/// <param name="repositoryMovementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(System.Int32 repositoryMovementId, int start, int pageLength, out int count)
		{
			return GetByRepositoryMovementId(null, repositoryMovementId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemMovements index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryMovementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemMovement"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemMovement GetByRepositoryMovementId(TransactionManager transactionManager, System.Int32 repositoryMovementId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemMovement&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemMovement&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemMovement> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemMovement> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ItemMovement c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemMovement" 
							+ (reader.IsDBNull(reader.GetOrdinal("RepositoryMovementId"))?(int)0:(System.Int32)reader["RepositoryMovementId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemMovement>(
						key.ToString(), // EntityTrackingKey 
						"ItemMovement",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemMovement();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RepositoryMovementId = (System.Int32)reader["RepositoryMovementId"];
					c.ItemId = (reader.IsDBNull(reader.GetOrdinal("ItemId")))?null:(System.Int64?)reader["ItemId"];
					c.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
					c.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
					c.FromRepositoryManagerId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryManagerId")))?null:(System.Int32?)reader["FromRepositoryManagerId"];
					c.ToRepositoryManagerId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryManagerId")))?null:(System.Int32?)reader["ToRepositoryManagerId"];
					c.TransferUserId = (reader.IsDBNull(reader.GetOrdinal("TransferUserId")))?null:(System.Int32?)reader["TransferUserId"];
					c.ReceiverUserId = (reader.IsDBNull(reader.GetOrdinal("ReceiverUserId")))?null:(System.Int32?)reader["ReceiverUserId"];
					c.UnitPrice = (reader.IsDBNull(reader.GetOrdinal("UnitPrice")))?null:(System.Decimal?)reader["UnitPrice"];
					c.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
					c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
					c.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
					c.TotalAmount = (reader.IsDBNull(reader.GetOrdinal("TotalAmount")))?null:(System.Decimal?)reader["TotalAmount"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
					c.DeliveryDate = (reader.IsDBNull(reader.GetOrdinal("DeliveryDate")))?null:(System.DateTime?)reader["DeliveryDate"];
					c.ReceivedDate = (reader.IsDBNull(reader.GetOrdinal("ReceivedDate")))?null:(System.DateTime?)reader["ReceivedDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemMovement"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemMovement"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemMovement entity)
		{
			if (!reader.Read()) return;
			
			entity.RepositoryMovementId = (System.Int32)reader["RepositoryMovementId"];
			entity.ItemId = (reader.IsDBNull(reader.GetOrdinal("ItemId")))?null:(System.Int64?)reader["ItemId"];
			entity.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
			entity.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
			entity.FromRepositoryManagerId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryManagerId")))?null:(System.Int32?)reader["FromRepositoryManagerId"];
			entity.ToRepositoryManagerId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryManagerId")))?null:(System.Int32?)reader["ToRepositoryManagerId"];
			entity.TransferUserId = (reader.IsDBNull(reader.GetOrdinal("TransferUserId")))?null:(System.Int32?)reader["TransferUserId"];
			entity.ReceiverUserId = (reader.IsDBNull(reader.GetOrdinal("ReceiverUserId")))?null:(System.Int32?)reader["ReceiverUserId"];
			entity.UnitPrice = (reader.IsDBNull(reader.GetOrdinal("UnitPrice")))?null:(System.Decimal?)reader["UnitPrice"];
			entity.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
			entity.TotalAmount = (reader.IsDBNull(reader.GetOrdinal("TotalAmount")))?null:(System.Decimal?)reader["TotalAmount"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
			entity.DeliveryDate = (reader.IsDBNull(reader.GetOrdinal("DeliveryDate")))?null:(System.DateTime?)reader["DeliveryDate"];
			entity.ReceivedDate = (reader.IsDBNull(reader.GetOrdinal("ReceivedDate")))?null:(System.DateTime?)reader["ReceivedDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemMovement"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemMovement"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemMovement entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RepositoryMovementId = (System.Int32)dataRow["RepositoryMovementId"];
			entity.ItemId = (Convert.IsDBNull(dataRow["ItemId"]))?null:(System.Int64?)dataRow["ItemId"];
			entity.FromRepositoryId = (Convert.IsDBNull(dataRow["FromRepositoryId"]))?null:(System.Int32?)dataRow["FromRepositoryId"];
			entity.ToRepositoryId = (Convert.IsDBNull(dataRow["ToRepositoryId"]))?null:(System.Int32?)dataRow["ToRepositoryId"];
			entity.FromRepositoryManagerId = (Convert.IsDBNull(dataRow["FromRepositoryManagerId"]))?null:(System.Int32?)dataRow["FromRepositoryManagerId"];
			entity.ToRepositoryManagerId = (Convert.IsDBNull(dataRow["ToRepositoryManagerId"]))?null:(System.Int32?)dataRow["ToRepositoryManagerId"];
			entity.TransferUserId = (Convert.IsDBNull(dataRow["TransferUserId"]))?null:(System.Int32?)dataRow["TransferUserId"];
			entity.ReceiverUserId = (Convert.IsDBNull(dataRow["ReceiverUserId"]))?null:(System.Int32?)dataRow["ReceiverUserId"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?null:(System.Decimal?)dataRow["UnitPrice"];
			entity.PriceUnitId = (Convert.IsDBNull(dataRow["PriceUnitId"]))?null:(System.Int32?)dataRow["PriceUnitId"];
			entity.ExchangeRate = (Convert.IsDBNull(dataRow["ExchangeRate"]))?null:(System.Int32?)dataRow["ExchangeRate"];
			entity.TotalQuantity = (Convert.IsDBNull(dataRow["TotalQuantity"]))?null:(System.Int64?)dataRow["TotalQuantity"];
			entity.TotalAmount = (Convert.IsDBNull(dataRow["TotalAmount"]))?null:(System.Decimal?)dataRow["TotalAmount"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Int64?)dataRow["IsActive"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Boolean?)dataRow["IsApprove"];
			entity.DeliveryDate = (Convert.IsDBNull(dataRow["DeliveryDate"]))?null:(System.DateTime?)dataRow["DeliveryDate"];
			entity.ReceivedDate = (Convert.IsDBNull(dataRow["ReceivedDate"]))?null:(System.DateTime?)dataRow["ReceivedDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemMovement"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemMovement Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemMovement entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Item", "ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ItemId ?? (long)0);
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemProvider.GetByItemId((entity.ItemId ?? (long)0));
			
				if (deep && entity.ItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ItemIdSource

			#region FromRepositoryIdSource	
			if (CanDeepLoad(entity, "Repository", "FromRepositoryIdSource", deepLoadType, innerList) 
				&& entity.FromRepositoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.FromRepositoryId ?? (int)0);
				Repository tmpEntity = EntityManager.LocateEntity<Repository>(EntityLocator.ConstructKeyFromPkItems(typeof(Repository), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromRepositoryIdSource = tmpEntity;
				else
					entity.FromRepositoryIdSource = DataRepository.RepositoryProvider.GetByRepositoryId((entity.FromRepositoryId ?? (int)0));
			
				if (deep && entity.FromRepositoryIdSource != null)
				{
					DataRepository.RepositoryProvider.DeepLoad(transactionManager, entity.FromRepositoryIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion FromRepositoryIdSource

			#region ToRepositoryIdSource	
			if (CanDeepLoad(entity, "Repository", "ToRepositoryIdSource", deepLoadType, innerList) 
				&& entity.ToRepositoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ToRepositoryId ?? (int)0);
				Repository tmpEntity = EntityManager.LocateEntity<Repository>(EntityLocator.ConstructKeyFromPkItems(typeof(Repository), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToRepositoryIdSource = tmpEntity;
				else
					entity.ToRepositoryIdSource = DataRepository.RepositoryProvider.GetByRepositoryId((entity.ToRepositoryId ?? (int)0));
			
				if (deep && entity.ToRepositoryIdSource != null)
				{
					DataRepository.RepositoryProvider.DeepLoad(transactionManager, entity.ToRepositoryIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ToRepositoryIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemMovement object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemMovement instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemMovement Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemMovement entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ItemIdSource
			if (CanDeepSave(entity, "Item", "ItemIdSource", deepSaveType, innerList) 
				&& entity.ItemIdSource != null)
			{
				DataRepository.ItemProvider.Save(transactionManager, entity.ItemIdSource);
				entity.ItemId = entity.ItemIdSource.ItemId;
			}
			#endregion 
			
			#region FromRepositoryIdSource
			if (CanDeepSave(entity, "Repository", "FromRepositoryIdSource", deepSaveType, innerList) 
				&& entity.FromRepositoryIdSource != null)
			{
				DataRepository.RepositoryProvider.Save(transactionManager, entity.FromRepositoryIdSource);
				entity.FromRepositoryId = entity.FromRepositoryIdSource.RepositoryId;
			}
			#endregion 
			
			#region ToRepositoryIdSource
			if (CanDeepSave(entity, "Repository", "ToRepositoryIdSource", deepSaveType, innerList) 
				&& entity.ToRepositoryIdSource != null)
			{
				DataRepository.RepositoryProvider.Save(transactionManager, entity.ToRepositoryIdSource);
				entity.ToRepositoryId = entity.ToRepositoryIdSource.RepositoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ItemMovementChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemMovement</c>
	///</summary>
	public enum ItemMovementChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Item</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
			
		///<summary>
		/// Composite Property for <c>Repository</c> at FromRepositoryIdSource
		///</summary>
		[ChildEntityType(typeof(Repository))]
		Repository,
		}
	
	#endregion ItemMovementChildEntityTypes
	
	#region ItemMovementFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemMovement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemMovementFilterBuilder : SqlFilterBuilder<ItemMovementColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemMovementFilterBuilder class.
		/// </summary>
		public ItemMovementFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemMovementFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemMovementFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemMovementFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemMovementFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemMovementFilterBuilder
	
	#region ItemMovementParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemMovement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemMovementParameterBuilder : ParameterizedSqlFilterBuilder<ItemMovementColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemMovementParameterBuilder class.
		/// </summary>
		public ItemMovementParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemMovementParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemMovementParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemMovementParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemMovementParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemMovementParameterBuilder
} // end namespace
