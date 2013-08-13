#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using RLM.Construction.Entities;
using RLM.Construction.Data;
using RLM.Construction.Data.Bases;
using RLM.Construction.Services;
#endregion

namespace RLM.Construction.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AppConfigProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AppConfigDataSourceDesigner))]
	public class AppConfigDataSource : ProviderDataSource<AppConfig, AppConfigKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppConfigDataSource class.
		/// </summary>
		public AppConfigDataSource() : base(new AppConfigService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AppConfigDataSourceView used by the AppConfigDataSource.
		/// </summary>
		protected AppConfigDataSourceView AppConfigView
		{
			get { return ( View as AppConfigDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AppConfigDataSource control invokes to retrieve data.
		/// </summary>
		public AppConfigSelectMethod SelectMethod
		{
			get
			{
				AppConfigSelectMethod selectMethod = AppConfigSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AppConfigSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AppConfigDataSourceView class that is to be
		/// used by the AppConfigDataSource.
		/// </summary>
		/// <returns>An instance of the AppConfigDataSourceView class.</returns>
		protected override BaseDataSourceView<AppConfig, AppConfigKey> GetNewDataSourceView()
		{
			return new AppConfigDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AppConfigDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AppConfigDataSourceView : ProviderDataSourceView<AppConfig, AppConfigKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AppConfigDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AppConfigDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AppConfigDataSourceView(AppConfigDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AppConfigDataSource AppConfigOwner
		{
			get { return Owner as AppConfigDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AppConfigSelectMethod SelectMethod
		{
			get { return AppConfigOwner.SelectMethod; }
			set { AppConfigOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AppConfigService AppConfigProvider
		{
			get { return Provider as AppConfigService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AppConfig> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AppConfig> results = null;
			AppConfig item;
			count = 0;
			
			System.Int32 appConfigId;
			System.Int32? applicationId;

			switch ( SelectMethod )
			{
				case AppConfigSelectMethod.Get:
					AppConfigKey entityKey  = new AppConfigKey();
					entityKey.Load(values);
					item = AppConfigProvider.Get(entityKey);
					results = new TList<AppConfig>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AppConfigSelectMethod.GetAll:
                    results = AppConfigProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AppConfigSelectMethod.GetPaged:
					results = AppConfigProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AppConfigSelectMethod.Find:
					if ( FilterParameters != null )
						results = AppConfigProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AppConfigProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AppConfigSelectMethod.GetByAppConfigId:
					appConfigId = ( values["AppConfigId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AppConfigId"], typeof(System.Int32)) : (int)0;
					item = AppConfigProvider.GetByAppConfigId(appConfigId);
					results = new TList<AppConfig>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AppConfigSelectMethod.GetByApplicationId:
					applicationId = (System.Int32?) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Int32?));
					results = AppConfigProvider.GetByApplicationId(applicationId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AppConfigSelectMethod.Get || SelectMethod == AppConfigSelectMethod.GetByAppConfigId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AppConfig entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AppConfigProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<AppConfig> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AppConfigProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AppConfigDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AppConfigDataSource class.
	/// </summary>
	public class AppConfigDataSourceDesigner : ProviderDataSourceDesigner<AppConfig, AppConfigKey>
	{
		/// <summary>
		/// Initializes a new instance of the AppConfigDataSourceDesigner class.
		/// </summary>
		public AppConfigDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AppConfigSelectMethod SelectMethod
		{
			get { return ((AppConfigDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AppConfigDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AppConfigDataSourceActionList

	/// <summary>
	/// Supports the AppConfigDataSourceDesigner class.
	/// </summary>
	internal class AppConfigDataSourceActionList : DesignerActionList
	{
		private AppConfigDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AppConfigDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AppConfigDataSourceActionList(AppConfigDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AppConfigSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AppConfigDataSourceActionList
	
	#endregion AppConfigDataSourceDesigner
	
	#region AppConfigSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AppConfigDataSource.SelectMethod property.
	/// </summary>
	public enum AppConfigSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByAppConfigId method.
		/// </summary>
		GetByAppConfigId,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId
	}
	
	#endregion AppConfigSelectMethod

	#region AppConfigFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AppConfig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppConfigFilter : SqlFilter<AppConfigColumn>
	{
	}
	
	#endregion AppConfigFilter

	#region AppConfigProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AppConfigChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AppConfig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AppConfigProperty : ChildEntityProperty<AppConfigChildEntityTypes>
	{
	}
	
	#endregion AppConfigProperty
}

