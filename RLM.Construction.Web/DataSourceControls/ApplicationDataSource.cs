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
	/// Represents the DataRepository.ApplicationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ApplicationDataSourceDesigner))]
	public class ApplicationDataSource : ProviderDataSource<Application, ApplicationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ApplicationDataSource class.
		/// </summary>
		public ApplicationDataSource() : base(new ApplicationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ApplicationDataSourceView used by the ApplicationDataSource.
		/// </summary>
		protected ApplicationDataSourceView ApplicationView
		{
			get { return ( View as ApplicationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ApplicationDataSource control invokes to retrieve data.
		/// </summary>
		public ApplicationSelectMethod SelectMethod
		{
			get
			{
				ApplicationSelectMethod selectMethod = ApplicationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ApplicationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ApplicationDataSourceView class that is to be
		/// used by the ApplicationDataSource.
		/// </summary>
		/// <returns>An instance of the ApplicationDataSourceView class.</returns>
		protected override BaseDataSourceView<Application, ApplicationKey> GetNewDataSourceView()
		{
			return new ApplicationDataSourceView(this, DefaultViewName);
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
	/// Supports the ApplicationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ApplicationDataSourceView : ProviderDataSourceView<Application, ApplicationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ApplicationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ApplicationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ApplicationDataSourceView(ApplicationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ApplicationDataSource ApplicationOwner
		{
			get { return Owner as ApplicationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ApplicationSelectMethod SelectMethod
		{
			get { return ApplicationOwner.SelectMethod; }
			set { ApplicationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ApplicationService ApplicationProvider
		{
			get { return Provider as ApplicationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Application> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Application> results = null;
			Application item;
			count = 0;
			
			System.Int32 applicationId;

			switch ( SelectMethod )
			{
				case ApplicationSelectMethod.Get:
					ApplicationKey entityKey  = new ApplicationKey();
					entityKey.Load(values);
					item = ApplicationProvider.Get(entityKey);
					results = new TList<Application>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ApplicationSelectMethod.GetAll:
                    results = ApplicationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ApplicationSelectMethod.GetPaged:
					results = ApplicationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ApplicationSelectMethod.Find:
					if ( FilterParameters != null )
						results = ApplicationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ApplicationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ApplicationSelectMethod.GetByApplicationId:
					applicationId = ( values["ApplicationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Int32)) : (int)0;
					item = ApplicationProvider.GetByApplicationId(applicationId);
					results = new TList<Application>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == ApplicationSelectMethod.Get || SelectMethod == ApplicationSelectMethod.GetByApplicationId )
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
				Application entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ApplicationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Application> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ApplicationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ApplicationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ApplicationDataSource class.
	/// </summary>
	public class ApplicationDataSourceDesigner : ProviderDataSourceDesigner<Application, ApplicationKey>
	{
		/// <summary>
		/// Initializes a new instance of the ApplicationDataSourceDesigner class.
		/// </summary>
		public ApplicationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ApplicationSelectMethod SelectMethod
		{
			get { return ((ApplicationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ApplicationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ApplicationDataSourceActionList

	/// <summary>
	/// Supports the ApplicationDataSourceDesigner class.
	/// </summary>
	internal class ApplicationDataSourceActionList : DesignerActionList
	{
		private ApplicationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ApplicationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ApplicationDataSourceActionList(ApplicationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ApplicationSelectMethod SelectMethod
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

	#endregion ApplicationDataSourceActionList
	
	#endregion ApplicationDataSourceDesigner
	
	#region ApplicationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ApplicationDataSource.SelectMethod property.
	/// </summary>
	public enum ApplicationSelectMethod
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
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId
	}
	
	#endregion ApplicationSelectMethod

	#region ApplicationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Application"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ApplicationFilter : SqlFilter<ApplicationColumn>
	{
	}
	
	#endregion ApplicationFilter

	#region ApplicationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ApplicationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Application"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ApplicationProperty : ChildEntityProperty<ApplicationChildEntityTypes>
	{
	}
	
	#endregion ApplicationProperty
}

