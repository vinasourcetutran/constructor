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
	/// This class is the base class for any <see cref="ItemIOTicketProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemIOTicketProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.ItemIOTicket, RLM.Construction.Entities.ItemIOTicketKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOTicketKey key)
		{
			return Delete(transactionManager, key.IOTicketId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="iOTicketId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 iOTicketId)
		{
			return Delete(null, iOTicketId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iOTicketId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 iOTicketId);		
		
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
		public override RLM.Construction.Entities.ItemIOTicket Get(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOTicketKey key, int start, int pageLength)
		{
			return GetByIOTicketId(transactionManager, key.IOTicketId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemIOTicket index.
		/// </summary>
		/// <param name="iOTicketId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(System.Int32 iOTicketId)
		{
			int count = -1;
			return GetByIOTicketId(null,iOTicketId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOTicket index.
		/// </summary>
		/// <param name="iOTicketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(System.Int32 iOTicketId, int start, int pageLength)
		{
			int count = -1;
			return GetByIOTicketId(null, iOTicketId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOTicket index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iOTicketId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(TransactionManager transactionManager, System.Int32 iOTicketId)
		{
			int count = -1;
			return GetByIOTicketId(transactionManager, iOTicketId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOTicket index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iOTicketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(TransactionManager transactionManager, System.Int32 iOTicketId, int start, int pageLength)
		{
			int count = -1;
			return GetByIOTicketId(transactionManager, iOTicketId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOTicket index.
		/// </summary>
		/// <param name="iOTicketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(System.Int32 iOTicketId, int start, int pageLength, out int count)
		{
			return GetByIOTicketId(null, iOTicketId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemIOTicket index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="iOTicketId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.ItemIOTicket"/> class.</returns>
		public abstract RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(TransactionManager transactionManager, System.Int32 iOTicketId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;ItemIOTicket&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;ItemIOTicket&gt;"/></returns>
		public static RLM.Construction.Entities.TList<ItemIOTicket> Fill(IDataReader reader, RLM.Construction.Entities.TList<ItemIOTicket> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.ItemIOTicket c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ItemIOTicket" 
							+ (reader.IsDBNull(reader.GetOrdinal("IOTicketId"))?(int)0:(System.Int32)reader["IOTicketId"]).ToString();

					c = EntityManager.LocateOrCreate<ItemIOTicket>(
						key.ToString(), // EntityTrackingKey 
						"ItemIOTicket",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.ItemIOTicket();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.IOTicketId = (System.Int32)reader["IOTicketId"];
					c.TicketId = (System.String)reader["TicketId"];
					c.RelatedTicketId = (reader.IsDBNull(reader.GetOrdinal("RelatedTicketId")))?null:(System.Int32?)reader["RelatedTicketId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Receiver = (reader.IsDBNull(reader.GetOrdinal("Receiver")))?null:(System.String)reader["Receiver"];
					c.Sender = (reader.IsDBNull(reader.GetOrdinal("Sender")))?null:(System.String)reader["Sender"];
					c.ProjectId = (reader.IsDBNull(reader.GetOrdinal("ProjectId")))?null:(System.Int32?)reader["ProjectId"];
					c.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
					c.IODate = (reader.IsDBNull(reader.GetOrdinal("IODate")))?null:(System.DateTime?)reader["IODate"];
					c.TaxPercent = (reader.IsDBNull(reader.GetOrdinal("TaxPercent")))?null:(System.Double?)reader["TaxPercent"];
					c.TotalAmount = (reader.IsDBNull(reader.GetOrdinal("TotalAmount")))?null:(System.Decimal?)reader["TotalAmount"];
					c.UnitId = (reader.IsDBNull(reader.GetOrdinal("UnitId")))?null:(System.Int32?)reader["UnitId"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
					c.IOType = (reader.IsDBNull(reader.GetOrdinal("IOType")))?null:(System.Int32?)reader["IOType"];
					c.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
					c.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
					c.FromStaffId = (reader.IsDBNull(reader.GetOrdinal("FromStaffId")))?null:(System.Int32?)reader["FromStaffId"];
					c.ToStaffId = (reader.IsDBNull(reader.GetOrdinal("ToStaffId")))?null:(System.Int32?)reader["ToStaffId"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.IsNeedApproved = (reader.IsDBNull(reader.GetOrdinal("IsNeedApproved")))?null:(System.Boolean?)reader["IsNeedApproved"];
					c.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
					c.ApproverUserId = (reader.IsDBNull(reader.GetOrdinal("ApproverUserId")))?null:(System.Int32?)reader["ApproverUserId"];
					c.ApproverStaffId = (reader.IsDBNull(reader.GetOrdinal("ApproverStaffId")))?null:(System.Int32?)reader["ApproverStaffId"];
					c.ApprovedDate = (reader.IsDBNull(reader.GetOrdinal("ApprovedDate")))?null:(System.DateTime?)reader["ApprovedDate"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemIOTicket"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOTicket"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.ItemIOTicket entity)
		{
			if (!reader.Read()) return;
			
			entity.IOTicketId = (System.Int32)reader["IOTicketId"];
			entity.TicketId = (System.String)reader["TicketId"];
			entity.RelatedTicketId = (reader.IsDBNull(reader.GetOrdinal("RelatedTicketId")))?null:(System.Int32?)reader["RelatedTicketId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Receiver = (reader.IsDBNull(reader.GetOrdinal("Receiver")))?null:(System.String)reader["Receiver"];
			entity.Sender = (reader.IsDBNull(reader.GetOrdinal("Sender")))?null:(System.String)reader["Sender"];
			entity.ProjectId = (reader.IsDBNull(reader.GetOrdinal("ProjectId")))?null:(System.Int32?)reader["ProjectId"];
			entity.ProjectPhaseId = (reader.IsDBNull(reader.GetOrdinal("ProjectPhaseId")))?null:(System.Int32?)reader["ProjectPhaseId"];
			entity.IODate = (reader.IsDBNull(reader.GetOrdinal("IODate")))?null:(System.DateTime?)reader["IODate"];
			entity.TaxPercent = (reader.IsDBNull(reader.GetOrdinal("TaxPercent")))?null:(System.Double?)reader["TaxPercent"];
			entity.TotalAmount = (reader.IsDBNull(reader.GetOrdinal("TotalAmount")))?null:(System.Decimal?)reader["TotalAmount"];
			entity.UnitId = (reader.IsDBNull(reader.GetOrdinal("UnitId")))?null:(System.Int32?)reader["UnitId"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.Status = (reader.IsDBNull(reader.GetOrdinal("Status")))?null:(System.Int32?)reader["Status"];
			entity.IOType = (reader.IsDBNull(reader.GetOrdinal("IOType")))?null:(System.Int32?)reader["IOType"];
			entity.FromRepositoryId = (reader.IsDBNull(reader.GetOrdinal("FromRepositoryId")))?null:(System.Int32?)reader["FromRepositoryId"];
			entity.ToRepositoryId = (reader.IsDBNull(reader.GetOrdinal("ToRepositoryId")))?null:(System.Int32?)reader["ToRepositoryId"];
			entity.FromStaffId = (reader.IsDBNull(reader.GetOrdinal("FromStaffId")))?null:(System.Int32?)reader["FromStaffId"];
			entity.ToStaffId = (reader.IsDBNull(reader.GetOrdinal("ToStaffId")))?null:(System.Int32?)reader["ToStaffId"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.IsNeedApproved = (reader.IsDBNull(reader.GetOrdinal("IsNeedApproved")))?null:(System.Boolean?)reader["IsNeedApproved"];
			entity.IsApproved = (reader.IsDBNull(reader.GetOrdinal("IsApproved")))?null:(System.Boolean?)reader["IsApproved"];
			entity.ApproverUserId = (reader.IsDBNull(reader.GetOrdinal("ApproverUserId")))?null:(System.Int32?)reader["ApproverUserId"];
			entity.ApproverStaffId = (reader.IsDBNull(reader.GetOrdinal("ApproverStaffId")))?null:(System.Int32?)reader["ApproverStaffId"];
			entity.ApprovedDate = (reader.IsDBNull(reader.GetOrdinal("ApprovedDate")))?null:(System.DateTime?)reader["ApprovedDate"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.ItemIOTicket"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOTicket"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.ItemIOTicket entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IOTicketId = (System.Int32)dataRow["IOTicketId"];
			entity.TicketId = (System.String)dataRow["TicketId"];
			entity.RelatedTicketId = (Convert.IsDBNull(dataRow["RelatedTicketId"]))?null:(System.Int32?)dataRow["RelatedTicketId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Receiver = (Convert.IsDBNull(dataRow["Receiver"]))?null:(System.String)dataRow["Receiver"];
			entity.Sender = (Convert.IsDBNull(dataRow["Sender"]))?null:(System.String)dataRow["Sender"];
			entity.ProjectId = (Convert.IsDBNull(dataRow["ProjectId"]))?null:(System.Int32?)dataRow["ProjectId"];
			entity.ProjectPhaseId = (Convert.IsDBNull(dataRow["ProjectPhaseId"]))?null:(System.Int32?)dataRow["ProjectPhaseId"];
			entity.IODate = (Convert.IsDBNull(dataRow["IODate"]))?null:(System.DateTime?)dataRow["IODate"];
			entity.TaxPercent = (Convert.IsDBNull(dataRow["TaxPercent"]))?null:(System.Double?)dataRow["TaxPercent"];
			entity.TotalAmount = (Convert.IsDBNull(dataRow["TotalAmount"]))?null:(System.Decimal?)dataRow["TotalAmount"];
			entity.UnitId = (Convert.IsDBNull(dataRow["UnitId"]))?null:(System.Int32?)dataRow["UnitId"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.Status = (Convert.IsDBNull(dataRow["Status"]))?null:(System.Int32?)dataRow["Status"];
			entity.IOType = (Convert.IsDBNull(dataRow["IOType"]))?null:(System.Int32?)dataRow["IOType"];
			entity.FromRepositoryId = (Convert.IsDBNull(dataRow["FromRepositoryId"]))?null:(System.Int32?)dataRow["FromRepositoryId"];
			entity.ToRepositoryId = (Convert.IsDBNull(dataRow["ToRepositoryId"]))?null:(System.Int32?)dataRow["ToRepositoryId"];
			entity.FromStaffId = (Convert.IsDBNull(dataRow["FromStaffId"]))?null:(System.Int32?)dataRow["FromStaffId"];
			entity.ToStaffId = (Convert.IsDBNull(dataRow["ToStaffId"]))?null:(System.Int32?)dataRow["ToStaffId"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.IsNeedApproved = (Convert.IsDBNull(dataRow["IsNeedApproved"]))?null:(System.Boolean?)dataRow["IsNeedApproved"];
			entity.IsApproved = (Convert.IsDBNull(dataRow["IsApproved"]))?null:(System.Boolean?)dataRow["IsApproved"];
			entity.ApproverUserId = (Convert.IsDBNull(dataRow["ApproverUserId"]))?null:(System.Int32?)dataRow["ApproverUserId"];
			entity.ApproverStaffId = (Convert.IsDBNull(dataRow["ApproverStaffId"]))?null:(System.Int32?)dataRow["ApproverStaffId"];
			entity.ApprovedDate = (Convert.IsDBNull(dataRow["ApprovedDate"]))?null:(System.DateTime?)dataRow["ApprovedDate"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.ItemIOTicket"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemIOTicket Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOTicket entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.ItemIOTicket object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.ItemIOTicket instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.ItemIOTicket Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.ItemIOTicket entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region ItemIOTicketChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.ItemIOTicket</c>
	///</summary>
	public enum ItemIOTicketChildEntityTypes
	{
	}
	
	#endregion ItemIOTicketChildEntityTypes
	
	#region ItemIOTicketFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOTicket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOTicketFilterBuilder : SqlFilterBuilder<ItemIOTicketColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketFilterBuilder class.
		/// </summary>
		public ItemIOTicketFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemIOTicketFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemIOTicketFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemIOTicketFilterBuilder
	
	#region ItemIOTicketParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOTicket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOTicketParameterBuilder : ParameterizedSqlFilterBuilder<ItemIOTicketColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketParameterBuilder class.
		/// </summary>
		public ItemIOTicketParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemIOTicketParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemIOTicketParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemIOTicketParameterBuilder
} // end namespace
