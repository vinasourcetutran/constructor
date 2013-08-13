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
	/// Represents the DataRepository.RoleOfStaffProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RoleOfStaffDataSourceDesigner))]
	public class RoleOfStaffDataSource : ProviderDataSource<RoleOfStaff, RoleOfStaffKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffDataSource class.
		/// </summary>
		public RoleOfStaffDataSource() : base(new RoleOfStaffService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RoleOfStaffDataSourceView used by the RoleOfStaffDataSource.
		/// </summary>
		protected RoleOfStaffDataSourceView RoleOfStaffView
		{
			get { return ( View as RoleOfStaffDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RoleOfStaffDataSource control invokes to retrieve data.
		/// </summary>
		public RoleOfStaffSelectMethod SelectMethod
		{
			get
			{
				RoleOfStaffSelectMethod selectMethod = RoleOfStaffSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RoleOfStaffSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RoleOfStaffDataSourceView class that is to be
		/// used by the RoleOfStaffDataSource.
		/// </summary>
		/// <returns>An instance of the RoleOfStaffDataSourceView class.</returns>
		protected override BaseDataSourceView<RoleOfStaff, RoleOfStaffKey> GetNewDataSourceView()
		{
			return new RoleOfStaffDataSourceView(this, DefaultViewName);
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
	/// Supports the RoleOfStaffDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RoleOfStaffDataSourceView : ProviderDataSourceView<RoleOfStaff, RoleOfStaffKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RoleOfStaffDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RoleOfStaffDataSourceView(RoleOfStaffDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RoleOfStaffDataSource RoleOfStaffOwner
		{
			get { return Owner as RoleOfStaffDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RoleOfStaffSelectMethod SelectMethod
		{
			get { return RoleOfStaffOwner.SelectMethod; }
			set { RoleOfStaffOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RoleOfStaffService RoleOfStaffProvider
		{
			get { return Provider as RoleOfStaffService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<RoleOfStaff> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<RoleOfStaff> results = null;
			RoleOfStaff item;
			count = 0;
			
			System.Int32 roleOfStaffId;
			System.Int32 staffId;
			System.Int32 roleId;

			switch ( SelectMethod )
			{
				case RoleOfStaffSelectMethod.Get:
					RoleOfStaffKey entityKey  = new RoleOfStaffKey();
					entityKey.Load(values);
					item = RoleOfStaffProvider.Get(entityKey);
					results = new TList<RoleOfStaff>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RoleOfStaffSelectMethod.GetAll:
                    results = RoleOfStaffProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RoleOfStaffSelectMethod.GetPaged:
					results = RoleOfStaffProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RoleOfStaffSelectMethod.Find:
					if ( FilterParameters != null )
						results = RoleOfStaffProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RoleOfStaffProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RoleOfStaffSelectMethod.GetByRoleOfStaffId:
					roleOfStaffId = ( values["RoleOfStaffId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RoleOfStaffId"], typeof(System.Int32)) : (int)0;
					item = RoleOfStaffProvider.GetByRoleOfStaffId(roleOfStaffId);
					results = new TList<RoleOfStaff>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case RoleOfStaffSelectMethod.GetByStaffId:
					staffId = ( values["StaffId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["StaffId"], typeof(System.Int32)) : (int)0;
					results = RoleOfStaffProvider.GetByStaffId(staffId, this.StartIndex, this.PageSize, out count);
					break;
				case RoleOfStaffSelectMethod.GetByRoleId:
					roleId = ( values["RoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RoleId"], typeof(System.Int32)) : (int)0;
					results = RoleOfStaffProvider.GetByRoleId(roleId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == RoleOfStaffSelectMethod.Get || SelectMethod == RoleOfStaffSelectMethod.GetByRoleOfStaffId )
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
				RoleOfStaff entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RoleOfStaffProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<RoleOfStaff> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RoleOfStaffProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RoleOfStaffDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RoleOfStaffDataSource class.
	/// </summary>
	public class RoleOfStaffDataSourceDesigner : ProviderDataSourceDesigner<RoleOfStaff, RoleOfStaffKey>
	{
		/// <summary>
		/// Initializes a new instance of the RoleOfStaffDataSourceDesigner class.
		/// </summary>
		public RoleOfStaffDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RoleOfStaffSelectMethod SelectMethod
		{
			get { return ((RoleOfStaffDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RoleOfStaffDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RoleOfStaffDataSourceActionList

	/// <summary>
	/// Supports the RoleOfStaffDataSourceDesigner class.
	/// </summary>
	internal class RoleOfStaffDataSourceActionList : DesignerActionList
	{
		private RoleOfStaffDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RoleOfStaffDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RoleOfStaffDataSourceActionList(RoleOfStaffDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RoleOfStaffSelectMethod SelectMethod
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

	#endregion RoleOfStaffDataSourceActionList
	
	#endregion RoleOfStaffDataSourceDesigner
	
	#region RoleOfStaffSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RoleOfStaffDataSource.SelectMethod property.
	/// </summary>
	public enum RoleOfStaffSelectMethod
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
		/// Represents the GetByRoleOfStaffId method.
		/// </summary>
		GetByRoleOfStaffId,
		/// <summary>
		/// Represents the GetByStaffId method.
		/// </summary>
		GetByStaffId,
		/// <summary>
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId
	}
	
	#endregion RoleOfStaffSelectMethod

	#region RoleOfStaffFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RoleOfStaff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleOfStaffFilter : SqlFilter<RoleOfStaffColumn>
	{
	}
	
	#endregion RoleOfStaffFilter

	#region RoleOfStaffProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RoleOfStaffChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="RoleOfStaff"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RoleOfStaffProperty : ChildEntityProperty<RoleOfStaffChildEntityTypes>
	{
	}
	
	#endregion RoleOfStaffProperty
}

