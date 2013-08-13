
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using RLM.Construction.Entities;

#endregion

namespace RLM.Construction.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : System.Configuration.Provider.ProviderBase
	{
		private Type entityCreationalFactoryType = null;
        private static object syncObject = new object();
        private bool enableEntityTracking = true;
        private bool enableListTracking = false;
        private bool useEntityFactory = true;
		private bool enableMethodAuthorization = false;
        private int defaultCommandTimeout = 30;

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
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(RLM.Construction.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
                bool.TryParse(config["enableEntityTracking"], out this.enableEntityTracking);

                bool.TryParse(config["enableListTracking"], out this.enableListTracking);

                bool.TryParse(config["useEntityFactory"], out this.useEntityFactory);
				
				bool.TryParse(config["enableMethodAuthorization"], out this.enableMethodAuthorization);
				
				int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
				
			}   
         }
	    
        /// <summary>
        /// Gets or sets the Creational Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual Type EntityCreationalFactoryType
        {
            get
            {
                return entityCreationalFactoryType;
            }
            set
            {
                entityCreationalFactoryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the ability to track entities.
        /// </summary>
        /// <value>true/false.</value>
        public virtual bool EnableEntityTracking
        {
            get
            {
                return enableEntityTracking;
            }
            set { enableEntityTracking = value; }
        }

        /// <summary>
        /// Gets or sets the Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual bool EnableListTracking
        {
            get
            {
                return enableListTracking;
            }
            set 
            {
                enableListTracking = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use entity factory property to enable the usage of the EntityFactory and it's type cache.
        /// </summary>
        /// <value>bool value</value>
        public virtual bool UseEntityFactory
        {
            get
            {
                return useEntityFactory;
            }
            set 
            {
                useEntityFactory = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use Enable Method Authorization to enable the usage of the Microsoft Patterns and Practices 
		/// IAuthorizationRuleProvider for code level authorization.
		/// </summary>
        /// <value>A bool value.</value>
        public virtual bool EnableMethodAuthorization
        {
            get
            {
                return enableMethodAuthorization;
            }
            set 
            {
                enableMethodAuthorization = value; 
            }
        }

        /// <summary>
        /// Gets or sets the default timeout for every command
        /// </summary>
        /// <value>integer value in seconds.</value>
        public virtual int DefaultCommandTimeout
        {
            get
            {
                return defaultCommandTimeout;
            }
            set
            {
                defaultCommandTimeout = value;
            }
        }
		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation is supporting Transactions.
		///</summary>
		public abstract bool IsTransactionSupported{get;}
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public virtual TransactionManager CreateTransaction() {throw new NotSupportedException();}
		
		
		///<summary>
		/// Current ItemProviderBase instance.
		///</summary>
		public virtual ItemProviderBase ItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvanceRequestProviderBase instance.
		///</summary>
		public virtual AdvanceRequestProviderBase AdvanceRequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RewardProviderBase instance.
		///</summary>
		public virtual RewardProviderBase RewardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StaffProviderBase instance.
		///</summary>
		public virtual StaffProviderBase StaffProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ResourceDataProviderBase instance.
		///</summary>
		public virtual ResourceDataProviderBase ResourceDataProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProjectPhaseProviderBase instance.
		///</summary>
		public virtual ProjectPhaseProviderBase ProjectPhaseProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RepositoryProviderBase instance.
		///</summary>
		public virtual RepositoryProviderBase RepositoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RoleProviderBase instance.
		///</summary>
		public virtual RoleProviderBase RoleProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RelatedContractProviderBase instance.
		///</summary>
		public virtual RelatedContractProviderBase RelatedContractProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GroupProviderBase instance.
		///</summary>
		public virtual GroupProviderBase GroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RoleOfStaffProviderBase instance.
		///</summary>
		public virtual RoleOfStaffProviderBase RoleOfStaffProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserGroupProviderBase instance.
		///</summary>
		public virtual UserGroupProviderBase UserGroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserProviderBase instance.
		///</summary>
		public virtual UserProviderBase UserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UnitProviderBase instance.
		///</summary>
		public virtual UnitProviderBase UnitProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TaskProviderBase instance.
		///</summary>
		public virtual TaskProviderBase TaskProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UnitConvertorProviderBase instance.
		///</summary>
		public virtual UnitConvertorProviderBase UnitConvertorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProjectProviderBase instance.
		///</summary>
		public virtual ProjectProviderBase ProjectProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TaskMemberProviderBase instance.
		///</summary>
		public virtual TaskMemberProviderBase TaskMemberProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PartnerProviderBase instance.
		///</summary>
		public virtual PartnerProviderBase PartnerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContactorProviderBase instance.
		///</summary>
		public virtual ContactorProviderBase ContactorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemMovementProviderBase instance.
		///</summary>
		public virtual ItemMovementProviderBase ItemMovementProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CommentProviderBase instance.
		///</summary>
		public virtual CommentProviderBase CommentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContractProviderBase instance.
		///</summary>
		public virtual ContractProviderBase ContractProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AttachFileProviderBase instance.
		///</summary>
		public virtual AttachFileProviderBase AttachFileProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ApplicationProviderBase instance.
		///</summary>
		public virtual ApplicationProviderBase ApplicationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DepartmentProviderBase instance.
		///</summary>
		public virtual DepartmentProviderBase DepartmentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AppConfigProviderBase instance.
		///</summary>
		public virtual AppConfigProviderBase AppConfigProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemIOItemProviderBase instance.
		///</summary>
		public virtual ItemIOItemProviderBase ItemIOItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FamilyProviderBase instance.
		///</summary>
		public virtual FamilyProviderBase FamilyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemInRepositoryProviderBase instance.
		///</summary>
		public virtual ItemInRepositoryProviderBase ItemInRepositoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemIOTicketProviderBase instance.
		///</summary>
		public virtual ItemIOTicketProviderBase ItemIOTicketProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IdentificationInfomationProviderBase instance.
		///</summary>
		public virtual IdentificationInfomationProviderBase IdentificationInfomationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemInProjectProviderBase instance.
		///</summary>
		public virtual ItemInProjectProviderBase ItemInProjectProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserInApplicationProviderBase instance.
		///</summary>
		public virtual UserInApplicationProviderBase UserInApplicationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemInItemProviderBase instance.
		///</summary>
		public virtual ItemInItemProviderBase ItemInItemProvider{get {throw new NotImplementedException();}}
		
		
					
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(DbCommand commandWrapper);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(DbCommand commandWrapper);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(DbCommand commandWrapper);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(DbCommand commandWrapper);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion
		
		#endregion
	}
}
