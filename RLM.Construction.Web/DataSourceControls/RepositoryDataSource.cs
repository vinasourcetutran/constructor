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
	/// Represents the DataRepository.RepositoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RepositoryDataSourceDesigner))]
	public class RepositoryDataSource : ProviderDataSource<Repository, RepositoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepositoryDataSource class.
		/// </summary>
		public RepositoryDataSource() : base(new RepositoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RepositoryDataSourceView used by the RepositoryDataSource.
		/// </summary>
		protected RepositoryDataSourceView RepositoryView
		{
			get { return ( View as RepositoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RepositoryDataSource control invokes to retrieve data.
		/// </summary>
		public RepositorySelectMethod SelectMethod
		{
			get
			{
				RepositorySelectMethod selectMethod = RepositorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RepositorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RepositoryDataSourceView class that is to be
		/// used by the RepositoryDataSource.
		/// </summary>
		/// <returns>An instance of the RepositoryDataSourceView class.</returns>
		protected override BaseDataSourceView<Repository, RepositoryKey> GetNewDataSourceView()
		{
			return new RepositoryDataSourceView(this, DefaultViewName);
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
	/// Supports the RepositoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RepositoryDataSourceView : ProviderDataSourceView<Repository, RepositoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RepositoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RepositoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RepositoryDataSourceView(RepositoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RepositoryDataSource RepositoryOwner
		{
			get { return Owner as RepositoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RepositorySelectMethod SelectMethod
		{
			get { return RepositoryOwner.SelectMethod; }
			set { RepositoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RepositoryService RepositoryProvider
		{
			get { return Provider as RepositoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Repository> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Repository> results = null;
			Repository item;
			count = 0;
			
			System.Int32 repositoryId;
			System.Int64 itemId;

			switch ( SelectMethod )
			{
				case RepositorySelectMethod.Get:
					RepositoryKey entityKey  = new RepositoryKey();
					entityKey.Load(values);
					item = RepositoryProvider.Get(entityKey);
					results = new TList<Repository>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RepositorySelectMethod.GetAll:
                    results = RepositoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RepositorySelectMethod.GetPaged:
					results = RepositoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RepositorySelectMethod.Find:
					if ( FilterParameters != null )
						results = RepositoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RepositoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RepositorySelectMethod.GetByRepositoryId:
					repositoryId = ( values["RepositoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RepositoryId"], typeof(System.Int32)) : (int)0;
					item = RepositoryProvider.GetByRepositoryId(repositoryId);
					results = new TList<Repository>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case RepositorySelectMethod.GetByItemIdFromItemInRepository:
					itemId = ( values["ItemId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int64)) : (long)0;
					results = RepositoryProvider.GetByItemIdFromItemInRepository(itemId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == RepositorySelectMethod.Get || SelectMethod == RepositorySelectMethod.GetByRepositoryId )
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
				Repository entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RepositoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Repository> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RepositoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RepositoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RepositoryDataSource class.
	/// </summary>
	public class RepositoryDataSourceDesigner : ProviderDataSourceDesigner<Repository, RepositoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the RepositoryDataSourceDesigner class.
		/// </summary>
		public RepositoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RepositorySelectMethod SelectMethod
		{
			get { return ((RepositoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RepositoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RepositoryDataSourceActionList

	/// <summary>
	/// Supports the RepositoryDataSourceDesigner class.
	/// </summary>
	internal class RepositoryDataSourceActionList : DesignerActionList
	{
		private RepositoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RepositoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RepositoryDataSourceActionList(RepositoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RepositorySelectMethod SelectMethod
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

	#endregion RepositoryDataSourceActionList
	
	#endregion RepositoryDataSourceDesigner
	
	#region RepositorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RepositoryDataSource.SelectMethod property.
	/// </summary>
	public enum RepositorySelectMethod
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
		/// Represents the GetByRepositoryId method.
		/// </summary>
		GetByRepositoryId,
		/// <summary>
		/// Represents the GetByItemIdFromItemInRepository method.
		/// </summary>
		GetByItemIdFromItemInRepository
	}
	
	#endregion RepositorySelectMethod

	#region RepositoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Repository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepositoryFilter : SqlFilter<RepositoryColumn>
	{
	}
	
	#endregion RepositoryFilter

	#region RepositoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RepositoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Repository"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RepositoryProperty : ChildEntityProperty<RepositoryChildEntityTypes>
	{
	}
	
	#endregion RepositoryProperty
}

