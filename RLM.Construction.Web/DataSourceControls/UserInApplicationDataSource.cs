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
	/// Represents the DataRepository.UserInApplicationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UserInApplicationDataSourceDesigner))]
	public class UserInApplicationDataSource : ProviderDataSource<UserInApplication, UserInApplicationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserInApplicationDataSource class.
		/// </summary>
		public UserInApplicationDataSource() : base(new UserInApplicationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UserInApplicationDataSourceView used by the UserInApplicationDataSource.
		/// </summary>
		protected UserInApplicationDataSourceView UserInApplicationView
		{
			get { return ( View as UserInApplicationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UserInApplicationDataSource control invokes to retrieve data.
		/// </summary>
		public UserInApplicationSelectMethod SelectMethod
		{
			get
			{
				UserInApplicationSelectMethod selectMethod = UserInApplicationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UserInApplicationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UserInApplicationDataSourceView class that is to be
		/// used by the UserInApplicationDataSource.
		/// </summary>
		/// <returns>An instance of the UserInApplicationDataSourceView class.</returns>
		protected override BaseDataSourceView<UserInApplication, UserInApplicationKey> GetNewDataSourceView()
		{
			return new UserInApplicationDataSourceView(this, DefaultViewName);
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
	/// Supports the UserInApplicationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UserInApplicationDataSourceView : ProviderDataSourceView<UserInApplication, UserInApplicationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserInApplicationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UserInApplicationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UserInApplicationDataSourceView(UserInApplicationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UserInApplicationDataSource UserInApplicationOwner
		{
			get { return Owner as UserInApplicationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UserInApplicationSelectMethod SelectMethod
		{
			get { return UserInApplicationOwner.SelectMethod; }
			set { UserInApplicationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UserInApplicationService UserInApplicationProvider
		{
			get { return Provider as UserInApplicationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<UserInApplication> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<UserInApplication> results = null;
			UserInApplication item;
			count = 0;
			
			System.Int32 userInApplicationId;

			switch ( SelectMethod )
			{
				case UserInApplicationSelectMethod.Get:
					UserInApplicationKey entityKey  = new UserInApplicationKey();
					entityKey.Load(values);
					item = UserInApplicationProvider.Get(entityKey);
					results = new TList<UserInApplication>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UserInApplicationSelectMethod.GetAll:
                    results = UserInApplicationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case UserInApplicationSelectMethod.GetPaged:
					results = UserInApplicationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UserInApplicationSelectMethod.Find:
					if ( FilterParameters != null )
						results = UserInApplicationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UserInApplicationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UserInApplicationSelectMethod.GetByUserInApplicationId:
					userInApplicationId = ( values["UserInApplicationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserInApplicationId"], typeof(System.Int32)) : (int)0;
					item = UserInApplicationProvider.GetByUserInApplicationId(userInApplicationId);
					results = new TList<UserInApplication>();
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
			if ( SelectMethod == UserInApplicationSelectMethod.Get || SelectMethod == UserInApplicationSelectMethod.GetByUserInApplicationId )
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
				UserInApplication entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					UserInApplicationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<UserInApplication> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			UserInApplicationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UserInApplicationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UserInApplicationDataSource class.
	/// </summary>
	public class UserInApplicationDataSourceDesigner : ProviderDataSourceDesigner<UserInApplication, UserInApplicationKey>
	{
		/// <summary>
		/// Initializes a new instance of the UserInApplicationDataSourceDesigner class.
		/// </summary>
		public UserInApplicationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserInApplicationSelectMethod SelectMethod
		{
			get { return ((UserInApplicationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UserInApplicationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UserInApplicationDataSourceActionList

	/// <summary>
	/// Supports the UserInApplicationDataSourceDesigner class.
	/// </summary>
	internal class UserInApplicationDataSourceActionList : DesignerActionList
	{
		private UserInApplicationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UserInApplicationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UserInApplicationDataSourceActionList(UserInApplicationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserInApplicationSelectMethod SelectMethod
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

	#endregion UserInApplicationDataSourceActionList
	
	#endregion UserInApplicationDataSourceDesigner
	
	#region UserInApplicationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UserInApplicationDataSource.SelectMethod property.
	/// </summary>
	public enum UserInApplicationSelectMethod
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
		/// Represents the GetByUserInApplicationId method.
		/// </summary>
		GetByUserInApplicationId
	}
	
	#endregion UserInApplicationSelectMethod

	#region UserInApplicationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserInApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserInApplicationFilter : SqlFilter<UserInApplicationColumn>
	{
	}
	
	#endregion UserInApplicationFilter

	#region UserInApplicationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UserInApplicationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="UserInApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserInApplicationProperty : ChildEntityProperty<UserInApplicationChildEntityTypes>
	{
	}
	
	#endregion UserInApplicationProperty
}

