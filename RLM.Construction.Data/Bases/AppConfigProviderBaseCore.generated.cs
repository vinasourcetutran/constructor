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
	/// This class is the base class for any <see cref="AppConfigProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AppConfigProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.AppConfig, RLM.Construction.Entities.AppConfigKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.AppConfigKey key)
		{
			return Delete(transactionManager, key.AppConfigId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="appConfigId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 appConfigId)
		{
			return Delete(null, appConfigId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="appConfigId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 appConfigId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		FK_AppConfig_Application Description: 
		/// </summary>
		/// <param name="applicationId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		public RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(System.Int32? applicationId)
		{
			int count = -1;
			return GetByApplicationId(applicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		FK_AppConfig_Application Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		/// <remarks></remarks>
		public RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(TransactionManager transactionManager, System.Int32? applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, applicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		FK_AppConfig_Application Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		public RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(TransactionManager transactionManager, System.Int32? applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		fKAppConfigApplication Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		public RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(System.Int32? applicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByApplicationId(null, applicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		fKAppConfigApplication Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		public RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(System.Int32? applicationId, int start, int pageLength,out int count)
		{
			return GetByApplicationId(null, applicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AppConfig_Application key.
		///		FK_AppConfig_Application Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of RLM.Construction.Entities.AppConfig objects.</returns>
		public abstract RLM.Construction.Entities.TList<AppConfig> GetByApplicationId(TransactionManager transactionManager, System.Int32? applicationId, int start, int pageLength, out int count);
		
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
		public override RLM.Construction.Entities.AppConfig Get(TransactionManager transactionManager, RLM.Construction.Entities.AppConfigKey key, int start, int pageLength)
		{
			return GetByAppConfigId(transactionManager, key.AppConfigId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AppConfig index.
		/// </summary>
		/// <param name="appConfigId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public RLM.Construction.Entities.AppConfig GetByAppConfigId(System.Int32 appConfigId)
		{
			int count = -1;
			return GetByAppConfigId(null,appConfigId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AppConfig index.
		/// </summary>
		/// <param name="appConfigId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public RLM.Construction.Entities.AppConfig GetByAppConfigId(System.Int32 appConfigId, int start, int pageLength)
		{
			int count = -1;
			return GetByAppConfigId(null, appConfigId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AppConfig index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="appConfigId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public RLM.Construction.Entities.AppConfig GetByAppConfigId(TransactionManager transactionManager, System.Int32 appConfigId)
		{
			int count = -1;
			return GetByAppConfigId(transactionManager, appConfigId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AppConfig index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="appConfigId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public RLM.Construction.Entities.AppConfig GetByAppConfigId(TransactionManager transactionManager, System.Int32 appConfigId, int start, int pageLength)
		{
			int count = -1;
			return GetByAppConfigId(transactionManager, appConfigId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AppConfig index.
		/// </summary>
		/// <param name="appConfigId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public RLM.Construction.Entities.AppConfig GetByAppConfigId(System.Int32 appConfigId, int start, int pageLength, out int count)
		{
			return GetByAppConfigId(null, appConfigId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AppConfig index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="appConfigId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.AppConfig"/> class.</returns>
		public abstract RLM.Construction.Entities.AppConfig GetByAppConfigId(TransactionManager transactionManager, System.Int32 appConfigId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;AppConfig&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;AppConfig&gt;"/></returns>
		public static RLM.Construction.Entities.TList<AppConfig> Fill(IDataReader reader, RLM.Construction.Entities.TList<AppConfig> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.AppConfig c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"AppConfig" 
							+ (reader.IsDBNull(reader.GetOrdinal("AppConfigId"))?(int)0:(System.Int32)reader["AppConfigId"]).ToString();

					c = EntityManager.LocateOrCreate<AppConfig>(
						key.ToString(), // EntityTrackingKey 
						"AppConfig",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.AppConfig();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AppConfigId = (System.Int32)reader["AppConfigId"];
					c.ApplicationId = (reader.IsDBNull(reader.GetOrdinal("ApplicationId")))?null:(System.Int32?)reader["ApplicationId"];
					c.AppConfigName = (reader.IsDBNull(reader.GetOrdinal("AppConfigName")))?null:(System.String)reader["AppConfigName"];
					c.AppConfigValue = (reader.IsDBNull(reader.GetOrdinal("AppConfigValue")))?null:(System.String)reader["AppConfigValue"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.IsVisible = (reader.IsDBNull(reader.GetOrdinal("IsVisible")))?null:(System.Boolean?)reader["IsVisible"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.AppConfig"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AppConfig"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.AppConfig entity)
		{
			if (!reader.Read()) return;
			
			entity.AppConfigId = (System.Int32)reader["AppConfigId"];
			entity.ApplicationId = (reader.IsDBNull(reader.GetOrdinal("ApplicationId")))?null:(System.Int32?)reader["ApplicationId"];
			entity.AppConfigName = (reader.IsDBNull(reader.GetOrdinal("AppConfigName")))?null:(System.String)reader["AppConfigName"];
			entity.AppConfigValue = (reader.IsDBNull(reader.GetOrdinal("AppConfigValue")))?null:(System.String)reader["AppConfigValue"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.IsVisible = (reader.IsDBNull(reader.GetOrdinal("IsVisible")))?null:(System.Boolean?)reader["IsVisible"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.AppConfig"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AppConfig"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.AppConfig entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AppConfigId = (System.Int32)dataRow["AppConfigId"];
			entity.ApplicationId = (Convert.IsDBNull(dataRow["ApplicationId"]))?null:(System.Int32?)dataRow["ApplicationId"];
			entity.AppConfigName = (Convert.IsDBNull(dataRow["AppConfigName"]))?null:(System.String)dataRow["AppConfigName"];
			entity.AppConfigValue = (Convert.IsDBNull(dataRow["AppConfigValue"]))?null:(System.String)dataRow["AppConfigValue"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.IsVisible = (Convert.IsDBNull(dataRow["IsVisible"]))?null:(System.Boolean?)dataRow["IsVisible"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.AppConfig"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.AppConfig Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.AppConfig entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ApplicationIdSource	
			if (CanDeepLoad(entity, "Application", "ApplicationIdSource", deepLoadType, innerList) 
				&& entity.ApplicationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ApplicationId ?? (int)0);
				Application tmpEntity = EntityManager.LocateEntity<Application>(EntityLocator.ConstructKeyFromPkItems(typeof(Application), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ApplicationIdSource = tmpEntity;
				else
					entity.ApplicationIdSource = DataRepository.ApplicationProvider.GetByApplicationId((entity.ApplicationId ?? (int)0));
			
				if (deep && entity.ApplicationIdSource != null)
				{
					DataRepository.ApplicationProvider.DeepLoad(transactionManager, entity.ApplicationIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ApplicationIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.AppConfig object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.AppConfig instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.AppConfig Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.AppConfig entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ApplicationIdSource
			if (CanDeepSave(entity, "Application", "ApplicationIdSource", deepSaveType, innerList) 
				&& entity.ApplicationIdSource != null)
			{
				DataRepository.ApplicationProvider.Save(transactionManager, entity.ApplicationIdSource);
				entity.ApplicationId = entity.ApplicationIdSource.ApplicationId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region AppConfigChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.AppConfig</c>
	///</summary>
	public enum AppConfigChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Application</c> at ApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(Application))]
		Application,
		}
	
	#endregion AppConfigChildEntityTypes
	
	#region AppConfigFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AppConfig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppConfigFilterBuilder : SqlFilterBuilder<AppConfigColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppConfigFilterBuilder class.
		/// </summary>
		public AppConfigFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AppConfigFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AppConfigFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AppConfigFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AppConfigFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AppConfigFilterBuilder
	
	#region AppConfigParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AppConfig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppConfigParameterBuilder : ParameterizedSqlFilterBuilder<AppConfigColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppConfigParameterBuilder class.
		/// </summary>
		public AppConfigParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AppConfigParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AppConfigParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AppConfigParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AppConfigParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AppConfigParameterBuilder
} // end namespace
