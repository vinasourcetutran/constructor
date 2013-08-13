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
	/// This class is the base class for any <see cref="AdvanceRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvanceRequestProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.AdvanceRequest, RLM.Construction.Entities.AdvanceRequestKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.AdvanceRequestKey key)
		{
			return Delete(transactionManager, key.AdvanceRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="advanceRequestId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 advanceRequestId)
		{
			return Delete(null, advanceRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="advanceRequestId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 advanceRequestId);		
		
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
		public override RLM.Construction.Entities.AdvanceRequest Get(TransactionManager transactionManager, RLM.Construction.Entities.AdvanceRequestKey key, int start, int pageLength)
		{
			return GetByAdvanceRequestId(transactionManager, key.AdvanceRequestId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AdvanceRequest index.
		/// </summary>
		/// <param name="advanceRequestId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(System.Int32 advanceRequestId)
		{
			int count = -1;
			return GetByAdvanceRequestId(null,advanceRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdvanceRequest index.
		/// </summary>
		/// <param name="advanceRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(System.Int32 advanceRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvanceRequestId(null, advanceRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdvanceRequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="advanceRequestId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(TransactionManager transactionManager, System.Int32 advanceRequestId)
		{
			int count = -1;
			return GetByAdvanceRequestId(transactionManager, advanceRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdvanceRequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="advanceRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(TransactionManager transactionManager, System.Int32 advanceRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvanceRequestId(transactionManager, advanceRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdvanceRequest index.
		/// </summary>
		/// <param name="advanceRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(System.Int32 advanceRequestId, int start, int pageLength, out int count)
		{
			return GetByAdvanceRequestId(null, advanceRequestId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AdvanceRequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="advanceRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AdvanceRequest"/> class.</returns>
		public abstract RLM.Construction.Entities.AdvanceRequest GetByAdvanceRequestId(TransactionManager transactionManager, System.Int32 advanceRequestId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;AdvanceRequest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;AdvanceRequest&gt;"/></returns>
		public static RLM.Construction.Entities.TList<AdvanceRequest> Fill(IDataReader reader, RLM.Construction.Entities.TList<AdvanceRequest> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.AdvanceRequest c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"AdvanceRequest" 
							+ (reader.IsDBNull(reader.GetOrdinal("AdvanceRequestId"))?(int)0:(System.Int32)reader["AdvanceRequestId"]).ToString();

					c = EntityManager.LocateOrCreate<AdvanceRequest>(
						key.ToString(), // EntityTrackingKey 
						"AdvanceRequest",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.AdvanceRequest();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AdvanceRequestId = (System.Int32)reader["AdvanceRequestId"];
					c.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
					c.RequestContactorId = (System.Int32)reader["RequestContactorId"];
					c.ResponseContactorId = (reader.IsDBNull(reader.GetOrdinal("ResponseContactorId")))?null:(System.Int32?)reader["ResponseContactorId"];
					c.RequestDate = (reader.IsDBNull(reader.GetOrdinal("RequestDate")))?null:(System.DateTime?)reader["RequestDate"];
					c.ResponseDate = (reader.IsDBNull(reader.GetOrdinal("ResponseDate")))?null:(System.DateTime?)reader["ResponseDate"];
					c.RequestAmount = (reader.IsDBNull(reader.GetOrdinal("RequestAmount")))?null:(System.Decimal?)reader["RequestAmount"];
					c.ResponseAmount = (reader.IsDBNull(reader.GetOrdinal("ResponseAmount")))?null:(System.Decimal?)reader["ResponseAmount"];
					c.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
					c.RequestComment = (reader.IsDBNull(reader.GetOrdinal("RequestComment")))?null:(System.String)reader["RequestComment"];
					c.ResponseComment = (reader.IsDBNull(reader.GetOrdinal("ResponseComment")))?null:(System.String)reader["ResponseComment"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.LastModifidationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModifidationUserId")))?null:(System.Int32?)reader["LastModifidationUserId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.AdvanceRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AdvanceRequest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.AdvanceRequest entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvanceRequestId = (System.Int32)reader["AdvanceRequestId"];
			entity.ContractId = (reader.IsDBNull(reader.GetOrdinal("ContractId")))?null:(System.Int32?)reader["ContractId"];
			entity.RequestContactorId = (System.Int32)reader["RequestContactorId"];
			entity.ResponseContactorId = (reader.IsDBNull(reader.GetOrdinal("ResponseContactorId")))?null:(System.Int32?)reader["ResponseContactorId"];
			entity.RequestDate = (reader.IsDBNull(reader.GetOrdinal("RequestDate")))?null:(System.DateTime?)reader["RequestDate"];
			entity.ResponseDate = (reader.IsDBNull(reader.GetOrdinal("ResponseDate")))?null:(System.DateTime?)reader["ResponseDate"];
			entity.RequestAmount = (reader.IsDBNull(reader.GetOrdinal("RequestAmount")))?null:(System.Decimal?)reader["RequestAmount"];
			entity.ResponseAmount = (reader.IsDBNull(reader.GetOrdinal("ResponseAmount")))?null:(System.Decimal?)reader["ResponseAmount"];
			entity.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId")))?null:(System.Int32?)reader["CurrencyUnitId"];
			entity.RequestComment = (reader.IsDBNull(reader.GetOrdinal("RequestComment")))?null:(System.String)reader["RequestComment"];
			entity.ResponseComment = (reader.IsDBNull(reader.GetOrdinal("ResponseComment")))?null:(System.String)reader["ResponseComment"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.Type = (reader.IsDBNull(reader.GetOrdinal("Type")))?null:(System.Int32?)reader["Type"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModifidationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModifidationUserId")))?null:(System.Int32?)reader["LastModifidationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.AdvanceRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AdvanceRequest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.AdvanceRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvanceRequestId = (System.Int32)dataRow["AdvanceRequestId"];
			entity.ContractId = (Convert.IsDBNull(dataRow["ContractId"]))?null:(System.Int32?)dataRow["ContractId"];
			entity.RequestContactorId = (System.Int32)dataRow["RequestContactorId"];
			entity.ResponseContactorId = (Convert.IsDBNull(dataRow["ResponseContactorId"]))?null:(System.Int32?)dataRow["ResponseContactorId"];
			entity.RequestDate = (Convert.IsDBNull(dataRow["RequestDate"]))?null:(System.DateTime?)dataRow["RequestDate"];
			entity.ResponseDate = (Convert.IsDBNull(dataRow["ResponseDate"]))?null:(System.DateTime?)dataRow["ResponseDate"];
			entity.RequestAmount = (Convert.IsDBNull(dataRow["RequestAmount"]))?null:(System.Decimal?)dataRow["RequestAmount"];
			entity.ResponseAmount = (Convert.IsDBNull(dataRow["ResponseAmount"]))?null:(System.Decimal?)dataRow["ResponseAmount"];
			entity.CurrencyUnitId = (Convert.IsDBNull(dataRow["CurrencyUnitId"]))?null:(System.Int32?)dataRow["CurrencyUnitId"];
			entity.RequestComment = (Convert.IsDBNull(dataRow["RequestComment"]))?null:(System.String)dataRow["RequestComment"];
			entity.ResponseComment = (Convert.IsDBNull(dataRow["ResponseComment"]))?null:(System.String)dataRow["ResponseComment"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.Type = (Convert.IsDBNull(dataRow["Type"]))?null:(System.Int32?)dataRow["Type"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.LastModifidationUserId = (Convert.IsDBNull(dataRow["LastModifidationUserId"]))?null:(System.Int32?)dataRow["LastModifidationUserId"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AdvanceRequest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.AdvanceRequest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.AdvanceRequest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.AdvanceRequest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.AdvanceRequest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.AdvanceRequest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.AdvanceRequest entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region AdvanceRequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.AdvanceRequest</c>
	///</summary>
	public enum AdvanceRequestChildEntityTypes
	{
	}
	
	#endregion AdvanceRequestChildEntityTypes
	
	#region AdvanceRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvanceRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvanceRequestFilterBuilder : SqlFilterBuilder<AdvanceRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestFilterBuilder class.
		/// </summary>
		public AdvanceRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvanceRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvanceRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvanceRequestFilterBuilder
	
	#region AdvanceRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvanceRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvanceRequestParameterBuilder : ParameterizedSqlFilterBuilder<AdvanceRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestParameterBuilder class.
		/// </summary>
		public AdvanceRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvanceRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvanceRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvanceRequestParameterBuilder
} // end namespace
