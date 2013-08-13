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
	/// Represents the DataRepository.ProjectProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProjectDataSourceDesigner))]
	public class ProjectDataSource : ProviderDataSource<Project, ProjectKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectDataSource class.
		/// </summary>
		public ProjectDataSource() : base(new ProjectService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProjectDataSourceView used by the ProjectDataSource.
		/// </summary>
		protected ProjectDataSourceView ProjectView
		{
			get { return ( View as ProjectDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProjectDataSource control invokes to retrieve data.
		/// </summary>
		public ProjectSelectMethod SelectMethod
		{
			get
			{
				ProjectSelectMethod selectMethod = ProjectSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProjectSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProjectDataSourceView class that is to be
		/// used by the ProjectDataSource.
		/// </summary>
		/// <returns>An instance of the ProjectDataSourceView class.</returns>
		protected override BaseDataSourceView<Project, ProjectKey> GetNewDataSourceView()
		{
			return new ProjectDataSourceView(this, DefaultViewName);
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
	/// Supports the ProjectDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProjectDataSourceView : ProviderDataSourceView<Project, ProjectKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProjectDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProjectDataSourceView(ProjectDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProjectDataSource ProjectOwner
		{
			get { return Owner as ProjectDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProjectSelectMethod SelectMethod
		{
			get { return ProjectOwner.SelectMethod; }
			set { ProjectOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProjectService ProjectProvider
		{
			get { return Provider as ProjectService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Project> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Project> results = null;
			Project item;
			count = 0;
			
			System.Int32 projectId;
			System.Int32 groupId;
			System.Int32 contractId;

			switch ( SelectMethod )
			{
				case ProjectSelectMethod.Get:
					ProjectKey entityKey  = new ProjectKey();
					entityKey.Load(values);
					item = ProjectProvider.Get(entityKey);
					results = new TList<Project>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProjectSelectMethod.GetAll:
                    results = ProjectProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProjectSelectMethod.GetPaged:
					results = ProjectProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProjectSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProjectProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProjectProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProjectSelectMethod.GetByProjectId:
					projectId = ( values["ProjectId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProjectId"], typeof(System.Int32)) : (int)0;
					item = ProjectProvider.GetByProjectId(projectId);
					results = new TList<Project>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProjectSelectMethod.GetByGroupId:
					groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					results = ProjectProvider.GetByGroupId(groupId, this.StartIndex, this.PageSize, out count);
					break;
				case ProjectSelectMethod.GetByContractId:
					contractId = ( values["ContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContractId"], typeof(System.Int32)) : (int)0;
					results = ProjectProvider.GetByContractId(contractId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProjectSelectMethod.Get || SelectMethod == ProjectSelectMethod.GetByProjectId )
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
				Project entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProjectProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Project> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProjectProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProjectDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProjectDataSource class.
	/// </summary>
	public class ProjectDataSourceDesigner : ProviderDataSourceDesigner<Project, ProjectKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProjectDataSourceDesigner class.
		/// </summary>
		public ProjectDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProjectSelectMethod SelectMethod
		{
			get { return ((ProjectDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProjectDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProjectDataSourceActionList

	/// <summary>
	/// Supports the ProjectDataSourceDesigner class.
	/// </summary>
	internal class ProjectDataSourceActionList : DesignerActionList
	{
		private ProjectDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProjectDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProjectDataSourceActionList(ProjectDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProjectSelectMethod SelectMethod
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

	#endregion ProjectDataSourceActionList
	
	#endregion ProjectDataSourceDesigner
	
	#region ProjectSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProjectDataSource.SelectMethod property.
	/// </summary>
	public enum ProjectSelectMethod
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
		/// Represents the GetByProjectId method.
		/// </summary>
		GetByProjectId,
		/// <summary>
		/// Represents the GetByGroupId method.
		/// </summary>
		GetByGroupId,
		/// <summary>
		/// Represents the GetByContractId method.
		/// </summary>
		GetByContractId
	}
	
	#endregion ProjectSelectMethod

	#region ProjectFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectFilter : SqlFilter<ProjectColumn>
	{
	}
	
	#endregion ProjectFilter

	#region ProjectProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProjectChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectProperty : ChildEntityProperty<ProjectChildEntityTypes>
	{
	}
	
	#endregion ProjectProperty
}

