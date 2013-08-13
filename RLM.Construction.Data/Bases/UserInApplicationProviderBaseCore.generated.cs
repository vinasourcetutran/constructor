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
	/// This class is the base class for any <see cref="UserInApplicationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserInApplicationProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.UserInApplication, RLM.Construction.Entities.UserInApplicationKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.UserInApplicationKey key)
		{
			return Delete(transactionManager, key.UserInApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="userInApplicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 userInApplicationId)
		{
			return Delete(null, userInApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userInApplicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 userInApplicationId);		
		
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
		public override RLM.Construction.Entities.UserInApplication Get(TransactionManager transactionManager, RLM.Construction.Entities.UserInApplicationKey key, int start, int pageLength)
		{
			return GetByUserInApplicationId(transactionManager, key.UserInApplicationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_UserInApplication index.
		/// </summary>
		/// <param name="userInApplicationId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(System.Int32 userInApplicationId)
		{
			int count = -1;
			return GetByUserInApplicationId(null,userInApplicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserInApplication index.
		/// </summary>
		/// <param name="userInApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(System.Int32 userInApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserInApplicationId(null, userInApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserInApplication index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userInApplicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(TransactionManager transactionManager, System.Int32 userInApplicationId)
		{
			int count = -1;
			return GetByUserInApplicationId(transactionManager, userInApplicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserInApplication index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userInApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(TransactionManager transactionManager, System.Int32 userInApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserInApplicationId(transactionManager, userInApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserInApplication index.
		/// </summary>
		/// <param name="userInApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(System.Int32 userInApplicationId, int start, int pageLength, out int count)
		{
			return GetByUserInApplicationId(null, userInApplicationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_UserInApplication index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userInApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.UserInApplication"/> class.</returns>
		public abstract RLM.Construction.Entities.UserInApplication GetByUserInApplicationId(TransactionManager transactionManager, System.Int32 userInApplicationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;UserInApplication&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;UserInApplication&gt;"/></returns>
		public static RLM.Construction.Entities.TList<UserInApplication> Fill(IDataReader reader, RLM.Construction.Entities.TList<UserInApplication> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.UserInApplication c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"UserInApplication" 
							+ (reader.IsDBNull(reader.GetOrdinal("UserInApplicationId"))?(int)0:(System.Int32)reader["UserInApplicationId"]).ToString();

					c = EntityManager.LocateOrCreate<UserInApplication>(
						key.ToString(), // EntityTrackingKey 
						"UserInApplication",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.UserInApplication();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.UserInApplicationId = (System.Int32)reader["UserInApplicationId"];
					c.ResourceId = (System.Int32)reader["ResourceId"];
					c.ResourceType = (reader.IsDBNull(reader.GetOrdinal("ResourceType")))?null:(System.Int32?)reader["ResourceType"];
					c.ApplicationId = (System.Int32)reader["ApplicationId"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.UserInApplication"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UserInApplication"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.UserInApplication entity)
		{
			if (!reader.Read()) return;
			
			entity.UserInApplicationId = (System.Int32)reader["UserInApplicationId"];
			entity.ResourceId = (System.Int32)reader["ResourceId"];
			entity.ResourceType = (reader.IsDBNull(reader.GetOrdinal("ResourceType")))?null:(System.Int32?)reader["ResourceType"];
			entity.ApplicationId = (System.Int32)reader["ApplicationId"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.UserInApplication"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UserInApplication"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.UserInApplication entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserInApplicationId = (System.Int32)dataRow["UserInApplicationId"];
			entity.ResourceId = (System.Int32)dataRow["ResourceId"];
			entity.ResourceType = (Convert.IsDBNull(dataRow["ResourceType"]))?null:(System.Int32?)dataRow["ResourceType"];
			entity.ApplicationId = (System.Int32)dataRow["ApplicationId"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.UserInApplication"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.UserInApplication Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.UserInApplication entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.UserInApplication object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.UserInApplication instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.UserInApplication Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.UserInApplication entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region UserInApplicationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.UserInApplication</c>
	///</summary>
	public enum UserInApplicationChildEntityTypes
	{
	}
	
	#endregion UserInApplicationChildEntityTypes
	
	#region UserInApplicationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserInApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserInApplicationFilterBuilder : SqlFilterBuilder<UserInApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserInApplicationFilterBuilder class.
		/// </summary>
		public UserInApplicationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserInApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserInApplicationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserInApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserInApplicationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserInApplicationFilterBuilder
	
	#region UserInApplicationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserInApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserInApplicationParameterBuilder : ParameterizedSqlFilterBuilder<UserInApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserInApplicationParameterBuilder class.
		/// </summary>
		public UserInApplicationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserInApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserInApplicationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserInApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserInApplicationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserInApplicationParameterBuilder
} // end namespace
