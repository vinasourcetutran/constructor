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
	/// This class is the base class for any <see cref="ProjectPhaseProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProjectPhaseProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ProjectPhase, RLM.Construction.Entities.ProjectPhaseKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ProjectPhaseKey key)
		{
			return Delete(transactionManager, key.ProjectPhaseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="projectPhaseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 projectPhaseId)
		{
			return Delete(null, projectPhaseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectPhaseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 projectPhaseId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		FK_ProjectPhase_Project Description: 
		/// </summary>
		/// <param name="projectId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(projectId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		FK_ProjectPhase_Project Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		FK_ProjectPhase_Project Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		fKProjectPhaseProject Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="projectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(System.Int32 projectId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProjectId(null, projectId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		fKProjectPhaseProject Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="projectId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(System.Int32 projectId, int start, int pageLength,out int count)
		{
			return GetByProjectId(null, projectId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Project key.
		///		FK_ProjectPhase_Project Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public abstract RLM.Construction.Entities.TList<ProjectPhase> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		FK_ProjectPhase_Contract Description: 
		/// </summary>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(System.Int32? contractId)
		{
			int count = -1;
			return GetByContractId(contractId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		FK_ProjectPhase_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(TransactionManager transactionManager, System.Int32? contractId)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		FK_ProjectPhase_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(TransactionManager transactionManager, System.Int32? contractId, int start, int pageLength)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		fKProjectPhaseContract Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(System.Int32? contractId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContractId(null, contractId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		fKProjectPhaseContract Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(System.Int32? contractId, int start, int pageLength,out int count)
		{
			return GetByContractId(null, contractId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProjectPhase_Contract key.
		///		FK_ProjectPhase_Contract Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ProjectPhase objects.</returns>
		public abstract RLM.Construction.Entities.TList<ProjectPhase> GetByContractId(TransactionManager transactionManager, System.Int32? contractId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.ProjectPhase Get(TransactionManager transactionManager, RLM.Construction.Entities.ProjectPhaseKey key, int start, int pageLength)
		{
			return GetByProjectPhaseId(transactionManager, key.ProjectPhaseId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProjectPhase index.
		/// </summary>
		/// <param name="projectPhaseId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(System.Int32 projectPhaseId)
		{
			int count = -1;
			return GetByProjectPhaseId(null,projectPhaseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProjectPhase index.
		/// </summary>
		/// <param name="projectPhaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(System.Int32 projectPhaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectPhaseId(null, projectPhaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProjectPhase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectPhaseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(TransactionManager transactionManager, System.Int32 projectPhaseId)
		{
			int count = -1;
			return GetByProjectPhaseId(transactionManager, projectPhaseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProjectPhase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectPhaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(TransactionManager transactionManager, System.Int32 projectPhaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectPhaseId(transactionManager, projectPhaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProjectPhase index.
		/// </summary>
		/// <param name="projectPhaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(System.Int32 projectPhaseId, int start, int pageLength, out int count)
		{
			return GetByProjectPhaseId(null, projectPhaseId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProjectPhase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectPhaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ProjectPhase"/> class.</returns>
		public abstract RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(TransactionManager transactionManager, System.Int32 projectPhaseId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ProjectPhase&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ProjectPhase&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ProjectPhase> Fill(IDataReader reader, RLM.Construction.Entities.TList<ProjectPhase> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ProjectPhase c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProjectPhase" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId"))?(int)0:(System.Int32)reader["ProjectPhaseId"]).ToString();

					c = EntityManager.LocateOrCreate<ProjectPhase>(
						key.ToString(), // EntityTrackingKey 
						"ProjectPhase",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ProjectPhase();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProjectPhaseId = (System.Int32)reader["ProjectPhaseId"];
					c.ParentProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ParentProjectPhaseId")))?null:(System.Int32?)reader["ParentProjectPhaseId"];
					c.ProjectId = (System.Int32)reader["ProjectId"];
					c.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
					c.ManagerId = (reader.IsDBNull(reader.GetOrdinal("ManagerId")))?null:(System.Int32?)reader["ManagerId"];
					c.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.DesignPrice = (reader.IsDBNull(reader.GetOrdinal("DesignPrice")))?null:(System.Decimal?)reader["DesignPrice"];
					c.AuctualPrice = (reader.IsDBNull(reader.GetOrdinal("AuctualPrice")))?null:(System.Decimal?)reader["AuctualPrice"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
					c.IsCurrentProjectPhase = (reader.IsDBNull(reader.GetOrdinal("IsCurrentProjectPhase")))?null:(System.Boolean?)reader["IsCurrentProjectPhase"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
					c.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
					c.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
					c.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
					c.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
					c.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
					c.IsCollectItemFromChild = (reader.IsDBNull(reader.GetOrdinal("IsCollectItemFromChild")))?null:(System.Boolean?)reader["IsCollectItemFromChild"];
					c.IsStart = (reader.IsDBNull(reader.GetOrdinal("IsStart")))?null:(System.Boolean?)reader["IsStart"];
					c.IsFinished = (reader.IsDBNull(reader.GetOrdinal("IsFinished")))?null:(System.Boolean?)reader["IsFinished"];
					c.IsBillable = (reader.IsDBNull(reader.GetOrdinal("IsBillable")))?null:(System.Boolean?)reader["IsBillable"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ProjectPhase"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ProjectPhase"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ProjectPhase entity)
		{
			if (!reader.Read()) return;
			
			entity.ProjectPhaseId = (System.Int32)reader["ProjectPhaseId"];
			entity.ParentProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ParentProjectPhaseId")))?null:(System.Int32?)reader["ParentProjectPhaseId"];
			entity.ProjectId = (System.Int32)reader["ProjectId"];
			entity.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
			entity.ManagerId = (reader.IsDBNull(reader.GetOrdinal("ManagerId")))?null:(System.Int32?)reader["ManagerId"];
			entity.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.DesignPrice = (reader.IsDBNull(reader.GetOrdinal("DesignPrice")))?null:(System.Decimal?)reader["DesignPrice"];
			entity.AuctualPrice = (reader.IsDBNull(reader.GetOrdinal("AuctualPrice")))?null:(System.Decimal?)reader["AuctualPrice"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
			entity.IsCurrentProjectPhase = (reader.IsDBNull(reader.GetOrdinal("IsCurrentProjectPhase")))?null:(System.Boolean?)reader["IsCurrentProjectPhase"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
			entity.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
			entity.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
			entity.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
			entity.ParentPath = (reader.IsDBNull(reader.GetOrdinal("ParentPath")))?null:(System.String)reader["ParentPath"];
			entity.IsCollectItemFromChild = (reader.IsDBNull(reader.GetOrdinal("IsCollectItemFromChild")))?null:(System.Boolean?)reader["IsCollectItemFromChild"];
			entity.IsStart = (reader.IsDBNull(reader.GetOrdinal("IsStart")))?null:(System.Boolean?)reader["IsStart"];
			entity.IsFinished = (reader.IsDBNull(reader.GetOrdinal("IsFinished")))?null:(System.Boolean?)reader["IsFinished"];
			entity.IsBillable = (reader.IsDBNull(reader.GetOrdinal("IsBillable")))?null:(System.Boolean?)reader["IsBillable"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ProjectPhase"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ProjectPhase"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ProjectPhase entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProjectPhaseId = (System.Int32)dataRow["ProjectPhaseId"];
			entity.ParentProjectPhaseId = (Convert.IsDBNull(dataRow["ParentProjectPhaseId"]))?null:(System.Int32?)dataRow["ParentProjectPhaseId"];
			entity.ProjectId = (System.Int32)dataRow["ProjectId"];
			entity.ContractId = (Convert.IsDBNull(dataRow["ContractId"]))?null:(System.Int32?)dataRow["ContractId"];
			entity.ManagerId = (Convert.IsDBNull(dataRow["ManagerId"]))?null:(System.Int32?)dataRow["ManagerId"];
			entity.CurrencyUnitId = (Convert.IsDBNull(dataRow["CurrencyUnitId"]))?null:(System.Int32?)dataRow["CurrencyUnitId"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.DesignPrice = (Convert.IsDBNull(dataRow["DesignPrice"]))?null:(System.Decimal?)dataRow["DesignPrice"];
			entity.AuctualPrice = (Convert.IsDBNull(dataRow["AuctualPrice"]))?null:(System.Decimal?)dataRow["AuctualPrice"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Boolean?)dataRow["IsApprove"];
			entity.IsCurrentProjectPhase = (Convert.IsDBNull(dataRow["IsCurrentProjectPhase"]))?null:(System.Boolean?)dataRow["IsCurrentProjectPhase"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
			entity.FromDate = (Convert.IsDBNull(dataRow["FromDate"]))?null:(System.DateTime?)dataRow["FromDate"];
			entity.ToDate = (Convert.IsDBNull(dataRow["ToDate"]))?null:(System.DateTime?)dataRow["ToDate"];
			entity.RealFromDate = (Convert.IsDBNull(dataRow["RealFromDate"]))?null:(System.DateTime?)dataRow["RealFromDate"];
			entity.RealToDate = (Convert.IsDBNull(dataRow["RealToDate"]))?null:(System.DateTime?)dataRow["RealToDate"];
			entity.ParentPath = (Convert.IsDBNull(dataRow["ParentPath"]))?null:(System.String)dataRow["ParentPath"];
			entity.IsCollectItemFromChild = (Convert.IsDBNull(dataRow["IsCollectItemFromChild"]))?null:(System.Boolean?)dataRow["IsCollectItemFromChild"];
			entity.IsStart = (Convert.IsDBNull(dataRow["IsStart"]))?null:(System.Boolean?)dataRow["IsStart"];
			entity.IsFinished = (Convert.IsDBNull(dataRow["IsFinished"]))?null:(System.Boolean?)dataRow["IsFinished"];
			entity.IsBillable = (Convert.IsDBNull(dataRow["IsBillable"]))?null:(System.Boolean?)dataRow["IsBillable"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ProjectPhase"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ProjectPhase Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ProjectPhase entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ProjectIdSource	
			if (CanDeepLoad(entity, "Project", "ProjectIdSource", deepLoadType, innerList) 
				&& entity.ProjectIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProjectId;
				Project tmpEntity = EntityManager.LocateEntity<Project>(EntityLocator.ConstructKeyFromPkItems(typeof(Project), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProjectIdSource = tmpEntity;
				else
					entity.ProjectIdSource = DataRepository.ProjectProvider.GetByProjectId(entity.ProjectId);
			
				if (deep && entity.ProjectIdSource != null)
				{
					DataRepository.ProjectProvider.DeepLoad(transactionManager, entity.ProjectIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProjectIdSource

			#region ContractIdSource	
			if (CanDeepLoad(entity, "Contract", "ContractIdSource", deepLoadType, innerList) 
				&& entity.ContractIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ContractId ?? (int)0);
				Contract tmpEntity = EntityManager.LocateEntity<Contract>(EntityLocator.ConstructKeyFromPkItems(typeof(Contract), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContractIdSource = tmpEntity;
				else
					entity.ContractIdSource = DataRepository.ContractProvider.GetByContractId((entity.ContractId ?? (int)0));
			
				if (deep && entity.ContractIdSource != null)
				{
					DataRepository.ContractProvider.DeepLoad(transactionManager, entity.ContractIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ContractIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ProjectPhase object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ProjectPhase instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ProjectPhase Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ProjectPhase entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProjectIdSource
			if (CanDeepSave(entity, "Project", "ProjectIdSource", deepSaveType, innerList) 
				&& entity.ProjectIdSource != null)
			{
				DataRepository.ProjectProvider.Save(transactionManager, entity.ProjectIdSource);
				entity.ProjectId = entity.ProjectIdSource.ProjectId;
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
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProjectPhaseChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ProjectPhase</c>
	///</summary>
	public enum ProjectPhaseChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Project</c> at ProjectIdSource
		///</summary>
		[ChildEntityType(typeof(Project))]
		Project,
			
		///<summary>
		/// Composite Property for <c>Contract</c> at ContractIdSource
		///</summary>
		[ChildEntityType(typeof(Contract))]
		Contract,
		}
	
	#endregion ProjectPhaseChildEntityTypes
	
	#region ProjectPhaseFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProjectPhase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectPhaseFilterBuilder : SqlFilterBuilder<ProjectPhaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseFilterBuilder class.
		/// </summary>
		public ProjectPhaseFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectPhaseFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectPhaseFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectPhaseFilterBuilder
	
	#region ProjectPhaseParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProjectPhase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectPhaseParameterBuilder : ParameterizedSqlFilterBuilder<ProjectPhaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseParameterBuilder class.
		/// </summary>
		public ProjectPhaseParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectPhaseParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectPhaseParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectPhaseParameterBuilder
} // end namespace
