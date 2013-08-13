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
	/// This class is the base class for any <see cref="ApplicationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ApplicationProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Application, RLM.Construction.Entities.ApplicationKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ApplicationKey key)
		{
			return Delete(transactionManager, key.ApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="applicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 applicationId)
		{
			return Delete(null, applicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 applicationId);		
		
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
		public override RLM.Construction.Entities.Application Get(TransactionManager transactionManager, RLM.Construction.Entities.ApplicationKey key, int start, int pageLength)
		{
			return GetByApplicationId(transactionManager, key.ApplicationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Application index.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public RLM.Construction.Entities.Application GetByApplicationId(System.Int32 applicationId)
		{
			int count = -1;
			return GetByApplicationId(null,applicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Application index.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public RLM.Construction.Entities.Application GetByApplicationId(System.Int32 applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(null, applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Application index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public RLM.Construction.Entities.Application GetByApplicationId(TransactionManager transactionManager, System.Int32 applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, applicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Application index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public RLM.Construction.Entities.Application GetByApplicationId(TransactionManager transactionManager, System.Int32 applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Application index.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public RLM.Construction.Entities.Application GetByApplicationId(System.Int32 applicationId, int start, int pageLength, out int count)
		{
			return GetByApplicationId(null, applicationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Application index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Application"/> class.</returns>
		public abstract RLM.Construction.Entities.Application GetByApplicationId(TransactionManager transactionManager, System.Int32 applicationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Application&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Application&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Application> Fill(IDataReader reader, RLM.Construction.Entities.TList<Application> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Application c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Application" 
							+ (reader.IsDBNull(reader.GetOrdinal("ApplicationId"))?(int)0:(System.Int32)reader["ApplicationId"]).ToString();

					c = EntityManager.LocateOrCreate<Application>(
						key.ToString(), // EntityTrackingKey 
						"Application",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Application();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ApplicationId = (System.Int32)reader["ApplicationId"];
					c.Code = (System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
					c.DefaultUrl = (reader.IsDBNull(reader.GetOrdinal("DefaultUrl")))?null:(System.String)reader["DefaultUrl"];
					c.WebserviceUrl = (reader.IsDBNull(reader.GetOrdinal("WebserviceUrl")))?null:(System.String)reader["WebserviceUrl"];
					c.WebserviceUserName = (reader.IsDBNull(reader.GetOrdinal("WebserviceUserName")))?null:(System.String)reader["WebserviceUserName"];
					c.WebServicePwd = (reader.IsDBNull(reader.GetOrdinal("WebServicePwd")))?null:(System.String)reader["WebServicePwd"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Application"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Application"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Application entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationId = (System.Int32)reader["ApplicationId"];
			entity.Code = (System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Int64?)reader["IsActive"];
			entity.DefaultUrl = (reader.IsDBNull(reader.GetOrdinal("DefaultUrl")))?null:(System.String)reader["DefaultUrl"];
			entity.WebserviceUrl = (reader.IsDBNull(reader.GetOrdinal("WebserviceUrl")))?null:(System.String)reader["WebserviceUrl"];
			entity.WebserviceUserName = (reader.IsDBNull(reader.GetOrdinal("WebserviceUserName")))?null:(System.String)reader["WebserviceUserName"];
			entity.WebServicePwd = (reader.IsDBNull(reader.GetOrdinal("WebServicePwd")))?null:(System.String)reader["WebServicePwd"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Application"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Application"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Application entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationId = (System.Int32)dataRow["ApplicationId"];
			entity.Code = (System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Int64?)dataRow["IsActive"];
			entity.DefaultUrl = (Convert.IsDBNull(dataRow["DefaultUrl"]))?null:(System.String)dataRow["DefaultUrl"];
			entity.WebserviceUrl = (Convert.IsDBNull(dataRow["WebserviceUrl"]))?null:(System.String)dataRow["WebserviceUrl"];
			entity.WebserviceUserName = (Convert.IsDBNull(dataRow["WebserviceUserName"]))?null:(System.String)dataRow["WebserviceUserName"];
			entity.WebServicePwd = (Convert.IsDBNull(dataRow["WebServicePwd"]))?null:(System.String)dataRow["WebServicePwd"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Application"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Application Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Application entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByApplicationId methods when available
			
			#region AppConfigCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AppConfig>", "AppConfigCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AppConfigCollection' loaded.");
				#endif 

				entity.AppConfigCollection = DataRepository.AppConfigProvider.GetByApplicationId(transactionManager, entity.ApplicationId);

				if (deep && entity.AppConfigCollection.Count > 0)
				{
					DataRepository.AppConfigProvider.DeepLoad(transactionManager, entity.AppConfigCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Application object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Application instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Application Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Application entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<AppConfig>
				if (CanDeepSave(entity, "List<AppConfig>", "AppConfigCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AppConfig child in entity.AppConfigCollection)
					{
						child.ApplicationId = entity.ApplicationId;
					}
				
				if (entity.AppConfigCollection.Count > 0 || entity.AppConfigCollection.DeletedItems.Count > 0)
					DataRepository.AppConfigProvider.DeepSave(transactionManager, entity.AppConfigCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region ApplicationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Application</c>
	///</summary>
	public enum ApplicationChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Application</c> as OneToMany for AppConfigCollection
		///</summary>
		[ChildEntityType(typeof(TList<AppConfig>))]
		AppConfigCollection,
	}
	
	#endregion ApplicationChildEntityTypes
	
	#region ApplicationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Application"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ApplicationFilterBuilder : SqlFilterBuilder<ApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ApplicationFilterBuilder class.
		/// </summary>
		public ApplicationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ApplicationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ApplicationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ApplicationFilterBuilder
	
	#region ApplicationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Application"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ApplicationParameterBuilder : ParameterizedSqlFilterBuilder<ApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ApplicationParameterBuilder class.
		/// </summary>
		public ApplicationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ApplicationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ApplicationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ApplicationParameterBuilder
} // end namespace
