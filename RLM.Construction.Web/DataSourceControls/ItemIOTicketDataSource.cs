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
	/// Represents the DataRepository.ItemIOTicketProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemIOTicketDataSourceDesigner))]
	public class ItemIOTicketDataSource : ProviderDataSource<ItemIOTicket, ItemIOTicketKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketDataSource class.
		/// </summary>
		public ItemIOTicketDataSource() : base(new ItemIOTicketService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemIOTicketDataSourceView used by the ItemIOTicketDataSource.
		/// </summary>
		protected ItemIOTicketDataSourceView ItemIOTicketView
		{
			get { return ( View as ItemIOTicketDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemIOTicketDataSource control invokes to retrieve data.
		/// </summary>
		public ItemIOTicketSelectMethod SelectMethod
		{
			get
			{
				ItemIOTicketSelectMethod selectMethod = ItemIOTicketSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemIOTicketSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemIOTicketDataSourceView class that is to be
		/// used by the ItemIOTicketDataSource.
		/// </summary>
		/// <returns>An instance of the ItemIOTicketDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemIOTicket, ItemIOTicketKey> GetNewDataSourceView()
		{
			return new ItemIOTicketDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemIOTicketDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemIOTicketDataSourceView : ProviderDataSourceView<ItemIOTicket, ItemIOTicketKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemIOTicketDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemIOTicketDataSourceView(ItemIOTicketDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemIOTicketDataSource ItemIOTicketOwner
		{
			get { return Owner as ItemIOTicketDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemIOTicketSelectMethod SelectMethod
		{
			get { return ItemIOTicketOwner.SelectMethod; }
			set { ItemIOTicketOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemIOTicketService ItemIOTicketProvider
		{
			get { return Provider as ItemIOTicketService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemIOTicket> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemIOTicket> results = null;
			ItemIOTicket item;
			count = 0;
			
			System.Int32 iOTicketId;

			switch ( SelectMethod )
			{
				case ItemIOTicketSelectMethod.Get:
					ItemIOTicketKey entityKey  = new ItemIOTicketKey();
					entityKey.Load(values);
					item = ItemIOTicketProvider.Get(entityKey);
					results = new TList<ItemIOTicket>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemIOTicketSelectMethod.GetAll:
                    results = ItemIOTicketProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ItemIOTicketSelectMethod.GetPaged:
					results = ItemIOTicketProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemIOTicketSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemIOTicketProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemIOTicketProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemIOTicketSelectMethod.GetByIOTicketId:
					iOTicketId = ( values["IOTicketId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IOTicketId"], typeof(System.Int32)) : (int)0;
					item = ItemIOTicketProvider.GetByIOTicketId(iOTicketId);
					results = new TList<ItemIOTicket>();
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
			if ( SelectMethod == ItemIOTicketSelectMethod.Get || SelectMethod == ItemIOTicketSelectMethod.GetByIOTicketId )
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
				ItemIOTicket entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ItemIOTicketProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemIOTicket> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ItemIOTicketProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemIOTicketDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemIOTicketDataSource class.
	/// </summary>
	public class ItemIOTicketDataSourceDesigner : ProviderDataSourceDesigner<ItemIOTicket, ItemIOTicketKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemIOTicketDataSourceDesigner class.
		/// </summary>
		public ItemIOTicketDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemIOTicketSelectMethod SelectMethod
		{
			get { return ((ItemIOTicketDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemIOTicketDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemIOTicketDataSourceActionList

	/// <summary>
	/// Supports the ItemIOTicketDataSourceDesigner class.
	/// </summary>
	internal class ItemIOTicketDataSourceActionList : DesignerActionList
	{
		private ItemIOTicketDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemIOTicketDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemIOTicketDataSourceActionList(ItemIOTicketDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemIOTicketSelectMethod SelectMethod
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

	#endregion ItemIOTicketDataSourceActionList
	
	#endregion ItemIOTicketDataSourceDesigner
	
	#region ItemIOTicketSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemIOTicketDataSource.SelectMethod property.
	/// </summary>
	public enum ItemIOTicketSelectMethod
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
		/// Represents the GetByIOTicketId method.
		/// </summary>
		GetByIOTicketId
	}
	
	#endregion ItemIOTicketSelectMethod

	#region ItemIOTicketFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOTicket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOTicketFilter : SqlFilter<ItemIOTicketColumn>
	{
	}
	
	#endregion ItemIOTicketFilter

	#region ItemIOTicketProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemIOTicketChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemIOTicket"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemIOTicketProperty : ChildEntityProperty<ItemIOTicketChildEntityTypes>
	{
	}
	
	#endregion ItemIOTicketProperty
}

