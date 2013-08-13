#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using RLM.Construction.Entities;
using RLM.Construction.Data;
using RLM.Construction.Data.Bases;

#endregion

namespace RLM.Construction.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("RLM.Construction.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.8.0");
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
					path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
					configMap = new ExeConfigurationFileMap();
					configMap.ExeConfigFilename = path;
				}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		
		
		#region ItemProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Item"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemProviderBase ItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemProvider;
			}
		}
		
		#endregion
		
		
		
		#region AdvanceRequestProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvanceRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AdvanceRequestProviderBase AdvanceRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvanceRequestProvider;
			}
		}
		
		#endregion
		
		
		
		#region RewardProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Reward"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static RewardProviderBase RewardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RewardProvider;
			}
		}
		
		#endregion
		
		
		
		#region StaffProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Staff"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static StaffProviderBase StaffProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StaffProvider;
			}
		}
		
		#endregion
		
		
		
		#region ResourceDataProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ResourceData"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ResourceDataProviderBase ResourceDataProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ResourceDataProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProjectPhaseProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProjectPhase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProjectPhaseProviderBase ProjectPhaseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProjectPhaseProvider;
			}
		}
		
		#endregion
		
		
		
		#region RepositoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Repository"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static RepositoryProviderBase RepositoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RepositoryProvider;
			}
		}
		
		#endregion
		
		
		
		#region RoleProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Role"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static RoleProviderBase RoleProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RoleProvider;
			}
		}
		
		#endregion
		
		
		
		#region RelatedContractProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RelatedContract"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static RelatedContractProviderBase RelatedContractProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RelatedContractProvider;
			}
		}
		
		#endregion
		
		
		
		#region GroupProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Group"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static GroupProviderBase GroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GroupProvider;
			}
		}
		
		#endregion
		
		
		
		#region RoleOfStaffProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RoleOfStaff"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static RoleOfStaffProviderBase RoleOfStaffProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RoleOfStaffProvider;
			}
		}
		
		#endregion
		
		
		
		#region UserGroupProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UserGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static UserGroupProviderBase UserGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserGroupProvider;
			}
		}
		
		#endregion
		
		
		
		#region UserProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static UserProviderBase UserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserProvider;
			}
		}
		
		#endregion
		
		
		
		#region UnitProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Unit"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static UnitProviderBase UnitProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UnitProvider;
			}
		}
		
		#endregion
		
		
		
		#region TaskProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Task"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static TaskProviderBase TaskProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TaskProvider;
			}
		}
		
		#endregion
		
		
		
		#region UnitConvertorProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UnitConvertor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static UnitConvertorProviderBase UnitConvertorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UnitConvertorProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProjectProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Project"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProjectProviderBase ProjectProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProjectProvider;
			}
		}
		
		#endregion
		
		
		
		#region TaskMemberProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TaskMember"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static TaskMemberProviderBase TaskMemberProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TaskMemberProvider;
			}
		}
		
		#endregion
		
		
		
		#region PartnerProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Partner"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static PartnerProviderBase PartnerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PartnerProvider;
			}
		}
		
		#endregion
		
		
		
		#region ContactorProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Contactor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ContactorProviderBase ContactorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContactorProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemMovementProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemMovement"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemMovementProviderBase ItemMovementProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemMovementProvider;
			}
		}
		
		#endregion
		
		
		
		#region CommentProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Comment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CommentProviderBase CommentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CommentProvider;
			}
		}
		
		#endregion
		
		
		
		#region ContractProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Contract"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ContractProviderBase ContractProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContractProvider;
			}
		}
		
		#endregion
		
		
		
		#region AttachFileProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AttachFile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AttachFileProviderBase AttachFileProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AttachFileProvider;
			}
		}
		
		#endregion
		
		
		
		#region ApplicationProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Application"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ApplicationProviderBase ApplicationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ApplicationProvider;
			}
		}
		
		#endregion
		
		
		
		#region DepartmentProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Department"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static DepartmentProviderBase DepartmentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DepartmentProvider;
			}
		}
		
		#endregion
		
		
		
		#region AppConfigProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AppConfig"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AppConfigProviderBase AppConfigProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AppConfigProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemIOItemProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemIOItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemIOItemProviderBase ItemIOItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemIOItemProvider;
			}
		}
		
		#endregion
		
		
		
		#region FamilyProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Family"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static FamilyProviderBase FamilyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FamilyProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemInRepositoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemInRepository"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemInRepositoryProviderBase ItemInRepositoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemInRepositoryProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemIOTicketProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemIOTicket"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemIOTicketProviderBase ItemIOTicketProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemIOTicketProvider;
			}
		}
		
		#endregion
		
		
		
		#region IdentificationInfomationProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="IdentificationInfomation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static IdentificationInfomationProviderBase IdentificationInfomationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IdentificationInfomationProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemInProjectProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemInProject"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemInProjectProviderBase ItemInProjectProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemInProjectProvider;
			}
		}
		
		#endregion
		
		
		
		#region UserInApplicationProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UserInApplication"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static UserInApplicationProviderBase UserInApplicationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserInApplicationProvider;
			}
		}
		
		#endregion
		
		
		
		#region ItemInItemProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemInItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ItemInItemProviderBase ItemInItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemInItemProvider;
			}
		}
		
		#endregion
		
		
		
		#endregion
		
	}
}
