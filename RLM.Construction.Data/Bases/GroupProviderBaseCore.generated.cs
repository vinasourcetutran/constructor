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
	/// This class is the base class for any <see cref="GroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GroupProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Group, RLM.Construction.Entities.GroupKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.GroupKey key)
		{
			return Delete(transactionManager, key.GroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 groupId)
		{
			return Delete(null, groupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 groupId);		
		
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
		public override RLM.Construction.Entities.Group Get(TransactionManager transactionManager, RLM.Construction.Entities.GroupKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Groups index.
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public RLM.Construction.Entities.Group GetByGroupId(System.Int32 groupId)
		{
			int count = -1;
			return GetByGroupId(null,groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Groups index.
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public RLM.Construction.Entities.Group GetByGroupId(System.Int32 groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(null, groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Groups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public RLM.Construction.Entities.Group GetByGroupId(TransactionManager transactionManager, System.Int32 groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Groups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public RLM.Construction.Entities.Group GetByGroupId(TransactionManager transactionManager, System.Int32 groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Groups index.
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public RLM.Construction.Entities.Group GetByGroupId(System.Int32 groupId, int start, int pageLength, out int count)
		{
			return GetByGroupId(null, groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Groups index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Group"/> class.</returns>
		public abstract RLM.Construction.Entities.Group GetByGroupId(TransactionManager transactionManager, System.Int32 groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Group&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Group&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Group> Fill(IDataReader reader, RLM.Construction.Entities.TList<Group> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Group c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Group" 
							+ (reader.IsDBNull(reader.GetOrdinal("GroupId"))?(int)0:(System.Int32)reader["GroupId"]).ToString();

					c = EntityManager.LocateOrCreate<Group>(
						key.ToString(), // EntityTrackingKey 
						"Group",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Group();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.GroupId = (System.Int32)reader["GroupId"];
					c.ParentGroupId = (reader.IsDBNull(reader.GetOrdinal("ParentGroupId")))?null:(System.Int32?)reader["ParentGroupId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Group"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Group"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Group entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader["GroupId"];
			entity.ParentGroupId = (reader.IsDBNull(reader.GetOrdinal("ParentGroupId")))?null:(System.Int32?)reader["ParentGroupId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Group"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Group"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Group entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GroupId = (System.Int32)dataRow["GroupId"];
			entity.ParentGroupId = (Convert.IsDBNull(dataRow["ParentGroupId"]))?null:(System.Int32?)dataRow["ParentGroupId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Group"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Group Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Group entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByGroupId methods when available
			
			#region ContractCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Contract>", "ContractCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ContractCollection' loaded.");
				#endif 

				entity.ContractCollection = DataRepository.ContractProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.ContractCollection.Count > 0)
				{
					DataRepository.ContractProvider.DeepLoad(transactionManager, entity.ContractCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Item>", "ItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ItemCollection' loaded.");
				#endif 

				entity.ItemCollection = DataRepository.ItemProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.ItemCollection.Count > 0)
				{
					DataRepository.ItemProvider.DeepLoad(transactionManager, entity.ItemCollection, deep, deepLoadType, childTypes, innerList);
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

				entity.ProjectCollection = DataRepository.ProjectProvider.GetByGroupId(transactionManager, entity.GroupId);

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
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Group object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Group instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Group Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Group entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			







			#region List<Contract>
				if (CanDeepSave(entity, "List<Contract>", "ContractCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Contract child in entity.ContractCollection)
					{
						child.GroupId = entity.GroupId;
					}
				
				if (entity.ContractCollection.Count > 0 || entity.ContractCollection.DeletedItems.Count > 0)
					DataRepository.ContractProvider.DeepSave(transactionManager, entity.ContractCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Item>
				if (CanDeepSave(entity, "List<Item>", "ItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Item child in entity.ItemCollection)
					{
						child.GroupId = entity.GroupId;
					}
				
				if (entity.ItemCollection.Count > 0 || entity.ItemCollection.DeletedItems.Count > 0)
					DataRepository.ItemProvider.DeepSave(transactionManager, entity.ItemCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Project>
				if (CanDeepSave(entity, "List<Project>", "ProjectCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Project child in entity.ProjectCollection)
					{
						child.GroupId = entity.GroupId;
					}
				
				if (entity.ProjectCollection.Count > 0 || entity.ProjectCollection.DeletedItems.Count > 0)
					DataRepository.ProjectProvider.DeepSave(transactionManager, entity.ProjectCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				



						
			return true;
		}
		#endregion
	} // end class
	
	#region GroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Group</c>
	///</summary>
	public enum GroupChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Group</c> as OneToMany for ContractCollection
		///</summary>
		[ChildEntityType(typeof(TList<Contract>))]
		ContractCollection,

		///<summary>
		/// Collection of <c>Group</c> as OneToMany for ItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<Item>))]
		ItemCollection,

		///<summary>
		/// Collection of <c>Group</c> as OneToMany for ProjectCollection
		///</summary>
		[ChildEntityType(typeof(TList<Project>))]
		ProjectCollection,
	}
	
	#endregion GroupChildEntityTypes
	
	#region GroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Group"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GroupFilterBuilder : SqlFilterBuilder<GroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GroupFilterBuilder class.
		/// </summary>
		public GroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GroupFilterBuilder
	
	#region GroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Group"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GroupParameterBuilder : ParameterizedSqlFilterBuilder<GroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GroupParameterBuilder class.
		/// </summary>
		public GroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GroupParameterBuilder
} // end namespace
