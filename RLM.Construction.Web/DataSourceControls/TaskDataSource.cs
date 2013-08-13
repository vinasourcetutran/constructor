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
	/// Represents the DataRepository.TaskProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TaskDataSourceDesigner))]
	public class TaskDataSource : ProviderDataSource<Task, TaskKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskDataSource class.
		/// </summary>
		public TaskDataSource() : base(new TaskService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TaskDataSourceView used by the TaskDataSource.
		/// </summary>
		protected TaskDataSourceView TaskView
		{
			get { return ( View as TaskDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TaskDataSource control invokes to retrieve data.
		/// </summary>
		public TaskSelectMethod SelectMethod
		{
			get
			{
				TaskSelectMethod selectMethod = TaskSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TaskSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TaskDataSourceView class that is to be
		/// used by the TaskDataSource.
		/// </summary>
		/// <returns>An instance of the TaskDataSourceView class.</returns>
		protected override BaseDataSourceView<Task, TaskKey> GetNewDataSourceView()
		{
			return new TaskDataSourceView(this, DefaultViewName);
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
	/// Supports the TaskDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TaskDataSourceView : ProviderDataSourceView<Task, TaskKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaskDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TaskDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TaskDataSourceView(TaskDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TaskDataSource TaskOwner
		{
			get { return Owner as TaskDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TaskSelectMethod SelectMethod
		{
			get { return TaskOwner.SelectMethod; }
			set { TaskOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TaskService TaskProvider
		{
			get { return Provider as TaskService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Task> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Task> results = null;
			Task item;
			count = 0;
			
			System.Int32 taskId;

			switch ( SelectMethod )
			{
				case TaskSelectMethod.Get:
					TaskKey entityKey  = new TaskKey();
					entityKey.Load(values);
					item = TaskProvider.Get(entityKey);
					results = new TList<Task>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TaskSelectMethod.GetAll:
                    results = TaskProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TaskSelectMethod.GetPaged:
					results = TaskProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TaskSelectMethod.Find:
					if ( FilterParameters != null )
						results = TaskProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TaskProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TaskSelectMethod.GetByTaskId:
					taskId = ( values["TaskId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TaskId"], typeof(System.Int32)) : (int)0;
					item = TaskProvider.GetByTaskId(taskId);
					results = new TList<Task>();
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
			if ( SelectMethod == TaskSelectMethod.Get || SelectMethod == TaskSelectMethod.GetByTaskId )
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
				Task entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TaskProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Task> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TaskProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TaskDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TaskDataSource class.
	/// </summary>
	public class TaskDataSourceDesigner : ProviderDataSourceDesigner<Task, TaskKey>
	{
		/// <summary>
		/// Initializes a new instance of the TaskDataSourceDesigner class.
		/// </summary>
		public TaskDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaskSelectMethod SelectMethod
		{
			get { return ((TaskDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TaskDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TaskDataSourceActionList

	/// <summary>
	/// Supports the TaskDataSourceDesigner class.
	/// </summary>
	internal class TaskDataSourceActionList : DesignerActionList
	{
		private TaskDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TaskDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TaskDataSourceActionList(TaskDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TaskSelectMethod SelectMethod
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

	#endregion TaskDataSourceActionList
	
	#endregion TaskDataSourceDesigner
	
	#region TaskSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TaskDataSource.SelectMethod property.
	/// </summary>
	public enum TaskSelectMethod
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
		/// Represents the GetByTaskId method.
		/// </summary>
		GetByTaskId
	}
	
	#endregion TaskSelectMethod

	#region TaskFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Task"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskFilter : SqlFilter<TaskColumn>
	{
	}
	
	#endregion TaskFilter

	#region TaskProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TaskChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Task"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaskProperty : ChildEntityProperty<TaskChildEntityTypes>
	{
	}
	
	#endregion TaskProperty
}

