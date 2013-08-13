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
	/// This class is the base class for any <see cref="ItemIOItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemIOItemProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemIOItem, RLM.Construction.Entities.ItemIOItemKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOItemKey key)
		{
			return Delete(transactionManager, key.ItemIOItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="itemIOItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 itemIOItemId)
		{
			return Delete(null, itemIOItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemIOItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 itemIOItemId);		
		
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
		public override RLM.Construction.Entities.ItemIOItem Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOItemKey key, int start, int pageLength)
		{
			return GetByItemIOItemId(transactionManager, key.ItemIOItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemIOItem index.
		/// </summary>
		/// <param name="itemIOItemId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(System.Int32 itemIOItemId)
		{
			int count = -1;
			return GetByItemIOItemId(null,itemIOItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOItem index.
		/// </summary>
		/// <param name="itemIOItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(System.Int32 itemIOItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIOItemId(null, itemIOItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemIOItemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(TransactionManager transactionManager, System.Int32 itemIOItemId)
		{
			int count = -1;
			return GetByItemIOItemId(transactionManager, itemIOItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemIOItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(TransactionManager transactionManager, System.Int32 itemIOItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemIOItemId(transactionManager, itemIOItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOItem index.
		/// </summary>
		/// <param name="itemIOItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(System.Int32 itemIOItemId, int start, int pageLength, out int count)
		{
			return GetByItemIOItemId(null, itemIOItemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOItem index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemIOItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOItem"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemIOItem GetByItemIOItemId(TransactionManager transactionManager, System.Int32 itemIOItemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemIOItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemIOItem&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemIOItem> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemIOItem> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ItemIOItem c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemIOItem" 
							+ (reader.IsDBNull(reader.GetOrdinal("ItemIOItemId"))?(int)0:(System.Int32)reader["ItemIOItemId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemIOItem>(
						key.ToString(), // EntityTrackingKey 
						"ItemIOItem",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemIOItem();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ItemIOItemId = (System.Int32)reader["ItemIOItemId"];
					c.IOTicketId = (System.Int32)reader["IOTicketId"];
					c.ItemId = (System.Int32)reader["ItemId"];
					c.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
					c.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
					c.UnitPrice = (System.Decimal)reader["UnitPrice"];
					c.PriceUnitId = (System.Int32)reader["PriceUnitId"];
					c.ExchangeRate = (System.Int32)reader["ExchangeRate"];
					c.UnitId = (System.Int32)reader["UnitId"];
					c.Quantity = (System.Double)reader["Quantity"];
					c.TaxPercent = (reader.IsDBNull(reader.GetOrdinal("TaxPercent")))?null:(System.Double?)reader["TaxPercent"];
					c.IOType = (System.Int32)reader["IOType"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsNeedAppred = (reader.IsDBNull(reader.GetOrdinal("IsNeedAppred")))?null:(System.Boolean?)reader["IsNeedAppred"];
					c.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
					c.ApprovedDate = (reader.IsDBNull(reader.GetOrdinal("ApprovedDate")))?null:(System.DateTime?)reader["ApprovedDate"];
					c.ApproverUserId = (reader.IsDBNull(reader.GetOrdinal("ApproverUserId")))?null:(System.Int32?)reader["ApproverUserId"];
					c.ApproverStaffId = (reader.IsDBNull(reader.GetOrdinal("ApproverStaffId")))?null:(System.Int32?)reader["ApproverStaffId"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
					c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
					c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemIOItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemIOItem entity)
		{
			if (!reader.Read()) return;
			
			entity.ItemIOItemId = (System.Int32)reader["ItemIOItemId"];
			entity.IOTicketId = (System.Int32)reader["IOTicketId"];
			entity.ItemId = (System.Int32)reader["ItemId"];
			entity.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
			entity.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
			entity.UnitPrice = (System.Decimal)reader["UnitPrice"];
			entity.PriceUnitId = (System.Int32)reader["PriceUnitId"];
			entity.ExchangeRate = (System.Int32)reader["ExchangeRate"];
			entity.UnitId = (System.Int32)reader["UnitId"];
			entity.Quantity = (System.Double)reader["Quantity"];
			entity.TaxPercent = (reader.IsDBNull(reader.GetOrdinal("TaxPercent")))?null:(System.Double?)reader["TaxPercent"];
			entity.IOType = (System.Int32)reader["IOType"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsNeedAppred = (reader.IsDBNull(reader.GetOrdinal("IsNeedAppred")))?null:(System.Boolean?)reader["IsNeedAppred"];
			entity.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
			entity.ApprovedDate = (reader.IsDBNull(reader.GetOrdinal("ApprovedDate")))?null:(System.DateTime?)reader["ApprovedDate"];
			entity.ApproverUserId = (reader.IsDBNull(reader.GetOrdinal("ApproverUserId")))?null:(System.Int32?)reader["ApproverUserId"];
			entity.ApproverStaffId = (reader.IsDBNull(reader.GetOrdinal("ApproverStaffId")))?null:(System.Int32?)reader["ApproverStaffId"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemIOItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemIOItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ItemIOItemId = (System.Int32)dataRow["ItemIOItemId"];
			entity.IOTicketId = (System.Int32)dataRow["IOTicketId"];
			entity.ItemId = (System.Int32)dataRow["ItemId"];
			entity.ToRepositoryId = (Convert.IsDBNull(dataRow["ToRepositoryId"]))?null:(System.Int32?)dataRow["ToRepositoryId"];
			entity.FromRepositoryId = (Convert.IsDBNull(dataRow["FromRepositoryId"]))?null:(System.Int32?)dataRow["FromRepositoryId"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
			entity.PriceUnitId = (System.Int32)dataRow["PriceUnitId"];
			entity.ExchangeRate = (System.Int32)dataRow["ExchangeRate"];
			entity.UnitId = (System.Int32)dataRow["UnitId"];
			entity.Quantity = (System.Double)dataRow["Quantity"];
			entity.TaxPercent = (Convert.IsDBNull(dataRow["TaxPercent"]))?null:(System.Double?)dataRow["TaxPercent"];
			entity.IOType = (System.Int32)dataRow["IOType"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsNeedAppred = (Convert.IsDBNull(dataRow["IsNeedAppred"]))?null:(System.Boolean?)dataRow["IsNeedAppred"];
			entity.IsApproved = (Convert.IsDBNull(dataRow["IsApproved"]))?null:(System.Boolean?)dataRow["IsApproved"];
			entity.ApprovedDate = (Convert.IsDBNull(dataRow["ApprovedDate"]))?null:(System.DateTime?)dataRow["ApprovedDate"];
			entity.ApproverUserId = (Convert.IsDBNull(dataRow["ApproverUserId"]))?null:(System.Int32?)dataRow["ApproverUserId"];
			entity.ApproverStaffId = (Convert.IsDBNull(dataRow["ApproverStaffId"]))?null:(System.Int32?)dataRow["ApproverStaffId"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.CreationDate = (Convert.IsDBNull(dataRow["CreationDate"]))?null:(System.DateTime?)dataRow["CreationDate"];
			entity.LastModificationDate = (Convert.IsDBNull(dataRow["LastModificationDate"]))?null:(System.DateTime?)dataRow["LastModificationDate"];
			entity.CreationUserId = (Convert.IsDBNull(dataRow["CreationUserId"]))?null:(System.Int32?)dataRow["CreationUserId"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemIOItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemIOItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemIOItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemIOItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region ItemIOItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemIOItem</c>
	///</summary>
	public enum ItemIOItemChildEntityTypes
	{
	}
	
	#endregion ItemIOItemChildEntityTypes
	
	#region ItemIOItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOItemFilterBuilder : SqlFilterBuilder<ItemIOItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOItemFilterBuilder class.
		/// </summary>
		public ItemIOItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemIOItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemIOItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemIOItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemIOItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemIOItemFilterBuilder
	
	#region ItemIOItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOItemParameterBuilder : ParameterizedSqlFilterBuilder<ItemIOItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOItemParameterBuilder class.
		/// </summary>
		public ItemIOItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemIOItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemIOItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemIOItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemIOItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemIOItemParameterBuilder
} // end namespace
