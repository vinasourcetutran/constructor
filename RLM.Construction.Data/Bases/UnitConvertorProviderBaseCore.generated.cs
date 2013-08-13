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
	/// This class is the base class for any <see cref="UnitConvertorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UnitConvertorProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.UnitConvertor, RLM.Construction.Entities.UnitConvertorKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertorKey key)
		{
			return Delete(transactionManager, key.UnitConvertorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="unitConvertorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 unitConvertorId)
		{
			return Delete(null, unitConvertorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitConvertorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 unitConvertorId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		FK_UnitConvertors_Units Description: 
		/// </summary>
		/// <param name="fromUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(System.Int32 fromUnitId)
		{
			int count = -1;
			return GetByFromUnitId(fromUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		FK_UnitConvertors_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(TransactionManager transactionManager, System.Int32 fromUnitId)
		{
			int count = -1;
			return GetByFromUnitId(transactionManager, fromUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		FK_UnitConvertors_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(TransactionManager transactionManager, System.Int32 fromUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromUnitId(transactionManager, fromUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		fKUnitConvertorsUnits Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(System.Int32 fromUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromUnitId(null, fromUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		fKUnitConvertorsUnits Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(System.Int32 fromUnitId, int start, int pageLength,out int count)
		{
			return GetByFromUnitId(null, fromUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		FK_UnitConvertors_Units Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public abstract RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(TransactionManager transactionManager, System.Int32 fromUnitId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		FK_UnitConvertors_Units1 Description: 
		/// </summary>
		/// <param name="toUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(System.Int32 toUnitId)
		{
			int count = -1;
			return GetByToUnitId(toUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		FK_UnitConvertors_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(TransactionManager transactionManager, System.Int32 toUnitId)
		{
			int count = -1;
			return GetByToUnitId(transactionManager, toUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		FK_UnitConvertors_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(TransactionManager transactionManager, System.Int32 toUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByToUnitId(transactionManager, toUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		fKUnitConvertorsUnits1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(System.Int32 toUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByToUnitId(null, toUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		fKUnitConvertorsUnits1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(System.Int32 toUnitId, int start, int pageLength,out int count)
		{
			return GetByToUnitId(null, toUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		FK_UnitConvertors_Units1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public abstract RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(TransactionManager transactionManager, System.Int32 toUnitId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.UnitConvertor Get(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertorKey key, int start, int pageLength)
		{
			return GetByUnitConvertorId(transactionManager, key.UnitConvertorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_UnitConvertors index.
		/// </summary>
		/// <param name="unitConvertorId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(System.Int32 unitConvertorId)
		{
			int count = -1;
			return GetByUnitConvertorId(null,unitConvertorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="unitConvertorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(System.Int32 unitConvertorId, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitConvertorId(null, unitConvertorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitConvertorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(TransactionManager transactionManager, System.Int32 unitConvertorId)
		{
			int count = -1;
			return GetByUnitConvertorId(transactionManager, unitConvertorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitConvertorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(TransactionManager transactionManager, System.Int32 unitConvertorId, int start, int pageLength)
		{
			int count = -1;
			return GetByUnitConvertorId(transactionManager, unitConvertorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="unitConvertorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(System.Int32 unitConvertorId, int start, int pageLength, out int count)
		{
			return GetByUnitConvertorId(null, unitConvertorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitConvertorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		public abstract RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(TransactionManager transactionManager, System.Int32 unitConvertorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;UnitConvertor&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;UnitConvertor&gt;"/></returns>
		public static RLM.Construction.Entities.TList<UnitConvertor> Fill(IDataReader reader, RLM.Construction.Entities.TList<UnitConvertor> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.UnitConvertor c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"UnitConvertor" 
							+ (reader.IsDBNull(reader.GetOrdinal("UnitConvertorId"))?(int)0:(System.Int32)reader["UnitConvertorId"]).ToString();

					c = EntityManager.LocateOrCreate<UnitConvertor>(
						key.ToString(), // EntityTrackingKey 
						"UnitConvertor",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.UnitConvertor();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.UnitConvertorId = (System.Int32)reader["UnitConvertorId"];
					c.FromUnitId = (System.Int32)reader["FromUnitId"];
					c.ToUnitId = (System.Int32)reader["ToUnitId"];
					c.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Double?)reader["Quantity"];
					c.EffectFrom = (reader.IsDBNull(reader.GetOrdinal("EffectFrom")))?null:(System.DateTime?)reader["EffectFrom"];
					c.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.UnitConvertor"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UnitConvertor"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.UnitConvertor entity)
		{
			if (!reader.Read()) return;
			
			entity.UnitConvertorId = (System.Int32)reader["UnitConvertorId"];
			entity.FromUnitId = (System.Int32)reader["FromUnitId"];
			entity.ToUnitId = (System.Int32)reader["ToUnitId"];
			entity.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Double?)reader["Quantity"];
			entity.EffectFrom = (reader.IsDBNull(reader.GetOrdinal("EffectFrom")))?null:(System.DateTime?)reader["EffectFrom"];
			entity.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.UnitConvertor"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UnitConvertor"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.UnitConvertor entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UnitConvertorId = (System.Int32)dataRow["UnitConvertorId"];
			entity.FromUnitId = (System.Int32)dataRow["FromUnitId"];
			entity.ToUnitId = (System.Int32)dataRow["ToUnitId"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?null:(System.Double?)dataRow["Quantity"];
			entity.EffectFrom = (Convert.IsDBNull(dataRow["EffectFrom"]))?null:(System.DateTime?)dataRow["EffectFrom"];
			entity.ParentPath = (Convert.IsDBNull(dataRow["ParentPath"]))?null:(System.String)dataRow["ParentPath"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UnitConvertor"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.UnitConvertor Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertor entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region FromUnitIdSource	
			if (CanDeepLoad(entity, "Unit", "FromUnitIdSource", deepLoadType, innerList) 
				&& entity.FromUnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FromUnitId;
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromUnitIdSource = tmpEntity;
				else
					entity.FromUnitIdSource = DataRepository.UnitProvider.GetByUnitId(entity.FromUnitId);
			
				if (deep && entity.FromUnitIdSource != null)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.FromUnitIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion FromUnitIdSource

			#region ToUnitIdSource	
			if (CanDeepLoad(entity, "Unit", "ToUnitIdSource", deepLoadType, innerList) 
				&& entity.ToUnitIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ToUnitId;
				Unit tmpEntity = EntityManager.LocateEntity<Unit>(EntityLocator.ConstructKeyFromPkItems(typeof(Unit), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToUnitIdSource = tmpEntity;
				else
					entity.ToUnitIdSource = DataRepository.UnitProvider.GetByUnitId(entity.ToUnitId);
			
				if (deep && entity.ToUnitIdSource != null)
				{
					DataRepository.UnitProvider.DeepLoad(transactionManager, entity.ToUnitIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ToUnitIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.UnitConvertor object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.UnitConvertor instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.UnitConvertor Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertor entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FromUnitIdSource
			if (CanDeepSave(entity, "Unit", "FromUnitIdSource", deepSaveType, innerList) 
				&& entity.FromUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.FromUnitIdSource);
				entity.FromUnitId = entity.FromUnitIdSource.UnitId;
			}
			#endregion 
			
			#region ToUnitIdSource
			if (CanDeepSave(entity, "Unit", "ToUnitIdSource", deepSaveType, innerList) 
				&& entity.ToUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.ToUnitIdSource);
				entity.ToUnitId = entity.ToUnitIdSource.UnitId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region UnitConvertorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.UnitConvertor</c>
	///</summary>
	public enum UnitConvertorChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Unit</c> at FromUnitIdSource
		///</summary>
		[ChildEntityType(typeof(Unit))]
		Unit,
		}
	
	#endregion UnitConvertorChildEntityTypes
	
	#region UnitConvertorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitConvertor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitConvertorFilterBuilder : SqlFilterBuilder<UnitConvertorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitConvertorFilterBuilder class.
		/// </summary>
		public UnitConvertorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitConvertorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitConvertorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitConvertorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitConvertorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitConvertorFilterBuilder
	
	#region UnitConvertorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitConvertor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitConvertorParameterBuilder : ParameterizedSqlFilterBuilder<UnitConvertorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitConvertorParameterBuilder class.
		/// </summary>
		public UnitConvertorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UnitConvertorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UnitConvertorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UnitConvertorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UnitConvertorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UnitConvertorParameterBuilder
} // end namespace
