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
	/// This class is the base class for any <see cref="ItemInRepositoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemInRepositoryProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemInRepository, RLM.Construction.Entities.ItemInRepositoryKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemInRepositoryKey key)
		{
			return Delete(transactionManager, key.RepositoryId, key.ItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="repositoryId">. Primary Key.</param>
		/// <param name="itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 repositoryId, System.Int64 itemId)
		{
			return Delete(null, repositoryId, itemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId">. Primary Key.</param>
		/// <param name="itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 repositoryId, System.Int64 itemId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		FK_ItemInRepositories_Items Description: 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		FK_ItemInRepositories_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(TransactionManager transactionManager, System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		FK_ItemInRepositories_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		fKItemInRepositoriesItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(System.Int64 itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		fKItemInRepositoriesItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(System.Int64 itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Items key.
		///		FK_ItemInRepositories_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInRepository> GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		FK_ItemInRepositories_Repositories Description: 
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryId(repositoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		FK_ItemInRepositories_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryId(transactionManager, repositoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		FK_ItemInRepositories_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryId(transactionManager, repositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		fKItemInRepositoriesRepositories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="repositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(System.Int32 repositoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRepositoryId(null, repositoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		fKItemInRepositoriesRepositories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="repositoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(System.Int32 repositoryId, int start, int pageLength,out int count)
		{
			return GetByRepositoryId(null, repositoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepositories_Repositories key.
		///		FK_ItemInRepositories_Repositories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInRepository> GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		FK_ItemInRepository_Unit Description: 
		/// </summary>
		/// <param name="priceUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(System.Int32? priceUnitId)
		{
			int count = -1;
			return GetByPriceUnitId(priceUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		FK_ItemInRepository_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId)
		{
			int count = -1;
			return GetByPriceUnitId(transactionManager, priceUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		FK_ItemInRepository_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriceUnitId(transactionManager, priceUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		fKItemInRepositoryUnit Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="priceUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(System.Int32? priceUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPriceUnitId(null, priceUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		fKItemInRepositoryUnit Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="priceUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(System.Int32? priceUnitId, int start, int pageLength,out int count)
		{
			return GetByPriceUnitId(null, priceUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInRepository_Unit key.
		///		FK_ItemInRepository_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInRepository objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInRepository> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.ItemInRepository Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemInRepositoryKey key, int start, int pageLength)
		{
			return GetByRepositoryIdItemId(transactionManager, key.RepositoryId, key.ItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemInRepositories index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(System.Int32 repositoryId, System.Int64 itemId)
		{
			int count = -1;
			return GetByRepositoryIdItemId(null,repositoryId, itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInRepositories index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(System.Int32 repositoryId, System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryIdItemId(null, repositoryId, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInRepositories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(TransactionManager transactionManager, System.Int32 repositoryId, System.Int64 itemId)
		{
			int count = -1;
			return GetByRepositoryIdItemId(transactionManager, repositoryId, itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInRepositories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(TransactionManager transactionManager, System.Int32 repositoryId, System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryIdItemId(transactionManager, repositoryId, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInRepositories index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(System.Int32 repositoryId, System.Int64 itemId, int start, int pageLength, out int count)
		{
			return GetByRepositoryIdItemId(null, repositoryId, itemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInRepositories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInRepository"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemInRepository GetByRepositoryIdItemId(TransactionManager transactionManager, System.Int32 repositoryId, System.Int64 itemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemInRepository&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemInRepository&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemInRepository> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemInRepository> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ItemInRepository c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemInRepository" 
							+ (reader.IsDBNull(reader.GetOrdinal("RepositoryId"))?(int)0:(System.Int32)reader["RepositoryId"]).ToString()
							+ (reader.IsDBNull(reader.GetOrdinal("ItemId"))?(long)0:(System.Int64)reader["ItemId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemInRepository>(
						key.ToString(), // EntityTrackingKey 
						"ItemInRepository",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemInRepository();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RepositoryId = (System.Int32)reader["RepositoryId"];
					c.OriginalRepositoryId = c.RepositoryId; //(reader.IsDBNull(reader.GetOrdinal("RepositoryId")))?(int)0:(System.Int32)reader["RepositoryId"];
					c.ItemId = (System.Int64)reader["ItemId"];
					c.OriginalItemId = c.ItemId; //(reader.IsDBNull(reader.GetOrdinal("ItemId")))?(long)0:(System.Int64)reader["ItemId"];
					c.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
					c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
					c.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
					c.AvailabelQuantity = (reader.IsDBNull(reader.GetOrdinal("AvailabelQuantity")))?null:(System.Int64?)reader["AvailabelQuantity"];
					c.ReserveQuantity = (reader.IsDBNull(reader.GetOrdinal("ReserveQuantity")))?null:(System.Int64?)reader["ReserveQuantity"];
					c.ReturnQuantity = (reader.IsDBNull(reader.GetOrdinal("ReturnQuantity")))?null:(System.Int64?)reader["ReturnQuantity"];
					c.AdjustQuantity = (reader.IsDBNull(reader.GetOrdinal("AdjustQuantity")))?null:(System.Int64?)reader["AdjustQuantity"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.BaseUnitId = (reader.IsDBNull(reader.GetOrdinal("BaseUnitId")))?null:(System.Int32?)reader["BaseUnitId"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInRepository"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInRepository"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemInRepository entity)
		{
			if (!reader.Read()) return;
			
			entity.RepositoryId = (System.Int32)reader["RepositoryId"];
			entity.OriginalRepositoryId = (System.Int32)reader["RepositoryId"];
			entity.ItemId = (System.Int64)reader["ItemId"];
			entity.OriginalItemId = (System.Int64)reader["ItemId"];
			entity.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
			entity.AvailabelQuantity = (reader.IsDBNull(reader.GetOrdinal("AvailabelQuantity")))?null:(System.Int64?)reader["AvailabelQuantity"];
			entity.ReserveQuantity = (reader.IsDBNull(reader.GetOrdinal("ReserveQuantity")))?null:(System.Int64?)reader["ReserveQuantity"];
			entity.ReturnQuantity = (reader.IsDBNull(reader.GetOrdinal("ReturnQuantity")))?null:(System.Int64?)reader["ReturnQuantity"];
			entity.AdjustQuantity = (reader.IsDBNull(reader.GetOrdinal("AdjustQuantity")))?null:(System.Int64?)reader["AdjustQuantity"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.BaseUnitId = (reader.IsDBNull(reader.GetOrdinal("BaseUnitId")))?null:(System.Int32?)reader["BaseUnitId"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInRepository"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInRepository"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemInRepository entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RepositoryId = (System.Int32)dataRow["RepositoryId"];
			entity.OriginalRepositoryId = (System.Int32)dataRow["RepositoryId"];
			entity.ItemId = (System.Int64)dataRow["ItemId"];
			entity.OriginalItemId = (System.Int64)dataRow["ItemId"];
			entity.PriceUnitId = (Convert.IsDBNull(dataRow["PriceUnitId"]))?null:(System.Int32?)dataRow["PriceUnitId"];
			entity.ExchangeRate = (Convert.IsDBNull(dataRow["ExchangeRate"]))?null:(System.Int32?)dataRow["ExchangeRate"];
			entity.TotalQuantity = (Convert.IsDBNull(dataRow["TotalQuantity"]))?null:(System.Int64?)dataRow["TotalQuantity"];
			entity.AvailabelQuantity = (Convert.IsDBNull(dataRow["AvailabelQuantity"]))?null:(System.Int64?)dataRow["AvailabelQuantity"];
			entity.ReserveQuantity = (Convert.IsDBNull(dataRow["ReserveQuantity"]))?null:(System.Int64?)dataRow["ReserveQuantity"];
			entity.ReturnQuantity = (Convert.IsDBNull(dataRow["ReturnQuantity"]))?null:(System.Int64?)dataRow["ReturnQuantity"];
			entity.AdjustQuantity = (Convert.IsDBNull(dataRow["AdjustQuantity"]))?null:(System.Int64?)dataRow["AdjustQuantity"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.BaseUnitId = (Convert.IsDBNull(dataRow["BaseUnitId"]))?null:(System.Int32?)dataRow["BaseUnitId"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInRepository"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInRepository Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemInRepository entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Item", "ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ItemId;
				Item tmpEntity = EntityManager.LocateEntity<Item>(EntityLocator.ConstructKeyFromPkItems(typeof(Item), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemProvider.GetByItemId(entity.ItemId);
			
				if (deep && entity.ItemIdSource != null)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ItemIdSource

			#region RepositoryIdSource	
			if (CanDeepLoad(entity, "Repository", "RepositoryIdSource", deepLoadType, innerList) 
				&& entity.RepositoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RepositoryId;
				Repository tmpEntity = EntityManager.LocateEntity<Repository>(EntityLocator.ConstructKeyFromPkItems(typeof(Repository), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RepositoryIdSource = tmpEntity;
				else
					entity.RepositoryIdSource = DataRepository.RepositoryProvider.GetByRepositoryId(entity.RepositoryId);
			
				if (deep && entity.RepositoryIdSource != null)
				{
					DataRepository.RepositoryProvider.DeepLoad(transactionManager, entity.RepositoryIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion RepositoryIdSource

			#region PriceUnitIdSource	
			if (CanDeepLoad(entity, "Unit", "PriceUnitIdSource", deepLoadType, innerList) 
				&& entity.PriceUnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PriceUnitId ?? (int)0);
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PriceUnitIdSource = tmpEntity;
				else
					entity.PriceUnitIdSource = DataRepository.UnitProvider.GetByUnitId((entity.PriceUnitId ?? (int)0));
			
				if (deep && entity.PriceUnitIdSource != null)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.PriceUnitIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PriceUnitIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemInRepository object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemInRepository instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInRepository Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemInRepository entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			#region RepositoryIdSource
			if (CanDeepSave(entity, "Repository", "RepositoryIdSource", deepSaveType, innerList) 
				&& entity.RepositoryIdSource != null)
			{
				DataRepository.RepositoryProvider.Save(transactionManager, entity.RepositoryIdSource);
				entity.RepositoryId = entity.RepositoryIdSource.RepositoryId;
			}
			#endregion 
			
			#region PriceUnitIdSource
			if (CanDeepSave(entity, "Unit", "PriceUnitIdSource", deepSaveType, innerList) 
				&& entity.PriceUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.PriceUnitIdSource);
				entity.PriceUnitId = entity.PriceUnitIdSource.UnitId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ItemInRepositoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemInRepository</c>
	///</summary>
	public enum ItemInRepositoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Item</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
			
		///<summary>
		/// Composite Property for <c>Repository</c> at RepositoryIdSource
		///</summary>
		[ChildEntityType(typeof(Repository))]
		Repository,
			
		///<summary>
		/// Composite Property for <c>Unit</c> at PriceUnitIdSource
		///</summary>
		[ChildEntityType(typeof(Unit))]
		Unit,
		}
	
	#endregion ItemInRepositoryChildEntityTypes
	
	#region ItemInRepositoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInRepository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInRepositoryFilterBuilder : SqlFilterBuilder<ItemInRepositoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryFilterBuilder class.
		/// </summary>
		public ItemInRepositoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInRepositoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInRepositoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInRepositoryFilterBuilder
	
	#region ItemInRepositoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInRepository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInRepositoryParameterBuilder : ParameterizedSqlFilterBuilder<ItemInRepositoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryParameterBuilder class.
		/// </summary>
		public ItemInRepositoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInRepositoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInRepositoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInRepositoryParameterBuilder
} // end namespace
