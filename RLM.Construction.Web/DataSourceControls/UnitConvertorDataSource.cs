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
	/// Represents the DataRepository.UnitConvertorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UnitConvertorDataSourceDesigner))]
	public class UnitConvertorDataSource : ProviderDataSource<UnitConvertor, UnitConvertorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitConvertorDataSource class.
		/// </summary>
		public UnitConvertorDataSource() : base(new UnitConvertorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UnitConvertorDataSourceView used by the UnitConvertorDataSource.
		/// </summary>
		protected UnitConvertorDataSourceView UnitConvertorView
		{
			get { return ( View as UnitConvertorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UnitConvertorDataSource control invokes to retrieve data.
		/// </summary>
		public UnitConvertorSelectMethod SelectMethod
		{
			get
			{
				UnitConvertorSelectMethod selectMethod = UnitConvertorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UnitConvertorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UnitConvertorDataSourceView class that is to be
		/// used by the UnitConvertorDataSource.
		/// </summary>
		/// <returns>An instance of the UnitConvertorDataSourceView class.</returns>
		protected override BaseDataSourceView<UnitConvertor, UnitConvertorKey> GetNewDataSourceView()
		{
			return new UnitConvertorDataSourceView(this, DefaultViewName);
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
	/// Supports the UnitConvertorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UnitConvertorDataSourceView : ProviderDataSourceView<UnitConvertor, UnitConvertorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UnitConvertorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UnitConvertorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UnitConvertorDataSourceView(UnitConvertorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UnitConvertorDataSource UnitConvertorOwner
		{
			get { return Owner as UnitConvertorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UnitConvertorSelectMethod SelectMethod
		{
			get { return UnitConvertorOwner.SelectMethod; }
			set { UnitConvertorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UnitConvertorService UnitConvertorProvider
		{
			get { return Provider as UnitConvertorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<UnitConvertor> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<UnitConvertor> results = null;
			UnitConvertor item;
			count = 0;
			
			System.Int32 unitConvertorId;
			System.Int32 fromUnitId;
			System.Int32 toUnitId;

			switch ( SelectMethod )
			{
				case UnitConvertorSelectMethod.Get:
					UnitConvertorKey entityKey  = new UnitConvertorKey();
					entityKey.Load(values);
					item = UnitConvertorProvider.Get(entityKey);
					results = new TList<UnitConvertor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UnitConvertorSelectMethod.GetAll:
                    results = UnitConvertorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case UnitConvertorSelectMethod.GetPaged:
					results = UnitConvertorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UnitConvertorSelectMethod.Find:
					if ( FilterParameters != null )
						results = UnitConvertorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UnitConvertorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UnitConvertorSelectMethod.GetByUnitConvertorId:
					unitConvertorId = ( values["UnitConvertorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UnitConvertorId"], typeof(System.Int32)) : (int)0;
					item = UnitConvertorProvider.GetByUnitConvertorId(unitConvertorId);
					results = new TList<UnitConvertor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case UnitConvertorSelectMethod.GetByFromUnitId:
					fromUnitId = ( values["FromUnitId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FromUnitId"], typeof(System.Int32)) : (int)0;
					results = UnitConvertorProvider.GetByFromUnitId(fromUnitId, this.StartIndex, this.PageSize, out count);
					break;
				case UnitConvertorSelectMethod.GetByToUnitId:
					toUnitId = ( values["ToUnitId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ToUnitId"], typeof(System.Int32)) : (int)0;
					results = UnitConvertorProvider.GetByToUnitId(toUnitId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == UnitConvertorSelectMethod.Get || SelectMethod == UnitConvertorSelectMethod.GetByUnitConvertorId )
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
				UnitConvertor entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					UnitConvertorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<UnitConvertor> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			UnitConvertorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UnitConvertorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UnitConvertorDataSource class.
	/// </summary>
	public class UnitConvertorDataSourceDesigner : ProviderDataSourceDesigner<UnitConvertor, UnitConvertorKey>
	{
		/// <summary>
		/// Initializes a new instance of the UnitConvertorDataSourceDesigner class.
		/// </summary>
		public UnitConvertorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitConvertorSelectMethod SelectMethod
		{
			get { return ((UnitConvertorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UnitConvertorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UnitConvertorDataSourceActionList

	/// <summary>
	/// Supports the UnitConvertorDataSourceDesigner class.
	/// </summary>
	internal class UnitConvertorDataSourceActionList : DesignerActionList
	{
		private UnitConvertorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UnitConvertorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UnitConvertorDataSourceActionList(UnitConvertorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UnitConvertorSelectMethod SelectMethod
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

	#endregion UnitConvertorDataSourceActionList
	
	#endregion UnitConvertorDataSourceDesigner
	
	#region UnitConvertorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UnitConvertorDataSource.SelectMethod property.
	/// </summary>
	public enum UnitConvertorSelectMethod
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
		/// Represents the GetByUnitConvertorId method.
		/// </summary>
		GetByUnitConvertorId,
		/// <summary>
		/// Represents the GetByFromUnitId method.
		/// </summary>
		GetByFromUnitId,
		/// <summary>
		/// Represents the GetByToUnitId method.
		/// </summary>
		GetByToUnitId
	}
	
	#endregion UnitConvertorSelectMethod

	#region UnitConvertorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UnitConvertor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitConvertorFilter : SqlFilter<UnitConvertorColumn>
	{
	}
	
	#endregion UnitConvertorFilter

	#region UnitConvertorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UnitConvertorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="UnitConvertor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UnitConvertorProperty : ChildEntityProperty<UnitConvertorChildEntityTypes>
	{
	}
	
	#endregion UnitConvertorProperty
}

