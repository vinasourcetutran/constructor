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
	/// Represents the DataRepository.ContactorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ContactorDataSourceDesigner))]
	public class ContactorDataSource : ProviderDataSource<Contactor, ContactorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactorDataSource class.
		/// </summary>
		public ContactorDataSource() : base(new ContactorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ContactorDataSourceView used by the ContactorDataSource.
		/// </summary>
		protected ContactorDataSourceView ContactorView
		{
			get { return ( View as ContactorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ContactorDataSource control invokes to retrieve data.
		/// </summary>
		public ContactorSelectMethod SelectMethod
		{
			get
			{
				ContactorSelectMethod selectMethod = ContactorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ContactorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ContactorDataSourceView class that is to be
		/// used by the ContactorDataSource.
		/// </summary>
		/// <returns>An instance of the ContactorDataSourceView class.</returns>
		protected override BaseDataSourceView<Contactor, ContactorKey> GetNewDataSourceView()
		{
			return new ContactorDataSourceView(this, DefaultViewName);
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
	/// Supports the ContactorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ContactorDataSourceView : ProviderDataSourceView<Contactor, ContactorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ContactorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ContactorDataSourceView(ContactorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ContactorDataSource ContactorOwner
		{
			get { return Owner as ContactorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ContactorSelectMethod SelectMethod
		{
			get { return ContactorOwner.SelectMethod; }
			set { ContactorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ContactorService ContactorProvider
		{
			get { return Provider as ContactorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Contactor> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Contactor> results = null;
			Contactor item;
			count = 0;
			
			System.Int32 contactorId;

			switch ( SelectMethod )
			{
				case ContactorSelectMethod.Get:
					ContactorKey entityKey  = new ContactorKey();
					entityKey.Load(values);
					item = ContactorProvider.Get(entityKey);
					results = new TList<Contactor>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContactorSelectMethod.GetAll:
                    results = ContactorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ContactorSelectMethod.GetPaged:
					results = ContactorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ContactorSelectMethod.Find:
					if ( FilterParameters != null )
						results = ContactorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ContactorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ContactorSelectMethod.GetByContactorId:
					contactorId = ( values["ContactorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContactorId"], typeof(System.Int32)) : (int)0;
					item = ContactorProvider.GetByContactorId(contactorId);
					results = new TList<Contactor>();
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
			if ( SelectMethod == ContactorSelectMethod.Get || SelectMethod == ContactorSelectMethod.GetByContactorId )
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
				Contactor entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ContactorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Contactor> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ContactorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ContactorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ContactorDataSource class.
	/// </summary>
	public class ContactorDataSourceDesigner : ProviderDataSourceDesigner<Contactor, ContactorKey>
	{
		/// <summary>
		/// Initializes a new instance of the ContactorDataSourceDesigner class.
		/// </summary>
		public ContactorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactorSelectMethod SelectMethod
		{
			get { return ((ContactorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ContactorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ContactorDataSourceActionList

	/// <summary>
	/// Supports the ContactorDataSourceDesigner class.
	/// </summary>
	internal class ContactorDataSourceActionList : DesignerActionList
	{
		private ContactorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ContactorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ContactorDataSourceActionList(ContactorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContactorSelectMethod SelectMethod
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

	#endregion ContactorDataSourceActionList
	
	#endregion ContactorDataSourceDesigner
	
	#region ContactorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ContactorDataSource.SelectMethod property.
	/// </summary>
	public enum ContactorSelectMethod
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
		/// Represents the GetByContactorId method.
		/// </summary>
		GetByContactorId
	}
	
	#endregion ContactorSelectMethod

	#region ContactorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contactor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactorFilter : SqlFilter<ContactorColumn>
	{
	}
	
	#endregion ContactorFilter

	#region ContactorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ContactorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Contactor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactorProperty : ChildEntityProperty<ContactorChildEntityTypes>
	{
	}
	
	#endregion ContactorProperty
}

