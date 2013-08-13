#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RLM.Construction.Entities;
using RLM.Construction.Data;
using RLM.Construction.Web.UI;
#endregion

namespace RLM.Construction.Web.Data
{
	/// <summary>
	/// Binds SQL filter expressions to a parameter object.
	/// </summary>
	[CLSCompliant(true)]
	[ParseChildren(true), PersistChildren(false)]
	public class SqlParameter : Parameter
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the SqlParameter class.
		/// </summary>
		public SqlParameter() : base()
		{
		}
		
		#endregion Constructors

		#region Properties

		/// <summary>
		/// The Filters member variable.
		/// </summary>
		private IList filters;

		/// <summary>
		/// Gets or sets the Filters property.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList Filters
		{
			get
			{
				if ( filters == null )
				{
					filters = new ArrayList();
				}

				return filters;
			}
		}

		/// <summary>
		/// The CallbackControlID member variable.
		/// </summary>
		private String callbackControlID;

		/// <summary>
		/// Gets or sets the CallbackControlID property.
		/// </summary>
		public String CallbackControlID
		{
			get { return callbackControlID; }
			set { callbackControlID = value; }
		}

		/// <summary>
		/// The UseParameterizedFilters member variable.
		/// </summary>
		private bool useParameterizedFilters = true;

		/// <summary>
		/// Gets or sets the UseParameterizedFilters property.
		/// </summary>
		public bool UseParameterizedFilters
		{
			get { return useParameterizedFilters; }
			set { useParameterizedFilters = value; }
		}

		#endregion Properties

		#region Evaluate

		/// <summary>
		/// Updates and returns the value of the SqlParameter object.
		/// </summary>
		/// <param name="context">The current System.Web.HttpContext of the request.</param>
		/// <param name="control">The System.Web.UI.Control that the parameter is bound to.</param>
		/// <returns>A System.Object that represents the updated and current value of the parameter.</returns>
		protected override object Evaluate(HttpContext context, Control control)
		{
			Object returnValue = null;
			bool isCallback = false;

			if ( !UseParameterizedFilters )
			{
				returnValue = String.Empty;
			}
			if ( !String.IsNullOrEmpty(CallbackControlID) )
			{
				IList<Control> controls = FormUtil.GetControls(control.Page, CallbackControlID);
				if ( controls != null && controls.Count > 0 )
				{
					try
					{
						isCallback = (bool) EntityUtil.GetPropertyValue(controls[0], "IsCallback");
					}
					catch ( Exception ) { /* ignore */ }
				}
			}
			if ( filters != null && filters.Count > 0 )
			{
				if ( UseParameterizedFilters )
				{
					returnValue = ( filters[0] as ISqlFilter ).GetSqlFilterParameters(control, filters, isCallback);
				}
				else
				{
					returnValue = ( filters[0] as ISqlFilter ).GetSqlFilterString(control, filters, isCallback);
				}
			}

			return returnValue;
		}

