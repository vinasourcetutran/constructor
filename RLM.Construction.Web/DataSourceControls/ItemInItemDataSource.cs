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
	/// Represents the DataRepository.ItemInItemProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemInItemDataSourceDesigner))]
	public class ItemInItemDataSource : ProviderDataSource<ItemInItem, ItemInItemKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInItemDataSource class.
		/// </summary>
		public ItemInItemDataSource() : base(new ItemInItemService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemInItemDataSourceView used by the ItemInItemDataSource.
		/// </summary>
		protected ItemInItemDataSourceView ItemInItemView
		{
			get { return ( View as ItemInItemDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemInItemDataSource control invokes to retrieve data.
		/// </summary>
		public ItemInItemSelectMethod SelectMethod
		{
			get
			{
				ItemInItemSelectMethod selectMethod = ItemInItemSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemInItemSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemInItemDataSourceView class that is to be
		/// used by the ItemInItemDataSource.
		/// </summary>
		/// <returns>An instance of the ItemInItemDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemInItem, ItemInItemKey> GetNewDataSourceView()
		{
			return new ItemInItemDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemInItemDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemInItemDataSourceView : ProviderDataSourceView<ItemInItem, ItemInItemKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInItemDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemInItemDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemInItemDataSourceView(ItemInItemDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemInItemDataSource ItemInItemOwner
		{
			get { return Owner as ItemInItemDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemInItemSelectMethod SelectMethod
		{
			get { return ItemInItemOwner.SelectMethod; }
			set { ItemInItemOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemInItemService ItemInItemProvider
		{
			get { return Provider as ItemInItemService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemInItem> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemInItem> results = null;
			ItemInItem item;
			count = 0;
			
			System.Int32 itemInItemId;
			System.Int64 fromItemId;
			System.Int64 toItemId;

			switch ( SelectMethod )
			{
				case ItemInItemSelectMethod.Get:
					ItemInItemKey entityKey  = new ItemInItemKey();
					entityKey.Load(values);
					item = ItemInItemProvider.Get(entityKey);
					results = new TList<ItemInItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemInItemSelectMethod.GetAll:
                    results = ItemInItemProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemInItemSelectMethod.GetPaged:
					results = ItemInItemProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemInItemSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemInItemProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemInItemProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemInItemSelectMethod.GetByItemInItemId:
					itemInItemId = ( values["ItemInItemId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ItemInItemId"], typeof(System.Int32)) : (int)0;
					item = ItemInItemProvider.GetByItemInItemId(itemInItemId);
					results = new TList<ItemInItem>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemInItemSelectMethod.GetByFromItemId:
					fromItemId = ( values["FromItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["FromItemId"], typeof(System.Int64)) : (long)0;
					results = ItemInItemProvider.GetByFromItemId(fromItemId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInItemSelectMethod.GetByToItemId:
					toItemId = ( values["ToItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["ToItemId"], typeof(System.Int64)) : (long)0;
					results = ItemInItemProvider.GetByToItemId(toItemId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemInItemSelectMethod.Get || SelectMethod == ItemInItemSelectMethod.GetByItemInItemId )
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
				ItemInItem entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ItemInItemProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemInItem> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ItemInItemProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemInItemDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemInItemDataSource class.
	/// </summary>
	public class ItemInItemDataSourceDesigner : ProviderDataSourceDesigner<ItemInItem, ItemInItemKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemInItemDataSourceDesigner class.
		/// </summary>
		public ItemInItemDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInItemSelectMethod SelectMethod
		{
			get { return ((ItemInItemDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemInItemDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemInItemDataSourceActionList

	/// <summary>
	/// Supports the ItemInItemDataSourceDesigner class.
	/// </summary>
	internal class ItemInItemDataSourceActionList : DesignerActionList
	{
		private ItemInItemDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemInItemDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemInItemDataSourceActionList(ItemInItemDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInItemSelectMethod SelectMethod
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

	#endregion ItemInItemDataSourceActionList
	
	#endregion ItemInItemDataSourceDesigner
	
	#region ItemInItemSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemInItemDataSource.SelectMethod property.
	/// </summary>
	public enum ItemInItemSelectMethod
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
		/// Represents the GetByItemInItemId method.
		/// </summary>
		GetByItemInItemId,
		/// <summary>
		/// Represents the GetByFromItemId method.
		/// </summary>
		GetByFromItemId,
		/// <summary>
		/// Represents the GetByToItemId method.
		/// </summary>
		GetByToItemId
	}
	
	#endregion ItemInItemSelectMethod

	#region ItemInItemFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInItemFilter : SqlFilter<ItemInItemColumn>
	{
	}
	
	#endregion ItemInItemFilter

	#region ItemInItemProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemInItemChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInItemProperty : ChildEntityProperty<ItemInItemChildEntityTypes>
	{
	}
	
	#endregion ItemInItemProperty
}

