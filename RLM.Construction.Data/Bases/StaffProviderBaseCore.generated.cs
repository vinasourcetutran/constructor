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
	/// This class is the base class for any <see cref="StaffProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StaffProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Staff, RLM.Construction.Entities.StaffKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.StaffKey key)
		{
			return Delete(transactionManager, key.StaffId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="staffId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 staffId)
		{
			return Delete(null, staffId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 staffId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override RLM.Construction.Entities.Staff Get(TransactionManager transactionManager, RLM.Construction.Entities.StaffKey key, int start, int pageLength)
		{
			return GetByStaffId(transactionManager, key.StaffId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Staffs index.
		/// </summary>
		/// <param name="staffId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public RLM.Construction.Entities.Staff GetByStaffId(System.Int32 staffId)
		{
			int count = -1;
			return GetByStaffId(null,staffId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Staffs index.
		/// </summary>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public RLM.Construction.Entities.Staff GetByStaffId(System.Int32 staffId, int start, int pageLength)
		{
			int count = -1;
			return GetByStaffId(null, staffId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Staffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public RLM.Construction.Entities.Staff GetByStaffId(TransactionManager transactionManager, System.Int32 staffId)
		{
			int count = -1;
			return GetByStaffId(transactionManager, staffId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Staffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public RLM.Construction.Entities.Staff GetByStaffId(TransactionManager transactionManager, System.Int32 staffId, int start, int pageLength)
		{
			int count = -1;
			return GetByStaffId(transactionManager, staffId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Staffs index.
		/// </summary>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public RLM.Construction.Entities.Staff GetByStaffId(System.Int32 staffId, int start, int pageLength, out int count)
		{
			return GetByStaffId(null, staffId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Staffs index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="staffId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Staff"/> class.</returns>
		public abstract RLM.Construction.Entities.Staff GetByStaffId(TransactionManager transactionManager, System.Int32 staffId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Staff&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Staff&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Staff> Fill(IDataReader reader, RLM.Construction.Entities.TList<Staff> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Staff c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Staff" 
							+ (reader.IsDBNull(reader.GetOrdinal("StaffId"))?(int)0:(System.Int32)reader["StaffId"]).ToString();

					c = EntityManager.LocateOrCreate<Staff>(
						key.ToString(), // EntityTrackingKey 
						"Staff",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Staff();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.StaffId = (System.Int32)reader["StaffId"];
					c.StaffCode = (reader.IsDBNull(reader.GetOrdinal("StaffCode")))?null:(System.String)reader["StaffCode"];
					c.FirstName = (System.String)reader["FirstName"];
					c.LastName = (System.String)reader["LastName"];
					c.MiddleName = (reader.IsDBNull(reader.GetOrdinal("MiddleName")))?null:(System.String)reader["MiddleName"];
					c.Sex = (reader.IsDBNull(reader.GetOrdinal("Sex")))?null:(System.Int32?)reader["Sex"];
					c.BirthDate = (reader.IsDBNull(reader.GetOrdinal("BirthDate")))?null:(System.DateTime?)reader["BirthDate"];
					c.BirthPlaceId = (reader.IsDBNull(reader.GetOrdinal("BirthPlaceId")))?null:(System.Int32?)reader["BirthPlaceId"];
					c.BirthdayPlace = (reader.IsDBNull(reader.GetOrdinal("BirthdayPlace")))?null:(System.String)reader["BirthdayPlace"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.MagneticCardId = (reader.IsDBNull(reader.GetOrdinal("MagneticCardId")))?null:(System.String)reader["MagneticCardId"];
					c.ReligiousId = (reader.IsDBNull(reader.GetOrdinal("ReligiousId")))?null:(System.Int32?)reader["ReligiousId"];
					c.ProvinceId = (reader.IsDBNull(reader.GetOrdinal("ProvinceId")))?null:(System.Int32?)reader["ProvinceId"];
					c.PeopleId = (reader.IsDBNull(reader.GetOrdinal("PeopleId")))?null:(System.Int32?)reader["PeopleId"];
					c.StartWorkingDate = (reader.IsDBNull(reader.GetOrdinal("StartWorkingDate")))?null:(System.DateTime?)reader["StartWorkingDate"];
					c.WorkingDate = (reader.IsDBNull(reader.GetOrdinal("WorkingDate")))?null:(System.DateTime?)reader["WorkingDate"];
					c.DeptId = (reader.IsDBNull(reader.GetOrdinal("DeptId")))?null:(System.Int32?)reader["DeptId"];
					c.JobTitleId = (reader.IsDBNull(reader.GetOrdinal("JobTitleId")))?null:(System.Int32?)reader["JobTitleId"];
					c.PermanentAddress = (reader.IsDBNull(reader.GetOrdinal("PermanentAddress")))?null:(System.String)reader["PermanentAddress"];
					c.PermanentProvinceId = (reader.IsDBNull(reader.GetOrdinal("PermanentProvinceId")))?null:(System.Int32?)reader["PermanentProvinceId"];
					c.CurrentAddress = (reader.IsDBNull(reader.GetOrdinal("CurrentAddress")))?null:(System.String)reader["CurrentAddress"];
					c.CurrentProvinceId = (reader.IsDBNull(reader.GetOrdinal("CurrentProvinceId")))?null:(System.Int32?)reader["CurrentProvinceId"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.Photo = (reader.IsDBNull(reader.GetOrdinal("Photo")))?null:(System.String)reader["Photo"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Staff"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Staff"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Staff entity)
		{
			if (!reader.Read()) return;
			
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.StaffCode = (reader.IsDBNull(reader.GetOrdinal("StaffCode")))?null:(System.String)reader["StaffCode"];
			entity.FirstName = (System.String)reader["FirstName"];
			entity.LastName = (System.String)reader["LastName"];
			entity.MiddleName = (reader.IsDBNull(reader.GetOrdinal("MiddleName")))?null:(System.String)reader["MiddleName"];
			entity.Sex = (reader.IsDBNull(reader.GetOrdinal("Sex")))?null:(System.Int32?)reader["Sex"];
			entity.BirthDate = (reader.IsDBNull(reader.GetOrdinal("BirthDate")))?null:(System.DateTime?)reader["BirthDate"];
			entity.BirthPlaceId = (reader.IsDBNull(reader.GetOrdinal("BirthPlaceId")))?null:(System.Int32?)reader["BirthPlaceId"];
			entity.BirthdayPlace = (reader.IsDBNull(reader.GetOrdinal("BirthdayPlace")))?null:(System.String)reader["BirthdayPlace"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.MagneticCardId = (reader.IsDBNull(reader.GetOrdinal("MagneticCardId")))?null:(System.String)reader["MagneticCardId"];
			entity.ReligiousId = (reader.IsDBNull(reader.GetOrdinal("ReligiousId")))?null:(System.Int32?)reader["ReligiousId"];
			entity.ProvinceId = (reader.IsDBNull(reader.GetOrdinal("ProvinceId")))?null:(System.Int32?)reader["ProvinceId"];
			entity.PeopleId = (reader.IsDBNull(reader.GetOrdinal("PeopleId")))?null:(System.Int32?)reader["PeopleId"];
			entity.StartWorkingDate = (reader.IsDBNull(reader.GetOrdinal("StartWorkingDate")))?null:(System.DateTime?)reader["StartWorkingDate"];
			entity.WorkingDate = (reader.IsDBNull(reader.GetOrdinal("WorkingDate")))?null:(System.DateTime?)reader["WorkingDate"];
			entity.DeptId = (reader.IsDBNull(reader.GetOrdinal("DeptId")))?null:(System.Int32?)reader["DeptId"];
			entity.JobTitleId = (reader.IsDBNull(reader.GetOrdinal("JobTitleId")))?null:(System.Int32?)reader["JobTitleId"];
			entity.PermanentAddress = (reader.IsDBNull(reader.GetOrdinal("PermanentAddress")))?null:(System.String)reader["PermanentAddress"];
			entity.PermanentProvinceId = (reader.IsDBNull(reader.GetOrdinal("PermanentProvinceId")))?null:(System.Int32?)reader["PermanentProvinceId"];
			entity.CurrentAddress = (reader.IsDBNull(reader.GetOrdinal("CurrentAddress")))?null:(System.String)reader["CurrentAddress"];
			entity.CurrentProvinceId = (reader.IsDBNull(reader.GetOrdinal("CurrentProvinceId")))?null:(System.Int32?)reader["CurrentProvinceId"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.Photo = (reader.IsDBNull(reader.GetOrdinal("Photo")))?null:(System.String)reader["Photo"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Staff"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Staff"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Staff entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.StaffCode = (Convert.IsDBNull(dataRow["StaffCode"]))?null:(System.String)dataRow["StaffCode"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.MiddleName = (Convert.IsDBNull(dataRow["MiddleName"]))?null:(System.String)dataRow["MiddleName"];
			entity.Sex = (Convert.IsDBNull(dataRow["Sex"]))?null:(System.Int32?)dataRow["Sex"];
			entity.BirthDate = (Convert.IsDBNull(dataRow["BirthDate"]))?null:(System.DateTime?)dataRow["BirthDate"];
			entity.BirthPlaceId = (Convert.IsDBNull(dataRow["BirthPlaceId"]))?null:(System.Int32?)dataRow["BirthPlaceId"];
			entity.BirthdayPlace = (Convert.IsDBNull(dataRow["BirthdayPlace"]))?null:(System.String)dataRow["BirthdayPlace"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.MagneticCardId = (Convert.IsDBNull(dataRow["MagneticCardId"]))?null:(System.String)dataRow["MagneticCardId"];
			entity.ReligiousId = (Convert.IsDBNull(dataRow["ReligiousId"]))?null:(System.Int32?)dataRow["ReligiousId"];
			entity.ProvinceId = (Convert.IsDBNull(dataRow["ProvinceId"]))?null:(System.Int32?)dataRow["ProvinceId"];
			entity.PeopleId = (Convert.IsDBNull(dataRow["PeopleId"]))?null:(System.Int32?)dataRow["PeopleId"];
			entity.StartWorkingDate = (Convert.IsDBNull(dataRow["StartWorkingDate"]))?null:(System.DateTime?)dataRow["StartWorkingDate"];
			entity.WorkingDate = (Convert.IsDBNull(dataRow["WorkingDate"]))?null:(System.DateTime?)dataRow["WorkingDate"];
			entity.DeptId = (Convert.IsDBNull(dataRow["DeptId"]))?null:(System.Int32?)dataRow["DeptId"];
			entity.JobTitleId = (Convert.IsDBNull(dataRow["JobTitleId"]))?null:(System.Int32?)dataRow["JobTitleId"];
			entity.PermanentAddress = (Convert.IsDBNull(dataRow["PermanentAddress"]))?null:(System.String)dataRow["PermanentAddress"];
			entity.PermanentProvinceId = (Convert.IsDBNull(dataRow["PermanentProvinceId"]))?null:(System.Int32?)dataRow["PermanentProvinceId"];
			entity.CurrentAddress = (Convert.IsDBNull(dataRow["CurrentAddress"]))?null:(System.String)dataRow["CurrentAddress"];
			entity.CurrentProvinceId = (Convert.IsDBNull(dataRow["CurrentProvinceId"]))?null:(System.Int32?)dataRow["CurrentProvinceId"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.Photo = (Convert.IsDBNull(dataRow["Photo"]))?null:(System.String)dataRow["Photo"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Staff"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Staff Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Staff entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByStaffId methods when available
			
			#region RoleOfStaffCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RoleOfStaff>", "RoleOfStaffCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'RoleOfStaffCollection' loaded.");
				#endif 

				entity.RoleOfStaffCollection = DataRepository.RoleOfStaffProvider.GetByStaffId(transactionManager, entity.StaffId);

				if (deep && entity.RoleOfStaffCollection.Count > 0)
				{
					DataRepository.RoleOfStaffProvider.DeepLoad(transactionManager, entity.RoleOfStaffCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Staff object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Staff instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Staff Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Staff entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<RoleOfStaff>
				if (CanDeepSave(entity, "List<RoleOfStaff>", "RoleOfStaffCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RoleOfStaff child in entity.RoleOfStaffCollection)
					{
						child.StaffId = entity.StaffId;
					}
				
				if (entity.RoleOfStaffCollection.Count > 0 || entity.RoleOfStaffCollection.DeletedItems.Count > 0)
					DataRepository.RoleOfStaffProvider.DeepSave(transactionManager, entity.RoleOfStaffCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region StaffChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Staff</c>
	///</summary>
	public enum StaffChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Staff</c> as OneToMany for RoleOfStaffCollection
		///</summary>
		[ChildEntityType(typeof(TList<RoleOfStaff>))]
		RoleOfStaffCollection,
	}
	
	#endregion StaffChildEntityTypes
	
	#region StaffFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Staff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StaffFilterBuilder : SqlFilterBuilder<StaffColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StaffFilterBuilder class.
		/// </summary>
		public StaffFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StaffFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StaffFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StaffFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StaffFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StaffFilterBuilder
	
	#region StaffParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Staff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StaffParameterBuilder : ParameterizedSqlFilterBuilder<StaffColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StaffParameterBuilder class.
		/// </summary>
		public StaffParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StaffParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StaffParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StaffParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StaffParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StaffParameterBuilder
} // end namespace
