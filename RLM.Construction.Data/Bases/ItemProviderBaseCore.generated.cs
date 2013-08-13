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
	/// This class is the base class for any <see cref="ItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Item, RLM.Construction.Entities.ItemKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByRepositoryIdFromItemInRepository
		
		/// <summary>
		///		Gets Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetByRepositoryIdFromItemInRepository(System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryIdFromItemInRepository(null,repositoryId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets RLM.Construction.Entities.Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="repositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Item objects.</returns>
		public TList<Item> GetByRepositoryIdFromItemInRepository(System.Int32 repositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryIdFromItemInRepository(null, repositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetByRepositoryIdFromItemInRepository(TransactionManager transactionManager, System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryIdFromItemInRepository(transactionManager, repositoryId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetByRepositoryIdFromItemInRepository(TransactionManager transactionManager, System.Int32 repositoryId,int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryIdFromItemInRepository(transactionManager, repositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Item objects.</returns>
		public TList<Item> GetByRepositoryIdFromItemInRepository(System.Int32 repositoryId,int start, int pageLength, out int count)
		{
			
			return GetByRepositoryIdFromItemInRepository(null, repositoryId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Item objects from the datasource by RepositoryId in the
		///		ItemInRepository table. Table Item is related to table Repository
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="repositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Item objects.</returns>
		public abstract TList<Item> GetByRepositoryIdFromItemInRepository(TransactionManager transactionManager,System.Int32 repositoryId, int start, int pageLength, out int count);
		
		#endregion GetByRepositoryIdFromItemInRepository
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemKey key)
		{
			return Delete(transactionManager, key.ItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 itemId)
		{
			return Delete(null, itemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 itemId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		FK_Items_Units Description: 
		/// </summary>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByBaseUnitId(System.Int32? baseUnitId)
		{
			int count = -1;
			return GetByBaseUnitId(baseUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		FK_Items_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Item> GetByBaseUnitId(TransactionManager transactionManager, System.Int32? baseUnitId)
		{
			int count = -1;
			return GetByBaseUnitId(transactionManager, baseUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		FK_Items_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByBaseUnitId(TransactionManager transactionManager, System.Int32? baseUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByBaseUnitId(transactionManager, baseUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		fKItemsUnits Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByBaseUnitId(System.Int32? baseUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBaseUnitId(null, baseUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		fKItemsUnits Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByBaseUnitId(System.Int32? baseUnitId, int start, int pageLength,out int count)
		{
			return GetByBaseUnitId(null, baseUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units key.
		///		FK_Items_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="baseUnitId">Base unit of product, It can not be change base in any time</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public abstract RLM.Construction.Entities.TList<Item> GetByBaseUnitId(TransactionManager transactionManager, System.Int32? baseUnitId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		FK_Items_Units1 Description: 
		/// </summary>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByUsedUnitId(System.Int32? usedUnitId)
		{
			int count = -1;
			return GetByUsedUnitId(usedUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		FK_Items_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Item> GetByUsedUnitId(TransactionManager transactionManager, System.Int32? usedUnitId)
		{
			int count = -1;
			return GetByUsedUnitId(transactionManager, usedUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		FK_Items_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByUsedUnitId(TransactionManager transactionManager, System.Int32? usedUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByUsedUnitId(transactionManager, usedUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		fKItemsUnits1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByUsedUnitId(System.Int32? usedUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUsedUnitId(null, usedUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		fKItemsUnits1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByUsedUnitId(System.Int32? usedUnitId, int start, int pageLength,out int count)
		{
			return GetByUsedUnitId(null, usedUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Units1 key.
		///		FK_Items_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="usedUnitId">Current unit id, It can be change base on repository</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public abstract RLM.Construction.Entities.TList<Item> GetByUsedUnitId(TransactionManager transactionManager, System.Int32? usedUnitId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		FK_Items_Groups Description: 
		/// </summary>
		/// <param name="groupId">Item group</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByGroupId(System.Int32? groupId)
		{
			int count = -1;
			return GetByGroupId(groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		FK_Items_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId">Item group</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Item> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		FK_Items_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId">Item group</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		fKItemsGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId">Item group</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByGroupId(System.Int32? groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		fKItemsGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId">Item group</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public RLM.Construction.Entities.TList<Item> GetByGroupId(System.Int32? groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Items_Groups key.
		///		FK_Items_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId">Item group</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Item objects.</returns>
		public abstract RLM.Construction.Entities.TList<Item> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.Item Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemKey key, int start, int pageLength)
		{
			return GetByItemId(transactionManager, key.ItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Items index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public RLM.Construction.Entities.Item GetByItemId(System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(null,itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public RLM.Construction.Entities.Item GetByItemId(System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(null, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public RLM.Construction.Entities.Item GetByItemId(TransactionManager transactionManager, System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public RLM.Construction.Entities.Item GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public RLM.Construction.Entities.Item GetByItemId(System.Int64 itemId, int start, int pageLength, out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Item"/> class.</returns>
		public abstract RLM.Construction.Entities.Item GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Item&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Item&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Item> Fill(IDataReader reader, RLM.Construction.Entities.TList<Item> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Item c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Item" 
							+ (reader.IsDBNull(reader.GetOrdinal("ItemId"))?(long)0:(System.Int64)reader["ItemId"]).ToString();

					c = EntityManager.LocateOrCreate<Item>(
						key.ToString(), // EntityTrackingKey 
						"Item",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Item();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ItemId = (System.Int64)reader["ItemId"];
					c.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
					c.ParentItemId = (reader.IsDBNull(reader.GetOrdinal("ParentItemId")))?null:(System.Int32?)reader["ParentItemId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.BaseUnitId = (reader.IsDBNull(reader.GetOrdinal("BaseUnitId")))?null:(System.Int32?)reader["BaseUnitId"];
					c.UsedUnitId = (reader.IsDBNull(reader.GetOrdinal("UsedUnitId")))?null:(System.Int32?)reader["UsedUnitId"];
					c.Density = (reader.IsDBNull(reader.GetOrdinal("Density")))?null:(System.Double?)reader["Density"];
					c.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
					c.AvailabelQuantity = (reader.IsDBNull(reader.GetOrdinal("AvailabelQuantity")))?null:(System.Int64?)reader["AvailabelQuantity"];
					c.ReserveQuantity = (reader.IsDBNull(reader.GetOrdinal("ReserveQuantity")))?null:(System.Int64?)reader["ReserveQuantity"];
					c.ReturnQuantity = (reader.IsDBNull(reader.GetOrdinal("ReturnQuantity")))?null:(System.Int64?)reader["ReturnQuantity"];
					c.AdjustQuantity = (reader.IsDBNull(reader.GetOrdinal("AdjustQuantity")))?null:(System.Int64?)reader["AdjustQuantity"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.LastComputeDate = (reader.IsDBNull(reader.GetOrdinal("LastComputeDate")))?null:(System.DateTime?)reader["LastComputeDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Item"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Item"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Item entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemId = (System.Int64)reader["ItemId"];
			entity.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
			entity.ParentItemId = (reader.IsDBNull(reader.GetOrdinal("ParentItemId")))?null:(System.Int32?)reader["ParentItemId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.BaseUnitId = (reader.IsDBNull(reader.GetOrdinal("BaseUnitId")))?null:(System.Int32?)reader["BaseUnitId"];
			entity.UsedUnitId = (reader.IsDBNull(reader.GetOrdinal("UsedUnitId")))?null:(System.Int32?)reader["UsedUnitId"];
			entity.Density = (reader.IsDBNull(reader.GetOrdinal("Density")))?null:(System.Double?)reader["Density"];
			entity.TotalQuantity = (reader.IsDBNull(reader.GetOrdinal("TotalQuantity")))?null:(System.Int64?)reader["TotalQuantity"];
			entity.AvailabelQuantity = (reader.IsDBNull(reader.GetOrdinal("AvailabelQuantity")))?null:(System.Int64?)reader["AvailabelQuantity"];
			entity.ReserveQuantity = (reader.IsDBNull(reader.GetOrdinal("ReserveQuantity")))?null:(System.Int64?)reader["ReserveQuantity"];
			entity.ReturnQuantity = (reader.IsDBNull(reader.GetOrdinal("ReturnQuantity")))?null:(System.Int64?)reader["ReturnQuantity"];
			entity.AdjustQuantity = (reader.IsDBNull(reader.GetOrdinal("AdjustQuantity")))?null:(System.Int64?)reader["AdjustQuantity"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.LastComputeDate = (reader.IsDBNull(reader.GetOrdinal("LastComputeDate")))?null:(System.DateTime?)reader["LastComputeDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Item"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Item"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Item entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemId = (System.Int64)dataRow["ItemId"];
			entity.GroupId = (Convert.IsDBNull(dataRow["GroupId"]))?null:(System.Int32?)dataRow["GroupId"];
			entity.ParentItemId = (Convert.IsDBNull(dataRow["ParentItemId"]))?null:(System.Int32?)dataRow["ParentItemId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.BaseUnitId = (Convert.IsDBNull(dataRow["BaseUnitId"]))?null:(System.Int32?)dataRow["BaseUnitId"];
			entity.UsedUnitId = (Convert.IsDBNull(dataRow["UsedUnitId"]))?null:(System.Int32?)dataRow["UsedUnitId"];
			entity.Density = (Convert.IsDBNull(dataRow["Density"]))?null:(System.Double?)dataRow["Density"];
			entity.TotalQuantity = (Convert.IsDBNull(dataRow["TotalQuantity"]))?null:(System.Int64?)dataRow["TotalQuantity"];
			entity.AvailabelQuantity = (Convert.IsDBNull(dataRow["AvailabelQuantity"]))?null:(System.Int64?)dataRow["AvailabelQuantity"];
			entity.ReserveQuantity = (Convert.IsDBNull(dataRow["ReserveQuantity"]))?null:(System.Int64?)dataRow["ReserveQuantity"];
			entity.ReturnQuantity = (Convert.IsDBNull(dataRow["ReturnQuantity"]))?null:(System.Int64?)dataRow["ReturnQuantity"];
			entity.AdjustQuantity = (Convert.IsDBNull(dataRow["AdjustQuantity"]))?null:(System.Int64?)dataRow["AdjustQuantity"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.LastComputeDate = (Convert.IsDBNull(dataRow["LastComputeDate"]))?null:(System.DateTime?)dataRow["LastComputeDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Item"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Item Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Item entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region BaseUnitIdSource	
			if (CanDeepLoad(entity, "Unit", "BaseUnitIdSource", deepLoadType, innerList) 
				&& entity.BaseUnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BaseUnitId ?? (int)0);
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BaseUnitIdSource = tmpEntity;
				else
					entity.BaseUnitIdSource = DataRepository.UnitProvider.GetByUnitId((entity.BaseUnitId ?? (int)0));
			
				if (deep && entity.BaseUnitIdSource != null)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.BaseUnitIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion BaseUnitIdSource

			#region UsedUnitIdSource	
			if (CanDeepLoad(entity, "Unit", "UsedUnitIdSource", deepLoadType, innerList) 
				&& entity.UsedUnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UsedUnitId ?? (int)0);
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UsedUnitIdSource = tmpEntity;
				else
					entity.UsedUnitIdSource = DataRepository.UnitProvider.GetByUnitId((entity.UsedUnitId ?? (int)0));
			
				if (deep && entity.UsedUnitIdSource != null)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.UsedUnitIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion UsedUnitIdSource

			#region GroupIdSource	
			if (CanDeepLoad(entity, "Group", "GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GroupId ?? (int)0);
				Group tmpEntity = EntityManager.LocateEntity<Group>(EntityLocator.ConstructKeyFromPkItems(typeof(Group), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.GroupProvider.GetByGroupId((entity.GroupId ?? (int)0));
			
				if (deep && entity.GroupIdSource != null)
				{
					DataRepository.GroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion GroupIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByItemId methods when available
			
			#region ItemInItemCollectionByFromItemId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemInItem>", "ItemInItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemInItemCollectionByFromItemId' loaded.");
				#endif 

				entity.ItemInItemCollectionByFromItemId = DataRepository.ItemInItemProvider.GetByFromItemId(transactionManager, entity.ItemId);

				if (deep && entity.ItemInItemCollectionByFromItemId.Count > 0)
				{
					DataRepository.ItemInItemProvider.DeepLoad(transactionManager, entity.ItemInItemCollectionByFromItemId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region RepositoryCollection_From_ItemInRepository
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Repository>", "RepositoryCollection_From_ItemInRepository", deepLoadType, innerList))
			{
				entity.RepositoryCollection_From_ItemInRepository = DataRepository.RepositoryProvider.GetByItemIdFromItemInRepository(transactionManager, entity.ItemId);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'RepositoryCollection_From_ItemInRepository' loaded.");
				#endif 

				if (deep && entity.RepositoryCollection_From_ItemInRepository.Count > 0)
				{
					DataRepository.RepositoryProvider.DeepLoad(transactionManager, entity.RepositoryCollection_From_ItemInRepository, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion
			
			
			#region ItemMovementCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemMovement>", "ItemMovementCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemMovementCollection' loaded.");
				#endif 

				entity.ItemMovementCollection = DataRepository.ItemMovementProvider.GetByItemId(transactionManager, entity.ItemId);

				if (deep && entity.ItemMovementCollection.Count > 0)
				{
					DataRepository.ItemMovementProvider.DeepLoad(transactionManager, entity.ItemMovementCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemInItemCollectionByToItemId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemInItem>", "ItemInItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemInItemCollectionByToItemId' loaded.");
				#endif 

				entity.ItemInItemCollectionByToItemId = DataRepository.ItemInItemProvider.GetByToItemId(transactionManager, entity.ItemId);

				if (deep && entity.ItemInItemCollectionByToItemId.Count > 0)
				{
					DataRepository.ItemInItemProvider.DeepLoad(transactionManager, entity.ItemInItemCollectionByToItemId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemInProjectCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemInProject>", "ItemInProjectCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemInProjectCollection' loaded.");
				#endif 

				entity.ItemInProjectCollection = DataRepository.ItemInProjectProvider.GetByItemId(transactionManager, entity.ItemId);

				if (deep && entity.ItemInProjectCollection.Count > 0)
				{
					DataRepository.ItemInProjectProvider.DeepLoad(transactionManager, entity.ItemInProjectCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemInRepositoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemInRepository>", "ItemInRepositoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemInRepositoryCollection' loaded.");
				#endif 

				entity.ItemInRepositoryCollection = DataRepository.ItemInRepositoryProvider.GetByItemId(transactionManager, entity.ItemId);

				if (deep && entity.ItemInRepositoryCollection.Count > 0)
				{
					DataRepository.ItemInRepositoryProvider.DeepLoad(transactionManager, entity.ItemInRepositoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Item object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Item instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Item Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Item entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region BaseUnitIdSource
			if (CanDeepSave(entity, "Unit", "BaseUnitIdSource", deepSaveType, innerList) 
				&& entity.BaseUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.BaseUnitIdSource);
				entity.BaseUnitId = entity.BaseUnitIdSource.UnitId;
			}
			#endregion 
			
			#region UsedUnitIdSource
			if (CanDeepSave(entity, "Unit", "UsedUnitIdSource", deepSaveType, innerList) 
				&& entity.UsedUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.UsedUnitIdSource);
				entity.UsedUnitId = entity.UsedUnitIdSource.UnitId;
			}
			#endregion 
			
			#region GroupIdSource
			if (CanDeepSave(entity, "Group", "GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.GroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			








			#region RepositoryCollection_From_ItemInRepository>
			if (CanDeepSave(entity, "List<Repository>", "RepositoryCollection_From_ItemInRepository", deepSaveType, innerList))
			{
				if (entity.RepositoryCollection_From_ItemInRepository.Count > 0 || entity.RepositoryCollection_From_ItemInRepository.DeletedItems.Count > 0)
					DataRepository.RepositoryProvider.DeepSave(transactionManager, entity.RepositoryCollection_From_ItemInRepository, deepSaveType, childTypes, innerList); 
			}
			#endregion 





			#region List<ItemInItem>
				if (CanDeepSave(entity, "List<ItemInItem>", "ItemInItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInItem child in entity.ItemInItemCollectionByFromItemId)
					{
						child.FromItemId = entity.ItemId;
					}
				
				if (entity.ItemInItemCollectionByFromItemId.Count > 0 || entity.ItemInItemCollectionByFromItemId.DeletedItems.Count > 0)
					DataRepository.ItemInItemProvider.DeepSave(transactionManager, entity.ItemInItemCollectionByFromItemId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


			#region List<ItemMovement>
				if (CanDeepSave(entity, "List<ItemMovement>", "ItemMovementCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemMovement child in entity.ItemMovementCollection)
					{
						child.ItemId = entity.ItemId;
					}
				
				if (entity.ItemMovementCollection.Count > 0 || entity.ItemMovementCollection.DeletedItems.Count > 0)
					DataRepository.ItemMovementProvider.DeepSave(transactionManager, entity.ItemMovementCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemInItem>
				if (CanDeepSave(entity, "List<ItemInItem>", "ItemInItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInItem child in entity.ItemInItemCollectionByToItemId)
					{
						child.ToItemId = entity.ItemId;
					}
				
				if (entity.ItemInItemCollectionByToItemId.Count > 0 || entity.ItemInItemCollectionByToItemId.DeletedItems.Count > 0)
					DataRepository.ItemInItemProvider.DeepSave(transactionManager, entity.ItemInItemCollectionByToItemId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemInProject>
				if (CanDeepSave(entity, "List<ItemInProject>", "ItemInProjectCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInProject child in entity.ItemInProjectCollection)
					{
						child.ItemId = entity.ItemId;
					}
				
				if (entity.ItemInProjectCollection.Count > 0 || entity.ItemInProjectCollection.DeletedItems.Count > 0)
					DataRepository.ItemInProjectProvider.DeepSave(transactionManager, entity.ItemInProjectCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemInRepository>
				if (CanDeepSave(entity, "List<ItemInRepository>", "ItemInRepositoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInRepository child in entity.ItemInRepositoryCollection)
					{
						child.ItemId = entity.ItemId;
					}
				
				if (entity.ItemInRepositoryCollection.Count > 0 || entity.ItemInRepositoryCollection.DeletedItems.Count > 0)
					DataRepository.ItemInRepositoryProvider.DeepSave(transactionManager, entity.ItemInRepositoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				






						
			return true;
		}
		#endregion
	} // end class
	
	#region ItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Item</c>
	///</summary>
	public enum ItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Unit</c> at BaseUnitIdSource
		///</summary>
		[ChildEntityType(typeof(Unit))]
		Unit,
			
		///<summary>
		/// Composite Property for <c>Group</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(Group))]
		Group,
	
		///<summary>
		/// Collection of <c>Item</c> as OneToMany for ItemInItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInItem>))]
		ItemInItemCollectionByFromItemId,

		///<summary>
		/// Collection of <c>Item</c> as ManyToMany for RepositoryCollection_From_ItemInRepository
		///</summary>
		[ChildEntityType(typeof(TList<Repository>))]
		RepositoryCollection_From_ItemInRepository,

		///<summary>
		/// Collection of <c>Item</c> as OneToMany for ItemMovementCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemMovement>))]
		ItemMovementCollection,

		///<summary>
		/// Collection of <c>Item</c> as OneToMany for ItemInItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInItem>))]
		ItemInItemCollectionByToItemId,

		///<summary>
		/// Collection of <c>Item</c> as OneToMany for ItemInProjectCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInProject>))]
		ItemInProjectCollection,

		///<summary>
		/// Collection of <c>Item</c> as OneToMany for ItemInRepositoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInRepository>))]
		ItemInRepositoryCollection,
	}
	
	#endregion ItemChildEntityTypes
	
	#region ItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemFilterBuilder : SqlFilterBuilder<ItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		public ItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemFilterBuilder
	
	#region ItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Item"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemParameterBuilder : ParameterizedSqlFilterBuilder<ItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		public ItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemParameterBuilder
} // end namespace
