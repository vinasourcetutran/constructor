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
	/// Represents the DataRepository.AdvanceRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvanceRequestDataSourceDesigner))]
	public class AdvanceRequestDataSource : ProviderDataSource<AdvanceRequest, AdvanceRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestDataSource class.
		/// </summary>
		public AdvanceRequestDataSource() : base(new AdvanceRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvanceRequestDataSourceView used by the AdvanceRequestDataSource.
		/// </summary>
		protected AdvanceRequestDataSourceView AdvanceRequestView
		{
			get { return ( View as AdvanceRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvanceRequestDataSource control invokes to retrieve data.
		/// </summary>
		public AdvanceRequestSelectMethod SelectMethod
		{
			get
			{
				AdvanceRequestSelectMethod selectMethod = AdvanceRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvanceRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvanceRequestDataSourceView class that is to be
		/// used by the AdvanceRequestDataSource.
		/// </summary>
		/// <returns>An instance of the AdvanceRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvanceRequest, AdvanceRequestKey> GetNewDataSourceView()
		{
			return new AdvanceRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvanceRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvanceRequestDataSourceView : ProviderDataSourceView<AdvanceRequest, AdvanceRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvanceRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvanceRequestDataSourceView(AdvanceRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvanceRequestDataSource AdvanceRequestOwner
		{
			get { return Owner as AdvanceRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvanceRequestSelectMethod SelectMethod
		{
			get { return AdvanceRequestOwner.SelectMethod; }
			set { AdvanceRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvanceRequestService AdvanceRequestProvider
		{
			get { return Provider as AdvanceRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvanceRequest> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvanceRequest> results = null;
			AdvanceRequest item;
			count = 0;
			
			System.Int32 advanceRequestId;

			switch ( SelectMethod )
			{
				case AdvanceRequestSelectMethod.Get:
					AdvanceRequestKey entityKey  = new AdvanceRequestKey();
					entityKey.Load(values);
					item = AdvanceRequestProvider.Get(entityKey);
					results = new TList<AdvanceRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvanceRequestSelectMethod.GetAll:
                    results = AdvanceRequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvanceRequestSelectMethod.GetPaged:
					results = AdvanceRequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvanceRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvanceRequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvanceRequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvanceRequestSelectMethod.GetByAdvanceRequestId:
					advanceRequestId = ( values["AdvanceRequestId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvanceRequestId"], typeof(System.Int32)) : (int)0;
					item = AdvanceRequestProvider.GetByAdvanceRequestId(advanceRequestId);
					results = new TList<AdvanceRequest>();
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
			if ( SelectMethod == AdvanceRequestSelectMethod.Get || SelectMethod == AdvanceRequestSelectMethod.GetByAdvanceRequestId )
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
				AdvanceRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvanceRequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvanceRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvanceRequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvanceRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvanceRequestDataSource class.
	/// </summary>
	public class AdvanceRequestDataSourceDesigner : ProviderDataSourceDesigner<AdvanceRequest, AdvanceRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvanceRequestDataSourceDesigner class.
		/// </summary>
		public AdvanceRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvanceRequestSelectMethod SelectMethod
		{
			get { return ((AdvanceRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvanceRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvanceRequestDataSourceActionList

	/// <summary>
	/// Supports the AdvanceRequestDataSourceDesigner class.
	/// </summary>
	internal class AdvanceRequestDataSourceActionList : DesignerActionList
	{
		private AdvanceRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvanceRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvanceRequestDataSourceActionList(AdvanceRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvanceRequestSelectMethod SelectMethod
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

	#endregion AdvanceRequestDataSourceActionList
	
	#endregion AdvanceRequestDataSourceDesigner
	
	#region AdvanceRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvanceRequestDataSource.SelectMethod property.
	/// </summary>
	public enum AdvanceRequestSelectMethod
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
		/// Represents the GetByAdvanceRequestId method.
		/// </summary>
		GetByAdvanceRequestId
	}
	
	#endregion AdvanceRequestSelectMethod

	#region AdvanceRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvanceRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvanceRequestFilter : SqlFilter<AdvanceRequestColumn>
	{
	}
	
	#endregion AdvanceRequestFilter

	#region AdvanceRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvanceRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvanceRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvanceRequestProperty : ChildEntityProperty<AdvanceRequestChildEntityTypes>
	{
	}
	
	#endregion AdvanceRequestProperty
}

