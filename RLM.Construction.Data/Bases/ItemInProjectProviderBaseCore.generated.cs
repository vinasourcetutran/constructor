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
	/// This class is the base class for any <see cref="ItemInProjectProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemInProjectProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemInProject, RLM.Construction.Entities.ItemInProjectKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemInProjectKey key)
		{
			return Delete(transactionManager, key.ItemInProjectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="itemInProjectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 itemInProjectId)
		{
			return Delete(null, itemInProjectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInProjectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 itemInProjectId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		FK_ItemInProject_Unit Description: 
		/// </summary>
		/// <param name="priceUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(System.Int32? priceUnitId)
		{
			int count = -1;
			return GetByPriceUnitId(priceUnitId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		FK_ItemInProject_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId)
		{
			int count = -1;
			return GetByPriceUnitId(transactionManager, priceUnitId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		FK_ItemInProject_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriceUnitId(transactionManager, priceUnitId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		fKItemInProjectUnit Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="priceUnitId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(System.Int32? priceUnitId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPriceUnitId(null, priceUnitId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		fKItemInProjectUnit Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="priceUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(System.Int32? priceUnitId, int start, int pageLength,out int count)
		{
			return GetByPriceUnitId(null, priceUnitId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProject_Unit key.
		///		FK_ItemInProject_Unit Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="priceUnitId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInProject> GetByPriceUnitId(TransactionManager transactionManager, System.Int32? priceUnitId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		FK_ItemInProjects_Contracts Description: 
		/// </summary>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByContractId(System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(contractId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		FK_ItemInProjects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInProject> GetByContractId(TransactionManager transactionManager, System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		FK_ItemInProjects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		fKItemInProjectsContracts Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByContractId(System.Int32 contractId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContractId(null, contractId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		fKItemInProjectsContracts Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contractId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByContractId(System.Int32 contractId, int start, int pageLength,out int count)
		{
			return GetByContractId(null, contractId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Contracts key.
		///		FK_ItemInProjects_Contracts Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInProject> GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		FK_ItemInProjects_Items Description: 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByItemId(System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		FK_ItemInProjects_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInProject> GetByItemId(TransactionManager transactionManager, System.Int64 itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		FK_ItemInProjects_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		fKItemInProjectsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByItemId(System.Int64 itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		fKItemInProjectsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByItemId(System.Int64 itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Items key.
		///		FK_ItemInProjects_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInProject> GetByItemId(TransactionManager transactionManager, System.Int64 itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		FK_ItemInProjects_Projects Description: 
		/// </summary>
		/// <param name="projectId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(projectId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		FK_ItemInProjects_Projects Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		FK_ItemInProjects_Projects Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(transactionManager, projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		fKItemInProjectsProjects Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="projectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(System.Int32 projectId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProjectId(null, projectId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		fKItemInProjectsProjects Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="projectId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(System.Int32 projectId, int start, int pageLength,out int count)
		{
			return GetByProjectId(null, projectId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemInProjects_Projects key.
		///		FK_ItemInProjects_Projects Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.ItemInProject objects.</returns>
		public abstract RLM.Construction.Entities.TList<ItemInProject> GetByProjectId(TransactionManager transactionManager, System.Int32 projectId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.ItemInProject Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemInProjectKey key, int start, int pageLength)
		{
			return GetByItemInProjectId(transactionManager, key.ItemInProjectId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemInProjects index.
		/// </summary>
		/// <param name="itemInProjectId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public RLM.Construction.Entities.ItemInProject GetByItemInProjectId(System.Int32 itemInProjectId)
		{
			int count = -1;
			return GetByItemInProjectId(null,itemInProjectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInProjects index.
		/// </summary>
		/// <param name="itemInProjectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public RLM.Construction.Entities.ItemInProject GetByItemInProjectId(System.Int32 itemInProjectId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemInProjectId(null, itemInProjectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInProjects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInProjectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public RLM.Construction.Entities.ItemInProject GetByItemInProjectId(TransactionManager transactionManager, System.Int32 itemInProjectId)
		{
			int count = -1;
			return GetByItemInProjectId(transactionManager, itemInProjectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInProjects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInProjectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public RLM.Construction.Entities.ItemInProject GetByItemInProjectId(TransactionManager transactionManager, System.Int32 itemInProjectId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemInProjectId(transactionManager, itemInProjectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInProjects index.
		/// </summary>
		/// <param name="itemInProjectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public RLM.Construction.Entities.ItemInProject GetByItemInProjectId(System.Int32 itemInProjectId, int start, int pageLength, out int count)
		{
			return GetByItemInProjectId(null, itemInProjectId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemInProjects index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemInProjectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemInProject"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemInProject GetByItemInProjectId(TransactionManager transactionManager, System.Int32 itemInProjectId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemInProject&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemInProject&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemInProject> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemInProject> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ItemInProject c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemInProject" 
							+ (reader.IsDBNull(reader.GetOrdinal("ItemInProjectId"))?(int)0:(System.Int32)reader["ItemInProjectId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemInProject>(
						key.ToString(), // EntityTrackingKey 
						"ItemInProject",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemInProject();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ItemInProjectId = (System.Int32)reader["ItemInProjectId"];
					c.ItemId = (System.Int64)reader["ItemId"];
					c.ProjectId = (System.Int32)reader["ProjectId"];
					c.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
					c.ContractId = (System.Int32)reader["ContractId"];
					c.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
					c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
					c.Quantity = (System.Double)reader["Quantity"];
					c.UnitPrice = (System.Decimal)reader["UnitPrice"];
					c.Total = (System.Decimal)reader["Total"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInProject"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInProject"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemInProject entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemInProjectId = (System.Int32)reader["ItemInProjectId"];
			entity.ItemId = (System.Int64)reader["ItemId"];
			entity.ProjectId = (System.Int32)reader["ProjectId"];
			entity.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
			entity.ContractId = (System.Int32)reader["ContractId"];
			entity.PriceUnitId = (reader.IsDBNull(reader.GetOrdinal("PriceUnitId")))?null:(System.Int32?)reader["PriceUnitId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.Quantity = (System.Double)reader["Quantity"];
			entity.UnitPrice = (System.Decimal)reader["UnitPrice"];
			entity.Total = (System.Decimal)reader["Total"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemInProject"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInProject"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemInProject entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemInProjectId = (System.Int32)dataRow["ItemInProjectId"];
			entity.ItemId = (System.Int64)dataRow["ItemId"];
			entity.ProjectId = (System.Int32)dataRow["ProjectId"];
			entity.ProjectPhaseId = (Convert.IsDBNull(dataRow["ProjectPhaseId"]))?null:(System.Int32?)dataRow["ProjectPhaseId"];
			entity.ContractId = (System.Int32)dataRow["ContractId"];
			entity.PriceUnitId = (Convert.IsDBNull(dataRow["PriceUnitId"]))?null:(System.Int32?)dataRow["PriceUnitId"];
			entity.ExchangeRate = (Convert.IsDBNull(dataRow["ExchangeRate"]))?null:(System.Int32?)dataRow["ExchangeRate"];
			entity.Quantity = (System.Double)dataRow["Quantity"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
			entity.Total = (System.Decimal)dataRow["Total"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Boolean?)dataRow["IsApprove"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemInProject"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInProject Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemInProject entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

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
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemInProject object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemInProject instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemInProject Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemInProject entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PriceUnitIdSource
			if (CanDeepSave(entity, "Unit", "PriceUnitIdSource", deepSaveType, innerList) 
				&& entity.PriceUnitIdSource != null)
			{
				DataRepository.UnitProvider.Save(transactionManager, entity.PriceUnitIdSource);
				entity.PriceUnitId = entity.PriceUnitIdSource.UnitId;
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
			
			#region ItemIdSource
			if (CanDeepSave(entity, "Item", "ItemIdSource", deepSaveType, innerList) 
				&& entity.ItemIdSource != null)
			{
				DataRepository.ItemProvider.Save(transactionManager, entity.ItemIdSource);
				entity.ItemId = entity.ItemIdSource.ItemId;
			}
			#endregion 
			
			#region ProjectIdSource
			if (CanDeepSave(entity, "Project", "ProjectIdSource", deepSaveType, innerList) 
				&& entity.ProjectIdSource != null)
			{
				DataRepository.ProjectProvider.Save(transactionManager, entity.ProjectIdSource);
				entity.ProjectId = entity.ProjectIdSource.ProjectId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ItemInProjectChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemInProject</c>
	///</summary>
	public enum ItemInProjectChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Unit</c> at PriceUnitIdSource
		///</summary>
		[ChildEntityType(typeof(Unit))]
		Unit,
			
		///<summary>
		/// Composite Property for <c>Contract</c> at ContractIdSource
		///</summary>
		[ChildEntityType(typeof(Contract))]
		Contract,
			
		///<summary>
		/// Composite Property for <c>Item</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Item))]
		Item,
			
		///<summary>
		/// Composite Property for <c>Project</c> at ProjectIdSource
		///</summary>
		[ChildEntityType(typeof(Project))]
		Project,
		}
	
	#endregion ItemInProjectChildEntityTypes
	
	#region ItemInProjectFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInProject"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInProjectFilterBuilder : SqlFilterBuilder<ItemInProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInProjectFilterBuilder class.
		/// </summary>
		public ItemInProjectFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInProjectFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInProjectFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInProjectFilterBuilder
	
	#region ItemInProjectParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInProject"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInProjectParameterBuilder : ParameterizedSqlFilterBuilder<ItemInProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInProjectParameterBuilder class.
		/// </summary>
		public ItemInProjectParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemInProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemInProjectParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemInProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemInProjectParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemInProjectParameterBuilder
} // end namespace
