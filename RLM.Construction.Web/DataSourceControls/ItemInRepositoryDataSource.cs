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
	/// Represents the DataRepository.ItemInRepositoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemInRepositoryDataSourceDesigner))]
	public class ItemInRepositoryDataSource : ProviderDataSource<ItemInRepository, ItemInRepositoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryDataSource class.
		/// </summary>
		public ItemInRepositoryDataSource() : base(new ItemInRepositoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemInRepositoryDataSourceView used by the ItemInRepositoryDataSource.
		/// </summary>
		protected ItemInRepositoryDataSourceView ItemInRepositoryView
		{
			get { return ( View as ItemInRepositoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemInRepositoryDataSource control invokes to retrieve data.
		/// </summary>
		public ItemInRepositorySelectMethod SelectMethod
		{
			get
			{
				ItemInRepositorySelectMethod selectMethod = ItemInRepositorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemInRepositorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemInRepositoryDataSourceView class that is to be
		/// used by the ItemInRepositoryDataSource.
		/// </summary>
		/// <returns>An instance of the ItemInRepositoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemInRepository, ItemInRepositoryKey> GetNewDataSourceView()
		{
			return new ItemInRepositoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemInRepositoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemInRepositoryDataSourceView : ProviderDataSourceView<ItemInRepository, ItemInRepositoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemInRepositoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemInRepositoryDataSourceView(ItemInRepositoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemInRepositoryDataSource ItemInRepositoryOwner
		{
			get { return Owner as ItemInRepositoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemInRepositorySelectMethod SelectMethod
		{
			get { return ItemInRepositoryOwner.SelectMethod; }
			set { ItemInRepositoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemInRepositoryService ItemInRepositoryProvider
		{
			get { return Provider as ItemInRepositoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemInRepository> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemInRepository> results = null;
			ItemInRepository item;
			count = 0;
			
			System.Int32 repositoryId;
			System.Int64 itemId;
			System.Int32? priceUnitId;

			switch ( SelectMethod )
			{
				case ItemInRepositorySelectMethod.Get:
					ItemInRepositoryKey entityKey  = new ItemInRepositoryKey();
					entityKey.Load(values);
					item = ItemInRepositoryProvider.Get(entityKey);
					results = new TList<ItemInRepository>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemInRepositorySelectMethod.GetAll:
                    results = ItemInRepositoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemInRepositorySelectMethod.GetPaged:
					results = ItemInRepositoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemInRepositorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemInRepositoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemInRepositoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemInRepositorySelectMethod.GetByRepositoryIdItemId:
					repositoryId = ( values["RepositoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RepositoryId"], typeof(System.Int32)) : (int)0;
					itemId = ( values["ItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int64)) : (long)0;
					item = ItemInRepositoryProvider.GetByRepositoryIdItemId(repositoryId, itemId);
					results = new TList<ItemInRepository>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemInRepositorySelectMethod.GetByItemId:
					itemId = ( values["ItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int64)) : (long)0;
					results = ItemInRepositoryProvider.GetByItemId(itemId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInRepositorySelectMethod.GetByRepositoryId:
					repositoryId = ( values["RepositoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RepositoryId"], typeof(System.Int32)) : (int)0;
					results = ItemInRepositoryProvider.GetByRepositoryId(repositoryId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInRepositorySelectMethod.GetByPriceUnitId:
					priceUnitId = (System.Int32?) EntityUtil.ChangeType(values["PriceUnitId"], typeof(System.Int32?));
					results = ItemInRepositoryProvider.GetByPriceUnitId(priceUnitId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemInRepositorySelectMethod.Get || SelectMethod == ItemInRepositorySelectMethod.GetByRepositoryIdItemId )
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
				ItemInRepository entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ItemInRepositoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemInRepository> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ItemInRepositoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemInRepositoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemInRepositoryDataSource class.
	/// </summary>
	public class ItemInRepositoryDataSourceDesigner : ProviderDataSourceDesigner<ItemInRepository, ItemInRepositoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryDataSourceDesigner class.
		/// </summary>
		public ItemInRepositoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInRepositorySelectMethod SelectMethod
		{
			get { return ((ItemInRepositoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemInRepositoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemInRepositoryDataSourceActionList

	/// <summary>
	/// Supports the ItemInRepositoryDataSourceDesigner class.
	/// </summary>
	internal class ItemInRepositoryDataSourceActionList : DesignerActionList
	{
		private ItemInRepositoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemInRepositoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemInRepositoryDataSourceActionList(ItemInRepositoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInRepositorySelectMethod SelectMethod
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

	#endregion ItemInRepositoryDataSourceActionList
	
	#endregion ItemInRepositoryDataSourceDesigner
	
	#region ItemInRepositorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemInRepositoryDataSource.SelectMethod property.
	/// </summary>
	public enum ItemInRepositorySelectMethod
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
		/// Represents the GetByRepositoryIdItemId method.
		/// </summary>
		GetByRepositoryIdItemId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId,
		/// <summary>
		/// Represents the GetByRepositoryId method.
		/// </summary>
		GetByRepositoryId,
		/// <summary>
		/// Represents the GetByPriceUnitId method.
		/// </summary>
		GetByPriceUnitId
	}
	
	#endregion ItemInRepositorySelectMethod

	#region ItemInRepositoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInRepository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInRepositoryFilter : SqlFilter<ItemInRepositoryColumn>
	{
	}
	
	#endregion ItemInRepositoryFilter

	#region ItemInRepositoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemInRepositoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInRepository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInRepositoryProperty : ChildEntityProperty<ItemInRepositoryChildEntityTypes>
	{
	}
	
	#endregion ItemInRepositoryProperty
}

