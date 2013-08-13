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
	/// Represents the DataRepository.ResourceDataProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ResourceDataDataSourceDesigner))]
	public class ResourceDataDataSource : ProviderDataSource<ResourceData, ResourceDataKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResourceDataDataSource class.
		/// </summary>
		public ResourceDataDataSource() : base(new ResourceDataService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ResourceDataDataSourceView used by the ResourceDataDataSource.
		/// </summary>
		protected ResourceDataDataSourceView ResourceDataView
		{
			get { return ( View as ResourceDataDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ResourceDataDataSource control invokes to retrieve data.
		/// </summary>
		public ResourceDataSelectMethod SelectMethod
		{
			get
			{
				ResourceDataSelectMethod selectMethod = ResourceDataSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ResourceDataSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ResourceDataDataSourceView class that is to be
		/// used by the ResourceDataDataSource.
		/// </summary>
		/// <returns>An instance of the ResourceDataDataSourceView class.</returns>
		protected override BaseDataSourceView<ResourceData, ResourceDataKey> GetNewDataSourceView()
		{
			return new ResourceDataDataSourceView(this, DefaultViewName);
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
	/// Supports the ResourceDataDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ResourceDataDataSourceView : ProviderDataSourceView<ResourceData, ResourceDataKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResourceDataDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ResourceDataDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ResourceDataDataSourceView(ResourceDataDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ResourceDataDataSource ResourceDataOwner
		{
			get { return Owner as ResourceDataDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ResourceDataSelectMethod SelectMethod
		{
			get { return ResourceDataOwner.SelectMethod; }
			set { ResourceDataOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ResourceDataService ResourceDataProvider
		{
			get { return Provider as ResourceDataService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ResourceData> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ResourceData> results = null;
			ResourceData item;
			count = 0;
			
			System.Int32 resourceDataId;

			switch ( SelectMethod )
			{
				case ResourceDataSelectMethod.Get:
					ResourceDataKey entityKey  = new ResourceDataKey();
					entityKey.Load(values);
					item = ResourceDataProvider.Get(entityKey);
					results = new TList<ResourceData>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ResourceDataSelectMethod.GetAll:
                    results = ResourceDataProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ResourceDataSelectMethod.GetPaged:
					results = ResourceDataProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ResourceDataSelectMethod.Find:
					if ( FilterParameters != null )
						results = ResourceDataProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ResourceDataProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ResourceDataSelectMethod.GetByResourceDataId:
					resourceDataId = ( values["ResourceDataId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ResourceDataId"], typeof(System.Int32)) : (int)0;
					item = ResourceDataProvider.GetByResourceDataId(resourceDataId);
					results = new TList<ResourceData>();
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
			if ( SelectMethod == ResourceDataSelectMethod.Get || SelectMethod == ResourceDataSelectMethod.GetByResourceDataId )
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
				ResourceData entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ResourceDataProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ResourceData> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ResourceDataProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ResourceDataDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ResourceDataDataSource class.
	/// </summary>
	public class ResourceDataDataSourceDesigner : ProviderDataSourceDesigner<ResourceData, ResourceDataKey>
	{
		/// <summary>
		/// Initializes a new instance of the ResourceDataDataSourceDesigner class.
		/// </summary>
		public ResourceDataDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResourceDataSelectMethod SelectMethod
		{
			get { return ((ResourceDataDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ResourceDataDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ResourceDataDataSourceActionList

	/// <summary>
	/// Supports the ResourceDataDataSourceDesigner class.
	/// </summary>
	internal class ResourceDataDataSourceActionList : DesignerActionList
	{
		private ResourceDataDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ResourceDataDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ResourceDataDataSourceActionList(ResourceDataDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResourceDataSelectMethod SelectMethod
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

	#endregion ResourceDataDataSourceActionList
	
	#endregion ResourceDataDataSourceDesigner
	
	#region ResourceDataSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ResourceDataDataSource.SelectMethod property.
	/// </summary>
	public enum ResourceDataSelectMethod
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
		/// Represents the GetByResourceDataId method.
		/// </summary>
		GetByResourceDataId
	}
	
	#endregion ResourceDataSelectMethod

	#region ResourceDataFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ResourceData"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResourceDataFilter : SqlFilter<ResourceDataColumn>
	{
	}
	
	#endregion ResourceDataFilter

	#region ResourceDataProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ResourceDataChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ResourceData"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResourceDataProperty : ChildEntityProperty<ResourceDataChildEntityTypes>
	{
	}
	
	#endregion ResourceDataProperty
}

