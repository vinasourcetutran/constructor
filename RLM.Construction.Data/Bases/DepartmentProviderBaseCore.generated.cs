﻿#region Using directives

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
	/// This class is the base class for any <see cref="DepartmentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DepartmentProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Department, RLM.Construction.Entities.DepartmentKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.DepartmentKey key)
		{
			return Delete(transactionManager, key.DeptId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="deptId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 deptId)
		{
			return Delete(null, deptId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="deptId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 deptId);		
		
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
		public override RLM.Construction.Entities.Department Get(TransactionManager transactionManager, RLM.Construction.Entities.DepartmentKey key, int start, int pageLength)
		{
			return GetByDeptId(transactionManager, key.DeptId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Departments_1 index.
		/// </summary>
		/// <param name="deptId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public RLM.Construction.Entities.Department GetByDeptId(System.Int32 deptId)
		{
			int count = -1;
			return GetByDeptId(null,deptId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments_1 index.
		/// </summary>
		/// <param name="deptId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public RLM.Construction.Entities.Department GetByDeptId(System.Int32 deptId, int start, int pageLength)
		{
			int count = -1;
			return GetByDeptId(null, deptId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="deptId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public RLM.Construction.Entities.Department GetByDeptId(TransactionManager transactionManager, System.Int32 deptId)
		{
			int count = -1;
			return GetByDeptId(transactionManager, deptId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="deptId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public RLM.Construction.Entities.Department GetByDeptId(TransactionManager transactionManager, System.Int32 deptId, int start, int pageLength)
		{
			int count = -1;
			return GetByDeptId(transactionManager, deptId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments_1 index.
		/// </summary>
		/// <param name="deptId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public RLM.Construction.Entities.Department GetByDeptId(System.Int32 deptId, int start, int pageLength, out int count)
		{
			return GetByDeptId(null, deptId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="deptId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Department"/> class.</returns>
		public abstract RLM.Construction.Entities.Department GetByDeptId(TransactionManager transactionManager, System.Int32 deptId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Department&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Department&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Department> Fill(IDataReader reader, RLM.Construction.Entities.TList<Department> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Department c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Department" 
							+ (reader.IsDBNull(reader.GetOrdinal("DeptId"))?(int)0:(System.Int32)reader["DeptId"]).ToString();

					c = EntityManager.LocateOrCreate<Department>(
						key.ToString(), // EntityTrackingKey 
						"Department",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Department();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.DeptId = (System.Int32)reader["DeptId"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Int64?)reader["IsDeletable"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Department"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Department"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Department entity)
		{
			if (!reader.Read()) return;
			
			entity.DeptId = (System.Int32)reader["DeptId"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Int64?)reader["IsDeletable"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Department"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Department"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Department entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DeptId = (System.Int32)dataRow["DeptId"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.Fax = (Convert.IsDBNull(dataRow["Fax"]))?null:(System.String)dataRow["Fax"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Int64?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Int64?)dataRow["IsDeletable"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Department"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Department Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Department entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Department object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Department instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Department Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Department entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region DepartmentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Department</c>
	///</summary>
	public enum DepartmentChildEntityTypes
	{
	}
	
	#endregion DepartmentChildEntityTypes
	
	#region DepartmentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentFilterBuilder : SqlFilterBuilder<DepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		public DepartmentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentFilterBuilder
	
	#region DepartmentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Department"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentParameterBuilder : ParameterizedSqlFilterBuilder<DepartmentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		public DepartmentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentParameterBuilder
} // end namespace