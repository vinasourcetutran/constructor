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
	/// Represents the DataRepository.ItemIOItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemIOItemDataSourceDesigner))]
	public class ItemIOItemDataSource : ProviderDataSource<ItemIOItem, ItemIOItemKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOItemDataSource class.
		/// </summary>
		public ItemIOItemDataSource() : base(new ItemIOItemService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemIOItemDataSourceView used by the ItemIOItemDataSource.
		/// </summary>
		protected ItemIOItemDataSourceView ItemIOItemView
		{
			get { return ( View as ItemIOItemDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemIOItemDataSource control invokes to retrieve data.
		/// </summary>
		public ItemIOItemSelectMethod SelectMethod
		{
			get
			{
				ItemIOItemSelectMethod selectMethod = ItemIOItemSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemIOItemSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemIOItemDataSourceView class that is to be
		/// used by the ItemIOItemDataSource.
		/// </summary>
		/// <returns>An instance of the ItemIOItemDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemIOItem, ItemIOItemKey> GetNewDataSourceView()
		{
			return new ItemIOItemDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemIOItemDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemIOItemDataSourceView : ProviderDataSourceView<ItemIOItem, ItemIOItemKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOItemDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemIOItemDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemIOItemDataSourceView(ItemIOItemDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemIOItemDataSource ItemIOItemOwner
		{
			get { return Owner as ItemIOItemDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemIOItemSelectMethod SelectMethod
		{
			get { return ItemIOItemOwner.SelectMethod; }
			set { ItemIOItemOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemIOItemService ItemIOItemProvider
		{
			get { return Provider as ItemIOItemService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemIOItem> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemIOItem> results = null;
			ItemIOItem item;
			count = 0;
			
			System.Int32 itemIOItemId;

			switch ( SelectMethod )
			{
				case ItemIOItemSelectMethod.Get:
					ItemIOItemKey entityKey  = new ItemIOItemKey();
					entityKey.Load(values);
					item = ItemIOItemProvider.Get(entityKey);
					results = new TList<ItemIOItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemIOItemSelectMethod.GetAll:
                    results = ItemIOItemProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemIOItemSelectMethod.GetPaged:
					results = ItemIOItemProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemIOItemSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemIOItemProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemIOItemProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemIOItemSelectMethod.GetByItemIOItemId:
					itemIOItemId = ( values["ItemIOItemId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ItemIOItemId"], typeof(System.Int32)) : (int)0;
					item = ItemIOItemProvider.GetByItemIOItemId(itemIOItemId);
					results = new TList<ItemIOItem>();
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
			if ( SelectMethod == ItemIOItemSelectMethod.Get || SelectMethod == ItemIOItemSelectMethod.GetByItemIOItemId )
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
				ItemIOItem entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ItemIOItemProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemIOItem> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ItemIOItemProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemIOItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemIOItemDataSource class.
	/// </summary>
	public class ItemIOItemDataSourceDesigner : ProviderDataSourceDesigner<ItemIOItem, ItemIOItemKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemIOItemDataSourceDesigner class.
		/// </summary>
		public ItemIOItemDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemIOItemSelectMethod SelectMethod
		{
			get { return ((ItemIOItemDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemIOItemDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemIOItemDataSourceActionList

	/// <summary>
	/// Supports the ItemIOItemDataSourceDesigner class.
	/// </summary>
	internal class ItemIOItemDataSourceActionList : DesignerActionList
	{
		private ItemIOItemDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemIOItemDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemIOItemDataSourceActionList(ItemIOItemDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemIOItemSelectMethod SelectMethod
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

	#endregion ItemIOItemDataSourceActionList
	
	#endregion ItemIOItemDataSourceDesigner
	
	#region ItemIOItemSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemIOItemDataSource.SelectMethod property.
	/// </summary>
	public enum ItemIOItemSelectMethod
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
		/// Represents the GetByItemIOItemId method.
		/// </summary>
		GetByItemIOItemId
	}
	
	#endregion ItemIOItemSelectMethod

	#region ItemIOItemFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOItemFilter : SqlFilter<ItemIOItemColumn>
	{
	}
	
	#endregion ItemIOItemFilter

	#region ItemIOItemProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemIOItemChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOItemProperty : ChildEntityProperty<ItemIOItemChildEntityTypes>
	{
	}
	
	#endregion ItemIOItemProperty
}

