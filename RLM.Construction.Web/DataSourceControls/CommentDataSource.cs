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
	/// Represents the DataRepository.CommentProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CommentDataSourceDesigner))]
	public class CommentDataSource : ProviderDataSource<Comment, CommentKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentDataSource class.
		/// </summary>
		public CommentDataSource() : base(new CommentService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CommentDataSourceView used by the CommentDataSource.
		/// </summary>
		protected CommentDataSourceView CommentView
		{
			get { return ( View as CommentDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CommentDataSource control invokes to retrieve data.
		/// </summary>
		public CommentSelectMethod SelectMethod
		{
			get
			{
				CommentSelectMethod selectMethod = CommentSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CommentSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CommentDataSourceView class that is to be
		/// used by the CommentDataSource.
		/// </summary>
		/// <returns>An instance of the CommentDataSourceView class.</returns>
		protected override BaseDataSourceView<Comment, CommentKey> GetNewDataSourceView()
		{
			return new CommentDataSourceView(this, DefaultViewName);
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
	/// Supports the CommentDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CommentDataSourceView : ProviderDataSourceView<Comment, CommentKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CommentDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CommentDataSourceView(CommentDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CommentDataSource CommentOwner
		{
			get { return Owner as CommentDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CommentSelectMethod SelectMethod
		{
			get { return CommentOwner.SelectMethod; }
			set { CommentOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CommentService CommentProvider
		{
			get { return Provider as CommentService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Comment> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Comment> results = null;
			Comment item;
			count = 0;
			
			System.Int32 commentId;

			switch ( SelectMethod )
			{
				case CommentSelectMethod.Get:
					CommentKey entityKey  = new CommentKey();
					entityKey.Load(values);
					item = CommentProvider.Get(entityKey);
					results = new TList<Comment>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CommentSelectMethod.GetAll:
                    results = CommentProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CommentSelectMethod.GetPaged:
					results = CommentProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CommentSelectMethod.Find:
					if ( FilterParameters != null )
						results = CommentProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CommentProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CommentSelectMethod.GetByCommentId:
					commentId = ( values["CommentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CommentId"], typeof(System.Int32)) : (int)0;
					item = CommentProvider.GetByCommentId(commentId);
					results = new TList<Comment>();
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
			if ( SelectMethod == CommentSelectMethod.Get || SelectMethod == CommentSelectMethod.GetByCommentId )
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
				Comment entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CommentProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Comment> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CommentProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CommentDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CommentDataSource class.
	/// </summary>
	public class CommentDataSourceDesigner : ProviderDataSourceDesigner<Comment, CommentKey>
	{
		/// <summary>
		/// Initializes a new instance of the CommentDataSourceDesigner class.
		/// </summary>
		public CommentDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommentSelectMethod SelectMethod
		{
			get { return ((CommentDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CommentDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CommentDataSourceActionList

	/// <summary>
	/// Supports the CommentDataSourceDesigner class.
	/// </summary>
	internal class CommentDataSourceActionList : DesignerActionList
	{
		private CommentDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CommentDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CommentDataSourceActionList(CommentDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CommentSelectMethod SelectMethod
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

	#endregion CommentDataSourceActionList
	
	#endregion CommentDataSourceDesigner
	
	#region CommentSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CommentDataSource.SelectMethod property.
	/// </summary>
	public enum CommentSelectMethod
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
		/// Represents the GetByCommentId method.
		/// </summary>
		GetByCommentId
	}
	
	#endregion CommentSelectMethod

	#region CommentFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentFilter : SqlFilter<CommentColumn>
	{
	}
	
	#endregion CommentFilter

	#region CommentProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CommentChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentProperty : ChildEntityProperty<CommentChildEntityTypes>
	{
	}
	
	#endregion CommentProperty
}

