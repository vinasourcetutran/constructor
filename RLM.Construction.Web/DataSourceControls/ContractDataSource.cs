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
	/// Represents the DataRepository.ContractProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ContractDataSourceDesigner))]
	public class ContractDataSource : ProviderDataSource<Contract, ContractKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContractDataSource class.
		/// </summary>
		public ContractDataSource() : base(new ContractService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ContractDataSourceView used by the ContractDataSource.
		/// </summary>
		protected ContractDataSourceView ContractView
		{
			get { return ( View as ContractDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ContractDataSource control invokes to retrieve data.
		/// </summary>
		public ContractSelectMethod SelectMethod
		{
			get
			{
				ContractSelectMethod selectMethod = ContractSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ContractSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ContractDataSourceView class that is to be
		/// used by the ContractDataSource.
		/// </summary>
		/// <returns>An instance of the ContractDataSourceView class.</returns>
		protected override BaseDataSourceView<Contract, ContractKey> GetNewDataSourceView()
		{
			return new ContractDataSourceView(this, DefaultViewName);
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
	/// Supports the ContractDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ContractDataSourceView : ProviderDataSourceView<Contract, ContractKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContractDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ContractDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ContractDataSourceView(ContractDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ContractDataSource ContractOwner
		{
			get { return Owner as ContractDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ContractSelectMethod SelectMethod
		{
			get { return ContractOwner.SelectMethod; }
			set { ContractOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ContractService ContractProvider
		{
			get { return Provider as ContractService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Contract> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Contract> results = null;
			Contract item;
			count = 0;
			
			System.Int32 contractId;
			System.Int32? groupId;

			switch ( SelectMethod )
			{
				case ContractSelectMethod.Get:
					ContractKey entityKey  = new ContractKey();
					entityKey.Load(values);
					item = ContractProvider.Get(entityKey);
					results = new TList<Contract>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ContractSelectMethod.GetAll:
                    results = ContractProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ContractSelectMethod.GetPaged:
					results = ContractProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ContractSelectMethod.Find:
					if ( FilterParameters != null )
						results = ContractProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ContractProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ContractSelectMethod.GetByContractId:
					contractId = ( values["ContractId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ContractId"], typeof(System.Int32)) : (int)0;
					item = ContractProvider.GetByContractId(contractId);
					results = new TList<Contract>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ContractSelectMethod.GetByGroupId:
					groupId = (System.Int32?) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32?));
					results = ContractProvider.GetByGroupId(groupId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ContractSelectMethod.Get || SelectMethod == ContractSelectMethod.GetByContractId )
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
				Contract entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ContractProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Contract> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ContractProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ContractDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ContractDataSource class.
	/// </summary>
	public class ContractDataSourceDesigner : ProviderDataSourceDesigner<Contract, ContractKey>
	{
		/// <summary>
		/// Initializes a new instance of the ContractDataSourceDesigner class.
		/// </summary>
		public ContractDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContractSelectMethod SelectMethod
		{
			get { return ((ContractDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ContractDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ContractDataSourceActionList

	/// <summary>
	/// Supports the ContractDataSourceDesigner class.
	/// </summary>
	internal class ContractDataSourceActionList : DesignerActionList
	{
		private ContractDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ContractDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ContractDataSourceActionList(ContractDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ContractSelectMethod SelectMethod
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

	#endregion ContractDataSourceActionList
	
	#endregion ContractDataSourceDesigner
	
	#region ContractSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ContractDataSource.SelectMethod property.
	/// </summary>
	public enum ContractSelectMethod
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
		/// Represents the GetByContractId method.
		/// </summary>
		GetByContractId,
		/// <summary>
		/// Represents the GetByGroupId method.
		/// </summary>
		GetByGroupId
	}
	
	#endregion ContractSelectMethod

	#region ContractFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Contract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContractFilter : SqlFilter<ContractColumn>
	{
	}
	
	#endregion ContractFilter

	#region ContractProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ContractChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Contract"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContractProperty : ChildEntityProperty<ContractChildEntityTypes>
	{
	}
	
	#endregion ContractProperty
}

