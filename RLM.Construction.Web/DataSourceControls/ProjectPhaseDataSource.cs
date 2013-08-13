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
	/// Represents the DataRepository.ProjectPhaseProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProjectPhaseDataSourceDesigner))]
	public class ProjectPhaseDataSource : ProviderDataSource<ProjectPhase, ProjectPhaseKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseDataSource class.
		/// </summary>
		public ProjectPhaseDataSource() : base(new ProjectPhaseService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProjectPhaseDataSourceView used by the ProjectPhaseDataSource.
		/// </summary>
		protected ProjectPhaseDataSourceView ProjectPhaseView
		{
			get { return ( View as ProjectPhaseDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProjectPhaseDataSource control invokes to retrieve data.
		/// </summary>
		public ProjectPhaseSelectMethod SelectMethod
		{
			get
			{
				ProjectPhaseSelectMethod selectMethod = ProjectPhaseSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProjectPhaseSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProjectPhaseDataSourceView class that is to be
		/// used by the ProjectPhaseDataSource.
		/// </summary>
		/// <returns>An instance of the ProjectPhaseDataSourceView class.</returns>
		protected override BaseDataSourceView<ProjectPhase, ProjectPhaseKey> GetNewDataSourceView()
		{
			return new ProjectPhaseDataSourceView(this, DefaultViewName);
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
	/// Supports the ProjectPhaseDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProjectPhaseDataSourceView : ProviderDataSourceView<ProjectPhase, ProjectPhaseKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProjectPhaseDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProjectPhaseDataSourceView(ProjectPhaseDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProjectPhaseDataSource ProjectPhaseOwner
		{
			get { return Owner as ProjectPhaseDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProjectPhaseSelectMethod SelectMethod
		{
			get { return ProjectPhaseOwner.SelectMethod; }
			set { ProjectPhaseOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProjectPhaseService ProjectPhaseProvider
		{
			get { return Provider as ProjectPhaseService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProjectPhase> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProjectPhase> results = null;
			ProjectPhase item;
			count = 0;
			
			System.Int32 projectPhaseId;
			System.Int32 projectId;
			System.Int32? contractId;

			switch ( SelectMethod )
			{
				case ProjectPhaseSelectMethod.Get:
					ProjectPhaseKey entityKey  = new ProjectPhaseKey();
					entityKey.Load(values);
					item = ProjectPhaseProvider.Get(entityKey);
					results = new TList<ProjectPhase>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProjectPhaseSelectMethod.GetAll:
                    results = ProjectPhaseProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProjectPhaseSelectMethod.GetPaged:
					results = ProjectPhaseProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProjectPhaseSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProjectPhaseProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProjectPhaseProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProjectPhaseSelectMethod.GetByProjectPhaseId:
					projectPhaseId = ( values["ProjectPhaseId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProjectPhaseId"], typeof(System.Int32)) : (int)0;
					item = ProjectPhaseProvider.GetByProjectPhaseId(projectPhaseId);
					results = new TList<ProjectPhase>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProjectPhaseSelectMethod.GetByProjectId:
					projectId = ( values["ProjectId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProjectId"], typeof(System.Int32)) : (int)0;
					results = ProjectPhaseProvider.GetByProjectId(projectId, this.StartIndex, this.PageSize, out count);
					break;
				case ProjectPhaseSelectMethod.GetByContractId:
					contractId = (System.Int32?) EntityUtil.ChangeType(values["ContractId"], typeof(System.Int32?));
					results = ProjectPhaseProvider.GetByContractId(contractId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProjectPhaseSelectMethod.Get || SelectMethod == ProjectPhaseSelectMethod.GetByProjectPhaseId )
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
				ProjectPhase entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProjectPhaseProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProjectPhase> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProjectPhaseProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProjectPhaseDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProjectPhaseDataSource class.
	/// </summary>
	public class ProjectPhaseDataSourceDesigner : ProviderDataSourceDesigner<ProjectPhase, ProjectPhaseKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProjectPhaseDataSourceDesigner class.
		/// </summary>
		public ProjectPhaseDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProjectPhaseSelectMethod SelectMethod
		{
			get { return ((ProjectPhaseDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProjectPhaseDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProjectPhaseDataSourceActionList

	/// <summary>
	/// Supports the ProjectPhaseDataSourceDesigner class.
	/// </summary>
	internal class ProjectPhaseDataSourceActionList : DesignerActionList
	{
		private ProjectPhaseDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProjectPhaseDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProjectPhaseDataSourceActionList(ProjectPhaseDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProjectPhaseSelectMethod SelectMethod
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

	#endregion ProjectPhaseDataSourceActionList
	
	#endregion ProjectPhaseDataSourceDesigner
	
	#region ProjectPhaseSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProjectPhaseDataSource.SelectMethod property.
	/// </summary>
	public enum ProjectPhaseSelectMethod
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
		/// Represents the GetByProjectPhaseId method.
		/// </summary>
		GetByProjectPhaseId,
		/// <summary>
		/// Represents the GetByProjectId method.
		/// </summary>
		GetByProjectId,
		/// <summary>
		/// Represents the GetByContractId method.
		/// </summary>
		GetByContractId
	}
	
	#endregion ProjectPhaseSelectMethod

	#region ProjectPhaseFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProjectPhase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectPhaseFilter : SqlFilter<ProjectPhaseColumn>
	{
	}
	
	#endregion ProjectPhaseFilter

	#region ProjectPhaseProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProjectPhaseChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProjectPhase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectPhaseProperty : ChildEntityProperty<ProjectPhaseChildEntityTypes>
	{
	}
	
	#endregion ProjectPhaseProperty
}

