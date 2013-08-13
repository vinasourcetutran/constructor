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
	/// Represents the DataRepository.IdentificationInfomationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(IdentificationInfomationDataSourceDesigner))]
	public class IdentificationInfomationDataSource : ProviderDataSource<IdentificationInfomation, IdentificationInfomationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationDataSource class.
		/// </summary>
		public IdentificationInfomationDataSource() : base(new IdentificationInfomationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the IdentificationInfomationDataSourceView used by the IdentificationInfomationDataSource.
		/// </summary>
		protected IdentificationInfomationDataSourceView IdentificationInfomationView
		{
			get { return ( View as IdentificationInfomationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the IdentificationInfomationDataSource control invokes to retrieve data.
		/// </summary>
		public IdentificationInfomationSelectMethod SelectMethod
		{
			get
			{
				IdentificationInfomationSelectMethod selectMethod = IdentificationInfomationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (IdentificationInfomationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the IdentificationInfomationDataSourceView class that is to be
		/// used by the IdentificationInfomationDataSource.
		/// </summary>
		/// <returns>An instance of the IdentificationInfomationDataSourceView class.</returns>
		protected override BaseDataSourceView<IdentificationInfomation, IdentificationInfomationKey> GetNewDataSourceView()
		{
			return new IdentificationInfomationDataSourceView(this, DefaultViewName);
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
	/// Supports the IdentificationInfomationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class IdentificationInfomationDataSourceView : ProviderDataSourceView<IdentificationInfomation, IdentificationInfomationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the IdentificationInfomationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public IdentificationInfomationDataSourceView(IdentificationInfomationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal IdentificationInfomationDataSource IdentificationInfomationOwner
		{
			get { return Owner as IdentificationInfomationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal IdentificationInfomationSelectMethod SelectMethod
		{
			get { return IdentificationInfomationOwner.SelectMethod; }
			set { IdentificationInfomationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal IdentificationInfomationService IdentificationInfomationProvider
		{
			get { return Provider as IdentificationInfomationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<IdentificationInfomation> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<IdentificationInfomation> results = null;
			IdentificationInfomation item;
			count = 0;
			
			System.Int32 identificationInfomationId;

			switch ( SelectMethod )
			{
				case IdentificationInfomationSelectMethod.Get:
					IdentificationInfomationKey entityKey  = new IdentificationInfomationKey();
					entityKey.Load(values);
					item = IdentificationInfomationProvider.Get(entityKey);
					results = new TList<IdentificationInfomation>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case IdentificationInfomationSelectMethod.GetAll:
                    results = IdentificationInfomationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case IdentificationInfomationSelectMethod.GetPaged:
					results = IdentificationInfomationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case IdentificationInfomationSelectMethod.Find:
					if ( FilterParameters != null )
						results = IdentificationInfomationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = IdentificationInfomationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case IdentificationInfomationSelectMethod.GetByIdentificationInfomationId:
					identificationInfomationId = ( values["IdentificationInfomationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdentificationInfomationId"], typeof(System.Int32)) : (int)0;
					item = IdentificationInfomationProvider.GetByIdentificationInfomationId(identificationInfomationId);
					results = new TList<IdentificationInfomation>();
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
			if ( SelectMethod == IdentificationInfomationSelectMethod.Get || SelectMethod == IdentificationInfomationSelectMethod.GetByIdentificationInfomationId )
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
				IdentificationInfomation entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					IdentificationInfomationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<IdentificationInfomation> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			IdentificationInfomationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region IdentificationInfomationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the IdentificationInfomationDataSource class.
	/// </summary>
	public class IdentificationInfomationDataSourceDesigner : ProviderDataSourceDesigner<IdentificationInfomation, IdentificationInfomationKey>
	{
		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationDataSourceDesigner class.
		/// </summary>
		public IdentificationInfomationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IdentificationInfomationSelectMethod SelectMethod
		{
			get { return ((IdentificationInfomationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new IdentificationInfomationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region IdentificationInfomationDataSourceActionList

	/// <summary>
	/// Supports the IdentificationInfomationDataSourceDesigner class.
	/// </summary>
	internal class IdentificationInfomationDataSourceActionList : DesignerActionList
	{
		private IdentificationInfomationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the IdentificationInfomationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public IdentificationInfomationDataSourceActionList(IdentificationInfomationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IdentificationInfomationSelectMethod SelectMethod
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

	#endregion IdentificationInfomationDataSourceActionList
	
	#endregion IdentificationInfomationDataSourceDesigner
	
	#region IdentificationInfomationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the IdentificationInfomationDataSource.SelectMethod property.
	/// </summary>
	public enum IdentificationInfomationSelectMethod
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
		/// Represents the GetByIdentificationInfomationId method.
		/// </summary>
		GetByIdentificationInfomationId
	}
	
	#endregion IdentificationInfomationSelectMethod

	#region IdentificationInfomationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IdentificationInfomation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IdentificationInfomationFilter : SqlFilter<IdentificationInfomationColumn>
	{
	}
	
	#endregion IdentificationInfomationFilter

	#region IdentificationInfomationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;IdentificationInfomationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="IdentificationInfomation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IdentificationInfomationProperty : ChildEntityProperty<IdentificationInfomationChildEntityTypes>
	{
	}
	
	#endregion IdentificationInfomationProperty
}

