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
	/// This class is the base class for any <see cref="IdentificationInfomationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IdentificationInfomationProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.IdentificationInfomation, RLM.Construction.Entities.IdentificationInfomationKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.IdentificationInfomationKey key)
		{
			return Delete(transactionManager, key.IdentificationInfomationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="identificationInfomationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 identificationInfomationId)
		{
			return Delete(null, identificationInfomationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="identificationInfomationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 identificationInfomationId);		
		
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
		public override RLM.Construction.Entities.IdentificationInfomation Get(TransactionManager transactionManager, RLM.Construction.Entities.IdentificationInfomationKey key, int start, int pageLength)
		{
			return GetByIdentificationInfomationId(transactionManager, key.IdentificationInfomationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="identificationInfomationId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(System.Int32 identificationInfomationId)
		{
			int count = -1;
			return GetByIdentificationInfomationId(null,identificationInfomationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="identificationInfomationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(System.Int32 identificationInfomationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdentificationInfomationId(null, identificationInfomationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="identificationInfomationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(TransactionManager transactionManager, System.Int32 identificationInfomationId)
		{
			int count = -1;
			return GetByIdentificationInfomationId(transactionManager, identificationInfomationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="identificationInfomationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(TransactionManager transactionManager, System.Int32 identificationInfomationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIdentificationInfomationId(transactionManager, identificationInfomationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="identificationInfomationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(System.Int32 identificationInfomationId, int start, int pageLength, out int count)
		{
			return GetByIdentificationInfomationId(null, identificationInfomationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_IdentificationInfomation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="identificationInfomationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> class.</returns>
		public abstract RLM.Construction.Entities.IdentificationInfomation GetByIdentificationInfomationId(TransactionManager transactionManager, System.Int32 identificationInfomationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;IdentificationInfomation&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;IdentificationInfomation&gt;"/></returns>
		public static RLM.Construction.Entities.TList<IdentificationInfomation> Fill(IDataReader reader, RLM.Construction.Entities.TList<IdentificationInfomation> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.IdentificationInfomation c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"IdentificationInfomation" 
							+ (reader.IsDBNull(reader.GetOrdinal("IdentificationInfomationId"))?(int)0:(System.Int32)reader["IdentificationInfomationId"]).ToString();

					c = EntityManager.LocateOrCreate<IdentificationInfomation>(
						key.ToString(), // EntityTrackingKey 
						"IdentificationInfomation",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.IdentificationInfomation();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.IdentificationInfomationId = (System.Int32)reader["IdentificationInfomationId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.InfoType = (System.Int32)reader["InfoType"];
					c.CountryId = (reader.IsDBNull(reader.GetOrdinal("CountryId")))?null:(System.Int32?)reader["CountryId"];
					c.DistrictId = (reader.IsDBNull(reader.GetOrdinal("DistrictId")))?null:(System.Int32?)reader["DistrictId"];
					c.ExpiredDate = (reader.IsDBNull(reader.GetOrdinal("ExpiredDate")))?null:(System.DateTime?)reader["ExpiredDate"];
					c.Number = (reader.IsDBNull(reader.GetOrdinal("Number")))?null:(System.String)reader["Number"];
					c.IssuedProvinceId = (reader.IsDBNull(reader.GetOrdinal("IssuedProvinceId")))?null:(System.Int32?)reader["IssuedProvinceId"];
					c.IssuedDate = (reader.IsDBNull(reader.GetOrdinal("IssuedDate")))?null:(System.DateTime?)reader["IssuedDate"];
					c.IssuedPersonName = (reader.IsDBNull(reader.GetOrdinal("IssuedPersonName")))?null:(System.String)reader["IssuedPersonName"];
					c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.IdentificationInfomation"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.IdentificationInfomation entity)
		{
			if (!reader.Read()) return;
			
			entity.IdentificationInfomationId = (System.Int32)reader["IdentificationInfomationId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.InfoType = (System.Int32)reader["InfoType"];
			entity.CountryId = (reader.IsDBNull(reader.GetOrdinal("CountryId")))?null:(System.Int32?)reader["CountryId"];
			entity.DistrictId = (reader.IsDBNull(reader.GetOrdinal("DistrictId")))?null:(System.Int32?)reader["DistrictId"];
			entity.ExpiredDate = (reader.IsDBNull(reader.GetOrdinal("ExpiredDate")))?null:(System.DateTime?)reader["ExpiredDate"];
			entity.Number = (reader.IsDBNull(reader.GetOrdinal("Number")))?null:(System.String)reader["Number"];
			entity.IssuedProvinceId = (reader.IsDBNull(reader.GetOrdinal("IssuedProvinceId")))?null:(System.Int32?)reader["IssuedProvinceId"];
			entity.IssuedDate = (reader.IsDBNull(reader.GetOrdinal("IssuedDate")))?null:(System.DateTime?)reader["IssuedDate"];
			entity.IssuedPersonName = (reader.IsDBNull(reader.GetOrdinal("IssuedPersonName")))?null:(System.String)reader["IssuedPersonName"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.IdentificationInfomation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.IdentificationInfomation"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.IdentificationInfomation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdentificationInfomationId = (System.Int32)dataRow["IdentificationInfomationId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.InfoType = (System.Int32)dataRow["InfoType"];
			entity.CountryId = (Convert.IsDBNull(dataRow["CountryId"]))?null:(System.Int32?)dataRow["CountryId"];
			entity.DistrictId = (Convert.IsDBNull(dataRow["DistrictId"]))?null:(System.Int32?)dataRow["DistrictId"];
			entity.ExpiredDate = (Convert.IsDBNull(dataRow["ExpiredDate"]))?null:(System.DateTime?)dataRow["ExpiredDate"];
			entity.Number = (Convert.IsDBNull(dataRow["Number"]))?null:(System.String)dataRow["Number"];
			entity.IssuedProvinceId = (Convert.IsDBNull(dataRow["IssuedProvinceId"]))?null:(System.Int32?)dataRow["IssuedProvinceId"];
			entity.IssuedDate = (Convert.IsDBNull(dataRow["IssuedDate"]))?null:(System.DateTime?)dataRow["IssuedDate"];
			entity.IssuedPersonName = (Convert.IsDBNull(dataRow["IssuedPersonName"]))?null:(System.String)dataRow["IssuedPersonName"];
			entity.Comment = (Convert.IsDBNull(dataRow["Comment"]))?null:(System.String)dataRow["Comment"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.IdentificationInfomation"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.IdentificationInfomation Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.IdentificationInfomation entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.IdentificationInfomation object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.IdentificationInfomation instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.IdentificationInfomation Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.IdentificationInfomation entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region IdentificationInfomationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.IdentificationInfomation</c>
	///</summary>
	public enum IdentificationInfomationChildEntityTypes
	{
	}
	
	#endregion IdentificationInfomationChildEntityTypes
	
	#region IdentificationInfomationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IdentificationInfomation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IdentificationInfomationFilterBuilder : SqlFilterBuilder<IdentificationInfomationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationFilterBuilder class.
		/// </summary>
		public IdentificationInfomationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IdentificationInfomationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IdentificationInfomationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IdentificationInfomationFilterBuilder
	
	#region IdentificationInfomationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IdentificationInfomation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IdentificationInfomationParameterBuilder : ParameterizedSqlFilterBuilder<IdentificationInfomationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationParameterBuilder class.
		/// </summary>
		public IdentificationInfomationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IdentificationInfomationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IdentificationInfomationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IdentificationInfomationParameterBuilder
} // end namespace
