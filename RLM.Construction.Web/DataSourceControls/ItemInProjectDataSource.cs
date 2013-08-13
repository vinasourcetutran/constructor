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
	/// Represents the DataRepository.ItemInProjectProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemInProjectDataSourceDesigner))]
	public class ItemInProjectDataSource : ProviderDataSource<ItemInProject, ItemInProjectKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInProjectDataSource class.
		/// </summary>
		public ItemInProjectDataSource() : base(new ItemInProjectService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemInProjectDataSourceView used by the ItemInProjectDataSource.
		/// </summary>
		protected ItemInProjectDataSourceView ItemInProjectView
		{
			get { return ( View as ItemInProjectDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemInProjectDataSource control invokes to retrieve data.
		/// </summary>
		public ItemInProjectSelectMethod SelectMethod
		{
			get
			{
				ItemInProjectSelectMethod selectMethod = ItemInProjectSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemInProjectSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemInProjectDataSourceView class that is to be
		/// used by the ItemInProjectDataSource.
		/// </summary>
		/// <returns>An instance of the ItemInProjectDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemInProject, ItemInProjectKey> GetNewDataSourceView()
		{
			return new ItemInProjectDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemInProjectDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemInProjectDataSourceView : ProviderDataSourceView<ItemInProject, ItemInProjectKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemInProjectDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemInProjectDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemInProjectDataSourceView(ItemInProjectDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemInProjectDataSource ItemInProjectOwner
		{
			get { return Owner as ItemInProjectDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemInProjectSelectMethod SelectMethod
		{
			get { return ItemInProjectOwner.SelectMethod; }
			set { ItemInProjectOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemInProjectService ItemInProjectProvider
		{
			get { return Provider as ItemInProjectService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemInProject> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemInProject> results = null;
			ItemInProject item;
			count = 0;
			
			System.Int32 itemInProjectId;
			System.Int32? priceUnitId;
			System.Int32 contractId;
			System.Int64 itemId;
			System.Int32 projectId;

			switch ( SelectMethod )
			{
				case ItemInProjectSelectMethod.Get:
					ItemInProjectKey entityKey  = new ItemInProjectKey();
					entityKey.Load(values);
					item = ItemInProjectProvider.Get(entityKey);
					results = new TList<ItemInProject>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemInProjectSelectMethod.GetAll:
                    results = ItemInProjectProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemInProjectSelectMethod.GetPaged:
					results = ItemInProjectProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemInProjectSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemInProjectProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemInProjectProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemInProjectSelectMethod.GetByItemInProjectId:
					itemInProjectId = ( values["ItemInProjectId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ItemInProjectId"], typeof(System.Int32)) : (int)0;
					item = ItemInProjectProvider.GetByItemInProjectId(itemInProjectId);
					results = new TList<ItemInProject>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemInProjectSelectMethod.GetByPriceUnitId:
					priceUnitId = (System.Int32?) EntityUtil.ChangeType(values["PriceUnitId"], typeof(System.Int32?));
					results = ItemInProjectProvider.GetByPriceUnitId(priceUnitId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInProjectSelectMethod.GetByContractId:
					contractId = ( values["ContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContractId"], typeof(System.Int32)) : (int)0;
					results = ItemInProjectProvider.GetByContractId(contractId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInProjectSelectMethod.GetByItemId:
					itemId = ( values["ItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int64)) : (long)0;
					results = ItemInProjectProvider.GetByItemId(itemId, this.StartIndex, this.PageSize, out count);
					break;
				case ItemInProjectSelectMethod.GetByProjectId:
					projectId = ( values["ProjectId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProjectId"], typeof(System.Int32)) : (int)0;
					results = ItemInProjectProvider.GetByProjectId(projectId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemInProjectSelectMethod.Get || SelectMethod == ItemInProjectSelectMethod.GetByItemInProjectId )
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
				ItemInProject entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ItemInProjectProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemInProject> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ItemInProjectProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemInProjectDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemInProjectDataSource class.
	/// </summary>
	public class ItemInProjectDataSourceDesigner : ProviderDataSourceDesigner<ItemInProject, ItemInProjectKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemInProjectDataSourceDesigner class.
		/// </summary>
		public ItemInProjectDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInProjectSelectMethod SelectMethod
		{
			get { return ((ItemInProjectDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemInProjectDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemInProjectDataSourceActionList

	/// <summary>
	/// Supports the ItemInProjectDataSourceDesigner class.
	/// </summary>
	internal class ItemInProjectDataSourceActionList : DesignerActionList
	{
		private ItemInProjectDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemInProjectDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemInProjectDataSourceActionList(ItemInProjectDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemInProjectSelectMethod SelectMethod
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

	#endregion ItemInProjectDataSourceActionList
	
	#endregion ItemInProjectDataSourceDesigner
	
	#region ItemInProjectSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemInProjectDataSource.SelectMethod property.
	/// </summary>
	public enum ItemInProjectSelectMethod
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
		/// Represents the GetByItemInProjectId method.
		/// </summary>
		GetByItemInProjectId,
		/// <summary>
		/// Represents the GetByPriceUnitId method.
		/// </summary>
		GetByPriceUnitId,
		/// <summary>
		/// Represents the GetByContractId method.
		/// </summary>
		GetByContractId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId,
		/// <summary>
		/// Represents the GetByProjectId method.
		/// </summary>
		GetByProjectId
	}
	
	#endregion ItemInProjectSelectMethod

	#region ItemInProjectFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInProject"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInProjectFilter : SqlFilter<ItemInProjectColumn>
	{
	}
	
	#endregion ItemInProjectFilter

	#region ItemInProjectProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemInProjectChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemInProject"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemInProjectProperty : ChildEntityProperty<ItemInProjectChildEntityTypes>
	{
	}
	
	#endregion ItemInProjectProperty
}

