#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using RLM.Construction.Entities;
#endregion

namespace RLM.Construction.Data
{
	/// <summary>
	/// Represents a SQL filter expression.
	/// </summary>
	[CLSCompliant(true)]
	public class SqlStringBuilder
	{
		#region Declarations

		private StringBuilder sql = new StringBuilder();

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		public SqlStringBuilder()
		{
			this.junction = SqlUtil.AND;
			this.ignoreCase = false;
		}

		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SqlStringBuilder(bool ignoreCase)
		{
			this.junction = SqlUtil.AND;
			this.ignoreCase = ignoreCase;
		}

		/// <summary>
		/// Initializes a new instance of the SqlStringBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SqlStringBuilder(bool ignoreCase, bool useAnd)
		{
			this.junction = useAnd ? SqlUtil.AND : SqlUtil.OR;
			this.ignoreCase = ignoreCase;
		}

		#endregion Constructors

		#region Append

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder Append(String column, String searchText)
		{
			return Append(this.junction, column, searchText, this.ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder Append(String column, String searchText, bool ignoreCase)
		{
			return Append(this.junction, column, searchText, ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder Append(String junction, String column, String searchText, bool ignoreCase)
		{
			if ( !String.IsNullOrEmpty(searchText) )
			{
				AppendInternal(junction, Parse(column, searchText, ignoreCase));
			}

			return this;
		}

		#endregion Append

		#region AppendEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendEquals(String column, String value)
		{
			return AppendEquals(this.junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				AppendInternal(junction, column, "=", SqlUtil.Encode(value, true));
			}

			return this;
		}

		#endregion AppendEquals

		#region AppendNotEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotEquals(String column, String value)
		{
			return AppendNotEquals(this.junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				AppendInternal(junction, column, "<>", SqlUtil.Encode(value, true));
			}

			return this;
		}

		#endregion AppendNotEquals

		#region AppendIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIn(String column, String values)
		{
			return AppendIn(this.junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIn(String column, String values, bool encode)
		{
			return AppendIn(this.junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIn(String junction, String column, String values)
		{
			return AppendIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				values = GetInQueryValues(values, encode);

				if ( !String.IsNullOrEmpty(values) )
				{
					AppendInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendIn

		#region AppendNotIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotIn(String column, String values)
		{
			return AppendNotIn(this.junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotIn(String column, String values, bool encode)
		{
			return AppendNotIn(this.junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotIn(String junction, String column, String values)
		{
			return AppendNotIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				values = GetInQueryValues(values, encode);

				if ( !String.IsNullOrEmpty(values) )
				{
					AppendNotInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendNotIn

		#region AppendInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendInQuery(String column, String query)
		{
			return AppendInQuery(this.junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendInQuery(String junction, String column, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				AppendInternal(junction, column, "IN", "(" + query + ")");
			}

			return this;
		}

		#endregion AppendInQuery

		#region AppendNotInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotInQuery(String column, String query)
		{
			return AppendNotInQuery(this.junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendNotInQuery(String junction, String column, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				AppendInternal(junction, column, "NOT IN", "(" + query + ")");
			}

			return this;
		}

		#endregion AppendNotInQuery

		#region AppendRange

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendRange(String column, String from, String to)
		{
			return AppendRange(this.junction, column, from, to);
		}

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendRange(String junction, String column, String from, String to)
		{
			if ( !String.IsNullOrEmpty(from) || !String.IsNullOrEmpty(to) )
			{
				StringBuilder sb = new StringBuilder();

				if ( !String.IsNullOrEmpty(from) )
				{
					sb.AppendFormat("{0} >= {1}", column, SqlUtil.Encode(from, true));
				}
				if ( !String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat(" {0} ", SqlUtil.AND);
				}
				if ( !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat("{0} <= {1}", column, SqlUtil.Encode(to, true));
				}

				AppendInternal(junction, sb.ToString());
			}

			return this;
		}

		#endregion AppendRange

		#region AppendIsNull

		/// <summary>
		/// Appends an IS NULL expression to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIsNull(String column)
		{
			return AppendIsNull(this.junction, column);
		}

		/// <summary>
		/// Appends an IS NULL expression to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIsNull(String junction, String column)
		{
			AppendInternal(junction, SqlUtil.IsNull(column));
			return this;
		}

		#endregion AppendIsNull

		#region AppendIsNotNull

		/// <summary>
		/// Appends an IS NOT NULL expression to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIsNotNull(String column)
		{
			return AppendIsNotNull(this.junction, column);
		}

		/// <summary>
		/// Appends an IS NOT NULL expression to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlStringBuilder AppendIsNotNull(String junction, String column)
		{
			AppendInternal(junction, SqlUtil.IsNotNull(column));
			return this;
		}

		#endregion AppendIsNotNull
		
		#region AppendGreaterThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendGreaterThan(String column, String value)
      {
         return AppendGreaterThan(this.junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendGreaterThan(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            AppendInternal(junction, column, ">", SqlUtil.Encode(value, true));
         }

         return this;
      }

      #endregion AppendGreaterThan

      #region AppendGreaterThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendGreaterThanOrEqual(String column, String value)
      {
         return AppendGreaterThanOrEqual(this.junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendGreaterThanOrEqual(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            AppendInternal(junction, column, ">=", SqlUtil.Encode(value, true));
         }

         return this;
      }

      #endregion AppendGreaterThanOrEqual

      #region AppendLessThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendLessThan(String column, String value)
      {
         return AppendLessThan(this.junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendLessThan(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            AppendInternal(junction, column, "<", SqlUtil.Encode(value, true));
         }

         return this;
      }

      #endregion AppendLessThan

      #region AppendLessThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendLessThanOrEqual(String column, String value)
      {
         return AppendLessThanOrEqual(this.junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlStringBuilder AppendLessThanOrEqual(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            AppendInternal(junction, column, "<=", SqlUtil.Encode(value, true));
         }

         return this;
      }

      #endregion AppendLessThanOrEqual


		#region AppendInternal

		/// <summary>
		/// Appends the SQL expression to the internal <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="junction">The junction.</param>
		/// <param name="column">The column.</param>
		/// <param name="compare">The compare.</param>
		/// <param name="value">The value.</param>
		protected virtual void AppendInternal(String junction, String column, String compare, String value)
		{
			AppendInternal(junction, String.Format("{0} {1} {2}", column, compare, value));
		}

		/// <summary>
		/// Appends the SQL expression to the internal <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="junction">The junction.</param>
		/// <param name="query">The query.</param>
		protected virtual void AppendInternal(String junction, String query)
		{
			if ( !String.IsNullOrEmpty(query) )
			{
				#if DEBUG
				String end = Environment.NewLine;
				#else
				String end = String.Empty;
				#endif
				String format = ( sql.Length > 0 ) ? " {0} ({1}){2}" : " ({1}){2}";
				sql.AppendFormat(format, junction, query, end);
			}
		}

		#endregion AppendInternal

		#region Methods

		/// <summary>
		/// Clears the internal string buffer.
		/// </summary>
		public virtual void Clear()
		{
			sql.Length = 0;
		}

		/// <summary>
		/// Converts the value of this instance to a System.String.
		/// </summary>
		public override string ToString()
		{
			return sql.ToString().TrimEnd();
		}
		
		/// <summary>
		/// Converts the value of this instance to a System.String and
		/// prepends the specified junction if the expression is not empty.
		/// </summary>
		public virtual string ToString(String junction)
		{
			if( sql.Length > 0 )
			{
				return new StringBuilder(" ").Append(junction).Append(" ").Append(sql.ToString().Trim()).ToString();
			}
			
			return String.Empty;
		}

		/// <summary>
		/// Parses the specified searchText to create a SQL filter expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public virtual string Parse(String column, String searchText, bool ignoreCase)
		{
			return new SqlExpressionParser(column, ignoreCase).Parse(searchText);
		}

		/// <summary>
		/// Gets an encoded list of values for use with an IN clause.
		/// </summary>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual String GetInQueryValues(String values, bool encode)
		{
			if ( encode )
			{
				String[] split = values.Split(',');
				values = SqlUtil.Encode(split, encode);
			}

			return values;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// The Junction member variable.
		/// </summary>
		private String junction;

		/// <summary>
		/// Gets or sets the Junction property.
		/// </summary>
		public virtual String Junction
		{
			get { return junction; }
			set { junction = value; }
		}

		/// <summary>
		/// The IgnoreCase member variable.
		/// </summary>
		private bool ignoreCase;

		/// <summary>
		/// Gets or sets the IgnoreCase property.
		/// </summary>
		public virtual bool IgnoreCase
		{
			get { return ignoreCase; }
			set { ignoreCase = value; }
		}

		#endregion Properties
	}

	/// <summary>
	/// Allows for building SQL filter expressions using strongly-typed
	/// column enumeration values.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	[CLSCompliant(true)]
	public class SqlFilterBuilder<EntityColumn> : SqlStringBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		public SqlFilterBuilder() : base() {}

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SqlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SqlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SqlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors

		#region Append

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> Append(EntityColumn column, String searchText)
		{
			return Append(this.Junction, column, searchText, this.IgnoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> Append(EntityColumn column, String searchText, bool ignoreCase)
		{
			return Append(this.Junction, column, searchText, ignoreCase);
		}

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> Append(String junction, EntityColumn column, String searchText, bool ignoreCase)
		{
			Append(junction, GetColumnName(column), searchText, ignoreCase);
			return this;
		}

		#endregion Append

		#region AppendEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendEquals(EntityColumn column, String value)
		{
			return AppendEquals(this.Junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendEquals(String junction, EntityColumn column, String value)
		{
			AppendEquals(junction, GetColumnName(column), value);
			return this;
		}

		#endregion AppendEquals

		#region AppendNotEquals

		/// <summary>
		/// Appends the specified column and value to the current filter
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotEquals(EntityColumn column, String value)
		{
			return AppendNotEquals(this.Junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotEquals(String junction, EntityColumn column, String value)
		{
			AppendNotEquals(junction, GetColumnName(column), value);
			return this;
		}

		#endregion AppendNotEquals

		#region AppendIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, String values)
		{
			return AppendIn(this.Junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIn(EntityColumn column, String values, bool encode)
		{
			return AppendIn(this.Junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIn(String junction, EntityColumn column, String values)
		{
			return AppendIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIn(String junction, EntityColumn column, String values, bool encode)
		{
			AppendIn(junction, GetColumnName(column), values, encode);
			return this;
		}

		#endregion AppendIn

		#region AppendNotIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, String values)
		{
			return AppendNotIn(this.Junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(EntityColumn column, String values, bool encode)
		{
			return AppendNotIn(this.Junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(String junction, EntityColumn column, String values)
		{
			return AppendNotIn(junction, column, values, true);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotIn(String junction, EntityColumn column, String values, bool encode)
		{
			AppendNotIn(junction, GetColumnName(column), values, encode);
			return this;
		}

		#endregion AppendIn

		#region AppendInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendInQuery(EntityColumn column, String query)
		{
			return AppendInQuery(this.Junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendInQuery(String junction, EntityColumn column, String query)
		{
			AppendInQuery(junction, GetColumnName(column), query);
			return this;
		}

		#endregion AppendInQuery

		#region AppendNotInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotInQuery(EntityColumn column, String query)
		{
			return AppendNotInQuery(this.Junction, column, query);
		}

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendNotInQuery(String junction, EntityColumn column, String query)
		{
			AppendNotInQuery(junction, GetColumnName(column), query);
			return this;
		}

		#endregion AppendNotInQuery

		#region AppendIsNull

		/// <summary>
		/// Appends an IS NULL expression to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIsNull(EntityColumn column)
		{
			return AppendIsNull(this.Junction, column);
		}

		/// <summary>
		/// Appends an IS NULL expression to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIsNull(String junction, EntityColumn column)
		{
			AppendIsNull(junction, GetColumnName(column));
			return this;
		}

		#endregion AppendIsNull

		#region AppendIsNotNull

		/// <summary>
		/// Appends an IS NOT NULL expression to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIsNotNull(EntityColumn column)
		{
			return AppendIsNotNull(this.Junction, column);
		}

		/// <summary>
		/// Appends an IS NOT NULL expression to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendIsNotNull(String junction, EntityColumn column)
		{
			AppendIsNotNull(junction, GetColumnName(column));
			return this;
		}

		#endregion AppendIsNotNull

		#region AppendRange

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendRange(EntityColumn column, String from, String to)
		{
			return AppendRange(this.Junction, column, from, to);
		}

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public virtual SqlFilterBuilder<EntityColumn> AppendRange(String junction, EntityColumn column, String from, String to)
		{
			AppendRange(junction, GetColumnName(column), from, to);
			return this;
		}

		#endregion AppendRange

		#region AppendGreaterThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThan(EntityColumn column, String value)
      {
         return AppendGreaterThan(this.Junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThan(String junction, EntityColumn column, String value)
      {
         AppendGreaterThan(junction, GetColumnName(column), value);
         return this;
      }

      #endregion AppendGreaterThan

      #region AppendGreaterThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(EntityColumn column, String value)
      {
         return AppendGreaterThanOrEqual(this.Junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(String junction, EntityColumn column, String value)
      {
         AppendGreaterThanOrEqual(junction, GetColumnName(column), value);
         return this;
      }

      #endregion AppendGreaterThanOrEqual

      #region AppendLessThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendLessThan(EntityColumn column, String value)
      {
         return AppendLessThan(this.Junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendLessThan(String junction, EntityColumn column, String value)
      {
         AppendLessThan(junction, GetColumnName(column), value);
         return this;
      }

      #endregion AppendLessThan

      #region AppendLessThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(EntityColumn column, String value)
      {
         return AppendLessThanOrEqual(this.Junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public virtual SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(String junction, EntityColumn column, String value)
      {
         AppendLessThanOrEqual(junction, GetColumnName(column), value);
         return this;
      }

      #endregion AppendLessThanOrEqual
		
		#region Methods

		/// <summary>
		/// Gets the column name from the specified column enumeration value.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		protected virtual String GetColumnName(EntityColumn column)
		{
			String name = EntityHelper.GetEnumTextValue(column as Enum);

			if ( String.IsNullOrEmpty(name) )
			{
				name = column.ToString();
			}

			return name;
		}

		#endregion Methods
	}

	/// <summary>
	/// Allows for building parameterized SQL filter expressions using strongly-typed
	/// column enumeration values.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	[CLSCompliant(true)]
	public class ParameterizedSqlFilterBuilder<EntityColumn> : SqlFilterBuilder<EntityColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
		/// </summary>
		public ParameterizedSqlFilterBuilder() : base() {}

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ParameterizedSqlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ParameterizedSqlFilterBuilder&lt;EntityColumn&gt; class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ParameterizedSqlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors

		#region Append

		/// <summary>
		/// Appends the specified column and search text to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> Append(String junction, EntityColumn column, String searchText, bool ignoreCase)
		{
			Parameters.SetCurrentColumn(column);
			return base.Append(junction, column, searchText, ignoreCase);
		}

		#endregion Append

		#region AppendEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendEquals(String junction, EntityColumn column, String value)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendEquals(junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override SqlStringBuilder AppendEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				value = SqlUtil.Equals(value);
				AppendInternal(junction, column, "=", Parameters.GetParameter(value));
			}

			return this;
		}

		#endregion AppendEquals

		#region AppendNotEquals

		/// <summary>
		/// Appends the specified column and value to the current filter.
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendNotEquals(String junction, EntityColumn column, String value)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendNotEquals(junction, column, value);
		}

		/// <summary>
		/// Appends the specified column and value to the current filter
		/// as a NOT EQUALS expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override SqlStringBuilder AppendNotEquals(String junction, String column, String value)
		{
			if ( !String.IsNullOrEmpty(value) )
			{
				value = SqlUtil.Equals(value);
				AppendInternal(junction, column, "<>", Parameters.GetParameter(value));
			}

			return this;
		}

		#endregion AppendNotEquals

		#region AppendIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendIn(String junction, EntityColumn column, String values, bool encode)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendIn(junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public override SqlStringBuilder AppendIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				values = GetInQueryValues(values, encode);

				if ( !String.IsNullOrEmpty(values) )
				{
					AppendInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendIn

		#region AppendNotIn

		/// <summary>
		/// Appends the specified column and list of values to the current filter.
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendNotIn(String junction, EntityColumn column, String values, bool encode)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendNotIn(junction, column, values, encode);
		}

		/// <summary>
		/// Appends the specified column and list of values to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public override SqlStringBuilder AppendNotIn(String junction, String column, String values, bool encode)
		{
			if ( !String.IsNullOrEmpty(values) )
			{
				values = GetInQueryValues(values, encode);

				if ( !String.IsNullOrEmpty(values) )
				{
					AppendNotInQuery(junction, column, values);
				}
			}

			return this;
		}

		#endregion AppendNotIn

		#region AppendInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendInQuery(String junction, EntityColumn column, String query)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendInQuery(junction, column, query);
		}

		#endregion AppendInQuery

		#region AppendNotInQuery

		/// <summary>
		/// Appends the specified sub-query to the current filter
		/// as a NOT IN expression.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendNotInQuery(String junction, EntityColumn column, String query)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendNotInQuery(junction, column, query);
		}

		#endregion AppendNotInQuery

		#region AppendRange

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public override SqlFilterBuilder<EntityColumn> AppendRange(String junction, EntityColumn column, String from, String to)
		{
			Parameters.SetCurrentColumn(column);
			return base.AppendRange(junction, column, from, to);
		}

		/// <summary>
		/// Appends the specified column and value range to the current filter.
		/// </summary>
		/// <param name="junction"></param>
		/// <param name="column"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public override SqlStringBuilder AppendRange(String junction, String column, String from, String to)
		{
			if ( !String.IsNullOrEmpty(from) || !String.IsNullOrEmpty(to) )
			{
				StringBuilder sb = new StringBuilder();

				if ( !String.IsNullOrEmpty(from) )
				{
					sb.AppendFormat("{0} >= {1}", column, Parameters.GetParameter(from));
				}
				if ( !String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat(" {0} ", SqlUtil.AND);
				}
				if ( !String.IsNullOrEmpty(to) )
				{
					sb.AppendFormat("{0} <= {1}", column, Parameters.GetParameter(to));
				}

				AppendInternal(junction, sb.ToString());
			}

			return this;
		}

		#endregion AppendRange

		#region AppendGreaterThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlFilterBuilder<EntityColumn> AppendGreaterThan(String junction, EntityColumn column, String value)
      {
         Parameters.SetCurrentColumn(column);
         return base.AppendGreaterThan(junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlStringBuilder AppendGreaterThan(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            value = SqlUtil.Equals(value);
            AppendInternal(junction, column, ">", Parameters.GetParameter(value));
         }

         return this;
      }

      #endregion AppendGreaterThan

      #region AppendGreaterThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlFilterBuilder<EntityColumn> AppendGreaterThanOrEqual(String junction, EntityColumn column, String value)
      {
         Parameters.SetCurrentColumn(column);
         return base.AppendGreaterThanOrEqual(junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlStringBuilder AppendGreaterThanOrEqual(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            value = SqlUtil.Equals(value);
            AppendInternal(junction, column, ">=", Parameters.GetParameter(value));
         }

         return this;
      }

      #endregion AppendGreaterThanOrEqual

      #region AppendLessThan

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlFilterBuilder<EntityColumn> AppendLessThan(String junction, EntityColumn column, String value)
      {
         Parameters.SetCurrentColumn(column);
         return base.AppendLessThan(junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlStringBuilder AppendLessThan(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            value = SqlUtil.Equals(value);
            AppendInternal(junction, column, "<", Parameters.GetParameter(value));
         }

         return this;
      }

      #endregion AppendLessThan

      #region AppendLessThanOrEqual

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlFilterBuilder<EntityColumn> AppendLessThanOrEqual(String junction, EntityColumn column, String value)
      {
         Parameters.SetCurrentColumn(column);
         return base.AppendLessThanOrEqual(junction, column, value);
      }

      /// <summary>
      /// Appends the specified column and value to the current filter.
      /// </summary>
      /// <param name="junction"></param>
      /// <param name="column"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public override SqlStringBuilder AppendLessThanOrEqual(String junction, String column, String value)
      {
         if (!String.IsNullOrEmpty(value))
         {
            value = SqlUtil.Equals(value);
            AppendInternal(junction, column, "<=", Parameters.GetParameter(value));
         }

         return this;
      }

      #endregion AppendLessThanOrEqual
		
		#region Methods

		/// <summary>
		/// Parses the specified searchText to create a SQL filter expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="searchText"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public override string Parse(string column, string searchText, bool ignoreCase)
		{
			ParameterizedSqlExpressionParser parser = new ParameterizedSqlExpressionParser(column, ignoreCase);
			parser.Parameters = this.Parameters;
			return parser.Parse(searchText);
		}

		/// <summary>
		/// Gets an encoded list of values for use with an IN clause.
		/// </summary>
		/// <param name="values"></param>
		/// <param name="encode"></param>
		/// <returns></returns>
		public override String GetInQueryValues(String values, bool encode)
		{
			CommaDelimitedStringCollection csv = new CommaDelimitedStringCollection();
			String[] split = values.Split(',');
			String temp;

			foreach ( String value in split )
			{
				temp = value.Trim();

				if ( !String.IsNullOrEmpty(temp) )
				{
					csv.Add(Parameters.GetParameter(temp));
				}
			}

			return csv.ToString();
		}

		/// <summary>
		/// Gets the current collection of <see cref="SqlFilterParameter"/> objects and
		/// also sets the collection's FilterExpression property.
		/// </summary>
		/// <returns></returns>
		public virtual SqlFilterParameterCollection GetParameters()
		{
			Parameters.FilterExpression = this.ToString();
			return Parameters;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// The Parameters member variable.
		/// </summary>
		private SqlFilterParameterCollection parameters;

		/// <summary>
		/// Gets or sets the Parameters property.
		/// </summary>
		public virtual SqlFilterParameterCollection Parameters
		{
			get
			{
				if ( parameters == null )
				{
					parameters = new SqlFilterParameterCollection();
				}

				return parameters;
			}
			set { parameters = value; }
		}

		#endregion Properties
	}

	/// <summary>
	/// A collection of <see cref="SqlFilterParameter"/> objects.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class SqlFilterParameterCollection : List<SqlFilterParameter>
	{
		#region Methods

		/// <summary>
		/// Sets the CurrentColumn property.
		/// </summary>
		/// <param name="column"></param>
		public void SetCurrentColumn(Object column)
		{
			this.currentColumn = (Enum) column;
		}

		/// <summary>
		/// Gets the next parameter name for the specified value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public String GetParameter(String value)
		{
			SqlFilterParameter parameter = new SqlFilterParameter(CurrentColumn, value, Count);
			Add(parameter);
			return parameter.Name;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// The CurrentColumn member variable.
		/// </summary>
		private Enum currentColumn;

		/// <summary>
		/// Gets the CurrentColumn property.
		/// </summary>
		public Enum CurrentColumn
		{
			get { return currentColumn; }
		}

		/// <summary>
		/// The FilterExpression member variable.
		/// </summary>
		private String filterExpression;

		/// <summary>
		/// Gets or sets the FilterExpression property.
		/// </summary>
		public String FilterExpression
		{
			get { return filterExpression; }
			set { filterExpression = value; }
		}

		#endregion Properties
	}

	/// <summary>
	/// Represents the information needed for a database command parameter.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class SqlFilterParameter
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SqlFilterParameter class.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="index"></param>
		public SqlFilterParameter(Enum column, String value, int index)
		{
			this.column = column;
			this.parameterValue = value;
			this.parameterIndex = index;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// The Column member variable.
		/// </summary>
		private Enum column;

		/// <summary>
		/// Gets or sets the Column property.
		/// </summary>
		public Enum Column
		{
			get { return column; }
			set { column = value; }
		}

		/// <summary>
		/// The Value member variable.
		/// </summary>
		private String parameterValue;

		/// <summary>
		/// Gets or sets the Value property.
		/// </summary>
		public String Value
		{
			get { return parameterValue; }
			set { parameterValue = value; }
		}

		/// <summary>
		/// The Index member variable.
		/// </summary>
		private int parameterIndex;

		/// <summary>
		/// Gets the parameter index.
		/// </summary>
		public int Index
		{
			get { return parameterIndex; }
		}

		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		public String Name
		{
			get { return String.Format("@Param{0}", Index); }
		}

		/// <summary>
		/// Gets the <see cref="System.Data.SqlDbType"/> for
		/// the current entity column enumeration value.
		/// </summary>
		public System.Data.DbType DbType
		{
			get
			{
				System.Data.DbType dbType = System.Data.DbType.String;

				if ( column != null )
				{
					ColumnEnumAttribute attribute = EntityHelper.GetAttribute<ColumnEnumAttribute>(column);

					if ( attribute != null )
					{
						dbType = attribute.DbType;
					}
				}

				return dbType;
			}
		}

		#endregion Properties
	}
}
