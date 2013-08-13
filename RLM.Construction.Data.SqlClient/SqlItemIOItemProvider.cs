#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using RLM.Construction.Entities;
using RLM.Construction.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

#endregion

namespace RLM.Construction.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="ItemIOItem"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlItemIOItemProvider: SqlItemIOItemProviderBase
	{
		/// <summary>
		/// Creates a new <see cref="SqlItemIOItemProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlItemIOItemProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}

        public override TList<ItemIOItem> GetByItemIdAndType(TransactionManager transactionManager, int itemId, ItemIOTicketType ioType, int pageSize, int pageIndex, out int totalRecords)
        {
            SqlDatabase database = new SqlDatabase(this.ConnectionString);
            DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ItemIOItem_GetByItemIdAndType", this.UseStoredProcedure);

            database.AddInParameter(commandWrapper, "@ItemId", DbType.Int32, itemId);
            database.AddInParameter(commandWrapper, "@IOType", DbType.Int32, (int)ioType);
            database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, pageIndex);
            database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageSize);

            IDataReader reader = null;
            //Create Collection
            RLM.Construction.Entities.TList<ItemIOItem> rows = new RLM.Construction.Entities.TList<ItemIOItem>();

            try
            {
                if (transactionManager != null)
                {
                    reader = Utility.ExecuteReader(transactionManager, commandWrapper);
                }
                else
                {
                    reader = Utility.ExecuteReader(database, commandWrapper);
                }

                Fill(reader, rows, 0, int.MaxValue);
                totalRecords = rows.Count;

                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        totalRecords = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return rows;
        }
	}
}