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
	/// Represents the DataRepository.RewardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RewardDataSourceDesigner))]
	public class RewardDataSource : ProviderDataSource<Reward, RewardKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RewardDataSource class.
		/// </summary>
		public RewardDataSource() : base(new RewardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RewardDataSourceView used by the RewardDataSource.
		/// </summary>
		protected RewardDataSourceView RewardView
		{
			get { return ( View as RewardDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RewardDataSource control invokes to retrieve data.
		/// </summary>
		public RewardSelectMethod SelectMethod
		{
			get
			{
				RewardSelectMethod selectMethod = RewardSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RewardSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RewardDataSourceView class that is to be
		/// used by the RewardDataSource.
		/// </summary>
		/// <returns>An instance of the RewardDataSourceView class.</returns>
		protected override BaseDataSourceView<Reward, RewardKey> GetNewDataSourceView()
		{
			return new RewardDataSourceView(this, DefaultViewName);
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
	/// Supports the RewardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RewardDataSourceView : ProviderDataSourceView<Reward, RewardKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RewardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RewardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RewardDataSourceView(RewardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RewardDataSource RewardOwner
		{
			get { return Owner as RewardDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RewardSelectMethod SelectMethod
		{
			get { return RewardOwner.SelectMethod; }
			set { RewardOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RewardService RewardProvider
		{
			get { return Provider as RewardService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Reward> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Reward> results = null;
			Reward item;
			count = 0;
			
			System.Int32 rewardId;

			switch ( SelectMethod )
			{
				case RewardSelectMethod.Get:
					RewardKey entityKey  = new RewardKey();
					entityKey.Load(values);
					item = RewardProvider.Get(entityKey);
					results = new TList<Reward>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RewardSelectMethod.GetAll:
                    results = RewardProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RewardSelectMethod.GetPaged:
					results = RewardProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RewardSelectMethod.Find:
					if ( FilterParameters != null )
						results = RewardProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RewardProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RewardSelectMethod.GetByRewardId:
					rewardId = ( values["RewardId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RewardId"], typeof(System.Int32)) : (int)0;
					item = RewardProvider.GetByRewardId(rewardId);
					results = new TList<Reward>();
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
			if ( SelectMethod == RewardSelectMethod.Get || SelectMethod == RewardSelectMethod.GetByRewardId )
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
				Reward entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RewardProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Reward> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RewardProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RewardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RewardDataSource class.
	/// </summary>
	public class RewardDataSourceDesigner : ProviderDataSourceDesigner<Reward, RewardKey>
	{
		/// <summary>
		/// Initializes a new instance of the RewardDataSourceDesigner class.
		/// </summary>
		public RewardDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RewardSelectMethod SelectMethod
		{
			get { return ((RewardDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RewardDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RewardDataSourceActionList

	/// <summary>
	/// Supports the RewardDataSourceDesigner class.
	/// </summary>
	internal class RewardDataSourceActionList : DesignerActionList
	{
		private RewardDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RewardDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RewardDataSourceActionList(RewardDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RewardSelectMethod SelectMethod
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

	#endregion RewardDataSourceActionList
	
	#endregion RewardDataSourceDesigner
	
	#region RewardSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RewardDataSource.SelectMethod property.
	/// </summary>
	public enum RewardSelectMethod
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
		/// Represents the GetByRewardId method.
		/// </summary>
		GetByRewardId
	}
	
	#endregion RewardSelectMethod

	#region RewardFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Reward"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RewardFilter : SqlFilter<RewardColumn>
	{
	}
	
	#endregion RewardFilter

	#region RewardProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RewardChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Reward"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RewardProperty : ChildEntityProperty<RewardChildEntityTypes>
	{
	}
	
	#endregion RewardProperty
}

