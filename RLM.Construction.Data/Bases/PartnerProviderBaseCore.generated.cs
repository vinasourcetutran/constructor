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
	/// This class is the base class for any <see cref="PartnerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PartnerProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Partner, RLM.Construction.Entities.PartnerKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.PartnerKey key)
		{
			return Delete(transactionManager, key.PartnerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="partnerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 partnerId)
		{
			return Delete(null, partnerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="partnerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 partnerId);		
		
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
		public override RLM.Construction.Entities.Partner Get(TransactionManager transactionManager, RLM.Construction.Entities.PartnerKey key, int start, int pageLength)
		{
			return GetByPartnerId(transactionManager, key.PartnerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Departments index.
		/// </summary>
		/// <param name="partnerId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public RLM.Construction.Entities.Partner GetByPartnerId(System.Int32 partnerId)
		{
			int count = -1;
			return GetByPartnerId(null,partnerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public RLM.Construction.Entities.Partner GetByPartnerId(System.Int32 partnerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPartnerId(null, partnerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="partnerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public RLM.Construction.Entities.Partner GetByPartnerId(TransactionManager transactionManager, System.Int32 partnerId)
		{
			int count = -1;
			return GetByPartnerId(transactionManager, partnerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public RLM.Construction.Entities.Partner GetByPartnerId(TransactionManager transactionManager, System.Int32 partnerId, int start, int pageLength)
		{
			int count = -1;
			return GetByPartnerId(transactionManager, partnerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public RLM.Construction.Entities.Partner GetByPartnerId(System.Int32 partnerId, int start, int pageLength, out int count)
		{
			return GetByPartnerId(null, partnerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="partnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Partner"/> class.</returns>
		public abstract RLM.Construction.Entities.Partner GetByPartnerId(TransactionManager transactionManager, System.Int32 partnerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Partner&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Partner&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Partner> Fill(IDataReader reader, RLM.Construction.Entities.TList<Partner> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Partner c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Partner" 
							+ (reader.IsDBNull(reader.GetOrdinal("PartnerId"))?(int)0:(System.Int32)reader["PartnerId"]).ToString();

					c = EntityManager.LocateOrCreate<Partner>(
						key.ToString(), // EntityTrackingKey 
						"Partner",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Partner();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.PartnerId = (System.Int32)reader["PartnerId"];
					c.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
					c.ContactorId = (reader.IsDBNull(reader.GetOrdinal("ContactorId")))?null:(System.Int32?)reader["ContactorId"];
					c.RepresentatorId = (reader.IsDBNull(reader.GetOrdinal("RepresentatorId")))?null:(System.Int32?)reader["RepresentatorId"];
					c.ContactName = (reader.IsDBNull(reader.GetOrdinal("ContactName")))?null:(System.String)reader["ContactName"];
					c.RepresentativeName = (reader.IsDBNull(reader.GetOrdinal("RepresentativeName")))?null:(System.String)reader["RepresentativeName"];
					c.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
					c.Name = (System.String)reader["Name"];
					c.NameInEng = (reader.IsDBNull(reader.GetOrdinal("NameInEng")))?null:(System.String)reader["NameInEng"];
					c.TaxCode = (reader.IsDBNull(reader.GetOrdinal("TaxCode")))?null:(System.String)reader["TaxCode"];
					c.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
					c.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
					c.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
					c.Email = (reader.IsDBNull(reader.GetOrdinal("Email")))?null:(System.String)reader["Email"];
					c.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
					c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
					c.Website = (reader.IsDBNull(reader.GetOrdinal("Website")))?null:(System.String)reader["Website"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Partner"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Partner"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Partner entity)
		{
			if (!reader.Read()) return;
			
			entity.PartnerId = (System.Int32)reader["PartnerId"];
			entity.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId")))?null:(System.Int32?)reader["GroupId"];
			entity.ContactorId = (reader.IsDBNull(reader.GetOrdinal("ContactorId")))?null:(System.Int32?)reader["ContactorId"];
			entity.RepresentatorId = (reader.IsDBNull(reader.GetOrdinal("RepresentatorId")))?null:(System.Int32?)reader["RepresentatorId"];
			entity.ContactName = (reader.IsDBNull(reader.GetOrdinal("ContactName")))?null:(System.String)reader["ContactName"];
			entity.RepresentativeName = (reader.IsDBNull(reader.GetOrdinal("RepresentativeName")))?null:(System.String)reader["RepresentativeName"];
			entity.Code = (reader.IsDBNull(reader.GetOrdinal("Code")))?null:(System.String)reader["Code"];
			entity.Name = (System.String)reader["Name"];
			entity.NameInEng = (reader.IsDBNull(reader.GetOrdinal("NameInEng")))?null:(System.String)reader["NameInEng"];
			entity.TaxCode = (reader.IsDBNull(reader.GetOrdinal("TaxCode")))?null:(System.String)reader["TaxCode"];
			entity.Priority = (reader.IsDBNull(reader.GetOrdinal("Priority")))?null:(System.Int32?)reader["Priority"];
			entity.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
			entity.Email = (reader.IsDBNull(reader.GetOrdinal("Email")))?null:(System.String)reader["Email"];
			entity.IsDeletable = (reader.IsDBNull(reader.GetOrdinal("IsDeletable")))?null:(System.Boolean?)reader["IsDeletable"];
			entity.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive")))?null:(System.Boolean?)reader["IsActive"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.Website = (reader.IsDBNull(reader.GetOrdinal("Website")))?null:(System.String)reader["Website"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Partner"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Partner"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Partner entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PartnerId = (System.Int32)dataRow["PartnerId"];
			entity.GroupId = (Convert.IsDBNull(dataRow["GroupId"]))?null:(System.Int32?)dataRow["GroupId"];
			entity.ContactorId = (Convert.IsDBNull(dataRow["ContactorId"]))?null:(System.Int32?)dataRow["ContactorId"];
			entity.RepresentatorId = (Convert.IsDBNull(dataRow["RepresentatorId"]))?null:(System.Int32?)dataRow["RepresentatorId"];
			entity.ContactName = (Convert.IsDBNull(dataRow["ContactName"]))?null:(System.String)dataRow["ContactName"];
			entity.RepresentativeName = (Convert.IsDBNull(dataRow["RepresentativeName"]))?null:(System.String)dataRow["RepresentativeName"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?null:(System.String)dataRow["Code"];
			entity.Name = (System.String)dataRow["Name"];
			entity.NameInEng = (Convert.IsDBNull(dataRow["NameInEng"]))?null:(System.String)dataRow["NameInEng"];
			entity.TaxCode = (Convert.IsDBNull(dataRow["TaxCode"]))?null:(System.String)dataRow["TaxCode"];
			entity.Priority = (Convert.IsDBNull(dataRow["Priority"]))?null:(System.Int32?)dataRow["Priority"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?null:(System.String)dataRow["Address"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
			entity.Fax = (Convert.IsDBNull(dataRow["Fax"]))?null:(System.String)dataRow["Fax"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?null:(System.String)dataRow["Email"];
			entity.IsDeletable = (Convert.IsDBNull(dataRow["IsDeletable"]))?null:(System.Boolean?)dataRow["IsDeletable"];
			entity.IsActive = (Convert.IsDBNull(dataRow["IsActive"]))?null:(System.Boolean?)dataRow["IsActive"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
			entity.Website = (Convert.IsDBNull(dataRow["Website"]))?null:(System.String)dataRow["Website"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Partner"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Partner Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Partner entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Partner object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Partner instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Partner Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Partner entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region PartnerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Partner</c>
	///</summary>
	public enum PartnerChildEntityTypes
	{
	}
	
	#endregion PartnerChildEntityTypes
	
	#region PartnerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerFilterBuilder : SqlFilterBuilder<PartnerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		public PartnerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerFilterBuilder
	
	#region PartnerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Partner"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PartnerParameterBuilder : ParameterizedSqlFilterBuilder<PartnerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		public PartnerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PartnerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PartnerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PartnerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PartnerParameterBuilder
} // end namespace
