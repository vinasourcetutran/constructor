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
	/// This class is the base class for any <see cref="FamilyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FamilyProviderBaseCore : EntityProviderBase<RLM.Construction.Entities.Family, RLM.Construction.Entities.FamilyKey>
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
		public override bool Delete(TransactionManager transactionManager, RLM.Construction.Entities.FamilyKey key)
		{
			return Delete(transactionManager, key.FamilyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="familyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 familyId)
		{
			return Delete(null, familyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="familyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 familyId);		
		
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
		public override RLM.Construction.Entities.Family Get(TransactionManager transactionManager, RLM.Construction.Entities.FamilyKey key, int start, int pageLength)
		{
			return GetByFamilyId(transactionManager, key.FamilyId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Family index.
		/// </summary>
		/// <param name="familyId"></param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public RLM.Construction.Entities.Family GetByFamilyId(System.Int32 familyId)
		{
			int count = -1;
			return GetByFamilyId(null,familyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Family index.
		/// </summary>
		/// <param name="familyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public RLM.Construction.Entities.Family GetByFamilyId(System.Int32 familyId, int start, int pageLength)
		{
			int count = -1;
			return GetByFamilyId(null, familyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Family index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="familyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public RLM.Construction.Entities.Family GetByFamilyId(TransactionManager transactionManager, System.Int32 familyId)
		{
			int count = -1;
			return GetByFamilyId(transactionManager, familyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Family index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="familyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public RLM.Construction.Entities.Family GetByFamilyId(TransactionManager transactionManager, System.Int32 familyId, int start, int pageLength)
		{
			int count = -1;
			return GetByFamilyId(transactionManager, familyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Family index.
		/// </summary>
		/// <param name="familyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public RLM.Construction.Entities.Family GetByFamilyId(System.Int32 familyId, int start, int pageLength, out int count)
		{
			return GetByFamilyId(null, familyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Family index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="familyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="RLM.Construction.Entities.Family"/> class.</returns>
		public abstract RLM.Construction.Entities.Family GetByFamilyId(TransactionManager transactionManager, System.Int32 familyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a RLM.Construction.Entities.TList&lt;Family&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="RLM.Construction.Entities.TList&lt;Family&gt;"/></returns>
		public static RLM.Construction.Entities.TList<Family> Fill(IDataReader reader, RLM.Construction.Entities.TList<Family> rows, int start, int pageLength)
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
				
				RLM.Construction.Entities.Family c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Family" 
							+ (reader.IsDBNull(reader.GetOrdinal("FamilyId"))?(int)0:(System.Int32)reader["FamilyId"]).ToString();

					c = EntityManager.LocateOrCreate<Family>(
						key.ToString(), // EntityTrackingKey 
						"Family",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new RLM.Construction.Entities.Family();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.FamilyId = (System.Int32)reader["FamilyId"];
					c.StaffId = (System.Int32)reader["StaffId"];
					c.FamilySideType = (System.Int32)reader["FamilySideType"];
					c.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
					c.LastName = (System.String)reader["LastName"];
					c.BirthDate = (reader.IsDBNull(reader.GetOrdinal("BirthDate")))?null:(System.DateTime?)reader["BirthDate"];
					c.CardIdNumber = (reader.IsDBNull(reader.GetOrdinal("CardIdNumber")))?null:(System.String)reader["CardIdNumber"];
					c.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
					c.Mobile = (reader.IsDBNull(reader.GetOrdinal("Mobile")))?null:(System.String)reader["Mobile"];
					c.Sex = (reader.IsDBNull(reader.GetOrdinal("Sex")))?null:(System.Int32?)reader["Sex"];
					c.IsTheSameCompany = (reader.IsDBNull(reader.GetOrdinal("IsTheSameCompany")))?null:(System.Boolean?)reader["IsTheSameCompany"];
					c.IsDepend = (reader.IsDBNull(reader.GetOrdinal("IsDepend")))?null:(System.Boolean?)reader["IsDepend"];
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
		/// Refreshes the <see cref="RLM.Construction.Entities.Family"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Family"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, RLM.Construction.Entities.Family entity)
		{
			if (!reader.Read()) return;
			
			entity.FamilyId = (System.Int32)reader["FamilyId"];
			entity.StaffId = (System.Int32)reader["StaffId"];
			entity.FamilySideType = (System.Int32)reader["FamilySideType"];
			entity.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader["LastName"];
			entity.BirthDate = (reader.IsDBNull(reader.GetOrdinal("BirthDate")))?null:(System.DateTime?)reader["BirthDate"];
			entity.CardIdNumber = (reader.IsDBNull(reader.GetOrdinal("CardIdNumber")))?null:(System.String)reader["CardIdNumber"];
			entity.Address = (reader.IsDBNull(reader.GetOrdinal("Address")))?null:(System.String)reader["Address"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.Mobile = (reader.IsDBNull(reader.GetOrdinal("Mobile")))?null:(System.String)reader["Mobile"];
			entity.Sex = (reader.IsDBNull(reader.GetOrdinal("Sex")))?null:(System.Int32?)reader["Sex"];
			entity.IsTheSameCompany = (reader.IsDBNull(reader.GetOrdinal("IsTheSameCompany")))?null:(System.Boolean?)reader["IsTheSameCompany"];
			entity.IsDepend = (reader.IsDBNull(reader.GetOrdinal("IsDepend")))?null:(System.Boolean?)reader["IsDepend"];
			entity.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment")))?null:(System.String)reader["Comment"];
			entity.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate")))?null:(System.DateTime?)reader["CreationDate"];
			entity.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId")))?null:(System.Int32?)reader["CreationUserId"];
			entity.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate")))?null:(System.DateTime?)reader["LastModificationDate"];
			entity.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId")))?null:(System.Int32?)reader["LastModificationUserId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="RLM.Construction.Entities.Family"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Family"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, RLM.Construction.Entities.Family entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FamilyId = (System.Int32)dataRow["FamilyId"];
			entity.StaffId = (System.Int32)dataRow["StaffId"];
			entity.FamilySideType = (System.Int32)dataRow["FamilySideType"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?null:(System.String)dataRow["FirstName"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.BirthDate = (Convert.IsDBNull(dataRow["BirthDate"]))?null:(System.DateTime?)dataRow["BirthDate"];
			entity.CardIdNumber = (Convert.IsDBNull(dataRow["CardIdNumber"]))?null:(System.String)dataRow["CardIdNumber"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?null:(System.String)dataRow["Address"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
			entity.Mobile = (Convert.IsDBNull(dataRow["Mobile"]))?null:(System.String)dataRow["Mobile"];
			entity.Sex = (Convert.IsDBNull(dataRow["Sex"]))?null:(System.Int32?)dataRow["Sex"];
			entity.IsTheSameCompany = (Convert.IsDBNull(dataRow["IsTheSameCompany"]))?null:(System.Boolean?)dataRow["IsTheSameCompany"];
			entity.IsDepend = (Convert.IsDBNull(dataRow["IsDepend"]))?null:(System.Boolean?)dataRow["IsDepend"];
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
		/// <param name="entity">The <see cref="RLM.Construction.Entities.Family"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Family Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, RLM.Construction.Entities.Family entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the RLM.Construction.Entities.Family object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">RLM.Construction.Entities.Family instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">RLM.Construction.Entities.Family Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, RLM.Construction.Entities.Family entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
	
	#region FamilyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>RLM.Construction.Entities.Family</c>
	///</summary>
	public enum FamilyChildEntityTypes
	{
	}
	
	#endregion FamilyChildEntityTypes
	
	#region FamilyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Family"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FamilyFilterBuilder : SqlFilterBuilder<FamilyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FamilyFilterBuilder class.
		/// </summary>
		public FamilyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FamilyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FamilyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FamilyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FamilyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FamilyFilterBuilder
	
	#region FamilyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Family"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FamilyParameterBuilder : ParameterizedSqlFilterBuilder<FamilyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FamilyParameterBuilder class.
		/// </summary>
		public FamilyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FamilyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FamilyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FamilyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FamilyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FamilyParameterBuilder
} // end namespace
