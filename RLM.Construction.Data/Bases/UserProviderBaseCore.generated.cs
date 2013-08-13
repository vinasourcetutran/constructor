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
	/// This class is the base class for any <see cref="UserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.User, RLM.Construction.Entities.UserKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.UserKey key)
		{
			return Delete(transactionManager, key.UserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 userId)
		{
			return Delete(null, userId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 userId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		FK_Users_UserGroups Description: 
		/// </summary>
		/// <param name="userGroupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		public RLM.Construction.Entities.TList<User> GetByUserGroupId(System.Int32? userGroupId)
		{
			int count = -1;
			return GetByUserGroupId(userGroupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		FK_Users_UserGroups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userGroupId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<User> GetByUserGroupId(TransactionManager transactionManager, System.Int32? userGroupId)
		{
			int count = -1;
			return GetByUserGroupId(transactionManager, userGroupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		FK_Users_UserGroups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		public RLM.Construction.Entities.TList<User> GetByUserGroupId(TransactionManager transactionManager, System.Int32? userGroupId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserGroupId(transactionManager, userGroupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		fKUsersUserGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="userGroupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		public RLM.Construction.Entities.TList<User> GetByUserGroupId(System.Int32? userGroupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserGroupId(null, userGroupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		fKUsersUserGroups Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="userGroupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		public RLM.Construction.Entities.TList<User> GetByUserGroupId(System.Int32? userGroupId, int start, int pageLength,out int count)
		{
			return GetByUserGroupId(null, userGroupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserGroups key.
		///		FK_Users_UserGroups Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.User objects.</returns>
		public abstract RLM.Construction.Entities.TList<User> GetByUserGroupId(TransactionManager transactionManager, System.Int32? userGroupId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.User Get(TransactionManager transactionManager, RLM.Construction.Entities.UserKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Users index.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public RLM.Construction.Entities.User GetByUserId(System.Int32 userId)
		{
			int count = -1;
			return GetByUserId(null,userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public RLM.Construction.Entities.User GetByUserId(System.Int32 userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public RLM.Construction.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public RLM.Construction.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public RLM.Construction.Entities.User GetByUserId(System.Int32 userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.User"/> class.</returns>
		public abstract RLM.Construction.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;User&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;User&gt;"/></returns>
		public static RLM.Construction.Entities.TList<User> Fill(IDataReader reader, RLM.Construction.Entities.TList<User> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.User c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"User" 
							+ (reader.IsDBNull(reader.GetOrdinal("UserId"))?(int)0:(System.Int32)reader["UserId"]).ToString();

					c = EntityManager.LocateOrCreate<User>(
						key.ToString(), // EntityTrackingKey 
						"User",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.User();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.UserId = (System.Int32)reader["UserId"];
					c.UserGroupId = (reader.IsDBNull(reader.GetOrdinal("UserGroupId")))?null:(System.Int32?)reader["UserGroupId"];
					c.Email = (System.String)reader["Email"];
					c.Pwd = (System.String)reader["Pwd"];
					c.PwdFormat = (reader.IsDBNull(reader.GetOrdinal("PwdFormat")))?null:(System.Int32?)reader["PwdFormat"];
					c.FullName = (System.String)reader["FullName"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsFirstLoggedIn = (reader.IsDBNull(reader.GetOrdinal("IsFirstLoggedIn")))?null:(System.Boolean?)reader["IsFirstLoggedIn"];
					c.IsLocked = (reader.IsDBNull(reader.GetOrdinal("IsLocked")))?null:(System.Boolean?)reader["IsLocked"];
					c.LogInFail = (reader.IsDBNull(reader.GetOrdinal("LogInFail")))?null:(System.Int32?)reader["LogInFail"];
					c.LastLoginDate = (reader.IsDBNull(reader.GetOrdinal("LastLoginDate")))?null:(System.DateTime?)reader["LastLoginDate"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.IsLoggedIn = (reader.IsDBNull(reader.GetOrdinal("IsLoggedIn")))?null:(System.Boolean?)reader["IsLoggedIn"];
					c.LoggedInGuid = (reader.IsDBNull(reader.GetOrdinal("LoggedInGuid")))?null:(System.Guid?)reader["LoggedInGuid"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.User"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.User"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.User entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Int32)reader["UserId"];
			entity.UserGroupId = (reader.IsDBNull(reader.GetOrdinal("UserGroupId")))?null:(System.Int32?)reader["UserGroupId"];
			entity.Email = (System.String)reader["Email"];
			entity.Pwd = (System.String)reader["Pwd"];
			entity.PwdFormat = (reader.IsDBNull(reader.GetOrdinal("PwdFormat")))?null:(System.Int32?)reader["PwdFormat"];
			entity.FullName = (System.String)reader["FullName"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsFirstLoggedIn = (reader.IsDBNull(reader.GetOrdinal("IsFirstLoggedIn")))?null:(System.Boolean?)reader["IsFirstLoggedIn"];
			entity.IsLocked = (reader.IsDBNull(reader.GetOrdinal("IsLocked")))?null:(System.Boolean?)reader["IsLocked"];
			entity.LogInFail = (reader.IsDBNull(reader.GetOrdinal("LogInFail")))?null:(System.Int32?)reader["LogInFail"];
			entity.LastLoginDate = (reader.IsDBNull(reader.GetOrdinal("LastLoginDate")))?null:(System.DateTime?)reader["LastLoginDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.IsLoggedIn = (reader.IsDBNull(reader.GetOrdinal("IsLoggedIn")))?null:(System.Boolean?)reader["IsLoggedIn"];
			entity.LoggedInGuid = (reader.IsDBNull(reader.GetOrdinal("LoggedInGuid")))?null:(System.Guid?)reader["LoggedInGuid"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.User"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.User"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.User entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Int32)dataRow["UserId"];
			entity.UserGroupId = (Convert.IsDBNull(dataRow["UserGroupId"]))?null:(System.Int32?)dataRow["UserGroupId"];
			entity.Email = (System.String)dataRow["Email"];
			entity.Pwd = (System.String)dataRow["Pwd"];
			entity.PwdFormat = (Convert.IsDBNull(dataRow["PwdFormat"]))?null:(System.Int32?)dataRow["PwdFormat"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsFirstLoggedIn = (Convert.IsDBNull(dataRow["IsFirstLoggedIn"]))?null:(System.Boolean?)dataRow["IsFirstLoggedIn"];
			entity.IsLocked = (Convert.IsDBNull(dataRow["IsLocked"]))?null:(System.Boolean?)dataRow["IsLocked"];
			entity.LogInFail = (Convert.IsDBNull(dataRow["LogInFail"]))?null:(System.Int32?)dataRow["LogInFail"];
			entity.LastLoginDate = (Convert.IsDBNull(dataRow["LastLoginDate"]))?null:(System.DateTime?)dataRow["LastLoginDate"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.IsLoggedIn = (Convert.IsDBNull(dataRow["IsLoggedIn"]))?null:(System.Boolean?)dataRow["IsLoggedIn"];
			entity.LoggedInGuid = (Convert.IsDBNull(dataRow["LoggedInGuid"]))?null:(System.Guid?)dataRow["LoggedInGuid"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.User"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.User Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.User entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region UserGroupIdSource	
			if (CanDeepLoad(entity, "UserGroup", "UserGroupIdSource", deepLoadType, innerList) 
				&& entity.UserGroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UserGroupId ?? (int)0);
				UserGroup tmpEntity = EntityManager.LocateEntity<UserGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(UserGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserGroupIdSource = tmpEntity;
				else
					entity.UserGroupIdSource = DataRepository.UserGroupProvider.GetByUserGroupId((entity.UserGroupId ?? (int)0));
			
				if (deep && entity.UserGroupIdSource != null)
				{
					DataRepository.UserGroupProvider.DeepLoad(transactionManager, entity.UserGroupIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion UserGroupIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.User object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.User instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.User Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.User entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UserGroupIdSource
			if (CanDeepSave(entity, "UserGroup", "UserGroupIdSource", deepSaveType, innerList) 
				&& entity.UserGroupIdSource != null)
			{
				DataRepository.UserGroupProvider.Save(transactionManager, entity.UserGroupIdSource);
				entity.UserGroupId = entity.UserGroupIdSource.UserGroupId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region UserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.User</c>
	///</summary>
	public enum UserChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>UserGroup</c> at UserGroupIdSource
		///</summary>
		[ChildEntityType(typeof(UserGroup))]
		UserGroup,
		}
	
	#endregion UserChildEntityTypes
	
	#region UserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilterBuilder : SqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		public UserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilterBuilder
	
	#region UserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserParameterBuilder : ParameterizedSqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		public UserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserParameterBuilder
} // end namespace
