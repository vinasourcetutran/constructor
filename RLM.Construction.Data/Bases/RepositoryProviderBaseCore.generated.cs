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
	/// This class is the base class for any <see cref="RepositoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RepositoryProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Repository, RLM.Construction.Entities.RepositoryKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByItemIdFromItemInRepository
		
		/// <summary>
		///		Gets Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of Repository objects.</returns>
		public TList<Repository> GetByItemIdFromItemInRepository(System.Int64 itemId)
		{
			int count = -1;
			return GetByItemIdFromItemInRepository(null,itemId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets RLM.Construction.Entities.Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Repository objects.</returns>
		public TList<Repository> GetByItemIdFromItemInRepository(System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdFromItemInRepository(null, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Repository objects.</returns>
		public TList<Repository> GetByItemIdFromItemInRepository(TransactionManager transactionManager, System.Int64 itemId)
		{
			int count = -1;
			return GetByItemIdFromItemInRepository(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Repository objects.</returns>
		public TList<Repository> GetByItemIdFromItemInRepository(TransactionManager transactionManager, System.Int64 itemId,int start, int pageLength)
		{
			int count = -1;
			return GetByItemIdFromItemInRepository(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Repository objects.</returns>
		public TList<Repository> GetByItemIdFromItemInRepository(System.Int64 itemId,int start, int pageLength, out int count)
		{
			
			return GetByItemIdFromItemInRepository(null, itemId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Repository objects from the datasource by ItemId in the
		///		ItemInRepository table. Table Repository is related to table Item
		///		through the (M:N) relationship defined in the ItemInRepository table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Repository objects.</returns>
		public abstract TList<Repository> GetByItemIdFromItemInRepository(TransactionManager transactionManager,System.Int64 itemId, int start, int pageLength, out int count);
		
		#endregion GetByItemIdFromItemInRepository
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.RepositoryKey key)
		{
			return Delete(transactionManager, key.RepositoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="repositoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 repositoryId)
		{
			return Delete(null, repositoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 repositoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override RLM.Construction.Entities.Repository Get(TransactionManager transactionManager, RLM.Construction.Entities.RepositoryKey key, int start, int pageLength)
		{
			return GetByRepositoryId(transactionManager, key.RepositoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_RepositoryGroups index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public RLM.Construction.Entities.Repository GetByRepositoryId(System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryId(null,repositoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RepositoryGroups index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public RLM.Construction.Entities.Repository GetByRepositoryId(System.Int32 repositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryId(null, repositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RepositoryGroups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public RLM.Construction.Entities.Repository GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId)
		{
			int count = -1;
			return GetByRepositoryId(transactionManager, repositoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RepositoryGroups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public RLM.Construction.Entities.Repository GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByRepositoryId(transactionManager, repositoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RepositoryGroups index.
		/// </summary>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public RLM.Construction.Entities.Repository GetByRepositoryId(System.Int32 repositoryId, int start, int pageLength, out int count)
		{
			return GetByRepositoryId(null, repositoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RepositoryGroups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="repositoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Repository"/> class.</returns>
		public abstract RLM.Construction.Entities.Repository GetByRepositoryId(TransactionManager transactionManager, System.Int32 repositoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Repository&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Repository&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Repository> Fill(IDataReader reader, RLM.Construction.Entities.TList<Repository> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Repository c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Repository" 
							+ (reader.IsDBNull(reader.GetOrdinal("RepositoryId"))?(int)0:(System.Int32)reader["RepositoryId"]).ToString();

					c = EntityManager.LocateOrCreate<Repository>(
						key.ToString(), // EntityTrackingKey 
						"Repository",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Repository();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RepositoryId = (System.Int32)reader["RepositoryId"];
					c.RepositoryManagerStaffId = (reader.IsDBNull(reader.GetOrdinal("RepositoryManagerStaffId")))?null:(System.Int32?)reader["RepositoryManagerStaffId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
					c.ProvinceId = (reader.IsDBNull(reader.GetOrdinal("ProvinceId")))?null:(System.Int32?)reader["ProvinceId"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Repository"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Repository"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Repository entity)
		{
			if (!reader.Read()) return;
			
			entity.RepositoryId = (System.Int32)reader["RepositoryId"];
			entity.RepositoryManagerStaffId = (reader.IsDBNull(reader.GetOrdinal("RepositoryManagerStaffId")))?null:(System.Int32?)reader["RepositoryManagerStaffId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
			entity.ProvinceId = (reader.IsDBNull(reader.GetOrdinal("ProvinceId")))?null:(System.Int32?)reader["ProvinceId"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Repository"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Repository"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Repository entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RepositoryId = (System.Int32)dataRow["RepositoryId"];
			entity.RepositoryManagerStaffId = (Convert.IsDBNull(dataRow["RepositoryManagerStaffId"]))?null:(System.Int32?)dataRow["RepositoryManagerStaffId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?null:(System.String)dataRow["Address"];
			entity.ProvinceId = (Convert.IsDBNull(dataRow["ProvinceId"]))?null:(System.Int32?)dataRow["ProvinceId"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Repository"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Repository Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Repository entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByRepositoryId methods when available
			
			#region ItemMovementCollectionByFromRepositoryId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemMovement>", "ItemMovementCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemMovementCollectionByFromRepositoryId' loaded.");
				#endif 

				entity.ItemMovementCollectionByFromRepositoryId = DataRepository.ItemMovementProvider.GetByFromRepositoryId(transactionManager, entity.RepositoryId);

				if (deep && entity.ItemMovementCollectionByFromRepositoryId.Count > 0)
				{
					DataRepository.ItemMovementProvider.DeepLoad(transactionManager, entity.ItemMovementCollectionByFromRepositoryId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemMovementCollectionByToRepositoryId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemMovement>", "ItemMovementCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemMovementCollectionByToRepositoryId' loaded.");
				#endif 

				entity.ItemMovementCollectionByToRepositoryId = DataRepository.ItemMovementProvider.GetByToRepositoryId(transactionManager, entity.RepositoryId);

				if (deep && entity.ItemMovementCollectionByToRepositoryId.Count > 0)
				{
					DataRepository.ItemMovementProvider.DeepLoad(transactionManager, entity.ItemMovementCollectionByToRepositoryId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemCollection_From_ItemInRepository
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection_From_ItemInRepository", deepLoadType, innerList))
			{
				entity.ItemCollection_From_ItemInRepository = DataRepository.ItemProvider.GetByRepositoryIdFromItemInRepository(transactionManager, entity.RepositoryId);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollection_From_ItemInRepository' loaded.");
				#endif 

				if (deep && entity.ItemCollection_From_ItemInRepository.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollection_From_ItemInRepository, deep, deepLoadType, childTypes, innerList);
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

				entity.ItemInRepositoryCollection = DataRepository.ItemInRepositoryProvider.GetByRepositoryId(transactionManager, entity.RepositoryId);

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
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Repository object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Repository instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Repository Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Repository entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			







			#region ItemCollection_From_ItemInRepository>
			if (CanDeepSave(entity, "List<Item>", "ItemCollection_From_ItemInRepository", deepSaveType, innerList))
			{
				if (entity.ItemCollection_From_ItemInRepository.Count > 0 || entity.ItemCollection_From_ItemInRepository.DeletedItems.Count > 0)
					DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollection_From_ItemInRepository, deepSaveType, childTypes, innerList); 
			}
			#endregion 


			#region List<ItemMovement>
				if (CanDeepSave(entity, "List<ItemMovement>", "ItemMovementCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemMovement child in entity.ItemMovementCollectionByFromRepositoryId)
					{
						child.FromRepositoryId = entity.RepositoryId;
					}
				
				if (entity.ItemMovementCollectionByFromRepositoryId.Count > 0 || entity.ItemMovementCollectionByFromRepositoryId.DeletedItems.Count > 0)
					DataRepository.ItemMovementProvider.DeepSave(transactionManager, entity.ItemMovementCollectionByFromRepositoryId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemMovement>
				if (CanDeepSave(entity, "List<ItemMovement>", "ItemMovementCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemMovement child in entity.ItemMovementCollectionByToRepositoryId)
					{
						child.ToRepositoryId = entity.RepositoryId;
					}
				
				if (entity.ItemMovementCollectionByToRepositoryId.Count > 0 || entity.ItemMovementCollectionByToRepositoryId.DeletedItems.Count > 0)
					DataRepository.ItemMovementProvider.DeepSave(transactionManager, entity.ItemMovementCollectionByToRepositoryId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


			#region List<ItemInRepository>
				if (CanDeepSave(entity, "List<ItemInRepository>", "ItemInRepositoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInRepository child in entity.ItemInRepositoryCollection)
					{
						child.RepositoryId = entity.RepositoryId;
					}
				
				if (entity.ItemInRepositoryCollection.Count > 0 || entity.ItemInRepositoryCollection.DeletedItems.Count > 0)
					DataRepository.ItemInRepositoryProvider.DeepSave(transactionManager, entity.ItemInRepositoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				




						
			return true;
		}
		#endregion
	} // end class
	
	#region RepositoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Repository</c>
	///</summary>
	public enum RepositoryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Repository</c> as OneToMany for ItemMovementCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemMovement>))]
		ItemMovementCollectionByFromRepositoryId,

		///<summary>
		/// Collection of <c>Repository</c> as OneToMany for ItemMovementCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemMovement>))]
		ItemMovementCollectionByToRepositoryId,

		///<summary>
		/// Collection of <c>Repository</c> as ManyToMany for ItemCollection_From_ItemInRepository
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection_From_ItemInRepository,

		///<summary>
		/// Collection of <c>Repository</c> as OneToMany for ItemInRepositoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInRepository>))]
		ItemInRepositoryCollection,
	}
	
	#endregion RepositoryChildEntityTypes
	
	#region RepositoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Repository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepositoryFilterBuilder : SqlFilterBuilder<RepositoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepositoryFilterBuilder class.
		/// </summary>
		public RepositoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RepositoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RepositoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RepositoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RepositoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RepositoryFilterBuilder
	
	#region RepositoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Repository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepositoryParameterBuilder : ParameterizedSqlFilterBuilder<RepositoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepositoryParameterBuilder class.
		/// </summary>
		public RepositoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RepositoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RepositoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RepositoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RepositoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RepositoryParameterBuilder
} // end namespace
