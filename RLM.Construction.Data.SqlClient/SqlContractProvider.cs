#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using RLM.Construction.Entities;
using RLM.Construction.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

#endregion

namespace RLM.Construction.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Contract"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlContractProvider: SqlContractProviderBase
	{
		/// <summary>
		/// Creates a new <see cref="SqlContractProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlContractProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}


        #region Insert Methods

        /// <summary>
        /// 	Inserts a RLM.Construction.Entities.Contract object into the datasource using a transaction.
        /// </summary>
        /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
        /// <param name="entity">RLM.Construction.Entities.Contract object to insert.</param>
        /// <remarks>
        ///		After inserting into the datasource, the RLM.Construction.Entities.Contract object will be updated
        /// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
        /// </remarks>	
        /// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
        public override bool Insert(TransactionManager transactionManager, RLM.Construction.Entities.Contract entity)
        {
            SqlDatabase database = new SqlDatabase(this.ConnectionString);
            DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Contract_Insert", UseStoredProcedure);

            database.AddOutParameter(commandWrapper, "@ContractId", DbType.Int32, 4);
            database.AddInParameter(commandWrapper, "@FromContactName", DbType.String, entity.FromContactName);
            database.AddInParameter(commandWrapper, "@ToContactName", DbType.String, entity.ToContactName);
            database.AddInParameter(commandWrapper, "@Type", DbType.Int32, (entity.Type.HasValue ? (object)entity.Type : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ConstructDeptId", DbType.Int32, (entity.ConstructDeptId.HasValue ? (object)entity.ConstructDeptId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@DesignDeptId", DbType.Int32, (entity.DesignDeptId.HasValue ? (object)entity.DesignDeptId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, (entity.GroupId.HasValue ? (object)entity.GroupId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@PartnerId", DbType.Int32, (entity.PartnerId.HasValue ? (object)entity.PartnerId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Code", DbType.String, entity.Code);
            database.AddInParameter(commandWrapper, "@Days", DbType.Int32, entity.Days);
            database.AddInParameter(commandWrapper, "@RealDays", DbType.Int32, entity.RealDays);
            database.AddInParameter(commandWrapper, "@Number", DbType.String, entity.Number);
            database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name);
            database.AddInParameter(commandWrapper, "@Description", DbType.String, entity.Description);
            database.AddInParameter(commandWrapper, "@Comment", DbType.String, entity.Comment);
            database.AddInParameter(commandWrapper, "@InitPrice", DbType.Currency, (entity.InitPrice.HasValue ? (object)entity.InitPrice : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastPrice", DbType.Currency, (entity.LastPrice.HasValue ? (object)entity.LastPrice : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@SignedDate", DbType.DateTime, (entity.SignedDate.HasValue ? (object)entity.SignedDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@FromDate", DbType.DateTime, (entity.FromDate.HasValue ? (object)entity.FromDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ToDate", DbType.DateTime, (entity.ToDate.HasValue ? (object)entity.ToDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@RealFromDate", DbType.DateTime, (entity.RealFromDate.HasValue ? (object)entity.RealFromDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@RealToDate", DbType.DateTime, (entity.RealToDate.HasValue ? (object)entity.RealToDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Status", DbType.Int32, (entity.Status.HasValue ? (object)entity.Status : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsApprove", DbType.Boolean, (entity.IsApprove.HasValue ? (object)entity.IsApprove : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object)entity.IsActive : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsPrinted", DbType.Int64, (entity.IsPrinted.HasValue ? (object)entity.IsPrinted : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CurrencyUnitId", DbType.Int32, (entity.CurrencyUnitId.HasValue ? (object)entity.CurrencyUnitId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ContractType", DbType.Int32, (entity.ContractType.HasValue ? (object)entity.ContractType : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@FromContactorId", DbType.Int32, (entity.FromContactorId.HasValue ? (object)entity.FromContactorId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ToContactorId", DbType.Int32, (entity.ToContactorId.HasValue ? (object)entity.ToContactorId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@VATTax", DbType.Double, (entity.VATTax.HasValue ? (object)entity.VATTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@PITTax", DbType.Double, (entity.PITTax.HasValue ? (object)entity.PITTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CITTax", DbType.Double, (entity.CITTax.HasValue ? (object)entity.CITTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Other", DbType.Currency, (entity.Other.HasValue ? (object)entity.Other : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CreationUserId", DbType.Int32, (entity.CreationUserId.HasValue ? (object)entity.CreationUserId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, (entity.CreationDate.HasValue ? (object)entity.CreationDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastModificationUserId", DbType.Int32, (entity.LastModificationUserId.HasValue ? (object)entity.LastModificationUserId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastModificationDate", DbType.DateTime, (entity.LastModificationDate.HasValue ? (object)entity.LastModificationDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ExchangeRate", DbType.Int32, (entity.ExchangeRate.HasValue ? (object)entity.ExchangeRate : System.DBNull.Value));

            int results = 0;


            if (transactionManager != null)
            {
                results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
            }
            else
            {
                results = Utility.ExecuteNonQuery(database, commandWrapper);
            }


            entity.ContractId = (System.Int32)database.GetParameterValue(commandWrapper, "@ContractId");


            entity.AcceptChanges();

            return Convert.ToBoolean(results);
        }
        #endregion

        #region Update Methods

        /// <summary>
        /// 	Update an existing row in the datasource.
        /// </summary>
        /// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
        /// <param name="entity">RLM.Construction.Entities.Contract object to update.</param>
        /// <remarks>
        ///		After updating the datasource, the RLM.Construction.Entities.Contract object will be updated
        /// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
        /// </remarks>
        /// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
        public override bool Update(TransactionManager transactionManager, RLM.Construction.Entities.Contract entity)
        {
            SqlDatabase database = new SqlDatabase(this.ConnectionString);
            DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.Contract_Update", UseStoredProcedure);

            database.AddInParameter(commandWrapper, "@ContractId", DbType.Int32, entity.ContractId);
            database.AddInParameter(commandWrapper, "@FromContactName", DbType.String, entity.FromContactName);
            database.AddInParameter(commandWrapper, "@ToContactName", DbType.String, entity.ToContactName);
            database.AddInParameter(commandWrapper, "@Type", DbType.Int32, (entity.Type.HasValue ? (object)entity.Type : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ConstructDeptId", DbType.Int32, (entity.ConstructDeptId.HasValue ? (object)entity.ConstructDeptId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@DesignDeptId", DbType.Int32, (entity.DesignDeptId.HasValue ? (object)entity.DesignDeptId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@GroupId", DbType.Int32, (entity.GroupId.HasValue ? (object)entity.GroupId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@PartnerId", DbType.Int32, (entity.PartnerId.HasValue ? (object)entity.PartnerId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Code", DbType.String, entity.Code);
            database.AddInParameter(commandWrapper, "@RealDays", DbType.Int32, entity.RealDays);
            database.AddInParameter(commandWrapper, "@Days", DbType.Int32, entity.Days);
            database.AddInParameter(commandWrapper, "@Number", DbType.String, entity.Number);
            database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name);
            database.AddInParameter(commandWrapper, "@Description", DbType.String, entity.Description);
            database.AddInParameter(commandWrapper, "@Comment", DbType.String, entity.Comment);
            database.AddInParameter(commandWrapper, "@InitPrice", DbType.Currency, (entity.InitPrice.HasValue ? (object)entity.InitPrice : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastPrice", DbType.Currency, (entity.LastPrice.HasValue ? (object)entity.LastPrice : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@SignedDate", DbType.DateTime, (entity.SignedDate.HasValue ? (object)entity.SignedDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@FromDate", DbType.DateTime, (entity.FromDate.HasValue ? (object)entity.FromDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ToDate", DbType.DateTime, (entity.ToDate.HasValue ? (object)entity.ToDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@RealFromDate", DbType.DateTime, (entity.RealFromDate.HasValue ? (object)entity.RealFromDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@RealToDate", DbType.DateTime, (entity.RealToDate.HasValue ? (object)entity.RealToDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Status", DbType.Int32, (entity.Status.HasValue ? (object)entity.Status : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsApprove", DbType.Boolean, (entity.IsApprove.HasValue ? (object)entity.IsApprove : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object)entity.IsActive : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@IsPrinted", DbType.Int64, (entity.IsPrinted.HasValue ? (object)entity.IsPrinted : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CurrencyUnitId", DbType.Int32, (entity.CurrencyUnitId.HasValue ? (object)entity.CurrencyUnitId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ContractType", DbType.Int32, (entity.ContractType.HasValue ? (object)entity.ContractType : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@FromContactorId", DbType.Int32, (entity.FromContactorId.HasValue ? (object)entity.FromContactorId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ToContactorId", DbType.Int32, (entity.ToContactorId.HasValue ? (object)entity.ToContactorId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@VATTax", DbType.Double, (entity.VATTax.HasValue ? (object)entity.VATTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@PITTax", DbType.Double, (entity.PITTax.HasValue ? (object)entity.PITTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CITTax", DbType.Double, (entity.CITTax.HasValue ? (object)entity.CITTax : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@Other", DbType.Currency, (entity.Other.HasValue ? (object)entity.Other : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CreationUserId", DbType.Int32, (entity.CreationUserId.HasValue ? (object)entity.CreationUserId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, (entity.CreationDate.HasValue ? (object)entity.CreationDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastModificationUserId", DbType.Int32, (entity.LastModificationUserId.HasValue ? (object)entity.LastModificationUserId : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@LastModificationDate", DbType.DateTime, (entity.LastModificationDate.HasValue ? (object)entity.LastModificationDate : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@ExchangeRate", DbType.Int32, (entity.ExchangeRate.HasValue ? (object)entity.ExchangeRate : System.DBNull.Value));

            int results = 0;


            if (transactionManager != null)
            {
                results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
            }
            else
            {
                results = Utility.ExecuteNonQuery(database, commandWrapper);
            }

            //Stop Tracking Now that it has been updated and persisted.
            if (DataRepository.Provider.EnableEntityTracking)
                EntityManager.StopTracking(entity.EntityTrackingKey);


            entity.AcceptChanges();

            return Convert.ToBoolean(results);
        }

        #endregion
	}
}