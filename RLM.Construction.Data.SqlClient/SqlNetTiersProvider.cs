
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using RLM.Construction.Entities;
using RLM.Construction.Data;
using RLM.Construction.Data.Bases;

#endregion

namespace RLM.Construction.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : RLM.Construction.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "ItemProvider"
			
		private SqlItemProvider innerSqlItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemProviderBase ItemProvider
		{
			get
			{
				if (innerSqlItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemProvider == null)
						{
							this.innerSqlItemProvider = new SqlItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemProvider SqlItemProvider
		{
			get {return ItemProvider as SqlItemProvider;}
		}
		
		#endregion
		
		
		#region "AdvanceRequestProvider"
			
		private SqlAdvanceRequestProvider innerSqlAdvanceRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvanceRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvanceRequestProviderBase AdvanceRequestProvider
		{
			get
			{
				if (innerSqlAdvanceRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvanceRequestProvider == null)
						{
							this.innerSqlAdvanceRequestProvider = new SqlAdvanceRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvanceRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvanceRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvanceRequestProvider SqlAdvanceRequestProvider
		{
			get {return AdvanceRequestProvider as SqlAdvanceRequestProvider;}
		}
		
		#endregion
		
		
		#region "RewardProvider"
			
		private SqlRewardProvider innerSqlRewardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Reward"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RewardProviderBase RewardProvider
		{
			get
			{
				if (innerSqlRewardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRewardProvider == null)
						{
							this.innerSqlRewardProvider = new SqlRewardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRewardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRewardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRewardProvider SqlRewardProvider
		{
			get {return RewardProvider as SqlRewardProvider;}
		}
		
		#endregion
		
		
		#region "StaffProvider"
			
		private SqlStaffProvider innerSqlStaffProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Staff"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StaffProviderBase StaffProvider
		{
			get
			{
				if (innerSqlStaffProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStaffProvider == null)
						{
							this.innerSqlStaffProvider = new SqlStaffProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStaffProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlStaffProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStaffProvider SqlStaffProvider
		{
			get {return StaffProvider as SqlStaffProvider;}
		}
		
		#endregion
		
		
		#region "ResourceDataProvider"
			
		private SqlResourceDataProvider innerSqlResourceDataProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ResourceData"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ResourceDataProviderBase ResourceDataProvider
		{
			get
			{
				if (innerSqlResourceDataProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlResourceDataProvider == null)
						{
							this.innerSqlResourceDataProvider = new SqlResourceDataProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlResourceDataProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlResourceDataProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlResourceDataProvider SqlResourceDataProvider
		{
			get {return ResourceDataProvider as SqlResourceDataProvider;}
		}
		
		#endregion
		
		
		#region "ProjectPhaseProvider"
			
		private SqlProjectPhaseProvider innerSqlProjectPhaseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProjectPhase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProjectPhaseProviderBase ProjectPhaseProvider
		{
			get
			{
				if (innerSqlProjectPhaseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProjectPhaseProvider == null)
						{
							this.innerSqlProjectPhaseProvider = new SqlProjectPhaseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProjectPhaseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProjectPhaseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProjectPhaseProvider SqlProjectPhaseProvider
		{
			get {return ProjectPhaseProvider as SqlProjectPhaseProvider;}
		}
		
		#endregion
		
		
		#region "RepositoryProvider"
			
		private SqlRepositoryProvider innerSqlRepositoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Repository"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RepositoryProviderBase RepositoryProvider
		{
			get
			{
				if (innerSqlRepositoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRepositoryProvider == null)
						{
							this.innerSqlRepositoryProvider = new SqlRepositoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRepositoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRepositoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRepositoryProvider SqlRepositoryProvider
		{
			get {return RepositoryProvider as SqlRepositoryProvider;}
		}
		
		#endregion
		
		
		#region "RoleProvider"
			
		private SqlRoleProvider innerSqlRoleProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Role"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RoleProviderBase RoleProvider
		{
			get
			{
				if (innerSqlRoleProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRoleProvider == null)
						{
							this.innerSqlRoleProvider = new SqlRoleProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRoleProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRoleProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRoleProvider SqlRoleProvider
		{
			get {return RoleProvider as SqlRoleProvider;}
		}
		
		#endregion
		
		
		#region "RelatedContractProvider"
			
		private SqlRelatedContractProvider innerSqlRelatedContractProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RelatedContract"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RelatedContractProviderBase RelatedContractProvider
		{
			get
			{
				if (innerSqlRelatedContractProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRelatedContractProvider == null)
						{
							this.innerSqlRelatedContractProvider = new SqlRelatedContractProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRelatedContractProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRelatedContractProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRelatedContractProvider SqlRelatedContractProvider
		{
			get {return RelatedContractProvider as SqlRelatedContractProvider;}
		}
		
		#endregion
		
		
		#region "GroupProvider"
			
		private SqlGroupProvider innerSqlGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Group"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GroupProviderBase GroupProvider
		{
			get
			{
				if (innerSqlGroupProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGroupProvider == null)
						{
							this.innerSqlGroupProvider = new SqlGroupProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGroupProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGroupProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGroupProvider SqlGroupProvider
		{
			get {return GroupProvider as SqlGroupProvider;}
		}
		
		#endregion
		
		
		#region "RoleOfStaffProvider"
			
		private SqlRoleOfStaffProvider innerSqlRoleOfStaffProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RoleOfStaff"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RoleOfStaffProviderBase RoleOfStaffProvider
		{
			get
			{
				if (innerSqlRoleOfStaffProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRoleOfStaffProvider == null)
						{
							this.innerSqlRoleOfStaffProvider = new SqlRoleOfStaffProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRoleOfStaffProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRoleOfStaffProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRoleOfStaffProvider SqlRoleOfStaffProvider
		{
			get {return RoleOfStaffProvider as SqlRoleOfStaffProvider;}
		}
		
		#endregion
		
		
		#region "UserGroupProvider"
			
		private SqlUserGroupProvider innerSqlUserGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UserGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserGroupProviderBase UserGroupProvider
		{
			get
			{
				if (innerSqlUserGroupProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserGroupProvider == null)
						{
							this.innerSqlUserGroupProvider = new SqlUserGroupProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserGroupProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserGroupProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserGroupProvider SqlUserGroupProvider
		{
			get {return UserGroupProvider as SqlUserGroupProvider;}
		}
		
		#endregion
		
		
		#region "UserProvider"
			
		private SqlUserProvider innerSqlUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerSqlUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserProvider == null)
						{
							this.innerSqlUserProvider = new SqlUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserProvider SqlUserProvider
		{
			get {return UserProvider as SqlUserProvider;}
		}
		
		#endregion
		
		
		#region "UnitProvider"
			
		private SqlUnitProvider innerSqlUnitProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Unit"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UnitProviderBase UnitProvider
		{
			get
			{
				if (innerSqlUnitProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUnitProvider == null)
						{
							this.innerSqlUnitProvider = new SqlUnitProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUnitProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUnitProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUnitProvider SqlUnitProvider
		{
			get {return UnitProvider as SqlUnitProvider;}
		}
		
		#endregion
		
		
		#region "TaskProvider"
			
		private SqlTaskProvider innerSqlTaskProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Task"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TaskProviderBase TaskProvider
		{
			get
			{
				if (innerSqlTaskProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTaskProvider == null)
						{
							this.innerSqlTaskProvider = new SqlTaskProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTaskProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTaskProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTaskProvider SqlTaskProvider
		{
			get {return TaskProvider as SqlTaskProvider;}
		}
		
		#endregion
		
		
		#region "UnitConvertorProvider"
			
		private SqlUnitConvertorProvider innerSqlUnitConvertorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UnitConvertor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UnitConvertorProviderBase UnitConvertorProvider
		{
			get
			{
				if (innerSqlUnitConvertorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUnitConvertorProvider == null)
						{
							this.innerSqlUnitConvertorProvider = new SqlUnitConvertorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUnitConvertorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUnitConvertorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUnitConvertorProvider SqlUnitConvertorProvider
		{
			get {return UnitConvertorProvider as SqlUnitConvertorProvider;}
		}
		
		#endregion
		
		
		#region "ProjectProvider"
			
		private SqlProjectProvider innerSqlProjectProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Project"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProjectProviderBase ProjectProvider
		{
			get
			{
				if (innerSqlProjectProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProjectProvider == null)
						{
							this.innerSqlProjectProvider = new SqlProjectProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProjectProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProjectProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProjectProvider SqlProjectProvider
		{
			get {return ProjectProvider as SqlProjectProvider;}
		}
		
		#endregion
		
		
		#region "TaskMemberProvider"
			
		private SqlTaskMemberProvider innerSqlTaskMemberProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TaskMember"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TaskMemberProviderBase TaskMemberProvider
		{
			get
			{
				if (innerSqlTaskMemberProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTaskMemberProvider == null)
						{
							this.innerSqlTaskMemberProvider = new SqlTaskMemberProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTaskMemberProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTaskMemberProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTaskMemberProvider SqlTaskMemberProvider
		{
			get {return TaskMemberProvider as SqlTaskMemberProvider;}
		}
		
		#endregion
		
		
		#region "PartnerProvider"
			
		private SqlPartnerProvider innerSqlPartnerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Partner"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PartnerProviderBase PartnerProvider
		{
			get
			{
				if (innerSqlPartnerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPartnerProvider == null)
						{
							this.innerSqlPartnerProvider = new SqlPartnerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPartnerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPartnerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPartnerProvider SqlPartnerProvider
		{
			get {return PartnerProvider as SqlPartnerProvider;}
		}
		
		#endregion
		
		
		#region "ContactorProvider"
			
		private SqlContactorProvider innerSqlContactorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Contactor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactorProviderBase ContactorProvider
		{
			get
			{
				if (innerSqlContactorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContactorProvider == null)
						{
							this.innerSqlContactorProvider = new SqlContactorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContactorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlContactorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContactorProvider SqlContactorProvider
		{
			get {return ContactorProvider as SqlContactorProvider;}
		}
		
		#endregion
		
		
		#region "ItemMovementProvider"
			
		private SqlItemMovementProvider innerSqlItemMovementProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemMovement"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemMovementProviderBase ItemMovementProvider
		{
			get
			{
				if (innerSqlItemMovementProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemMovementProvider == null)
						{
							this.innerSqlItemMovementProvider = new SqlItemMovementProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemMovementProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemMovementProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemMovementProvider SqlItemMovementProvider
		{
			get {return ItemMovementProvider as SqlItemMovementProvider;}
		}
		
		#endregion
		
		
		#region "CommentProvider"
			
		private SqlCommentProvider innerSqlCommentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Comment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CommentProviderBase CommentProvider
		{
			get
			{
				if (innerSqlCommentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCommentProvider == null)
						{
							this.innerSqlCommentProvider = new SqlCommentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCommentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCommentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCommentProvider SqlCommentProvider
		{
			get {return CommentProvider as SqlCommentProvider;}
		}
		
		#endregion
		
		
		#region "ContractProvider"
			
		private SqlContractProvider innerSqlContractProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Contract"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContractProviderBase ContractProvider
		{
			get
			{
				if (innerSqlContractProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContractProvider == null)
						{
							this.innerSqlContractProvider = new SqlContractProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContractProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlContractProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContractProvider SqlContractProvider
		{
			get {return ContractProvider as SqlContractProvider;}
		}
		
		#endregion
		
		
		#region "AttachFileProvider"
			
		private SqlAttachFileProvider innerSqlAttachFileProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AttachFile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AttachFileProviderBase AttachFileProvider
		{
			get
			{
				if (innerSqlAttachFileProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAttachFileProvider == null)
						{
							this.innerSqlAttachFileProvider = new SqlAttachFileProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAttachFileProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAttachFileProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAttachFileProvider SqlAttachFileProvider
		{
			get {return AttachFileProvider as SqlAttachFileProvider;}
		}
		
		#endregion
		
		
		#region "ApplicationProvider"
			
		private SqlApplicationProvider innerSqlApplicationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Application"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ApplicationProviderBase ApplicationProvider
		{
			get
			{
				if (innerSqlApplicationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlApplicationProvider == null)
						{
							this.innerSqlApplicationProvider = new SqlApplicationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlApplicationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlApplicationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlApplicationProvider SqlApplicationProvider
		{
			get {return ApplicationProvider as SqlApplicationProvider;}
		}
		
		#endregion
		
		
		#region "DepartmentProvider"
			
		private SqlDepartmentProvider innerSqlDepartmentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentProviderBase DepartmentProvider
		{
			get
			{
				if (innerSqlDepartmentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDepartmentProvider == null)
						{
							this.innerSqlDepartmentProvider = new SqlDepartmentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDepartmentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDepartmentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDepartmentProvider SqlDepartmentProvider
		{
			get {return DepartmentProvider as SqlDepartmentProvider;}
		}
		
		#endregion
		
		
		#region "AppConfigProvider"
			
		private SqlAppConfigProvider innerSqlAppConfigProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AppConfig"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AppConfigProviderBase AppConfigProvider
		{
			get
			{
				if (innerSqlAppConfigProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAppConfigProvider == null)
						{
							this.innerSqlAppConfigProvider = new SqlAppConfigProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAppConfigProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAppConfigProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAppConfigProvider SqlAppConfigProvider
		{
			get {return AppConfigProvider as SqlAppConfigProvider;}
		}
		
		#endregion
		
		
		#region "ItemIOItemProvider"
			
		private SqlItemIOItemProvider innerSqlItemIOItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemIOItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemIOItemProviderBase ItemIOItemProvider
		{
			get
			{
				if (innerSqlItemIOItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemIOItemProvider == null)
						{
							this.innerSqlItemIOItemProvider = new SqlItemIOItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemIOItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemIOItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemIOItemProvider SqlItemIOItemProvider
		{
			get {return ItemIOItemProvider as SqlItemIOItemProvider;}
		}
		
		#endregion
		
		
		#region "FamilyProvider"
			
		private SqlFamilyProvider innerSqlFamilyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Family"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FamilyProviderBase FamilyProvider
		{
			get
			{
				if (innerSqlFamilyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFamilyProvider == null)
						{
							this.innerSqlFamilyProvider = new SqlFamilyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFamilyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFamilyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFamilyProvider SqlFamilyProvider
		{
			get {return FamilyProvider as SqlFamilyProvider;}
		}
		
		#endregion
		
		
		#region "ItemInRepositoryProvider"
			
		private SqlItemInRepositoryProvider innerSqlItemInRepositoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemInRepository"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemInRepositoryProviderBase ItemInRepositoryProvider
		{
			get
			{
				if (innerSqlItemInRepositoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemInRepositoryProvider == null)
						{
							this.innerSqlItemInRepositoryProvider = new SqlItemInRepositoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemInRepositoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemInRepositoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemInRepositoryProvider SqlItemInRepositoryProvider
		{
			get {return ItemInRepositoryProvider as SqlItemInRepositoryProvider;}
		}
		
		#endregion
		
		
		#region "ItemIOTicketProvider"
			
		private SqlItemIOTicketProvider innerSqlItemIOTicketProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemIOTicket"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemIOTicketProviderBase ItemIOTicketProvider
		{
			get
			{
				if (innerSqlItemIOTicketProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemIOTicketProvider == null)
						{
							this.innerSqlItemIOTicketProvider = new SqlItemIOTicketProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemIOTicketProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemIOTicketProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemIOTicketProvider SqlItemIOTicketProvider
		{
			get {return ItemIOTicketProvider as SqlItemIOTicketProvider;}
		}
		
		#endregion
		
		
		#region "IdentificationInfomationProvider"
			
		private SqlIdentificationInfomationProvider innerSqlIdentificationInfomationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="IdentificationInfomation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IdentificationInfomationProviderBase IdentificationInfomationProvider
		{
			get
			{
				if (innerSqlIdentificationInfomationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIdentificationInfomationProvider == null)
						{
							this.innerSqlIdentificationInfomationProvider = new SqlIdentificationInfomationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIdentificationInfomationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlIdentificationInfomationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIdentificationInfomationProvider SqlIdentificationInfomationProvider
		{
			get {return IdentificationInfomationProvider as SqlIdentificationInfomationProvider;}
		}
		
		#endregion
		
		
		#region "ItemInProjectProvider"
			
		private SqlItemInProjectProvider innerSqlItemInProjectProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemInProject"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemInProjectProviderBase ItemInProjectProvider
		{
			get
			{
				if (innerSqlItemInProjectProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemInProjectProvider == null)
						{
							this.innerSqlItemInProjectProvider = new SqlItemInProjectProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemInProjectProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemInProjectProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemInProjectProvider SqlItemInProjectProvider
		{
			get {return ItemInProjectProvider as SqlItemInProjectProvider;}
		}
		
		#endregion
		
		
		#region "UserInApplicationProvider"
			
		private SqlUserInApplicationProvider innerSqlUserInApplicationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UserInApplication"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserInApplicationProviderBase UserInApplicationProvider
		{
			get
			{
				if (innerSqlUserInApplicationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserInApplicationProvider == null)
						{
							this.innerSqlUserInApplicationProvider = new SqlUserInApplicationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserInApplicationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserInApplicationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserInApplicationProvider SqlUserInApplicationProvider
		{
			get {return UserInApplicationProvider as SqlUserInApplicationProvider;}
		}
		
		#endregion
		
		
		#region "ItemInItemProvider"
			
		private SqlItemInItemProvider innerSqlItemInItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemInItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemInItemProviderBase ItemInItemProvider
		{
			get
			{
				if (innerSqlItemInItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemInItemProvider == null)
						{
							this.innerSqlItemInItemProvider = new SqlItemInItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemInItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlItemInItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemInItemProvider SqlItemInItemProvider
		{
			get {return ItemInItemProvider as SqlItemInItemProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
