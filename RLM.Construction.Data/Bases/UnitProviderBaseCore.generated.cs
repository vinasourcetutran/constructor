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
	/// This class is the base class for any <see cref="UnitProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UnitProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Unit, RLM.Construction.Entities.UnitKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByToUnitIdFromUnitConvertor
		
		/// <summary>
		///		Gets Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="toUnitId"></param>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByToUnitIdFromUnitConvertor(System.Int32 toUnitId)
		{
			int count = -1;
			return GetByToUnitIdFromUnitConvertor(null,toUnitId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets RLM.Construction.Entities.Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Unit objects.</returns>
		public TList<Unit> GetByToUnitIdFromUnitConvertor(System.Int32 toUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByToUnitIdFromUnitConvertor(null, toUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByToUnitIdFromUnitConvertor(TransactionManager transactionManager, System.Int32 toUnitId)
		{
			int count = -1;
			return GetByToUnitIdFromUnitConvertor(transactionManager, toUnitId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByToUnitIdFromUnitConvertor(TransactionManager transactionManager, System.Int32 toUnitId,int start, int pageLength)
		{
			int count = -1;
			return GetByToUnitIdFromUnitConvertor(transactionManager, toUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="toUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByToUnitIdFromUnitConvertor(System.Int32 toUnitId,int start, int pageLength, out int count)
		{
			
			return GetByToUnitIdFromUnitConvertor(null, toUnitId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Unit objects from the datasource by ToUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="toUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Unit objects.</returns>
		public abstract TList<Unit> GetByToUnitIdFromUnitConvertor(TransactionManager transactionManager,System.Int32 toUnitId, int start, int pageLength, out int count);
		
		#endregion GetByToUnitIdFromUnitConvertor
		
		#region GetByFromUnitIdFromUnitConvertor
		
		/// <summary>
		///		Gets Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="fromUnitId"></param>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByFromUnitIdFromUnitConvertor(System.Int32 fromUnitId)
		{
			int count = -1;
			return GetByFromUnitIdFromUnitConvertor(null,fromUnitId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets RLM.Construction.Entities.Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Unit objects.</returns>
		public TList<Unit> GetByFromUnitIdFromUnitConvertor(System.Int32 fromUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromUnitIdFromUnitConvertor(null, fromUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByFromUnitIdFromUnitConvertor(TransactionManager transactionManager, System.Int32 fromUnitId)
		{
			int count = -1;
			return GetByFromUnitIdFromUnitConvertor(transactionManager, fromUnitId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByFromUnitIdFromUnitConvertor(TransactionManager transactionManager, System.Int32 fromUnitId,int start, int pageLength)
		{
			int count = -1;
			return GetByFromUnitIdFromUnitConvertor(transactionManager, fromUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="fromUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Unit objects.</returns>
		public TList<Unit> GetByFromUnitIdFromUnitConvertor(System.Int32 fromUnitId,int start, int pageLength, out int count)
		{
			
			return GetByFromUnitIdFromUnitConvertor(null, fromUnitId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Unit objects from the datasource by FromUnitId in the
		///		UnitConvertor table. Table Unit is related to table Unit
		///		through the (M:N) relationship defined in the UnitConvertor table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="fromUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Unit objects.</returns>
		public abstract TList<Unit> GetByFromUnitIdFromUnitConvertor(TransactionManager transactionManager,System.Int32 fromUnitId, int start, int pageLength, out int count);
		
		#endregion GetByFromUnitIdFromUnitConvertor
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.UnitKey key)
		{
			return Delete(transactionManager, key.UnitId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="unitId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 unitId)
		{
			return Delete(null, unitId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 unitId);		
		
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
		public override RLM.Construction.Entities.Unit Get(TransactionManager transactionManager, RLM.Construction.Entities.UnitKey key, int start, int pageLength)
		{
			return GetByUnitId(transactionManager, key.UnitId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Units index.
		/// </summary>
		/// <param name="unitId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public RLM.Construction.Entities.Unit GetByUnitId(System.Int32 unitId)
		{
			int count = -1;
			return GetByUnitId(null,unitId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Units index.
		/// </summary>
		/// <param name="unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public RLM.Construction.Entities.Unit GetByUnitId(System.Int32 unitId, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitId(null, unitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Units index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public RLM.Construction.Entities.Unit GetByUnitId(TransactionManager transactionManager, System.Int32 unitId)
		{
			int count = -1;
			return GetByUnitId(transactionManager, unitId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Units index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public RLM.Construction.Entities.Unit GetByUnitId(TransactionManager transactionManager, System.Int32 unitId, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitId(transactionManager, unitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Units index.
		/// </summary>
		/// <param name="unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public RLM.Construction.Entities.Unit GetByUnitId(System.Int32 unitId, int start, int pageLength, out int count)
		{
			return GetByUnitId(null, unitId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Units index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Unit"/> class.</returns>
		public abstract RLM.Construction.Entities.Unit GetByUnitId(TransactionManager transactionManager, System.Int32 unitId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Unit&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Unit&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Unit> Fill(IDataReader reader, RLM.Construction.Entities.TList<Unit> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Unit c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Unit" 
							+ (reader.IsDBNull(reader.GetOrdinal("UnitId"))?(int)0:(System.Int32)reader["UnitId"]).ToString();

					c = EntityManager.LocateOrCreate<Unit>(
						key.ToString(), // EntityTrackingKey 
						"Unit",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Unit();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.UnitId = (System.Int32)reader["UnitId"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.IsBaseUnit = (reader.IsDBNull(reader.GetOrdinal("IsBaseUnit")))?null:(System.Boolean?)reader["IsBaseUnit"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Unit"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Unit"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Unit entity)
		{
			if (!reader.Read()) return;
			
			entity.UnitId = (System.Int32)reader["UnitId"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.IsBaseUnit = (reader.IsDBNull(reader.GetOrdinal("IsBaseUnit")))?null:(System.Boolean?)reader["IsBaseUnit"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Unit"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Unit"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Unit entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UnitId = (System.Int32)dataRow["UnitId"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.IsBaseUnit = (Convert.IsDBNull(dataRow["IsBaseUnit"]))?null:(System.Boolean?)dataRow["IsBaseUnit"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Unit"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Unit Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Unit entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByUnitId methods when available
			
			#region UnitConvertorCollectionByToUnitId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<UnitConvertor>", "UnitConvertorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'UnitConvertorCollectionByToUnitId' loaded.");
				#endif 

				entity.UnitConvertorCollectionByToUnitId = DataRepository.UnitConvertorProvider.GetByToUnitId(transactionManager, entity.UnitId);

				if (deep && entity.UnitConvertorCollectionByToUnitId.Count > 0)
				{
					DataRepository.UnitConvertorProvider.DeepLoad(transactionManager, entity.UnitConvertorCollectionByToUnitId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemCollectionByUsedUnitId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollectionByUsedUnitId' loaded.");
				#endif 

				entity.ItemCollectionByUsedUnitId = DataRepository.ItemProvider.GetByUsedUnitId(transactionManager, entity.UnitId);

				if (deep && entity.ItemCollectionByUsedUnitId.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollectionByUsedUnitId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Unit>", "UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor", deepLoadType, innerList))
			{
				entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor = DataRepository.UnitProvider.GetByFromUnitIdFromUnitConvertor(transactionManager, entity.UnitId);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor' loaded.");
				#endif 

				if (deep && entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor.Count > 0)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion
			
			
			#region UnitCollection_From_UnitConvertornitIdFromUnitConvertor
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Unit>", "UnitCollection_From_UnitConvertornitIdFromUnitConvertor", deepLoadType, innerList))
			{
				entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor = DataRepository.UnitProvider.GetByToUnitIdFromUnitConvertor(transactionManager, entity.UnitId);			 
		
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'UnitCollection_From_UnitConvertornitIdFromUnitConvertor' loaded.");
				#endif 

				if (deep && entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor.Count > 0)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion
			
			
			#region ItemCollectionByBaseUnitId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollectionByBaseUnitId' loaded.");
				#endif 

				entity.ItemCollectionByBaseUnitId = DataRepository.ItemProvider.GetByBaseUnitId(transactionManager, entity.UnitId);

				if (deep && entity.ItemCollectionByBaseUnitId.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollectionByBaseUnitId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region UnitConvertorCollectionByFromUnitId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<UnitConvertor>", "UnitConvertorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'UnitConvertorCollectionByFromUnitId' loaded.");
				#endif 

				entity.UnitConvertorCollectionByFromUnitId = DataRepository.UnitConvertorProvider.GetByFromUnitId(transactionManager, entity.UnitId);

				if (deep && entity.UnitConvertorCollectionByFromUnitId.Count > 0)
				{
					DataRepository.UnitConvertorProvider.DeepLoad(transactionManager, entity.UnitConvertorCollectionByFromUnitId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Unit object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Unit instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Unit Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Unit entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			









			#region UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor>
			if (CanDeepSave(entity, "List<Unit>", "UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor", deepSaveType, innerList))
			{
				if (entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor.Count > 0 || entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor.DeletedItems.Count > 0)
					DataRepository.UnitProvider.DeepSave(transactionManager, entity.UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor, deepSaveType, childTypes, innerList); 
			}
			#endregion 

			#region UnitCollection_From_UnitConvertornitIdFromUnitConvertor>
			if (CanDeepSave(entity, "List<Unit>", "UnitCollection_From_UnitConvertornitIdFromUnitConvertor", deepSaveType, innerList))
			{
				if (entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor.Count > 0 || entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor.DeletedItems.Count > 0)
					DataRepository.UnitProvider.DeepSave(transactionManager, entity.UnitCollection_From_UnitConvertornitIdFromUnitConvertor, deepSaveType, childTypes, innerList); 
			}
			#endregion 



			#region List<UnitConvertor>
				if (CanDeepSave(entity, "List<UnitConvertor>", "UnitConvertorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(UnitConvertor child in entity.UnitConvertorCollectionByToUnitId)
					{
						child.ToUnitId = entity.UnitId;
					}
				
				if (entity.UnitConvertorCollectionByToUnitId.Count > 0 || entity.UnitConvertorCollectionByToUnitId.DeletedItems.Count > 0)
					DataRepository.UnitConvertorProvider.DeepSave(transactionManager, entity.UnitConvertorCollectionByToUnitId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Item>
				if (CanDeepSave(entity, "List<Item>", "ItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Item child in entity.ItemCollectionByUsedUnitId)
					{
						child.UsedUnitId = entity.UnitId;
					}
				
				if (entity.ItemCollectionByUsedUnitId.Count > 0 || entity.ItemCollectionByUsedUnitId.DeletedItems.Count > 0)
					DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollectionByUsedUnitId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				



			#region List<Item>
				if (CanDeepSave(entity, "List<Item>", "ItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Item child in entity.ItemCollectionByBaseUnitId)
					{
						child.BaseUnitId = entity.UnitId;
					}
				
				if (entity.ItemCollectionByBaseUnitId.Count > 0 || entity.ItemCollectionByBaseUnitId.DeletedItems.Count > 0)
					DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollectionByBaseUnitId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<UnitConvertor>
				if (CanDeepSave(entity, "List<UnitConvertor>", "UnitConvertorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(UnitConvertor child in entity.UnitConvertorCollectionByFromUnitId)
					{
						child.FromUnitId = entity.UnitId;
					}
				
				if (entity.UnitConvertorCollectionByFromUnitId.Count > 0 || entity.UnitConvertorCollectionByFromUnitId.DeletedItems.Count > 0)
					DataRepository.UnitConvertorProvider.DeepSave(transactionManager, entity.UnitConvertorCollectionByFromUnitId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				






						
			return true;
		}
		#endregion
	} // end class
	
	#region UnitChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Unit</c>
	///</summary>
	public enum UnitChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Unit</c> as OneToMany for UnitConvertorCollection
		///</summary>
		[ChildEntityType(typeof(TList<UnitConvertor>))]
		UnitConvertorCollectionByToUnitId,

		///<summary>
		/// Collection of <c>Unit</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollectionByUsedUnitId,

		///<summary>
		/// Collection of <c>Unit</c> as ManyToMany for UnitCollection_From_UnitConvertor
		///</summary>
		[ChildEntityType(typeof(TList<Unit>))]
		UnitCollection_From_UnitConvertormUnitIdFromUnitConvertor,

		///<summary>
		/// Collection of <c>Unit</c> as ManyToMany for UnitCollection_From_UnitConvertor
		///</summary>
		[ChildEntityType(typeof(TList<Unit>))]
		UnitCollection_From_UnitConvertornitIdFromUnitConvertor,

		///<summary>
		/// Collection of <c>Unit</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollectionByBaseUnitId,

		///<summary>
		/// Collection of <c>Unit</c> as OneToMany for UnitConvertorCollection
		///</summary>
		[ChildEntityType(typeof(TList<UnitConvertor>))]
		UnitConvertorCollectionByFromUnitId,
	}
	
	#endregion UnitChildEntityTypes
	
	#region UnitFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitFilterBuilder : SqlFilterBuilder<UnitColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitFilterBuilder class.
		/// </summary>
		public UnitFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitFilterBuilder
	
	#region UnitParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Unit"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitParameterBuilder : ParameterizedSqlFilterBuilder<UnitColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitParameterBuilder class.
		/// </summary>
		public UnitParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitParameterBuilder
} // end namespace