		#endregion Evaluate
	}
	
	#region SqlFilter<EntityColumn>

	/// <summary>
	/// Provides SQL filter expressions for the <see cref="SqlParameter"/> class.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	[CLSCompliant(true)]
	public abstract class SqlFilter<EntityColumn> : ISqlFilter
	{
		#region Properties

		/// <summary>
		/// The Column member variable.
		/// </summary>
		private EntityColumn column;

		/// <summary>
		/// Gets or sets the Column property.
		/// </summary>
		public EntityColumn Column
		{
			get { return column; }
			set { column = value; }
		}

		/// <summary>
		/// The ControlID member variable.
		/// </summary>
		private String controlID;

		/// <summary>
		/// Gets or sets the ControlID property.
		/// </summary>
		public String ControlID
		{
			get { return controlID; }
			set { controlID = value; }
		}

		/// <summary>
		/// The PropertyName member variable.
		/// </summary>
		private String propertyName;

		/// <summary>
		/// Gets or sets the PropertyName property.
		/// </summary>
		public String PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		/// <summary>
		/// The ComparisionType member variable.
		/// </summary>
		private SqlComparisonType comparisonType;

		/// <summary>
		/// Gets or sets the ComparisionType property.
		/// </summary>
		public SqlComparisonType ComparisionType
		{
			get { return comparisonType; }
			set { comparisonType = value; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Gets the filter value.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		protected virtual String GetFilterValue(Control control, bool isCallback)
		{
			Control input = FormUtil.FindControl(control, ControlID);
			Object value = null;

			if ( input == null )
			{
				// if the ControlID was not found using the supplied control, we will
				// search the entire conrol tree for the current page
				IList<Control> controls = FormUtil.GetControls(control.Page, ControlID);

				if ( controls != null && controls.Count > 0 )
				{
					input = controls[0];
				}
			}
			if ( input != null )
			{
				if ( isCallback )
				{
					value = HttpContext.Current.Request[input.UniqueID];
				}
				else
				{
					value = FormUtil.GetValue(input, PropertyName);
				}
			}

			String format = "{0}";

			if ( ComparisionType == SqlComparisonType.Contains )
			{
				format = "%{0}%";
			}
			else if ( ComparisionType == SqlComparisonType.StartsWith )
			{
				format = "{0}%";
			}
			else if ( ComparisionType == SqlComparisonType.EndsWith )
			{
				format = "%{0}";
			}

			return String.Format(format, value);
		}

		/// <summary>
		/// Applies the filters to the specified <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.
		/// </summary>
		/// <param name="sql">The <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		protected virtual void ApplyFilters(SqlFilterBuilder<EntityColumn> sql, Control control, IList filters, bool isCallback)
		{
			String value;

			foreach ( SqlFilter<EntityColumn> filter in filters )
			{
				value = filter.GetFilterValue(control, isCallback);

				if ( filter.ApplyFilter != null )
				{
					SqlFilterEventArgs<EntityColumn> args = new SqlFilterEventArgs<EntityColumn>(sql, filter.Column, value);
					filter.ApplyFilter(this, args);
				}
				else
				{
					sql.Append(filter.Column, value);
				}
			}
		}

		/// <summary>
		/// Creates a new instance of a <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
		/// that can be used to generate a SQL filter expression for this filter.
		/// </summary>
		/// <returns></returns>
		protected virtual SqlFilterBuilder<EntityColumn> GetFilterBuilder(bool useParameterizedFilters)
		{
			return useParameterizedFilters
				? new ParameterizedSqlFilterBuilder<EntityColumn>()
				: new SqlFilterBuilder<EntityColumn>();
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs when the filter expression is to be created.
		/// </summary>
		public event SqlFilterEventHandler<EntityColumn> ApplyFilter;

		#endregion Events

		#region ISqlFilter Members

		/// <summary>
		/// Gets the SQL filter expression that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A SQL filter expression.</returns>
		public String GetSqlFilterString(Control control, IList filters, bool isCallback)
		{
			SqlFilterBuilder<EntityColumn> sql = GetFilterBuilder(false);

			ApplyFilters(sql, control, filters, isCallback);

			return sql.ToString();
		}

		/// <summary>
		/// Gets the collection of SQL filter parameters that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A collection SQL filter parameters.</returns>
		public SqlFilterParameterCollection GetSqlFilterParameters(Control control, IList filters, bool isCallback)
		{
			SqlFilterBuilder<EntityColumn> sql = GetFilterBuilder(true);

			ApplyFilters(sql, control, filters, isCallback);

			return (sql as ParameterizedSqlFilterBuilder<EntityColumn>).GetParameters();
		}

		#endregion ISqlFilter Members
	}
	
	#endregion SqlFilter<EntityColumn>

	#region SqlFilterEventHandler

	/// <summary>
	/// Represents the method that will handle the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	/// <param name="sender">The data source control that the filter is bound to.</param>
	/// <param name="e">The event data.</param>
	public delegate void SqlFilterEventHandler<EntityColumn>(object sender, SqlFilterEventArgs<EntityColumn> e);

	/// <summary>
	/// Provides data for the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	public class SqlFilterEventArgs<EntityColumn> : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the SqlFilterEventArgs class.
		/// </summary>
		/// <param name="builder">An <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
		/// <param name="column">The current column.</param>
		/// <param name="filter">The column filter value.</param>
		public SqlFilterEventArgs(SqlFilterBuilder<EntityColumn> builder, EntityColumn column, String filter)
		{
			this.filterBuilder = builder;
			this.column = column;
			this.filter = filter;
		}

		#region Properties

		/// <summary>
		/// The FilterBuilder member variable.
		/// </summary>
		private SqlFilterBuilder<EntityColumn> filterBuilder;

		/// <summary>
		/// Gets or sets the FilterBuilder property.
		/// </summary>
		public SqlFilterBuilder<EntityColumn> FilterBuilder
		{
			get { return filterBuilder; }
		}

		/// <summary>
		/// The Column member variable.
		/// </summary>
		private EntityColumn column;

		/// <summary>
		/// Gets or sets the Column property.
		/// </summary>
		public EntityColumn Column
		{
			get { return column; }
		}

		/// <summary>
		/// The Filter member variable.
		/// </summary>
		private String filter;

		/// <summary>
		/// Gets or sets the Filter property.
		/// </summary>
		public String Filter
		{
			get { return filter; }
		}

		#endregion Properties
	}

	#endregion SqlFilterEventHandler

	#region ISqlFilter
	
	/// <summary>
	/// Provides the ability to construct a valid SQL filter expression.
	/// </summary>
	[CLSCompliant(true)]
	public interface ISqlFilter
	{
		/// <summary>
		/// Gets the SQL filter expression that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A SQL filter expression.</returns>
		String GetSqlFilterString(Control control, IList filters, bool isCallback);

		/// <summary>
		/// Gets the collection of SQL filter parameters that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A collection SQL filter parameters.</returns>
		SqlFilterParameterCollection GetSqlFilterParameters(Control control, IList filters, bool isCallback);
	}

	#endregion ISqlFilter
}