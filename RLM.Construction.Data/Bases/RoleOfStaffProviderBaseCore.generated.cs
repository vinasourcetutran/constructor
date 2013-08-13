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
	/// This class is the base class for any <see cref="RoleOfStaffProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RoleOfStaffProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.RoleOfStaff, RLM.Construction.Entities.RoleOfStaffKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.RoleOfStaffKey key)
		{
			return Delete(transactionManager, key.RoleOfStaffId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="roleOfStaffId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 roleOfStaffId)
		{
			return Delete(null, roleOfStaffId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleOfStaffId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 roleOfStaffId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		FK_RoleOfStaffs_Staffs Description: 
		/// </summary>
		/// <param name="staffId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(System.Int32 staffId)
		{
			int count = -1;
			return GetByStaffId(staffId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		FK_RoleOfStaffs_Staffs Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(TransactionManager transactionManager, System.Int32 staffId)
		{
			int count = -1;
			return GetByStaffId(transactionManager, staffId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		FK_RoleOfStaffs_Staffs Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(TransactionManager transactionManager, System.Int32 staffId, int start, int pageLength)
		{
			int count = -1;
			return GetByStaffId(transactionManager, staffId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		fKRoleOfStaffsStaffs Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="staffId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(System.Int32 staffId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStaffId(null, staffId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		fKRoleOfStaffsStaffs Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="staffId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(System.Int32 staffId, int start, int pageLength,out int count)
		{
			return GetByStaffId(null, staffId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Staffs key.
		///		FK_RoleOfStaffs_Staffs Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public abstract RLM.Construction.Entities.TList<RoleOfStaff> GetByStaffId(TransactionManager transactionManager, System.Int32 staffId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		FK_RoleOfStaffs_Roles Description: 
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(System.Int32 roleId)
		{
			int count = -1;
			return GetByRoleId(roleId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		FK_RoleOfStaffs_Roles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(TransactionManager transactionManager, System.Int32 roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, roleId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		FK_RoleOfStaffs_Roles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(TransactionManager transactionManager, System.Int32 roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		fKRoleOfStaffsRoles Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(System.Int32 roleId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRoleId(null, roleId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		fKRoleOfStaffsRoles Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="roleId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(System.Int32 roleId, int start, int pageLength,out int count)
		{
			return GetByRoleId(null, roleId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_RoleOfStaffs_Roles key.
		///		FK_RoleOfStaffs_Roles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.RoleOfStaff objects.</returns>
		public abstract RLM.Construction.Entities.TList<RoleOfStaff> GetByRoleId(TransactionManager transactionManager, System.Int32 roleId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.RoleOfStaff Get(TransactionManager transactionManager, RLM.Construction.Entities.RoleOfStaffKey key, int start, int pageLength)
		{
			return GetByRoleOfStaffId(transactionManager, key.RoleOfStaffId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="roleOfStaffId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(System.Int32 roleOfStaffId)
		{
			int count = -1;
			return GetByRoleOfStaffId(null,roleOfStaffId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="roleOfStaffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(System.Int32 roleOfStaffId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleOfStaffId(null, roleOfStaffId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleOfStaffId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(TransactionManager transactionManager, System.Int32 roleOfStaffId)
		{
			int count = -1;
			return GetByRoleOfStaffId(transactionManager, roleOfStaffId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleOfStaffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(TransactionManager transactionManager, System.Int32 roleOfStaffId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleOfStaffId(transactionManager, roleOfStaffId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="roleOfStaffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(System.Int32 roleOfStaffId, int start, int pageLength, out int count)
		{
			return GetByRoleOfStaffId(null, roleOfStaffId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_RoleOfStaffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="roleOfStaffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.RoleOfStaff"/> class.</returns>
		public abstract RLM.Construction.Entities.RoleOfStaff GetByRoleOfStaffId(TransactionManager transactionManager, System.Int32 roleOfStaffId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;RoleOfStaff&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;RoleOfStaff&gt;"/></returns>
		public static RLM.Construction.Entities.TList<RoleOfStaff> Fill(IDataReader reader, RLM.Construction.Entities.TList<RoleOfStaff> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.RoleOfStaff c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"RoleOfStaff" 
							+ (reader.IsDBNull(reader.GetOrdinal("RoleOfStaffId"))?(int)0:(System.Int32)reader["RoleOfStaffId"]).ToString();

					c = EntityManager.LocateOrCreate<RoleOfStaff>(
						key.ToString(), // EntityTrackingKey 
						"RoleOfStaff",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.RoleOfStaff();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RoleOfStaffId = (System.Int32)reader["RoleOfStaffId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.RoleId = (System.Int32)reader["RoleId"];
					c.ResourceId = (System.Int32)reader["ResourceId"];
					c.ResourceType = (System.Int32)reader["ResourceType"];
					c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Int64?)reader["IsApprove"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
					c.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.RoleOfStaff"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RoleOfStaff"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.RoleOfStaff entity)
		{
			if (!reader.Read()) return;
			
			entity.RoleOfStaffId = (System.Int32)reader["RoleOfStaffId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.RoleId = (System.Int32)reader["RoleId"];
			entity.ResourceId = (System.Int32)reader["ResourceId"];
			entity.ResourceType = (System.Int32)reader["ResourceType"];
			entity.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove")))?null:(System.Int64?)reader["IsApprove"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
			entity.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.RoleOfStaff"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RoleOfStaff"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.RoleOfStaff entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RoleOfStaffId = (System.Int32)dataRow["RoleOfStaffId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.RoleId = (System.Int32)dataRow["RoleId"];
			entity.ResourceId = (System.Int32)dataRow["ResourceId"];
			entity.ResourceType = (System.Int32)dataRow["ResourceType"];
			entity.IsApprove = (Convert.IsDBNull(dataRow["IsApprove"]))?null:(System.Int64?)dataRow["IsApprove"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.FromDate = (Convert.IsDBNull(dataRow["FromDate"]))?null:(System.DateTime?)dataRow["FromDate"];
			entity.ToDate = (Convert.IsDBNull(dataRow["ToDate"]))?null:(System.DateTime?)dataRow["ToDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.RoleOfStaff"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.RoleOfStaff Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.RoleOfStaff entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region StaffIdSource	
			if (CanDeepLoad(entity, "Staff", "StaffIdSource", deepLoadType, innerList) 
				&& entity.StaffIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.StaffId;
				Staff tmpEntity = EntityManager.LocateEntity<Staff>(EntityLocator.ConstructKeyFromPkItems(typeof(Staff), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StaffIdSource = tmpEntity;
				else
					entity.StaffIdSource = DataRepository.StaffProvider.GetByStaffId(entity.StaffId);
			
				if (deep && entity.StaffIdSource != null)
				{
					DataRepository.StaffProvider.DeepLoad(transactionManager, entity.StaffIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion StaffIdSource

			#region RoleIdSource	
			if (CanDeepLoad(entity, "Role", "RoleIdSource", deepLoadType, innerList) 
				&& entity.RoleIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RoleId;
				Role tmpEntity = EntityManager.LocateEntity<Role>(EntityLocator.ConstructKeyFromPkItems(typeof(Role), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RoleIdSource = tmpEntity;
				else
					entity.RoleIdSource = DataRepository.RoleProvider.GetByRoleId(entity.RoleId);
			
				if (deep && entity.RoleIdSource != null)
				{
					DataRepository.RoleProvider.DeepLoad(transactionManager, entity.RoleIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion RoleIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.RoleOfStaff object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.RoleOfStaff instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.RoleOfStaff Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.RoleOfStaff entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region StaffIdSource
			if (CanDeepSave(entity, "Staff", "StaffIdSource", deepSaveType, innerList) 
				&& entity.StaffIdSource != null)
			{
				DataRepository.StaffProvider.Save(transactionManager, entity.StaffIdSource);
				entity.StaffId = entity.StaffIdSource.StaffId;
			}
			#endregion 
			
			#region RoleIdSource
			if (CanDeepSave(entity, "Role", "RoleIdSource", deepSaveType, innerList) 
				&& entity.RoleIdSource != null)
			{
				DataRepository.RoleProvider.Save(transactionManager, entity.RoleIdSource);
				entity.RoleId = entity.RoleIdSource.RoleId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region RoleOfStaffChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.RoleOfStaff</c>
	///</summary>
	public enum RoleOfStaffChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Staff</c> at StaffIdSource
		///</summary>
		[ChildEntityType(typeof(Staff))]
		Staff,
			
		///<summary>
		/// Composite Property for <c>Role</c> at RoleIdSource
		///</summary>
		[ChildEntityType(typeof(Role))]
		Role,
		}
	
	#endregion RoleOfStaffChildEntityTypes
	
	#region RoleOfStaffFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RoleOfStaff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleOfStaffFilterBuilder : SqlFilterBuilder<RoleOfStaffColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffFilterBuilder class.
		/// </summary>
		public RoleOfStaffFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RoleOfStaffFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RoleOfStaffFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RoleOfStaffFilterBuilder
	
	#region RoleOfStaffParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RoleOfStaff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleOfStaffParameterBuilder : ParameterizedSqlFilterBuilder<RoleOfStaffColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffParameterBuilder class.
		/// </summary>
		public RoleOfStaffParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RoleOfStaffParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RoleOfStaffParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RoleOfStaffParameterBuilder
} // end namespace
