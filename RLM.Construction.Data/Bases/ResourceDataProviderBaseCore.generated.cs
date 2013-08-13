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
	/// This class is the base class for any <see cref="ResourceDataProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ResourceDataProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ResourceData, RLM.Construction.Entities.ResourceDataKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ResourceDataKey key)
		{
			return Delete(transactionManager, key.ResourceDataId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="resourceDataId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 resourceDataId)
		{
			return Delete(null, resourceDataId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="resourceDataId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 resourceDataId);		
		
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
		public override RLM.Construction.Entities.ResourceData Get(TransactionManager transactionManager, RLM.Construction.Entities.ResourceDataKey key, int start, int pageLength)
		{
			return GetByResourceDataId(transactionManager, key.ResourceDataId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ResourceData index.
		/// </summary>
		/// <param name="resourceDataId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public RLM.Construction.Entities.ResourceData GetByResourceDataId(System.Int32 resourceDataId)
		{
			int count = -1;
			return GetByResourceDataId(null,resourceDataId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ResourceData index.
		/// </summary>
		/// <param name="resourceDataId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public RLM.Construction.Entities.ResourceData GetByResourceDataId(System.Int32 resourceDataId, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceDataId(null, resourceDataId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ResourceData index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="resourceDataId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public RLM.Construction.Entities.ResourceData GetByResourceDataId(TransactionManager transactionManager, System.Int32 resourceDataId)
		{
			int count = -1;
			return GetByResourceDataId(transactionManager, resourceDataId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ResourceData index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="resourceDataId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public RLM.Construction.Entities.ResourceData GetByResourceDataId(TransactionManager transactionManager, System.Int32 resourceDataId, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceDataId(transactionManager, resourceDataId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ResourceData index.
		/// </summary>
		/// <param name="resourceDataId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public RLM.Construction.Entities.ResourceData GetByResourceDataId(System.Int32 resourceDataId, int start, int pageLength, out int count)
		{
			return GetByResourceDataId(null, resourceDataId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ResourceData index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="resourceDataId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ResourceData"/> class.</returns>
		public abstract RLM.Construction.Entities.ResourceData GetByResourceDataId(TransactionManager transactionManager, System.Int32 resourceDataId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ResourceData&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ResourceData&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ResourceData> Fill(IDataReader reader, RLM.Construction.Entities.TList<ResourceData> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ResourceData c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ResourceData" 
							+ (reader.IsDBNull(reader.GetOrdinal("ResourceDataId"))?(int)0:(System.Int32)reader["ResourceDataId"]).ToString();

					c = EntityManager.LocateOrCreate<ResourceData>(
						key.ToString(), // EntityTrackingKey 
						"ResourceData",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ResourceData();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ResourceDataId = (System.Int32)reader["ResourceDataId"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Title = (reader.IsDBNull(reader.GetOrdinal("Title")))?null:(System.String)reader["Title"];
					c.Content = (reader.IsDBNull(reader.GetOrdinal("Content")))?null:(System.String)reader["Content"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.Other = (reader.IsDBNull(reader.GetOrdinal("Other")))?null:(System.String)reader["Other"];
					c.ResourceType = (System.Int32)reader["ResourceType"];
					c.ResourceId = (System.Int32)reader["ResourceId"];
					c.ContentType = (reader.IsDBNull(reader.GetOrdinal("ContentType")))?null:(System.Int32?)reader["ContentType"];
					c.SubContentType = (reader.IsDBNull(reader.GetOrdinal("SubContentType")))?null:(System.Int32?)reader["SubContentType"];
					c.XMLContent = (reader.IsDBNull(reader.GetOrdinal("XMLContent")))?null:(System.String)reader["XMLContent"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ResourceData"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ResourceData"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ResourceData entity)
		{
			if (!reader.Read()) return;
			
			entity.ResourceDataId = (System.Int32)reader["ResourceDataId"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Title = (reader.IsDBNull(reader.GetOrdinal("Title")))?null:(System.String)reader["Title"];
			entity.Content = (reader.IsDBNull(reader.GetOrdinal("Content")))?null:(System.String)reader["Content"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.Other = (reader.IsDBNull(reader.GetOrdinal("Other")))?null:(System.String)reader["Other"];
			entity.ResourceType = (System.Int32)reader["ResourceType"];
			entity.ResourceId = (System.Int32)reader["ResourceId"];
			entity.ContentType = (reader.IsDBNull(reader.GetOrdinal("ContentType")))?null:(System.Int32?)reader["ContentType"];
			entity.SubContentType = (reader.IsDBNull(reader.GetOrdinal("SubContentType")))?null:(System.Int32?)reader["SubContentType"];
			entity.XMLContent = (reader.IsDBNull(reader.GetOrdinal("XMLContent")))?null:(System.String)reader["XMLContent"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ResourceData"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ResourceData"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ResourceData entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ResourceDataId = (System.Int32)dataRow["ResourceDataId"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?null:(System.String)dataRow["Title"];
			entity.Content = (Convert.IsDBNull(dataRow["Content"]))?null:(System.String)dataRow["Content"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.Other = (Convert.IsDBNull(dataRow["Other"]))?null:(System.String)dataRow["Other"];
			entity.ResourceType = (System.Int32)dataRow["ResourceType"];
			entity.ResourceId = (System.Int32)dataRow["ResourceId"];
			entity.ContentType = (Convert.IsDBNull(dataRow["ContentType"]))?null:(System.Int32?)dataRow["ContentType"];
			entity.SubContentType = (Convert.IsDBNull(dataRow["SubContentType"]))?null:(System.Int32?)dataRow["SubContentType"];
			entity.XMLContent = (Convert.IsDBNull(dataRow["XMLContent"]))?null:(System.String)dataRow["XMLContent"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ResourceData"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ResourceData Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ResourceData entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ResourceData object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ResourceData instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ResourceData Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ResourceData entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region ResourceDataChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ResourceData</c>
	///</summary>
	public enum ResourceDataChildEntityTypes
	{
	}
	
	#endregion ResourceDataChildEntityTypes
	
	#region ResourceDataFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ResourceData"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResourceDataFilterBuilder : SqlFilterBuilder<ResourceDataColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResourceDataFilterBuilder class.
		/// </summary>
		public ResourceDataFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResourceDataFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResourceDataFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResourceDataFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResourceDataFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResourceDataFilterBuilder
	
	#region ResourceDataParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ResourceData"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResourceDataParameterBuilder : ParameterizedSqlFilterBuilder<ResourceDataColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResourceDataParameterBuilder class.
		/// </summary>
		public ResourceDataParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResourceDataParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResourceDataParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResourceDataParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResourceDataParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResourceDataParameterBuilder
} // end namespace
