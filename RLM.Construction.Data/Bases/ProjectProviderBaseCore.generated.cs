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
	/// This class is the base class for any <see cref="ProjectProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProjectProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Project, RLM.Construction.Entities.ProjectKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ProjectKey key)
		{
			return Delete(transactionManager, key.ProjectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="projectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 projectId)
		{
			return Delete(null, projectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 projectId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		FK_Projects_Groups1 Description: 
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByGroupId(System.Int32 groupId)
		{
			int count = -1;
			return GetByGroupId(groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		FK_Projects_Groups1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Project> GetByGroupId(TransactionManager transactionManager, System.Int32 groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		FK_Projects_Groups1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByGroupId(TransactionManager transactionManager, System.Int32 groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		fKProjectsGroups1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByGroupId(System.Int32 groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		fKProjectsGroups1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByGroupId(System.Int32 groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Groups1 key.
		///		FK_Projects_Groups1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public abstract RLM.Construction.Entities.TList<Project> GetByGroupId(TransactionManager transactionManager, System.Int32 groupId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		FK_Projects_Contracts Description: 
		/// </summary>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByContractId(System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(contractId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		FK_Projects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Project> GetByContractId(TransactionManager transactionManager, System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		FK_Projects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		fKProjectsContracts Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByContractId(System.Int32 contractId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContractId(null, contractId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		fKProjectsContracts Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public RLM.Construction.Entities.TList<Project> GetByContractId(System.Int32 contractId, int start, int pageLength,out int count)
		{
			return GetByContractId(null, contractId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Projects_Contracts key.
		///		FK_Projects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Project objects.</returns>
		public abstract RLM.Construction.Entities.TList<Project> GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.Project Get(TransactionManager transactionManager, RLM.Construction.Entities.ProjectKey key, int start, int pageLength)
		{
			return GetByProjectId(transactionManager, key.ProjectId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Projects index.
		/// </summary>
		/// <param name="projectId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public RLM.Construction.Entities.Project GetByProjectId(System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(null,projectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Projects index.
		/// </summary>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public RLM.Construction.Entities.Project GetByProjectId(System.Int32 projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(null, projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Projects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public RLM.Construction.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Projects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public RLM.Construction.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Projects index.
		/// </summary>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public RLM.Construction.Entities.Project GetByProjectId(System.Int32 projectId, int start, int pageLength, out int count)
		{
			return GetByProjectId(null, projectId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Projects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Project"/> class.</returns>
		public abstract RLM.Construction.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Project&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Project&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Project> Fill(IDataReader reader, RLM.Construction.Entities.TList<Project> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Project c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Project" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProjectId"))?(int)0:(System.Int32)reader["ProjectId"]).ToString();

					c = EntityManager.LocateOrCreate<Project>(
						key.ToString(), // EntityTrackingKey 
						"Project",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Project();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProjectId = (System.Int32)reader["ProjectId"];
					c.GroupId = (System.Int32)reader["GroupId"];
					c.ContractId = (System.Int32)reader["ContractId"];
					c.ManagerId = (reader.IsDBNull(reader.GetOrdinal("ManagerId")))?null:(System.Int32?)reader["ManagerId"];
					c.CurrentPhaseId = (reader.IsDBNull(reader.GetOrdinal("CurrentPhaseId")))?null:(System.Int32?)reader["CurrentPhaseId"];
					c.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.DesignedPrice = (reader.IsDBNull(reader.GetOrdinal("DesignedPrice")))?null:(System.Decimal?)reader["DesignedPrice"];
					c.AuctualPrice = (reader.IsDBNull(reader.GetOrdinal("AuctualPrice")))?null:(System.Decimal?)reader["AuctualPrice"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Project"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Project"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Project entity)
		{
			if (!reader.Read()) return;
			
			entity.ProjectId = (System.Int32)reader["ProjectId"];
			entity.GroupId = (System.Int32)reader["GroupId"];
			entity.ContractId = (System.Int32)reader["ContractId"];
			entity.ManagerId = (reader.IsDBNull(reader.GetOrdinal("ManagerId")))?null:(System.Int32?)reader["ManagerId"];
			entity.CurrentPhaseId = (reader.IsDBNull(reader.GetOrdinal("CurrentPhaseId")))?null:(System.Int32?)reader["CurrentPhaseId"];
			entity.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.DesignedPrice = (reader.IsDBNull(reader.GetOrdinal("DesignedPrice")))?null:(System.Decimal?)reader["DesignedPrice"];
			entity.AuctualPrice = (reader.IsDBNull(reader.GetOrdinal("AuctualPrice")))?null:(System.Decimal?)reader["AuctualPrice"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Project"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Project"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Project entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProjectId = (System.Int32)dataRow["ProjectId"];
			entity.GroupId = (System.Int32)dataRow["GroupId"];
			entity.ContractId = (System.Int32)dataRow["ContractId"];
			entity.ManagerId = (Convert.IsDBNull(dataRow["ManagerId"]))?null:(System.Int32?)dataRow["ManagerId"];
			entity.CurrentPhaseId = (Convert.IsDBNull(dataRow["CurrentPhaseId"]))?null:(System.Int32?)dataRow["CurrentPhaseId"];
			entity.CurrencyUnitId = (Convert.IsDBNull(dataRow["CurrencyUnitId"]))?null:(System.Int32?)dataRow["CurrencyUnitId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.DesignedPrice = (Convert.IsDBNull(dataRow["DesignedPrice"]))?null:(System.Decimal?)dataRow["DesignedPrice"];
			entity.AuctualPrice = (Convert.IsDBNull(dataRow["AuctualPrice"]))?null:(System.Decimal?)dataRow["AuctualPrice"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Boolean?)dataRow["IsApprove"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.ExchangeRate = (Convert.IsDBNull(dataRow["ExchangeRate"]))?null:(System.Int32?)dataRow["ExchangeRate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Project"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Project Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Project entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region GroupIdSource	
			if (CanDeepLoad(entity, "Group", "GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.GroupId;
				Group tmpEntity = EntityManager.LocateEntity<Group>(EntityLocator.ConstructKeyFromPkItems(typeof(Group), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.GroupProvider.GetByGroupId(entity.GroupId);
			
				if (deep && entity.GroupIdSource != null)
				{
					DataRepository.GroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion GroupIdSource

			#region ContractIdSource	
			if (CanDeepLoad(entity, "Contract", "ContractIdSource", deepLoadType, innerList) 
				&& entity.ContractIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContractId;
				Contract tmpEntity = EntityManager.LocateEntity<Contract>(EntityLocator.ConstructKeyFromPkItems(typeof(Contract), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContractIdSource = tmpEntity;
				else
					entity.ContractIdSource = DataRepository.ContractProvider.GetByContractId(entity.ContractId);
			
				if (deep && entity.ContractIdSource != null)
				{
					DataRepository.ContractProvider.DeepLoad(transactionManager, entity.ContractIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ContractIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByProjectId methods when available
			
			#region ProjectPhaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProjectPhase>", "ProjectPhaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProjectPhaseCollection' loaded.");
				#endif 

				entity.ProjectPhaseCollection = DataRepository.ProjectPhaseProvider.GetByProjectId(transactionManager, entity.ProjectId);

				if (deep && entity.ProjectPhaseCollection.Count > 0)
				{
					DataRepository.ProjectPhaseProvider.DeepLoad(transactionManager, entity.ProjectPhaseCollection, deep, deepLoadType, childTypes, innerList);
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

				entity.ItemInProjectCollection = DataRepository.ItemInProjectProvider.GetByProjectId(transactionManager, entity.ProjectId);

				if (deep && entity.ItemInProjectCollection.Count > 0)
				{
					DataRepository.ItemInProjectProvider.DeepLoad(transactionManager, entity.ItemInProjectCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Project object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Project instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Project Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Project entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GroupIdSource
			if (CanDeepSave(entity, "Group", "GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.GroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			
			#region ContractIdSource
			if (CanDeepSave(entity, "Contract", "ContractIdSource", deepSaveType, innerList) 
				&& entity.ContractIdSource != null)
			{
				DataRepository.ContractProvider.Save(transactionManager, entity.ContractIdSource);
				entity.ContractId = entity.ContractIdSource.ContractId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<ProjectPhase>
				if (CanDeepSave(entity, "List<ProjectPhase>", "ProjectPhaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProjectPhase child in entity.ProjectPhaseCollection)
					{
						child.ProjectId = entity.ProjectId;
					}
				
				if (entity.ProjectPhaseCollection.Count > 0 || entity.ProjectPhaseCollection.DeletedItems.Count > 0)
					DataRepository.ProjectPhaseProvider.DeepSave(transactionManager, entity.ProjectPhaseCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemInProject>
				if (CanDeepSave(entity, "List<ItemInProject>", "ItemInProjectCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInProject child in entity.ItemInProjectCollection)
					{
						child.ProjectId = entity.ProjectId;
					}
				
				if (entity.ItemInProjectCollection.Count > 0 || entity.ItemInProjectCollection.DeletedItems.Count > 0)
					DataRepository.ItemInProjectProvider.DeepSave(transactionManager, entity.ItemInProjectCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region ProjectChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Project</c>
	///</summary>
	public enum ProjectChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Group</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(Group))]
		Group,
			
		///<summary>
		/// Composite Property for <c>Contract</c> at ContractIdSource
		///</summary>
		[ChildEntityType(typeof(Contract))]
		Contract,
	
		///<summary>
		/// Collection of <c>Project</c> as OneToMany for ProjectPhaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProjectPhase>))]
		ProjectPhaseCollection,

		///<summary>
		/// Collection of <c>Project</c> as OneToMany for ItemInProjectCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInProject>))]
		ItemInProjectCollection,
	}
	
	#endregion ProjectChildEntityTypes
	
	#region ProjectFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectFilterBuilder : SqlFilterBuilder<ProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		public ProjectFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectFilterBuilder
	
	#region ProjectParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectParameterBuilder : ParameterizedSqlFilterBuilder<ProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		public ProjectParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectParameterBuilder
} // end namespace
