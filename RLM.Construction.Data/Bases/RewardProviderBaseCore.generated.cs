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
	/// This class is the base class for any <see cref="RewardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RewardProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Reward, RLM.Construction.Entities.RewardKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.RewardKey key)
		{
			return Delete(transactionManager, key.RewardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="rewardId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 rewardId)
		{
			return Delete(null, rewardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="rewardId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 rewardId);		
		
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
		public override RLM.Construction.Entities.Reward Get(TransactionManager transactionManager, RLM.Construction.Entities.RewardKey key, int start, int pageLength)
		{
			return GetByRewardId(transactionManager, key.RewardId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Reward index.
		/// </summary>
		/// <param name="rewardId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public RLM.Construction.Entities.Reward GetByRewardId(System.Int32 rewardId)
		{
			int count = -1;
			return GetByRewardId(null,rewardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reward index.
		/// </summary>
		/// <param name="rewardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public RLM.Construction.Entities.Reward GetByRewardId(System.Int32 rewardId, int start, int pageLength)
		{
			int count = -1;
			return GetByRewardId(null, rewardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reward index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="rewardId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public RLM.Construction.Entities.Reward GetByRewardId(TransactionManager transactionManager, System.Int32 rewardId)
		{
			int count = -1;
			return GetByRewardId(transactionManager, rewardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reward index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="rewardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public RLM.Construction.Entities.Reward GetByRewardId(TransactionManager transactionManager, System.Int32 rewardId, int start, int pageLength)
		{
			int count = -1;
			return GetByRewardId(transactionManager, rewardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reward index.
		/// </summary>
		/// <param name="rewardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public RLM.Construction.Entities.Reward GetByRewardId(System.Int32 rewardId, int start, int pageLength, out int count)
		{
			return GetByRewardId(null, rewardId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Reward index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="rewardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Reward"/> class.</returns>
		public abstract RLM.Construction.Entities.Reward GetByRewardId(TransactionManager transactionManager, System.Int32 rewardId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Reward&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Reward&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Reward> Fill(IDataReader reader, RLM.Construction.Entities.TList<Reward> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Reward c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Reward" 
							+ (reader.IsDBNull(reader.GetOrdinal("RewardId"))?(int)0:(System.Int32)reader["RewardId"]).ToString();

					c = EntityManager.LocateOrCreate<Reward>(
						key.ToString(), // EntityTrackingKey 
						"Reward",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Reward();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RewardId = (System.Int32)reader["RewardId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.RewardTypeId = (reader.IsDBNull(reader.GetOrdinal("RewardTypeId")))?null:(System.Int32?)reader["RewardTypeId"];
					c.RewardDate = (reader.IsDBNull(reader.GetOrdinal("RewardDate")))?null:(System.DateTime?)reader["RewardDate"];
					c.EffectFrom = (reader.IsDBNull(reader.GetOrdinal("EffectFrom")))?null:(System.DateTime?)reader["EffectFrom"];
					c.RewardCode = (reader.IsDBNull(reader.GetOrdinal("RewardCode")))?null:(System.String)reader["RewardCode"];
					c.RewardForm = (reader.IsDBNull(reader.GetOrdinal("RewardForm")))?null:(System.Int32?)reader["RewardForm"];
					c.Reason = (reader.IsDBNull(reader.GetOrdinal("Reason")))?null:(System.String)reader["Reason"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.IssueLevel = (reader.IsDBNull(reader.GetOrdinal("IssueLevel")))?null:(System.Int32?)reader["IssueLevel"];
					c.FromLevelId = (reader.IsDBNull(reader.GetOrdinal("FromLevelId")))?null:(System.Int32?)reader["FromLevelId"];
					c.ToLevelId = (reader.IsDBNull(reader.GetOrdinal("ToLevelId")))?null:(System.Int32?)reader["ToLevelId"];
					c.MoneyAmount = (reader.IsDBNull(reader.GetOrdinal("MoneyAmount")))?null:(System.Decimal?)reader["MoneyAmount"];
					c.MoneyUnitId = (reader.IsDBNull(reader.GetOrdinal("MoneyUnitId")))?null:(System.Int32?)reader["MoneyUnitId"];
					c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Reward"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Reward"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Reward entity)
		{
			if (!reader.Read()) return;
			
			entity.RewardId = (System.Int32)reader["RewardId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.RewardTypeId = (reader.IsDBNull(reader.GetOrdinal("RewardTypeId")))?null:(System.Int32?)reader["RewardTypeId"];
			entity.RewardDate = (reader.IsDBNull(reader.GetOrdinal("RewardDate")))?null:(System.DateTime?)reader["RewardDate"];
			entity.EffectFrom = (reader.IsDBNull(reader.GetOrdinal("EffectFrom")))?null:(System.DateTime?)reader["EffectFrom"];
			entity.RewardCode = (reader.IsDBNull(reader.GetOrdinal("RewardCode")))?null:(System.String)reader["RewardCode"];
			entity.RewardForm = (reader.IsDBNull(reader.GetOrdinal("RewardForm")))?null:(System.Int32?)reader["RewardForm"];
			entity.Reason = (reader.IsDBNull(reader.GetOrdinal("Reason")))?null:(System.String)reader["Reason"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.IssueLevel = (reader.IsDBNull(reader.GetOrdinal("IssueLevel")))?null:(System.Int32?)reader["IssueLevel"];
			entity.FromLevelId = (reader.IsDBNull(reader.GetOrdinal("FromLevelId")))?null:(System.Int32?)reader["FromLevelId"];
			entity.ToLevelId = (reader.IsDBNull(reader.GetOrdinal("ToLevelId")))?null:(System.Int32?)reader["ToLevelId"];
			entity.MoneyAmount = (reader.IsDBNull(reader.GetOrdinal("MoneyAmount")))?null:(System.Decimal?)reader["MoneyAmount"];
			entity.MoneyUnitId = (reader.IsDBNull(reader.GetOrdinal("MoneyUnitId")))?null:(System.Int32?)reader["MoneyUnitId"];
			entity.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate")))?null:(System.Int32?)reader["ExchangeRate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Reward"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Reward"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Reward entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RewardId = (System.Int32)dataRow["RewardId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.RewardTypeId = (Convert.IsDBNull(dataRow["RewardTypeId"]))?null:(System.Int32?)dataRow["RewardTypeId"];
			entity.RewardDate = (Convert.IsDBNull(dataRow["RewardDate"]))?null:(System.DateTime?)dataRow["RewardDate"];
			entity.EffectFrom = (Convert.IsDBNull(dataRow["EffectFrom"]))?null:(System.DateTime?)dataRow["EffectFrom"];
			entity.RewardCode = (Convert.IsDBNull(dataRow["RewardCode"]))?null:(System.String)dataRow["RewardCode"];
			entity.RewardForm = (Convert.IsDBNull(dataRow["RewardForm"]))?null:(System.Int32?)dataRow["RewardForm"];
			entity.Reason = (Convert.IsDBNull(dataRow["Reason"]))?null:(System.String)dataRow["Reason"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.IssueLevel = (Convert.IsDBNull(dataRow["IssueLevel"]))?null:(System.Int32?)dataRow["IssueLevel"];
			entity.FromLevelId = (Convert.IsDBNull(dataRow["FromLevelId"]))?null:(System.Int32?)dataRow["FromLevelId"];
			entity.ToLevelId = (Convert.IsDBNull(dataRow["ToLevelId"]))?null:(System.Int32?)dataRow["ToLevelId"];
			entity.MoneyAmount = (Convert.IsDBNull(dataRow["MoneyAmount"]))?null:(System.Decimal?)dataRow["MoneyAmount"];
			entity.MoneyUnitId = (Convert.IsDBNull(dataRow["MoneyUnitId"]))?null:(System.Int32?)dataRow["MoneyUnitId"];
			entity.ExchangeRate = (Convert.IsDBNull(dataRow["ExchangeRate"]))?null:(System.Int32?)dataRow["ExchangeRate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Reward"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Reward Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Reward entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Reward object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Reward instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Reward Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Reward entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region RewardChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Reward</c>
	///</summary>
	public enum RewardChildEntityTypes
	{
	}
	
	#endregion RewardChildEntityTypes
	
	#region RewardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reward"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RewardFilterBuilder : SqlFilterBuilder<RewardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RewardFilterBuilder class.
		/// </summary>
		public RewardFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RewardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RewardFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RewardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RewardFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RewardFilterBuilder
	
	#region RewardParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reward"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RewardParameterBuilder : ParameterizedSqlFilterBuilder<RewardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RewardParameterBuilder class.
		/// </summary>
		public RewardParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RewardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RewardParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RewardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RewardParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RewardParameterBuilder
} // end namespace
