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
	/// This class is the base class for any <see cref="RelatedContractProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RelatedContractProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.RelatedContract, RLM.Construction.Entities.RelatedContractKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.RelatedContractKey key)
		{
			return Delete(transactionManager, key.RelatedContractId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="relatedContractId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 relatedContractId)
		{
			return Delete(null, relatedContractId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="relatedContractId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 relatedContractId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		FK_RelatedContract_Contract Description: 
		/// </summary>
		/// <param name="fromContractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(System.Int32 fromContractId)
		{
			int count = -1;
			return GetByFromContractId(fromContractId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		FK_RelatedContract_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromContractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(TransactionManager transactionManager, System.Int32 fromContractId)
		{
			int count = -1;
			return GetByFromContractId(transactionManager, fromContractId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		FK_RelatedContract_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(TransactionManager transactionManager, System.Int32 fromContractId, int start, int pageLength)
		{
			int count = -1;
			return GetByFromContractId(transactionManager, fromContractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		fKRelatedContractContract Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromContractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(System.Int32 fromContractId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFromContractId(null, fromContractId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		fKRelatedContractContract Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="fromContractId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(System.Int32 fromContractId, int start, int pageLength,out int count)
		{
			return GetByFromContractId(null, fromContractId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract key.
		///		FK_RelatedContract_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public abstract RLM.Construction.Entities.TList<RelatedContract> GetByFromContractId(TransactionManager transactionManager, System.Int32 fromContractId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		FK_RelatedContract_Contract1 Description: 
		/// </summary>
		/// <param name="toContractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(System.Int32 toContractId)
		{
			int count = -1;
			return GetByToContractId(toContractId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		FK_RelatedContract_Contract1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toContractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(TransactionManager transactionManager, System.Int32 toContractId)
		{
			int count = -1;
			return GetByToContractId(transactionManager, toContractId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		FK_RelatedContract_Contract1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(TransactionManager transactionManager, System.Int32 toContractId, int start, int pageLength)
		{
			int count = -1;
			return GetByToContractId(transactionManager, toContractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		fKRelatedContractContract1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toContractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(System.Int32 toContractId, int start, int pageLength)
		{
			int count =  -1;
			return GetByToContractId(null, toContractId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		fKRelatedContractContract1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="toContractId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(System.Int32 toContractId, int start, int pageLength,out int count)
		{
			return GetByToContractId(null, toContractId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RelatedContract_Contract1 key.
		///		FK_RelatedContract_Contract1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RelatedContract objects.</returns>
		public abstract RLM.Construction.Entities.TList<RelatedContract> GetByToContractId(TransactionManager transactionManager, System.Int32 toContractId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.RelatedContract Get(TransactionManager transactionManager, RLM.Construction.Entities.RelatedContractKey key, int start, int pageLength)
		{
			return GetByRelatedContractId(transactionManager, key.RelatedContractId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_RelatedContract index.
		/// </summary>
		/// <param name="relatedContractId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public RLM.Construction.Entities.RelatedContract GetByRelatedContractId(System.Int32 relatedContractId)
		{
			int count = -1;
			return GetByRelatedContractId(null,relatedContractId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RelatedContract index.
		/// </summary>
		/// <param name="relatedContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public RLM.Construction.Entities.RelatedContract GetByRelatedContractId(System.Int32 relatedContractId, int start, int pageLength)
		{
			int count = -1;
			return GetByRelatedContractId(null, relatedContractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RelatedContract index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="relatedContractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public RLM.Construction.Entities.RelatedContract GetByRelatedContractId(TransactionManager transactionManager, System.Int32 relatedContractId)
		{
			int count = -1;
			return GetByRelatedContractId(transactionManager, relatedContractId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RelatedContract index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="relatedContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public RLM.Construction.Entities.RelatedContract GetByRelatedContractId(TransactionManager transactionManager, System.Int32 relatedContractId, int start, int pageLength)
		{
			int count = -1;
			return GetByRelatedContractId(transactionManager, relatedContractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RelatedContract index.
		/// </summary>
		/// <param name="relatedContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public RLM.Construction.Entities.RelatedContract GetByRelatedContractId(System.Int32 relatedContractId, int start, int pageLength, out int count)
		{
			return GetByRelatedContractId(null, relatedContractId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RelatedContract index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="relatedContractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RelatedContract"/> class.</returns>
		public abstract RLM.Construction.Entities.RelatedContract GetByRelatedContractId(TransactionManager transactionManager, System.Int32 relatedContractId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;RelatedContract&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;RelatedContract&gt;"/></returns>
		public static RLM.Construction.Entities.TList<RelatedContract> Fill(IDataReader reader, RLM.Construction.Entities.TList<RelatedContract> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.RelatedContract c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"RelatedContract" 
							+ (reader.IsDBNull(reader.GetOrdinal("RelatedContractId"))?(int)0:(System.Int32)reader["RelatedContractId"]).ToString();

					c = EntityManager.LocateOrCreate<RelatedContract>(
						key.ToString(), // EntityTrackingKey 
						"RelatedContract",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.RelatedContract();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RelatedContractId = (System.Int32)reader["RelatedContractId"];
					c.FromContractId = (System.Int32)reader["FromContractId"];
					c.ToContractId = (System.Int32)reader["ToContractId"];
					c.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
					c.CreatedDate = (reader.IsDBNull(reader.GetOrdinal("CreatedDate")))?null:(System.DateTime?)reader["CreatedDate"];
					c.CreatedUserId = (reader.IsDBNull(reader.GetOrdinal("CreatedUserId")))?null:(System.Int32?)reader["CreatedUserId"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.RelatedContract"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RelatedContract"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.RelatedContract entity)
		{
			if (!reader.Read()) return;
			
			entity.RelatedContractId = (System.Int32)reader["RelatedContractId"];
			entity.FromContractId = (System.Int32)reader["FromContractId"];
			entity.ToContractId = (System.Int32)reader["ToContractId"];
			entity.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
			entity.CreatedDate = (reader.IsDBNull(reader.GetOrdinal("CreatedDate")))?null:(System.DateTime?)reader["CreatedDate"];
			entity.CreatedUserId = (reader.IsDBNull(reader.GetOrdinal("CreatedUserId")))?null:(System.Int32?)reader["CreatedUserId"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.RelatedContract"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RelatedContract"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.RelatedContract entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RelatedContractId = (System.Int32)dataRow["RelatedContractId"];
			entity.FromContractId = (System.Int32)dataRow["FromContractId"];
			entity.ToContractId = (System.Int32)dataRow["ToContractId"];
			entity.ParentPath = (Convert.IsDBNull(dataRow["ParentPath"]))?null:(System.String)dataRow["ParentPath"];
			entity.CreatedDate = (Convert.IsDBNull(dataRow["CreatedDate"]))?null:(System.DateTime?)dataRow["CreatedDate"];
			entity.CreatedUserId = (Convert.IsDBNull(dataRow["CreatedUserId"]))?null:(System.Int32?)dataRow["CreatedUserId"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RelatedContract"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.RelatedContract Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.RelatedContract entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region FromContractIdSource	
			if (CanDeepLoad(entity, "Contract", "FromContractIdSource", deepLoadType, innerList) 
				&& entity.FromContractIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FromContractId;
				Contract tmpEntity = EntityManager.LocateEntity<Contract>(EntityLocator.ConstructKeyFromPkItems(typeof(Contract), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FromContractIdSource = tmpEntity;
				else
					entity.FromContractIdSource = DataRepository.ContractProvider.GetByContractId(entity.FromContractId);
			
				if (deep && entity.FromContractIdSource != null)
				{
					DataRepository.ContractProvider.DeepLoad(transactionManager, entity.FromContractIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion FromContractIdSource

			#region ToContractIdSource	
			if (CanDeepLoad(entity, "Contract", "ToContractIdSource", deepLoadType, innerList) 
				&& entity.ToContractIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ToContractId;
				Contract tmpEntity = EntityManager.LocateEntity<Contract>(EntityLocator.ConstructKeyFromPkItems(typeof(Contract), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ToContractIdSource = tmpEntity;
				else
					entity.ToContractIdSource = DataRepository.ContractProvider.GetByContractId(entity.ToContractId);
			
				if (deep && entity.ToContractIdSource != null)
				{
					DataRepository.ContractProvider.DeepLoad(transactionManager, entity.ToContractIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ToContractIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.RelatedContract object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.RelatedContract instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.RelatedContract Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.RelatedContract entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FromContractIdSource
			if (CanDeepSave(entity, "Contract", "FromContractIdSource", deepSaveType, innerList) 
				&& entity.FromContractIdSource != null)
			{
				DataRepository.ContractProvider.Save(transactionManager, entity.FromContractIdSource);
				entity.FromContractId = entity.FromContractIdSource.ContractId;
			}
			#endregion 
			
			#region ToContractIdSource
			if (CanDeepSave(entity, "Contract", "ToContractIdSource", deepSaveType, innerList) 
				&& entity.ToContractIdSource != null)
			{
				DataRepository.ContractProvider.Save(transactionManager, entity.ToContractIdSource);
				entity.ToContractId = entity.ToContractIdSource.ContractId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region RelatedContractChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.RelatedContract</c>
	///</summary>
	public enum RelatedContractChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Contract</c> at FromContractIdSource
		///</summary>
		[ChildEntityType(typeof(Contract))]
		Contract,
		}
	
	#endregion RelatedContractChildEntityTypes
	
	#region RelatedContractFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedContract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedContractFilterBuilder : SqlFilterBuilder<RelatedContractColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedContractFilterBuilder class.
		/// </summary>
		public RelatedContractFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedContractFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedContractFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedContractFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedContractFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedContractFilterBuilder
	
	#region RelatedContractParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedContract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedContractParameterBuilder : ParameterizedSqlFilterBuilder<RelatedContractColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedContractParameterBuilder class.
		/// </summary>
		public RelatedContractParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedContractParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedContractParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedContractParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedContractParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedContractParameterBuilder
} // end namespace
