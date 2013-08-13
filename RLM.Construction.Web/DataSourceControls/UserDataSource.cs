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
	/// Represents the DataRepository.UserProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UserDataSourceDesigner))]
	public class UserDataSource : ProviderDataSource<User, UserKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserDataSource class.
		/// </summary>
		public UserDataSource() : base(new UserService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UserDataSourceView used by the UserDataSource.
		/// </summary>
		protected UserDataSourceView UserView
		{
			get { return ( View as UserDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UserDataSource control invokes to retrieve data.
		/// </summary>
		public UserSelectMethod SelectMethod
		{
			get
			{
				UserSelectMethod selectMethod = UserSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UserSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UserDataSourceView class that is to be
		/// used by the UserDataSource.
		/// </summary>
		/// <returns>An instance of the UserDataSourceView class.</returns>
		protected override BaseDataSourceView<User, UserKey> GetNewDataSourceView()
		{
			return new UserDataSourceView(this, DefaultViewName);
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
	/// Supports the UserDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UserDataSourceView : ProviderDataSourceView<User, UserKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UserDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UserDataSourceView(UserDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UserDataSource UserOwner
		{
			get { return Owner as UserDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UserSelectMethod SelectMethod
		{
			get { return UserOwner.SelectMethod; }
			set { UserOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UserService UserProvider
		{
			get { return Provider as UserService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<User> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<User> results = null;
			User item;
			count = 0;
			
			System.Int32 userId;
			System.Int32? userGroupId;

			switch ( SelectMethod )
			{
				case UserSelectMethod.Get:
					UserKey entityKey  = new UserKey();
					entityKey.Load(values);
					item = UserProvider.Get(entityKey);
					results = new TList<User>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UserSelectMethod.GetAll:
                    results = UserProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case UserSelectMethod.GetPaged:
					results = UserProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UserSelectMethod.Find:
					if ( FilterParameters != null )
						results = UserProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UserProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UserSelectMethod.GetByUserId:
					userId = ( values["UserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32)) : (int)0;
					item = UserProvider.GetByUserId(userId);
					results = new TList<User>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case UserSelectMethod.GetByUserGroupId:
					userGroupId = (System.Int32?) EntityUtil.ChangeType(values["UserGroupId"], typeof(System.Int32?));
					results = UserProvider.GetByUserGroupId(userGroupId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == UserSelectMethod.Get || SelectMethod == UserSelectMethod.GetByUserId )
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
				User entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					UserProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<User> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			UserProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UserDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UserDataSource class.
	/// </summary>
	public class UserDataSourceDesigner : ProviderDataSourceDesigner<User, UserKey>
	{
		/// <summary>
		/// Initializes a new instance of the UserDataSourceDesigner class.
		/// </summary>
		public UserDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserSelectMethod SelectMethod
		{
			get { return ((UserDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UserDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UserDataSourceActionList

	/// <summary>
	/// Supports the UserDataSourceDesigner class.
	/// </summary>
	internal class UserDataSourceActionList : DesignerActionList
	{
		private UserDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UserDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UserDataSourceActionList(UserDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserSelectMethod SelectMethod
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

	#endregion UserDataSourceActionList
	
	#endregion UserDataSourceDesigner
	
	#region UserSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UserDataSource.SelectMethod property.
	/// </summary>
	public enum UserSelectMethod
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
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByUserGroupId method.
		/// </summary>
		GetByUserGroupId
	}
	
	#endregion UserSelectMethod

	#region UserFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilter : SqlFilter<UserColumn>
	{
	}
	
	#endregion UserFilter

	#region UserProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UserChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserProperty : ChildEntityProperty<UserChildEntityTypes>
	{
	}
	
	#endregion UserProperty
}

