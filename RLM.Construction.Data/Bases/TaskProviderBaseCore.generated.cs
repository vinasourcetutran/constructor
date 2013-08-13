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
	/// This class is the base class for any <see cref="TaskProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TaskProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Task, RLM.Construction.Entities.TaskKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.TaskKey key)
		{
			return Delete(transactionManager, key.TaskId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="taskId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 taskId)
		{
			return Delete(null, taskId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 taskId);		
		
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
		public override RLM.Construction.Entities.Task Get(TransactionManager transactionManager, RLM.Construction.Entities.TaskKey key, int start, int pageLength)
		{
			return GetByTaskId(transactionManager, key.TaskId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Task index.
		/// </summary>
		/// <param name="taskId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public RLM.Construction.Entities.Task GetByTaskId(System.Int32 taskId)
		{
			int count = -1;
			return GetByTaskId(null,taskId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Task index.
		/// </summary>
		/// <param name="taskId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public RLM.Construction.Entities.Task GetByTaskId(System.Int32 taskId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaskId(null, taskId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Task index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public RLM.Construction.Entities.Task GetByTaskId(TransactionManager transactionManager, System.Int32 taskId)
		{
			int count = -1;
			return GetByTaskId(transactionManager, taskId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Task index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public RLM.Construction.Entities.Task GetByTaskId(TransactionManager transactionManager, System.Int32 taskId, int start, int pageLength)
		{
			int count = -1;
			return GetByTaskId(transactionManager, taskId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Task index.
		/// </summary>
		/// <param name="taskId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public RLM.Construction.Entities.Task GetByTaskId(System.Int32 taskId, int start, int pageLength, out int count)
		{
			return GetByTaskId(null, taskId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Task index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taskId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Task"/> class.</returns>
		public abstract RLM.Construction.Entities.Task GetByTaskId(TransactionManager transactionManager, System.Int32 taskId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Task&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Task&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Task> Fill(IDataReader reader, RLM.Construction.Entities.TList<Task> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Task c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Task" 
							+ (reader.IsDBNull(reader.GetOrdinal("TaskId"))?(int)0:(System.Int32)reader["TaskId"]).ToString();

					c = EntityManager.LocateOrCreate<Task>(
						key.ToString(), // EntityTrackingKey 
						"Task",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Task();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.TaskId = (System.Int32)reader["TaskId"];
					c.ProjectId = (reader.IsDBNull(reader.GetOrdinal("ProjectId")))?null:(System.Int32?)reader["ProjectId"];
					c.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
					c.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
					c.ResourceId = (reader.IsDBNull(reader.GetOrdinal("ResourceId")))?null:(System.Int32?)reader["ResourceId"];
					c.ResourceType = (reader.IsDBNull(reader.GetOrdinal("ResourceType")))?null:(System.Int32?)reader["ResourceType"];
					c.ApprovalUserId = (reader.IsDBNull(reader.GetOrdinal("ApprovalUserId")))?null:(System.Int32?)reader["ApprovalUserId"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.OperatorUserId = (reader.IsDBNull(reader.GetOrdinal("OperatorUserId")))?null:(System.Int32?)reader["OperatorUserId"];
					c.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
					c.IsCanComment = (reader.IsDBNull(reader.GetOrdinal("IsCanComment")))?null:(System.Boolean?)reader["IsCanComment"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.UseAsProjectTask = (reader.IsDBNull(reader.GetOrdinal("UseAsProjectTask")))?null:(System.Boolean?)reader["UseAsProjectTask"];
					c.PercentComplete = (reader.IsDBNull(reader.GetOrdinal("PercentComplete")))?null:(System.Double?)reader["PercentComplete"];
					c.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
					c.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
					c.EstimationFromDate = (reader.IsDBNull(reader.GetOrdinal("EstimationFromDate")))?null:(System.DateTime?)reader["EstimationFromDate"];
					c.EstimationToDate = (reader.IsDBNull(reader.GetOrdinal("EstimationToDate")))?null:(System.DateTime?)reader["EstimationToDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Task"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Task"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Task entity)
		{
			if (!reader.Read()) return;
			
			entity.TaskId = (System.Int32)reader["TaskId"];
			entity.ProjectId = (reader.IsDBNull(reader.GetOrdinal("ProjectId")))?null:(System.Int32?)reader["ProjectId"];
			entity.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
			entity.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
			entity.ResourceId = (reader.IsDBNull(reader.GetOrdinal("ResourceId")))?null:(System.Int32?)reader["ResourceId"];
			entity.ResourceType = (reader.IsDBNull(reader.GetOrdinal("ResourceType")))?null:(System.Int32?)reader["ResourceType"];
			entity.ApprovalUserId = (reader.IsDBNull(reader.GetOrdinal("ApprovalUserId")))?null:(System.Int32?)reader["ApprovalUserId"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.OperatorUserId = (reader.IsDBNull(reader.GetOrdinal("OperatorUserId")))?null:(System.Int32?)reader["OperatorUserId"];
			entity.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
			entity.IsCanComment = (reader.IsDBNull(reader.GetOrdinal("IsCanComment")))?null:(System.Boolean?)reader["IsCanComment"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.UseAsProjectTask = (reader.IsDBNull(reader.GetOrdinal("UseAsProjectTask")))?null:(System.Boolean?)reader["UseAsProjectTask"];
			entity.PercentComplete = (reader.IsDBNull(reader.GetOrdinal("PercentComplete")))?null:(System.Double?)reader["PercentComplete"];
			entity.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate")))?null:(System.DateTime?)reader["RealFromDate"];
			entity.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate")))?null:(System.DateTime?)reader["RealToDate"];
			entity.EstimationFromDate = (reader.IsDBNull(reader.GetOrdinal("EstimationFromDate")))?null:(System.DateTime?)reader["EstimationFromDate"];
			entity.EstimationToDate = (reader.IsDBNull(reader.GetOrdinal("EstimationToDate")))?null:(System.DateTime?)reader["EstimationToDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Task"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Task"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Task entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TaskId = (System.Int32)dataRow["TaskId"];
			entity.ProjectId = (Convert.IsDBNull(dataRow["ProjectId"]))?null:(System.Int32?)dataRow["ProjectId"];
			entity.ContractId = (Convert.IsDBNull(dataRow["ContractId"]))?null:(System.Int32?)dataRow["ContractId"];
			entity.ProjectPhaseId = (Convert.IsDBNull(dataRow["ProjectPhaseId"]))?null:(System.Int32?)dataRow["ProjectPhaseId"];
			entity.ResourceId = (Convert.IsDBNull(dataRow["ResourceId"]))?null:(System.Int32?)dataRow["ResourceId"];
			entity.ResourceType = (Convert.IsDBNull(dataRow["ResourceType"]))?null:(System.Int32?)dataRow["ResourceType"];
			entity.ApprovalUserId = (Convert.IsDBNull(dataRow["ApprovalUserId"]))?null:(System.Int32?)dataRow["ApprovalUserId"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.OperatorUserId = (Convert.IsDBNull(dataRow["OperatorUserId"]))?null:(System.Int32?)dataRow["OperatorUserId"];
			entity.IsApproved = (Convert.IsDBNull(dataRow["IsApproved"]))?null:(System.Boolean?)dataRow["IsApproved"];
			entity.IsCanComment = (Convert.IsDBNull(dataRow["IsCanComment"]))?null:(System.Boolean?)dataRow["IsCanComment"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.UseAsProjectTask = (Convert.IsDBNull(dataRow["UseAsProjectTask"]))?null:(System.Boolean?)dataRow["UseAsProjectTask"];
			entity.PercentComplete = (Convert.IsDBNull(dataRow["PercentComplete"]))?null:(System.Double?)dataRow["PercentComplete"];
			entity.RealFromDate = (Convert.IsDBNull(dataRow["RealFromDate"]))?null:(System.DateTime?)dataRow["RealFromDate"];
			entity.RealToDate = (Convert.IsDBNull(dataRow["RealToDate"]))?null:(System.DateTime?)dataRow["RealToDate"];
			entity.EstimationFromDate = (Convert.IsDBNull(dataRow["EstimationFromDate"]))?null:(System.DateTime?)dataRow["EstimationFromDate"];
			entity.EstimationToDate = (Convert.IsDBNull(dataRow["EstimationToDate"]))?null:(System.DateTime?)dataRow["EstimationToDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Task"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Task Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Task entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Task object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Task instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Task Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Task entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region TaskChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Task</c>
	///</summary>
	public enum TaskChildEntityTypes
	{
	}
	
	#endregion TaskChildEntityTypes
	
	#region TaskFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Task"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskFilterBuilder : SqlFilterBuilder<TaskColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskFilterBuilder class.
		/// </summary>
		public TaskFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaskFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaskFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaskFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaskFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaskFilterBuilder
	
	#region TaskParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Task"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskParameterBuilder : ParameterizedSqlFilterBuilder<TaskColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskParameterBuilder class.
		/// </summary>
		public TaskParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaskParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaskParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaskParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaskParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaskParameterBuilder
} // end namespace
