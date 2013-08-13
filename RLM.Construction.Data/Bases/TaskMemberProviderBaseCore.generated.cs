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
	/// This class is the base class for any <see cref="TaskMemberProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TaskMemberProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.TaskMember, RLM.Construction.Entities.TaskMemberKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.TaskMemberKey key)
		{
			return Delete(transactionManager, key.TaskMemberId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="taskMemberId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 taskMemberId)
		{
			return Delete(null, taskMemberId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskMemberId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 taskMemberId);		
		
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
		public override RLM.Construction.Entities.TaskMember Get(TransactionManager transactionManager, RLM.Construction.Entities.TaskMemberKey key, int start, int pageLength)
		{
			return GetByTaskMemberId(transactionManager, key.TaskMemberId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TaskMember index.
		/// </summary>
		/// <param name="taskMemberId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public RLM.Construction.Entities.TaskMember GetByTaskMemberId(System.Int32 taskMemberId)
		{
			int count = -1;
			return GetByTaskMemberId(null,taskMemberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TaskMember index.
		/// </summary>
		/// <param name="taskMemberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public RLM.Construction.Entities.TaskMember GetByTaskMemberId(System.Int32 taskMemberId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaskMemberId(null, taskMemberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TaskMember index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskMemberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public RLM.Construction.Entities.TaskMember GetByTaskMemberId(TransactionManager transactionManager, System.Int32 taskMemberId)
		{
			int count = -1;
			return GetByTaskMemberId(transactionManager, taskMemberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TaskMember index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskMemberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public RLM.Construction.Entities.TaskMember GetByTaskMemberId(TransactionManager transactionManager, System.Int32 taskMemberId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaskMemberId(transactionManager, taskMemberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TaskMember index.
		/// </summary>
		/// <param name="taskMemberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public RLM.Construction.Entities.TaskMember GetByTaskMemberId(System.Int32 taskMemberId, int start, int pageLength, out int count)
		{
			return GetByTaskMemberId(null, taskMemberId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TaskMember index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskMemberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.TaskMember"/> class.</returns>
		public abstract RLM.Construction.Entities.TaskMember GetByTaskMemberId(TransactionManager transactionManager, System.Int32 taskMemberId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;TaskMember&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;TaskMember&gt;"/></returns>
		public static RLM.Construction.Entities.TList<TaskMember> Fill(IDataReader reader, RLM.Construction.Entities.TList<TaskMember> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.TaskMember c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"TaskMember" 
							+ (reader.IsDBNull(reader.GetOrdinal("TaskMemberId"))?(int)0:(System.Int32)reader["TaskMemberId"]).ToString();

					c = EntityManager.LocateOrCreate<TaskMember>(
						key.ToString(), // EntityTrackingKey 
						"TaskMember",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.TaskMember();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.TaskMemberId = (System.Int32)reader["TaskMemberId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.RoleId = (System.Int32)reader["RoleId"];
					c.ResourceType = (System.Int32)reader["ResourceType"];
					c.ResourceId = (System.Int32)reader["ResourceId"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
					c.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
					c.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
					c.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.TaskMember"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.TaskMember"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.TaskMember entity)
		{
			if (!reader.Read()) return;
			
			entity.TaskMemberId = (System.Int32)reader["TaskMemberId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.RoleId = (System.Int32)reader["RoleId"];
			entity.ResourceType = (System.Int32)reader["ResourceType"];
			entity.ResourceId = (System.Int32)reader["ResourceId"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate")))?null:(System.DateTime?)reader["FromDate"];
			entity.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate")))?null:(System.DateTime?)reader["ToDate"];
			entity.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
			entity.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.TaskMember"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.TaskMember"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.TaskMember entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TaskMemberId = (System.Int32)dataRow["TaskMemberId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.RoleId = (System.Int32)dataRow["RoleId"];
			entity.ResourceType = (System.Int32)dataRow["ResourceType"];
			entity.ResourceId = (System.Int32)dataRow["ResourceId"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.FromDate = (Convert.IsDBNull(dataRow["FromDate"]))?null:(System.DateTime?)dataRow["FromDate"];
			entity.ToDate = (Convert.IsDBNull(dataRow["ToDate"]))?null:(System.DateTime?)dataRow["ToDate"];
			entity.RealFromDate = (Convert.IsDBNull(dataRow["RealFromDate"]))?null:(System.DateTime?)dataRow["RealFromDate"];
			entity.RealToDate = (Convert.IsDBNull(dataRow["RealToDate"]))?null:(System.DateTime?)dataRow["RealToDate"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationUserId = (Convert.IsDBNull(dataRow["LastModificationUserId"]))?null:(System.Int32?)dataRow["LastModificationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.TaskMember"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.TaskMember Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.TaskMember entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.TaskMember object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.TaskMember instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.TaskMember Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.TaskMember entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region TaskMemberChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.TaskMember</c>
	///</summary>
	public enum TaskMemberChildEntityTypes
	{
	}
	
	#endregion TaskMemberChildEntityTypes
	
	#region TaskMemberFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TaskMember"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskMemberFilterBuilder : SqlFilterBuilder<TaskMemberColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskMemberFilterBuilder class.
		/// </summary>
		public TaskMemberFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaskMemberFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaskMemberFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaskMemberFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaskMemberFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaskMemberFilterBuilder
	
	#region TaskMemberParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TaskMember"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskMemberParameterBuilder : ParameterizedSqlFilterBuilder<TaskMemberColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskMemberParameterBuilder class.
		/// </summary>
		public TaskMemberParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaskMemberParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaskMemberParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaskMemberParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaskMemberParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaskMemberParameterBuilder
} // end namespace
