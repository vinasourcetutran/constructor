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
	/// Represents the DataRepository.TaskMemberProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TaskMemberDataSourceDesigner))]
	public class TaskMemberDataSource : ProviderDataSource<TaskMember, TaskMemberKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskMemberDataSource class.
		/// </summary>
		public TaskMemberDataSource() : base(new TaskMemberService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TaskMemberDataSourceView used by the TaskMemberDataSource.
		/// </summary>
		protected TaskMemberDataSourceView TaskMemberView
		{
			get { return ( View as TaskMemberDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TaskMemberDataSource control invokes to retrieve data.
		/// </summary>
		public TaskMemberSelectMethod SelectMethod
		{
			get
			{
				TaskMemberSelectMethod selectMethod = TaskMemberSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TaskMemberSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TaskMemberDataSourceView class that is to be
		/// used by the TaskMemberDataSource.
		/// </summary>
		/// <returns>An instance of the TaskMemberDataSourceView class.</returns>
		protected override BaseDataSourceView<TaskMember, TaskMemberKey> GetNewDataSourceView()
		{
			return new TaskMemberDataSourceView(this, DefaultViewName);
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
	/// Supports the TaskMemberDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TaskMemberDataSourceView : ProviderDataSourceView<TaskMember, TaskMemberKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskMemberDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TaskMemberDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TaskMemberDataSourceView(TaskMemberDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TaskMemberDataSource TaskMemberOwner
		{
			get { return Owner as TaskMemberDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TaskMemberSelectMethod SelectMethod
		{
			get { return TaskMemberOwner.SelectMethod; }
			set { TaskMemberOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TaskMemberService TaskMemberProvider
		{
			get { return Provider as TaskMemberService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TaskMember> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TaskMember> results = null;
			TaskMember item;
			count = 0;
			
			System.Int32 taskMemberId;

			switch ( SelectMethod )
			{
				case TaskMemberSelectMethod.Get:
					TaskMemberKey entityKey  = new TaskMemberKey();
					entityKey.Load(values);
					item = TaskMemberProvider.Get(entityKey);
					results = new TList<TaskMember>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TaskMemberSelectMethod.GetAll:
                    results = TaskMemberProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TaskMemberSelectMethod.GetPaged:
					results = TaskMemberProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TaskMemberSelectMethod.Find:
					if ( FilterParameters != null )
						results = TaskMemberProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TaskMemberProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TaskMemberSelectMethod.GetByTaskMemberId:
					taskMemberId = ( values["TaskMemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TaskMemberId"], typeof(System.Int32)) : (int)0;
					item = TaskMemberProvider.GetByTaskMemberId(taskMemberId);
					results = new TList<TaskMember>();
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
			if ( SelectMethod == TaskMemberSelectMethod.Get || SelectMethod == TaskMemberSelectMethod.GetByTaskMemberId )
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
				TaskMember entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TaskMemberProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TaskMember> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TaskMemberProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TaskMemberDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TaskMemberDataSource class.
	/// </summary>
	public class TaskMemberDataSourceDesigner : ProviderDataSourceDesigner<TaskMember, TaskMemberKey>
	{
		/// <summary>
		/// Initializes a new instance of the TaskMemberDataSourceDesigner class.
		/// </summary>
		public TaskMemberDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaskMemberSelectMethod SelectMethod
		{
			get { return ((TaskMemberDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TaskMemberDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TaskMemberDataSourceActionList

	/// <summary>
	/// Supports the TaskMemberDataSourceDesigner class.
	/// </summary>
	internal class TaskMemberDataSourceActionList : DesignerActionList
	{
		private TaskMemberDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TaskMemberDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TaskMemberDataSourceActionList(TaskMemberDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaskMemberSelectMethod SelectMethod
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

	#endregion TaskMemberDataSourceActionList
	
	#endregion TaskMemberDataSourceDesigner
	
	#region TaskMemberSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TaskMemberDataSource.SelectMethod property.
	/// </summary>
	public enum TaskMemberSelectMethod
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
		/// Represents the GetByTaskMemberId method.
		/// </summary>
		GetByTaskMemberId
	}
	
	#endregion TaskMemberSelectMethod

	#region TaskMemberFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TaskMember"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskMemberFilter : SqlFilter<TaskMemberColumn>
	{
	}
	
	#endregion TaskMemberFilter

	#region TaskMemberProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TaskMemberChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TaskMember"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskMemberProperty : ChildEntityProperty<TaskMemberChildEntityTypes>
	{
	}
	
	#endregion TaskMemberProperty
}

