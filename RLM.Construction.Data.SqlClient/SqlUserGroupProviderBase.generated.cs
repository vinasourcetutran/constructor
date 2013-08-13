﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, November 18, 2010
	Important: Do not modify this file. Edit the file SqlUserGroupProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="UserGroup"/> entity.
	///</summary>
	public partial class SqlUserGroupProviderBase : UserGroupProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlUserGroupProviderBase"/> instance.
		/// </summary>
		public SqlUserGroupProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlUserGroupProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlUserGroupProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="userGroupId">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 userGroupId)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@UserGroupId", DbType.Int32, userGroupId);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(UserGroup)
					,userGroupId);
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
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UserGroup objects.</returns>
		public override RLM.Construction.Entities.TList<UserGroup> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new RLM.Construction.Entities.TList<UserGroup>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@UserGroupId", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UserGroupName", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, DBNull.Value);
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
				if (clause.Trim().StartsWith("usergroupid ") || clause.Trim().StartsWith("usergroupid="))
				{
					database.SetParameterValue(commandWrapper, "@UserGroupId", 
						clause.Replace("usergroupid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("usergroupname ") || clause.Trim().StartsWith("usergroupname="))
				{
					database.SetParameterValue(commandWrapper, "@UserGroupName", 
						clause.Replace("usergroupname","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("isactive ") || clause.Trim().StartsWith("isactive="))
				{
					database.SetParameterValue(commandWrapper, "@IsActive", 
						clause.Replace("isactive","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("isdeletable ") || clause.Trim().StartsWith("isdeletable="))
				{
					database.SetParameterValue(commandWrapper, "@IsDeletable", 
						clause.Replace("isdeletable","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("priority ") || clause.Trim().StartsWith("priority="))
				{
					database.SetParameterValue(commandWrapper, "@Priority", 
						clause.Replace("priority","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
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
			RLM.Construction.Entities.TList<UserGroup> rows = new RLM.Construction.Entities.TList<UserGroup>();
	
				
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
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UserGroup objects.</returns>
		public override RLM.Construction.Entities.TList<UserGroup> Find(TransactionManager transactionManager, SqlFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Find_Dynamic", typeof(UserGroupColumn), parameters, orderBy, start, pageLength);
			
			if ( parameters != null )
			{
				SqlFilterParameter param;

				for ( int i = 0; i < parameters.Count; i++ )
				{
					param = parameters[i];
					database.AddInParameter(commandWrapper, param.Name, param.DbType, param.Value);
				}
			}

			RLM.Construction.Entities.TList<UserGroup> rows = new RLM.Construction.Entities.TList<UserGroup>();
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
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UserGroup objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.TList<UserGroup> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			RLM.Construction.Entities.TList<UserGroup> rows = new RLM.Construction.Entities.TList<UserGroup>();
			
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
		/// <returns>Returns a typed collection of RLM.Construction.Entities.UserGroup objects.</returns>
		public override RLM.Construction.Entities.TList<UserGroup> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			RLM.Construction.Entities.TList<UserGroup> rows = new RLM.Construction.Entities.TList<UserGroup>();
			
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
	#endregion
	
		#region Get By Index Functions

		#region GetByUserGroupId
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserGroups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userGroupId"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserGroup"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override RLM.Construction.Entities.UserGroup GetByUserGroupId(TransactionManager transactionManager, System.Int32 userGroupId, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_GetByUserGroupId", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@UserGroupId", DbType.Int32, userGroupId);
			
			IDataReader reader = null;
			RLM.Construction.Entities.TList<UserGroup> tmp = new RLM.Construction.Entities.TList<UserGroup>();
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
		///		After inserting into the datasource, the RLM.Construction.Entities.UserGroup object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<RLM.Construction.Entities.UserGroup> entities)
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
			bulkCopy.DestinationTableName = "UserGroup";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("UserGroupId", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("UserGroupName", typeof(System.String));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("IsActive", typeof(System.Boolean));
			col2.AllowDBNull = true;		
			DataColumn col3 = dataTable.Columns.Add("IsDeletable", typeof(System.Boolean));
			col3.AllowDBNull = true;		
			DataColumn col4 = dataTable.Columns.Add("Priority", typeof(System.Int32));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("CreationDate", typeof(System.DateTime));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("CreationUserId", typeof(System.Int32));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("LastModificationDate", typeof(System.DateTime));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("LastModificationUserId", typeof(System.Int32));
			col8.AllowDBNull = true;		
			
			bulkCopy.ColumnMappings.Add("UserGroupId", "UserGroupId");
			bulkCopy.ColumnMappings.Add("UserGroupName", "UserGroupName");
			bulkCopy.ColumnMappings.Add("IsActive", "IsActive");
			bulkCopy.ColumnMappings.Add("IsDeletable", "IsDeletable");
			bulkCopy.ColumnMappings.Add("Priority", "Priority");
			bulkCopy.ColumnMappings.Add("CreationDate", "CreationDate");
			bulkCopy.ColumnMappings.Add("CreationUserId", "CreationUserId");
			bulkCopy.ColumnMappings.Add("LastModificationDate", "LastModificationDate");
			bulkCopy.ColumnMappings.Add("LastModificationUserId", "LastModificationUserId");
			
			foreach(RLM.Construction.Entities.UserGroup entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["UserGroupId"] = entity.UserGroupId;
							
				
					row["UserGroupName"] = entity.UserGroupName;
							
				
					row["IsActive"] = entity.IsActive.HasValue ? (object) entity.IsActive  : System.DBNull.Value;
							
				
					row["IsDeletable"] = entity.IsDeletable.HasValue ? (object) entity.IsDeletable  : System.DBNull.Value;
							
				
					row["Priority"] = entity.Priority.HasValue ? (object) entity.Priority  : System.DBNull.Value;
							
				
					row["CreationDate"] = entity.CreationDate.HasValue ? (object) entity.CreationDate  : System.DBNull.Value;
							
				
					row["CreationUserId"] = entity.CreationUserId.HasValue ? (object) entity.CreationUserId  : System.DBNull.Value;
							
				
					row["LastModificationDate"] = entity.LastModificationDate.HasValue ? (object) entity.LastModificationDate  : System.DBNull.Value;
							
				
					row["LastModificationUserId"] = entity.LastModificationUserId.HasValue ? (object) entity.LastModificationUserId  : System.DBNull.Value;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(RLM.Construction.Entities.UserGroup entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a RLM.Construction.Entities.UserGroup object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">RLM.Construction.Entities.UserGroup object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the RLM.Construction.Entities.UserGroup object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, RLM.Construction.Entities.UserGroup entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@UserGroupId", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@UserGroupName", DbType.String, entity.UserGroupName );
			database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object) entity.IsActive  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, (entity.IsDeletable.HasValue ? (object) entity.IsDeletable  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, (entity.Priority.HasValue ? (object) entity.Priority  : System.DBNull.Value));
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
					

			entity.UserGroupId = (System.Int32) database.GetParameterValue(commandWrapper, "@UserGroupId");						
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">RLM.Construction.Entities.UserGroup object to update.</param>
		/// <remarks>
		///		After updating the datasource, the RLM.Construction.Entities.UserGroup object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, RLM.Construction.Entities.UserGroup entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.UserGroup_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@UserGroupId", DbType.Int32, entity.UserGroupId );
			database.AddInParameter(commandWrapper, "@UserGroupName", DbType.String, entity.UserGroupName );
			database.AddInParameter(commandWrapper, "@IsActive", DbType.Boolean, (entity.IsActive.HasValue ? (object) entity.IsActive : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@IsDeletable", DbType.Boolean, (entity.IsDeletable.HasValue ? (object) entity.IsDeletable : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, (entity.Priority.HasValue ? (object) entity.Priority : System.DBNull.Value) );
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
