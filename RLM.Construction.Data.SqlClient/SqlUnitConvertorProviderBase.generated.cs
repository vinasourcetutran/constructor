﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, December 16, 2010
	Important: Do not modify this file. Edit the file SqlUnitConvertorProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using RLM.Construction.Entities;
using RLM.Construction.Data;
using RLM.Construction.Data.Bases;

#endregion

namespace RLM.Construction.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="UnitConvertor"/> entity.
	///</summary>
	public partial class SqlUnitConvertorProviderBase : UnitConvertorProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlUnitConvertorProviderBase"/> instance.
		/// </summary>
		public SqlUnitConvertorProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlUnitConvertorProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlUnitConvertorProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="unitConvertorId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 unitConvertorId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@UnitConvertorId", DbType.Int32, unitConvertorId);
			
			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(UnitConvertor)
					,unitConvertorId);
				EntityManager.StopTracking(entityKey);
			}
			
			if (results == 0)
			{
				//throw new DataException("The record has been already deleted.");
				return false;
			}
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public override RLM.Construction.Entities.TList<UnitConvertor> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new RLM.Construction.Entities.TList<UnitConvertor>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@UnitConvertorId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@FromUnitId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ToUnitId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Quantity", DbType.Double, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EffectFrom", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ParentPath", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreationUserId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@LastModificationDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@LastModificationUserId", DbType.Int32, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("unitconvertorid ") || clause.Trim().StartsWith("unitconvertorid="))
				{
					database.SetParameterValue(commandWrapper, "@UnitConvertorId", 
						clause.Replace("unitconvertorid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("fromunitid ") || clause.Trim().StartsWith("fromunitid="))
				{
					database.SetParameterValue(commandWrapper, "@FromUnitId", 
						clause.Replace("fromunitid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("tounitid ") || clause.Trim().StartsWith("tounitid="))
				{
					database.SetParameterValue(commandWrapper, "@ToUnitId", 
						clause.Replace("tounitid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("quantity ") || clause.Trim().StartsWith("quantity="))
				{
					database.SetParameterValue(commandWrapper, "@Quantity", 
						clause.Replace("quantity","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("effectfrom ") || clause.Trim().StartsWith("effectfrom="))
				{
					database.SetParameterValue(commandWrapper, "@EffectFrom", 
						clause.Replace("effectfrom","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("parentpath ") || clause.Trim().StartsWith("parentpath="))
				{
					database.SetParameterValue(commandWrapper, "@ParentPath", 
						clause.Replace("parentpath","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("isdeletable ") || clause.Trim().StartsWith("isdeletable="))
				{
					database.SetParameterValue(commandWrapper, "@IsDeletable", 
						clause.Replace("isdeletable","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("isactive ") || clause.Trim().StartsWith("isactive="))
				{
					database.SetParameterValue(commandWrapper, "@IsActive", 
						clause.Replace("isactive","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("creationdate ") || clause.Trim().StartsWith("creationdate="))
				{
					database.SetParameterValue(commandWrapper, "@CreationDate", 
						clause.Replace("creationdate","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("creationuserid ") || clause.Trim().StartsWith("creationuserid="))
				{
					database.SetParameterValue(commandWrapper, "@CreationUserId", 
						clause.Replace("creationuserid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("lastmodificationdate ") || clause.Trim().StartsWith("lastmodificationdate="))
				{
					database.SetParameterValue(commandWrapper, "@LastModificationDate", 
						clause.Replace("lastmodificationdate","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("lastmodificationuserid ") || clause.Trim().StartsWith("lastmodificationuserid="))
				{
					database.SetParameterValue(commandWrapper, "@LastModificationUserId", 
						clause.Replace("lastmodificationuserid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
	
				
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();				
			}
			return rows;
		}

		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public override RLM.Construction.Entities.TList<UnitConvertor> Find(TransactionManager transactionManager, SqlFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Find_Dynamic", typeof(UnitConvertorColumn), parameters, orderBy, start, pageLength);
			
			if ( parameters != null )
			{
				SqlFilterParameter param;

				for ( int i = 0; i < parameters.Count; i++ )
				{
					param = parameters[i];
					database.AddInParameter(commandWrapper, param.Name, param.DbType, param.Value);
				}
			}

			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
			IDataReader reader = null;
			
			try
			{
				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;
				
				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if ( reader != null )
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion Parameterized Find Methods
		
		#endregion Find Functions
	
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.TList<UnitConvertor> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region GetPaged Methods
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
		public override RLM.Construction.Entities.TList<UnitConvertor> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions

		#region GetByFromUnitId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units key.
		///		FK_UnitConvertors_Units Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="fromUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.TList<UnitConvertor> GetByFromUnitId(TransactionManager transactionManager, System.Int32 fromUnitId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_GetByFromUnitId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@FromUnitId", DbType.Int32, fromUnitId);
			
			IDataReader reader = null;
			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
			
				//Create Collection
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}	
		#endregion
	

		#region GetByToUnitId
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_UnitConvertors_Units1 key.
		///		FK_UnitConvertors_Units1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="toUnitId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UnitConvertor objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.TList<UnitConvertor> GetByToUnitId(TransactionManager transactionManager, System.Int32 toUnitId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_GetByToUnitId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@ToUnitId", DbType.Int32, toUnitId);
			
			IDataReader reader = null;
			RLM.Construction.Entities.TList<UnitConvertor> rows = new RLM.Construction.Entities.TList<UnitConvertor>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
			
				//Create Collection
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}	
		#endregion
	
	#endregion
	
		#region Get By Index Functions

		#region GetByUnitConvertorId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UnitConvertors index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="unitConvertorId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UnitConvertor"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.UnitConvertor GetByUnitConvertorId(TransactionManager transactionManager, System.Int32 unitConvertorId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_GetByUnitConvertorId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@UnitConvertorId", DbType.Int32, unitConvertorId);
			
			IDataReader reader = null;
			RLM.Construction.Entities.TList<UnitConvertor> tmp = new RLM.Construction.Entities.TList<UnitConvertor>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the RLM.Construction.Entities.UnitConvertor object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<RLM.Construction.Entities.UnitConvertor> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "UnitConvertor";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("UnitConvertorId", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("FromUnitId", typeof(System.Int32));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("ToUnitId", typeof(System.Int32));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("Quantity", typeof(System.Double));
			col3.AllowDBNull = true;		
			DataColumn col4 = dataTable.Columns.Add("EffectFrom", typeof(System.DateTime));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("ParentPath", typeof(System.String));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("IsDeletable", typeof(System.Boolean));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("IsActive", typeof(System.Boolean));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("CreationDate", typeof(System.DateTime));
			col8.AllowDBNull = true;		
			DataColumn col9 = dataTable.Columns.Add("CreationUserId", typeof(System.Int32));
			col9.AllowDBNull = true;		
			DataColumn col10 = dataTable.Columns.Add("LastModificationDate", typeof(System.DateTime));
			col10.AllowDBNull = true;		
			DataColumn col11 = dataTable.Columns.Add("LastModificationUserId", typeof(System.Int32));
			col11.AllowDBNull = true;		
			
			bulkCopy.ColumnMappings.Add("UnitConvertorId", "UnitConvertorId");
			bulkCopy.ColumnMappings.Add("FromUnitId", "FromUnitId");
			bulkCopy.ColumnMappings.Add("ToUnitId", "ToUnitId");
			bulkCopy.ColumnMappings.Add("Quantity", "Quantity");
			bulkCopy.ColumnMappings.Add("EffectFrom", "EffectFrom");
			bulkCopy.ColumnMappings.Add("ParentPath", "ParentPath");
			bulkCopy.ColumnMappings.Add("IsDeletable", "IsDeletable");
			bulkCopy.ColumnMappings.Add("IsActive", "IsActive");
			bulkCopy.ColumnMappings.Add("CreationDate", "CreationDate");
			bulkCopy.ColumnMappings.Add("CreationUserId", "CreationUserId");
			bulkCopy.ColumnMappings.Add("LastModificationDate", "LastModificationDate");
			bulkCopy.ColumnMappings.Add("LastModificationUserId", "LastModificationUserId");
			
			foreach(RLM.Construction.Entities.UnitConvertor entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["UnitConvertorId"] = entity.UnitConvertorId;
							
				
					row["FromUnitId"] = entity.FromUnitId;
							
				
					row["ToUnitId"] = entity.ToUnitId;
							
				
					row["Quantity"] = entity.Quantity.HasValue ? (object) entity.Quantity  : System.DBNull.Value;
							
				
					row["EffectFrom"] = entity.EffectFrom.HasValue ? (object) entity.EffectFrom  : System.DBNull.Value;
							
				
					row["ParentPath"] = entity.ParentPath;
							
				
					row["IsDeletable"] = entity.IsDeletable.HasValue ? (object) entity.IsDeletable  : System.DBNull.Value;
							
				
					row["IsActive"] = entity.IsActive.HasValue ? (object) entity.IsActive  : System.DBNull.Value;
							
				
					row["CreationDate"] = entity.CreationDate.HasValue ? (object) entity.CreationDate  : System.DBNull.Value;
							
				
					row["CreationUserId"] = entity.CreationUserId.HasValue ? (object) entity.CreationUserId  : System.DBNull.Value;
							
				
					row["LastModificationDate"] = entity.LastModificationDate.HasValue ? (object) entity.LastModificationDate  : System.DBNull.Value;
							
				
					row["LastModificationUserId"] = entity.LastModificationUserId.HasValue ? (object) entity.LastModificationUserId  : System.DBNull.Value;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(RLM.Construction.Entities.UnitConvertor entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a RLM.Construction.Entities.UnitConvertor object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">RLM.Construction.Entities.UnitConvertor object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the RLM.Construction.Entities.UnitConvertor object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertor entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@UnitConvertorId", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@FromUnitId", DbType.Int32, entity.FromUnitId );
			database.AddInParameter(commandWrapper, "@ToUnitId", DbType.Int32, entity.ToUnitId );
			database.AddInParameter(commandWrapper, "@Quantity", DbType.Double, (entity.Quantity.HasValue ? (object) entity.Quantity  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@EffectFrom", DbType.DateTime, (entity.EffectFrom.HasValue ? (object) entity.EffectFrom  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@ParentPath", DbType.String, entity.ParentPath );
			database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, (entity.IsDeletable.HasValue ? (object) entity.IsDeletable  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object) entity.IsActive  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, (entity.CreationDate.HasValue ? (object) entity.CreationDate  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@CreationUserId", DbType.Int32, (entity.CreationUserId.HasValue ? (object) entity.CreationUserId  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@LastModificationDate", DbType.DateTime, (entity.LastModificationDate.HasValue ? (object) entity.LastModificationDate  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@LastModificationUserId", DbType.Int32, (entity.LastModificationUserId.HasValue ? (object) entity.LastModificationUserId  : System.DBNull.Value));
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					

			entity.UnitConvertorId = (System.Int32) database.GetParameterValue(commandWrapper, "@UnitConvertorId");						
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">RLM.Construction.Entities.UnitConvertor object to update.</param>
		/// <remarks>
		///		After updating the datasource, the RLM.Construction.Entities.UnitConvertor object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, RLM.Construction.Entities.UnitConvertor entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UnitConvertor_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@UnitConvertorId", DbType.Int32, entity.UnitConvertorId );
			database.AddInParameter(commandWrapper, "@FromUnitId", DbType.Int32, entity.FromUnitId );
			database.AddInParameter(commandWrapper, "@ToUnitId", DbType.Int32, entity.ToUnitId );
			database.AddInParameter(commandWrapper, "@Quantity", DbType.Double, (entity.Quantity.HasValue ? (object) entity.Quantity : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@EffectFrom", DbType.DateTime, (entity.EffectFrom.HasValue ? (object) entity.EffectFrom : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@ParentPath", DbType.String, entity.ParentPath );
			database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, (entity.IsDeletable.HasValue ? (object) entity.IsDeletable : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object) entity.IsActive : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, (entity.CreationDate.HasValue ? (object) entity.CreationDate : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@CreationUserId", DbType.Int32, (entity.CreationUserId.HasValue ? (object) entity.CreationUserId : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@LastModificationDate", DbType.DateTime, (entity.LastModificationDate.HasValue ? (object) entity.LastModificationDate : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@LastModificationUserId", DbType.Int32, (entity.LastModificationUserId.HasValue ? (object) entity.LastModificationUserId : System.DBNull.Value) );
			
			int results = 0;
			
			
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#endregion
	}//end class
} // end namespace
