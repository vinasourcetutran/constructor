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
	/// Represents the DataRepository.AttachFileProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AttachFileDataSourceDesigner))]
	public class AttachFileDataSource : ProviderDataSource<AttachFile, AttachFileKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AttachFileDataSource class.
		/// </summary>
		public AttachFileDataSource() : base(new AttachFileService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AttachFileDataSourceView used by the AttachFileDataSource.
		/// </summary>
		protected AttachFileDataSourceView AttachFileView
		{
			get { return ( View as AttachFileDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AttachFileDataSource control invokes to retrieve data.
		/// </summary>
		public AttachFileSelectMethod SelectMethod
		{
			get
			{
				AttachFileSelectMethod selectMethod = AttachFileSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AttachFileSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AttachFileDataSourceView class that is to be
		/// used by the AttachFileDataSource.
		/// </summary>
		/// <returns>An instance of the AttachFileDataSourceView class.</returns>
		protected override BaseDataSourceView<AttachFile, AttachFileKey> GetNewDataSourceView()
		{
			return new AttachFileDataSourceView(this, DefaultViewName);
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
	/// Supports the AttachFileDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AttachFileDataSourceView : ProviderDataSourceView<AttachFile, AttachFileKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AttachFileDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AttachFileDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AttachFileDataSourceView(AttachFileDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AttachFileDataSource AttachFileOwner
		{
			get { return Owner as AttachFileDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AttachFileSelectMethod SelectMethod
		{
			get { return AttachFileOwner.SelectMethod; }
			set { AttachFileOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AttachFileService AttachFileProvider
		{
			get { return Provider as AttachFileService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AttachFile> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AttachFile> results = null;
			AttachFile item;
			count = 0;
			
			System.Int32 attachFileId;

			switch ( SelectMethod )
			{
				case AttachFileSelectMethod.Get:
					AttachFileKey entityKey  = new AttachFileKey();
					entityKey.Load(values);
					item = AttachFileProvider.Get(entityKey);
					results = new TList<AttachFile>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AttachFileSelectMethod.GetAll:
                    results = AttachFileProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AttachFileSelectMethod.GetPaged:
					results = AttachFileProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AttachFileSelectMethod.Find:
					if ( FilterParameters != null )
						results = AttachFileProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AttachFileProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AttachFileSelectMethod.GetByAttachFileId:
					attachFileId = ( values["AttachFileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AttachFileId"], typeof(System.Int32)) : (int)0;
					item = AttachFileProvider.GetByAttachFileId(attachFileId);
					results = new TList<AttachFile>();
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
			if ( SelectMethod == AttachFileSelectMethod.Get || SelectMethod == AttachFileSelectMethod.GetByAttachFileId )
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
				AttachFile entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AttachFileProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AttachFile> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AttachFileProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AttachFileDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AttachFileDataSource class.
	/// </summary>
	public class AttachFileDataSourceDesigner : ProviderDataSourceDesigner<AttachFile, AttachFileKey>
	{
		/// <summary>
		/// Initializes a new instance of the AttachFileDataSourceDesigner class.
		/// </summary>
		public AttachFileDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AttachFileSelectMethod SelectMethod
		{
			get { return ((AttachFileDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AttachFileDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AttachFileDataSourceActionList

	/// <summary>
	/// Supports the AttachFileDataSourceDesigner class.
	/// </summary>
	internal class AttachFileDataSourceActionList : DesignerActionList
	{
		private AttachFileDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AttachFileDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AttachFileDataSourceActionList(AttachFileDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AttachFileSelectMethod SelectMethod
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

	#endregion AttachFileDataSourceActionList
	
	#endregion AttachFileDataSourceDesigner
	
	#region AttachFileSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AttachFileDataSource.SelectMethod property.
	/// </summary>
	public enum AttachFileSelectMethod
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
		/// Represents the GetByAttachFileId method.
		/// </summary>
		GetByAttachFileId
	}
	
	#endregion AttachFileSelectMethod

	#region AttachFileFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AttachFileFilter : SqlFilter<AttachFileColumn>
	{
	}
	
	#endregion AttachFileFilter

	#region AttachFileProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AttachFileChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AttachFileProperty : ChildEntityProperty<AttachFileChildEntityTypes>
	{
	}
	
	#endregion AttachFileProperty
}

