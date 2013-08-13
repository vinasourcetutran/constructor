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
	/// This class is the base class for any <see cref="ContractProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContractProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Contract, RLM.Construction.Entities.ContractKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ContractKey key)
		{
			return Delete(transactionManager, key.ContractId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="contractId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 contractId)
		{
			return Delete(null, contractId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 contractId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		FK_Contracts_Groups Description: 
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		public RLM.Construction.Entities.TList<Contract> GetByGroupId(System.Int32? groupId)
		{
			int count = -1;
			return GetByGroupId(groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		FK_Contracts_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<Contract> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		FK_Contracts_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		public RLM.Construction.Entities.TList<Contract> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		fKContractsGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		public RLM.Construction.Entities.TList<Contract> GetByGroupId(System.Int32? groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		fKContractsGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		public RLM.Construction.Entities.TList<Contract> GetByGroupId(System.Int32? groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Contracts_Groups key.
		///		FK_Contracts_Groups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.Contract objects.</returns>
		public abstract RLM.Construction.Entities.TList<Contract> GetByGroupId(TransactionManager transactionManager, System.Int32? groupId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.Contract Get(TransactionManager transactionManager, RLM.Construction.Entities.ContractKey key, int start, int pageLength)
		{
			return GetByContractId(transactionManager, key.ContractId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Contracts index.
		/// </summary>
		/// <param name="contractId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public RLM.Construction.Entities.Contract GetByContractId(System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(null,contractId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contracts index.
		/// </summary>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public RLM.Construction.Entities.Contract GetByContractId(System.Int32 contractId, int start, int pageLength)
		{
			int count = -1;
			return GetByContractId(null, contractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contracts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public RLM.Construction.Entities.Contract GetByContractId(TransactionManager transactionManager, System.Int32 contractId)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contracts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public RLM.Construction.Entities.Contract GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength)
		{
			int count = -1;
			return GetByContractId(transactionManager, contractId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contracts index.
		/// </summary>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public RLM.Construction.Entities.Contract GetByContractId(System.Int32 contractId, int start, int pageLength, out int count)
		{
			return GetByContractId(null, contractId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Contracts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contractId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Contract"/> class.</returns>
		public abstract RLM.Construction.Entities.Contract GetByContractId(TransactionManager transactionManager, System.Int32 contractId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Contract&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Contract&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Contract> Fill(IDataReader reader, RLM.Construction.Entities.TList<Contract> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Contract c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Contract" 
							+ (reader.IsDBNull(reader.GetOrdinal("ContractId"))?(int)0:(System.Int32)reader["ContractId"]).ToString();

					c = EntityManager.LocateOrCreate<Contract>(
						key.ToString(), // EntityTrackingKey 
						"Contract",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Contract();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ContractId = (System.Int32)reader["ContractId"];
					c.FromContactName = (reader.IsDBNull(reader.GetOrdinal("FromContactName")))?null:(System.String)reader["FromContactName"];
					c.ToContactName = (reader.IsDBNull(reader.GetOrdinal("ToContactName")))?null:(System.String)reader["ToContactName"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
					c.ConstructDeptId = (reader.IsDBNull(reader.GetOrdinal("ConstructDeptId")))?null:(System.Int32?)reader["ConstructDeptId"];
					c.DesignDeptId = (reader.IsDBNull(reader.GetOrdinal("DesignDeptId")))?null:(System.Int32?)reader["DesignDeptId"];
					c.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
					c.PartnerId = (reader.IsDBNull(reader.GetOrdinal("PartnerId")))?null:(System.Int32?)reader["PartnerId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Number = (reader.IsDBNull(reader.GetOrdinal("Number")))?null:(System.String)reader["Number"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.InitPrice = (reader.IsDBNull(reader.GetOrdinal("InitPrice")))?null:(System.Decimal?)reader["InitPrice"];
					c.LastPrice = (reader.IsDBNull(reader.GetOrdinal("LastPrice")))?null:(System.Decimal?)reader["LastPrice"];
					c.SignedDate = (reader.IsDBNull(reader.GetOrdinal("SignedDate")))?null:(System.DateTime?)reader["SignedDate"];
					c.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
					c.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
					c.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
					c.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsPrinted = (reader.IsDBNull(reader.GetOrdinal("IsPrinted")))?null:(System.Int64?)reader["IsPrinted"];
					c.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
					c.ContractType = (reader.IsDBNull(reader.GetOrdinal("ContractType")))?null:(System.Int32?)reader["ContractType"];
					c.FromContactorId = (reader.IsDBNull(reader.GetOrdinal("FromContactorId")))?null:(System.Int32?)reader["FromContactorId"];
					c.ToContactorId = (reader.IsDBNull(reader.GetOrdinal("ToContactorId")))?null:(System.Int32?)reader["ToContactorId"];
					c.VATTax = (reader.IsDBNull(reader.GetOrdinal("VATTax")))?null:(System.Double?)reader["VATTax"];
					c.PITTax = (reader.IsDBNull(reader.GetOrdinal("PITTax")))?null:(System.Double?)reader["PITTax"];
					c.CITTax = (reader.IsDBNull(reader.GetOrdinal("CITTax")))?null:(System.Double?)reader["CITTax"];
					c.Other = (reader.IsDBNull(reader.GetOrdinal("Other")))?null:(System.Decimal?)reader["Other"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Contract"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Contract"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Contract entity)
		{
			if (!reader.Read()) return;
			
			entity.ContractId = (System.Int32)reader["ContractId"];
			entity.FromContactName = (reader.IsDBNull(reader.GetOrdinal("FromContactName")))?null:(System.String)reader["FromContactName"];
			entity.ToContactName = (reader.IsDBNull(reader.GetOrdinal("ToContactName")))?null:(System.String)reader["ToContactName"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.ConstructDeptId = (reader.IsDBNull(reader.GetOrdinal("ConstructDeptId")))?null:(System.Int32?)reader["ConstructDeptId"];
			entity.DesignDeptId = (reader.IsDBNull(reader.GetOrdinal("DesignDeptId")))?null:(System.Int32?)reader["DesignDeptId"];
			entity.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
			entity.PartnerId = (reader.IsDBNull(reader.GetOrdinal("PartnerId")))?null:(System.Int32?)reader["PartnerId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Number = (reader.IsDBNull(reader.GetOrdinal("Number")))?null:(System.String)reader["Number"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.InitPrice = (reader.IsDBNull(reader.GetOrdinal("InitPrice")))?null:(System.Decimal?)reader["InitPrice"];
			entity.LastPrice = (reader.IsDBNull(reader.GetOrdinal("LastPrice")))?null:(System.Decimal?)reader["LastPrice"];
			entity.SignedDate = (reader.IsDBNull(reader.GetOrdinal("SignedDate")))?null:(System.DateTime?)reader["SignedDate"];
			entity.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
			entity.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
			entity.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
			entity.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Boolean?)reader["IsApprove"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsPrinted = (reader.IsDBNull(reader.GetOrdinal("IsPrinted")))?null:(System.Int64?)reader["IsPrinted"];
			entity.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
			entity.ContractType = (reader.IsDBNull(reader.GetOrdinal("ContractType")))?null:(System.Int32?)reader["ContractType"];
			entity.FromContactorId = (reader.IsDBNull(reader.GetOrdinal("FromContactorId")))?null:(System.Int32?)reader["FromContactorId"];
			entity.ToContactorId = (reader.IsDBNull(reader.GetOrdinal("ToContactorId")))?null:(System.Int32?)reader["ToContactorId"];
			entity.VATTax = (reader.IsDBNull(reader.GetOrdinal("VATTax")))?null:(System.Double?)reader["VATTax"];
			entity.PITTax = (reader.IsDBNull(reader.GetOrdinal("PITTax")))?null:(System.Double?)reader["PITTax"];
			entity.CITTax = (reader.IsDBNull(reader.GetOrdinal("CITTax")))?null:(System.Double?)reader["CITTax"];
			entity.Other = (reader.IsDBNull(reader.GetOrdinal("Other")))?null:(System.Decimal?)reader["Other"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Contract"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Contract"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Contract entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContractId = (System.Int32)dataRow["ContractId"];
			entity.FromContactName = (Convert.IsDBNull(dataRow["FromContactName"]))?null:(System.String)dataRow["FromContactName"];
			entity.ToContactName = (Convert.IsDBNull(dataRow["ToContactName"]))?null:(System.String)dataRow["ToContactName"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
			entity.ConstructDeptId = (Convert.IsDBNull(dataRow["ConstructDeptId"]))?null:(System.Int32?)dataRow["ConstructDeptId"];
			entity.DesignDeptId = (Convert.IsDBNull(dataRow["DesignDeptId"]))?null:(System.Int32?)dataRow["DesignDeptId"];
			entity.GroupId = (Convert.IsDBNull(dataRow["GroupId"]))?null:(System.Int32?)dataRow["GroupId"];
			entity.PartnerId = (Convert.IsDBNull(dataRow["PartnerId"]))?null:(System.Int32?)dataRow["PartnerId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Number = (Convert.IsDBNull(dataRow["Number"]))?null:(System.String)dataRow["Number"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.InitPrice = (Convert.IsDBNull(dataRow["InitPrice"]))?null:(System.Decimal?)dataRow["InitPrice"];
			entity.LastPrice = (Convert.IsDBNull(dataRow["LastPrice"]))?null:(System.Decimal?)dataRow["LastPrice"];
			entity.SignedDate = (Convert.IsDBNull(dataRow["SignedDate"]))?null:(System.DateTime?)dataRow["SignedDate"];
			entity.FromDate = (Convert.IsDBNull(dataRow["FromDate"]))?null:(System.DateTime?)dataRow["FromDate"];
			entity.ToDate = (Convert.IsDBNull(dataRow["ToDate"]))?null:(System.DateTime?)dataRow["ToDate"];
			entity.RealFromDate = (Convert.IsDBNull(dataRow["RealFromDate"]))?null:(System.DateTime?)dataRow["RealFromDate"];
			entity.RealToDate = (Convert.IsDBNull(dataRow["RealToDate"]))?null:(System.DateTime?)dataRow["RealToDate"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Boolean?)dataRow["IsApprove"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsPrinted = (Convert.IsDBNull(dataRow["IsPrinted"]))?null:(System.Int64?)dataRow["IsPrinted"];
			entity.CurrencyUnitId = (Convert.IsDBNull(dataRow["CurrencyUnitId"]))?null:(System.Int32?)dataRow["CurrencyUnitId"];
			entity.ContractType = (Convert.IsDBNull(dataRow["ContractType"]))?null:(System.Int32?)dataRow["ContractType"];
			entity.FromContactorId = (Convert.IsDBNull(dataRow["FromContactorId"]))?null:(System.Int32?)dataRow["FromContactorId"];
			entity.ToContactorId = (Convert.IsDBNull(dataRow["ToContactorId"]))?null:(System.Int32?)dataRow["ToContactorId"];
			entity.VATTax = (Convert.IsDBNull(dataRow["VATTax"]))?null:(System.Double?)dataRow["VATTax"];
			entity.PITTax = (Convert.IsDBNull(dataRow["PITTax"]))?null:(System.Double?)dataRow["PITTax"];
			entity.CITTax = (Convert.IsDBNull(dataRow["CITTax"]))?null:(System.Double?)dataRow["CITTax"];
			entity.Other = (Convert.IsDBNull(dataRow["Other"]))?null:(System.Decimal?)dataRow["Other"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Contract"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Contract Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Contract entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

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
			// Deep load child collections  - Call GetByContractId methods when available
			
			#region ProjectPhaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProjectPhase>", "ProjectPhaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProjectPhaseCollection' loaded.");
				#endif 

				entity.ProjectPhaseCollection = DataRepository.ProjectPhaseProvider.GetByContractId(transactionManager, entity.ContractId);

				if (deep && entity.ProjectPhaseCollection.Count > 0)
				{
					DataRepository.ProjectPhaseProvider.DeepLoad(transactionManager, entity.ProjectPhaseCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region RelatedContractCollectionByFromContractId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RelatedContract>", "RelatedContractCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'RelatedContractCollectionByFromContractId' loaded.");
				#endif 

				entity.RelatedContractCollectionByFromContractId = DataRepository.RelatedContractProvider.GetByFromContractId(transactionManager, entity.ContractId);

				if (deep && entity.RelatedContractCollectionByFromContractId.Count > 0)
				{
					DataRepository.RelatedContractProvider.DeepLoad(transactionManager, entity.RelatedContractCollectionByFromContractId, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region RelatedContractCollectionByToContractId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RelatedContract>", "RelatedContractCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'RelatedContractCollectionByToContractId' loaded.");
				#endif 

				entity.RelatedContractCollectionByToContractId = DataRepository.RelatedContractProvider.GetByToContractId(transactionManager, entity.ContractId);

				if (deep && entity.RelatedContractCollectionByToContractId.Count > 0)
				{
					DataRepository.RelatedContractProvider.DeepLoad(transactionManager, entity.RelatedContractCollectionByToContractId, deep, deepLoadType, childTypes, innerList);
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

				entity.ItemInProjectCollection = DataRepository.ItemInProjectProvider.GetByContractId(transactionManager, entity.ContractId);

				if (deep && entity.ItemInProjectCollection.Count > 0)
				{
					DataRepository.ItemInProjectProvider.DeepLoad(transactionManager, entity.ItemInProjectCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProjectCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Project>", "ProjectCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProjectCollection' loaded.");
				#endif 

				entity.ProjectCollection = DataRepository.ProjectProvider.GetByContractId(transactionManager, entity.ContractId);

				if (deep && entity.ProjectCollection.Count > 0)
				{
					DataRepository.ProjectProvider.DeepLoad(transactionManager, entity.ProjectCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Contract object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Contract instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Contract Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Contract entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			











			#region List<ProjectPhase>
				if (CanDeepSave(entity, "List<ProjectPhase>", "ProjectPhaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProjectPhase child in entity.ProjectPhaseCollection)
					{
						child.ContractId = entity.ContractId;
					}
				
				if (entity.ProjectPhaseCollection.Count > 0 || entity.ProjectPhaseCollection.DeletedItems.Count > 0)
					DataRepository.ProjectPhaseProvider.DeepSave(transactionManager, entity.ProjectPhaseCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<RelatedContract>
				if (CanDeepSave(entity, "List<RelatedContract>", "RelatedContractCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RelatedContract child in entity.RelatedContractCollectionByFromContractId)
					{
						child.FromContractId = entity.ContractId;
					}
				
				if (entity.RelatedContractCollectionByFromContractId.Count > 0 || entity.RelatedContractCollectionByFromContractId.DeletedItems.Count > 0)
					DataRepository.RelatedContractProvider.DeepSave(transactionManager, entity.RelatedContractCollectionByFromContractId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<RelatedContract>
				if (CanDeepSave(entity, "List<RelatedContract>", "RelatedContractCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RelatedContract child in entity.RelatedContractCollectionByToContractId)
					{
						child.ToContractId = entity.ContractId;
					}
				
				if (entity.RelatedContractCollectionByToContractId.Count > 0 || entity.RelatedContractCollectionByToContractId.DeletedItems.Count > 0)
					DataRepository.RelatedContractProvider.DeepSave(transactionManager, entity.RelatedContractCollectionByToContractId, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ItemInProject>
				if (CanDeepSave(entity, "List<ItemInProject>", "ItemInProjectCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemInProject child in entity.ItemInProjectCollection)
					{
						child.ContractId = entity.ContractId;
					}
				
				if (entity.ItemInProjectCollection.Count > 0 || entity.ItemInProjectCollection.DeletedItems.Count > 0)
					DataRepository.ItemInProjectProvider.DeepSave(transactionManager, entity.ItemInProjectCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Project>
				if (CanDeepSave(entity, "List<Project>", "ProjectCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Project child in entity.ProjectCollection)
					{
						child.ContractId = entity.ContractId;
					}
				
				if (entity.ProjectCollection.Count > 0 || entity.ProjectCollection.DeletedItems.Count > 0)
					DataRepository.ProjectProvider.DeepSave(transactionManager, entity.ProjectCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				





						
			return true;
		}
		#endregion
	} // end class
	
	#region ContractChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Contract</c>
	///</summary>
	public enum ContractChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Group</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(Group))]
		Group,
	
		///<summary>
		/// Collection of <c>Contract</c> as OneToMany for ProjectPhaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProjectPhase>))]
		ProjectPhaseCollection,

		///<summary>
		/// Collection of <c>Contract</c> as OneToMany for RelatedContractCollection
		///</summary>
		[ChildEntityType(typeof(TList<RelatedContract>))]
		RelatedContractCollectionByFromContractId,

		///<summary>
		/// Collection of <c>Contract</c> as OneToMany for RelatedContractCollection
		///</summary>
		[ChildEntityType(typeof(TList<RelatedContract>))]
		RelatedContractCollectionByToContractId,

		///<summary>
		/// Collection of <c>Contract</c> as OneToMany for ItemInProjectCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemInProject>))]
		ItemInProjectCollection,

		///<summary>
		/// Collection of <c>Contract</c> as OneToMany for ProjectCollection
		///</summary>
		[ChildEntityType(typeof(TList<Project>))]
		ProjectCollection,
	}
	
	#endregion ContractChildEntityTypes
	
	#region ContractFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContractFilterBuilder : SqlFilterBuilder<ContractColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContractFilterBuilder class.
		/// </summary>
		public ContractFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContractFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContractFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContractFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContractFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContractFilterBuilder
	
	#region ContractParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContractParameterBuilder : ParameterizedSqlFilterBuilder<ContractColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContractParameterBuilder class.
		/// </summary>
		public ContractParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContractParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContractParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContractParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContractParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContractParameterBuilder
} // end namespace
