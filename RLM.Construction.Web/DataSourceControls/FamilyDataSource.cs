﻿#region Using Directives
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
	/// Represents the DataRepository.FamilyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FamilyDataSourceDesigner))]
	public class FamilyDataSource : ProviderDataSource<Family, FamilyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FamilyDataSource class.
		/// </summary>
		public FamilyDataSource() : base(new FamilyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FamilyDataSourceView used by the FamilyDataSource.
		/// </summary>
		protected FamilyDataSourceView FamilyView
		{
			get { return ( View as FamilyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FamilyDataSource control invokes to retrieve data.
		/// </summary>
		public FamilySelectMethod SelectMethod
		{
			get
			{
				FamilySelectMethod selectMethod = FamilySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FamilySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FamilyDataSourceView class that is to be
		/// used by the FamilyDataSource.
		/// </summary>
		/// <returns>An instance of the FamilyDataSourceView class.</returns>
		protected override BaseDataSourceView<Family, FamilyKey> GetNewDataSourceView()
		{
			return new FamilyDataSourceView(this, DefaultViewName);
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
	/// Supports the FamilyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FamilyDataSourceView : ProviderDataSourceView<Family, FamilyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FamilyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FamilyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FamilyDataSourceView(FamilyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FamilyDataSource FamilyOwner
		{
			get { return Owner as FamilyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FamilySelectMethod SelectMethod
		{
			get { return FamilyOwner.SelectMethod; }
			set { FamilyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FamilyService FamilyProvider
		{
			get { return Provider as FamilyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Family> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Family> results = null;
			Family item;
			count = 0;
			
			System.Int32 familyId;

			switch ( SelectMethod )
			{
				case FamilySelectMethod.Get:
					FamilyKey entityKey  = new FamilyKey();
					entityKey.Load(values);
					item = FamilyProvider.Get(entityKey);
					results = new TList<Family>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FamilySelectMethod.GetAll:
                    results = FamilyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FamilySelectMethod.GetPaged:
					results = FamilyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FamilySelectMethod.Find:
					if ( FilterParameters != null )
						results = FamilyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FamilyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FamilySelectMethod.GetByFamilyId:
					familyId = ( values["FamilyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FamilyId"], typeof(System.Int32)) : (int)0;
					item = FamilyProvider.GetByFamilyId(familyId);
					results = new TList<Family>();
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
			if ( SelectMethod == FamilySelectMethod.Get || SelectMethod == FamilySelectMethod.GetByFamilyId )
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
				Family entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FamilyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Family> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FamilyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FamilyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FamilyDataSource class.
	/// </summary>
	public class FamilyDataSourceDesigner : ProviderDataSourceDesigner<Family, FamilyKey>
	{
		/// <summary>
		/// Initializes a new instance of the FamilyDataSourceDesigner class.
		/// </summary>
		public FamilyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FamilySelectMethod SelectMethod
		{
			get { return ((FamilyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FamilyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FamilyDataSourceActionList

	/// <summary>
	/// Supports the FamilyDataSourceDesigner class.
	/// </summary>
	internal class FamilyDataSourceActionList : DesignerActionList
	{
		private FamilyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FamilyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FamilyDataSourceActionList(FamilyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FamilySelectMethod SelectMethod
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

	#endregion FamilyDataSourceActionList
	
	#endregion FamilyDataSourceDesigner
	
	#region FamilySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FamilyDataSource.SelectMethod property.
	/// </summary>
	public enum FamilySelectMethod
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
		/// Represents the GetByFamilyId method.
		/// </summary>
		GetByFamilyId
	}
	
	#endregion FamilySelectMethod

	#region FamilyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Family"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FamilyFilter : SqlFilter<FamilyColumn>
	{
	}
	
	#endregion FamilyFilter

	#region FamilyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FamilyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Family"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FamilyProperty : ChildEntityProperty<FamilyChildEntityTypes>
	{
	}
	
	#endregion FamilyProperty
}

