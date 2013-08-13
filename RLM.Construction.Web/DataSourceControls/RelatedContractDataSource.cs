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
	/// Represents the DataRepository.RelatedContractProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RelatedContractDataSourceDesigner))]
	public class RelatedContractDataSource : ProviderDataSource<RelatedContract, RelatedContractKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedContractDataSource class.
		/// </summary>
		public RelatedContractDataSource() : base(new RelatedContractService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RelatedContractDataSourceView used by the RelatedContractDataSource.
		/// </summary>
		protected RelatedContractDataSourceView RelatedContractView
		{
			get { return ( View as RelatedContractDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RelatedContractDataSource control invokes to retrieve data.
		/// </summary>
		public RelatedContractSelectMethod SelectMethod
		{
			get
			{
				RelatedContractSelectMethod selectMethod = RelatedContractSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RelatedContractSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RelatedContractDataSourceView class that is to be
		/// used by the RelatedContractDataSource.
		/// </summary>
		/// <returns>An instance of the RelatedContractDataSourceView class.</returns>
		protected override BaseDataSourceView<RelatedContract, RelatedContractKey> GetNewDataSourceView()
		{
			return new RelatedContractDataSourceView(this, DefaultViewName);
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
	/// Supports the RelatedContractDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RelatedContractDataSourceView : ProviderDataSourceView<RelatedContract, RelatedContractKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedContractDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RelatedContractDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RelatedContractDataSourceView(RelatedContractDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RelatedContractDataSource RelatedContractOwner
		{
			get { return Owner as RelatedContractDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RelatedContractSelectMethod SelectMethod
		{
			get { return RelatedContractOwner.SelectMethod; }
			set { RelatedContractOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RelatedContractService RelatedContractProvider
		{
			get { return Provider as RelatedContractService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RelatedContract> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RelatedContract> results = null;
			RelatedContract item;
			count = 0;
			
			System.Int32 relatedContractId;
			System.Int32 fromContractId;
			System.Int32 toContractId;

			switch ( SelectMethod )
			{
				case RelatedContractSelectMethod.Get:
					RelatedContractKey entityKey  = new RelatedContractKey();
					entityKey.Load(values);
					item = RelatedContractProvider.Get(entityKey);
					results = new TList<RelatedContract>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RelatedContractSelectMethod.GetAll:
                    results = RelatedContractProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RelatedContractSelectMethod.GetPaged:
					results = RelatedContractProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RelatedContractSelectMethod.Find:
					if ( FilterParameters != null )
						results = RelatedContractProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RelatedContractProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RelatedContractSelectMethod.GetByRelatedContractId:
					relatedContractId = ( values["RelatedContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RelatedContractId"], typeof(System.Int32)) : (int)0;
					item = RelatedContractProvider.GetByRelatedContractId(relatedContractId);
					results = new TList<RelatedContract>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case RelatedContractSelectMethod.GetByFromContractId:
					fromContractId = ( values["FromContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FromContractId"], typeof(System.Int32)) : (int)0;
					results = RelatedContractProvider.GetByFromContractId(fromContractId, this.StartIndex, this.PageSize, out count);
					break;
				case RelatedContractSelectMethod.GetByToContractId:
					toContractId = ( values["ToContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ToContractId"], typeof(System.Int32)) : (int)0;
					results = RelatedContractProvider.GetByToContractId(toContractId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RelatedContractSelectMethod.Get || SelectMethod == RelatedContractSelectMethod.GetByRelatedContractId )
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
				RelatedContract entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RelatedContractProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RelatedContract> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RelatedContractProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RelatedContractDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RelatedContractDataSource class.
	/// </summary>
	public class RelatedContractDataSourceDesigner : ProviderDataSourceDesigner<RelatedContract, RelatedContractKey>
	{
		/// <summary>
		/// Initializes a new instance of the RelatedContractDataSourceDesigner class.
		/// </summary>
		public RelatedContractDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RelatedContractSelectMethod SelectMethod
		{
			get { return ((RelatedContractDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RelatedContractDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RelatedContractDataSourceActionList

	/// <summary>
	/// Supports the RelatedContractDataSourceDesigner class.
	/// </summary>
	internal class RelatedContractDataSourceActionList : DesignerActionList
	{
		private RelatedContractDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RelatedContractDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RelatedContractDataSourceActionList(RelatedContractDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RelatedContractSelectMethod SelectMethod
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

	#endregion RelatedContractDataSourceActionList
	
	#endregion RelatedContractDataSourceDesigner
	
	#region RelatedContractSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RelatedContractDataSource.SelectMethod property.
	/// </summary>
	public enum RelatedContractSelectMethod
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
		/// Represents the GetByRelatedContractId method.
		/// </summary>
		GetByRelatedContractId,
		/// <summary>
		/// Represents the GetByFromContractId method.
		/// </summary>
		GetByFromContractId,
		/// <summary>
		/// Represents the GetByToContractId method.
		/// </summary>
		GetByToContractId
	}
	
	#endregion RelatedContractSelectMethod

	#region RelatedContractFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedContract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedContractFilter : SqlFilter<RelatedContractColumn>
	{
	}
	
	#endregion RelatedContractFilter

	#region RelatedContractProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RelatedContractChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedContract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedContractProperty : ChildEntityProperty<RelatedContractChildEntityTypes>
	{
	}
	
	#endregion RelatedContractProperty
}

