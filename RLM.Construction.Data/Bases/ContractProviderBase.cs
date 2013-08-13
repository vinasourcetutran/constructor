#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using RLM.Construction.Entities;
using RLM.Construction.Data;

#endregion

namespace RLM.Construction.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ContractProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContractProviderBase : ContractProviderBaseCore
	{

        public static RLM.Construction.Entities.TList<Contract> Fill(IDataReader reader, RLM.Construction.Entities.TList<Contract> rows, int start, int pageLength)
        {
            // advance to the starting row
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return rows; // not enough rows, just return
            }

            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break; // we are done

                string key = null;

                RLM.Construction.Entities.Contract c = null;
                if (DataRepository.Provider.UseEntityFactory)
                {
                    key = @"Contract"
                            + (reader.IsDBNull(reader.GetOrdinal("ContractId")) ? (int)0 : (System.Int32)reader["ContractId"]).ToString();

                    c = EntityManager.LocateOrCreate<Contract>(
                        key.ToString(), // EntityTrackingKey 
                        "Contract",  //Creational Type
                        DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
                        DataRepository.Provider.EnableEntityTracking); // Track this entity?
                }
                else
                {
                    c = new RLM.Construction.Entities.Contract();
                }

                if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
                    c.SuppressEntityEvents = true;
                    c.ContractId = (System.Int32)reader["ContractId"];
                    c.FromContactName = (reader.IsDBNull(reader.GetOrdinal("FromContactName"))) ? null : (System.String)reader["FromContactName"];
                    c.ToContactName = (reader.IsDBNull(reader.GetOrdinal("ToContactName"))) ? null : (System.String)reader["ToContactName"];
                    c.Type = (reader.IsDBNull(reader.GetOrdinal("Type"))) ? null : (System.Int32?)reader["Type"];
                    c.ConstructDeptId = (reader.IsDBNull(reader.GetOrdinal("ConstructDeptId"))) ? null : (System.Int32?)reader["ConstructDeptId"];
                    c.DesignDeptId = (reader.IsDBNull(reader.GetOrdinal("DesignDeptId"))) ? null : (System.Int32?)reader["DesignDeptId"];
                    c.GroupId = (reader.IsDBNull(reader.GetOrdinal("GroupId"))) ? null : (System.Int32?)reader["GroupId"];
                    c.PartnerId = (reader.IsDBNull(reader.GetOrdinal("PartnerId"))) ? null : (System.Int32?)reader["PartnerId"];
                    c.Code = (reader.IsDBNull(reader.GetOrdinal("Code"))) ? null : (System.String)reader["Code"];
                    c.Days = (reader.IsDBNull(reader.GetOrdinal("Days"))) ? 0 : (System.Int32)reader["Days"];
                    c.RealDays = (reader.IsDBNull(reader.GetOrdinal("RealDays"))) ? 0 : (System.Int32)reader["RealDays"];
                    c.Number = (reader.IsDBNull(reader.GetOrdinal("Number"))) ? null : (System.String)reader["Number"];
                    c.Name = (System.String)reader["Name"];
                    c.Description = (reader.IsDBNull(reader.GetOrdinal("Description"))) ? null : (System.String)reader["Description"];
                    c.Comment = (reader.IsDBNull(reader.GetOrdinal("Comment"))) ? null : (System.String)reader["Comment"];
                    c.InitPrice = (reader.IsDBNull(reader.GetOrdinal("InitPrice"))) ? null : (System.Decimal?)reader["InitPrice"];
                    c.LastPrice = (reader.IsDBNull(reader.GetOrdinal("LastPrice"))) ? null : (System.Decimal?)reader["LastPrice"];
                    c.SignedDate = (reader.IsDBNull(reader.GetOrdinal("SignedDate"))) ? null : (System.DateTime?)reader["SignedDate"];
                    c.FromDate = (reader.IsDBNull(reader.GetOrdinal("FromDate"))) ? null : (System.DateTime?)reader["FromDate"];
                    c.ToDate = (reader.IsDBNull(reader.GetOrdinal("ToDate"))) ? null : (System.DateTime?)reader["ToDate"];
                    c.RealFromDate = (reader.IsDBNull(reader.GetOrdinal("RealFromDate"))) ? null : (System.DateTime?)reader["RealFromDate"];
                    c.RealToDate = (reader.IsDBNull(reader.GetOrdinal("RealToDate"))) ? null : (System.DateTime?)reader["RealToDate"];
                    c.Status = (reader.IsDBNull(reader.GetOrdinal("Status"))) ? null : (System.Int32?)reader["Status"];
                    c.IsApprove = (reader.IsDBNull(reader.GetOrdinal("IsApprove"))) ? null : (System.Boolean?)reader["IsApprove"];
                    c.IsActive = (reader.IsDBNull(reader.GetOrdinal("IsActive"))) ? null : (System.Boolean?)reader["IsActive"];
                    c.IsPrinted = (reader.IsDBNull(reader.GetOrdinal("IsPrinted"))) ? null : (System.Int64?)reader["IsPrinted"];
                    c.CurrencyUnitId = (reader.IsDBNull(reader.GetOrdinal("CurrencyUnitId"))) ? null : (System.Int32?)reader["CurrencyUnitId"];
                    c.ContractType = (reader.IsDBNull(reader.GetOrdinal("ContractType"))) ? null : (System.Int32?)reader["ContractType"];
                    c.FromContactorId = (reader.IsDBNull(reader.GetOrdinal("FromContactorId"))) ? null : (System.Int32?)reader["FromContactorId"];
                    c.ToContactorId = (reader.IsDBNull(reader.GetOrdinal("ToContactorId"))) ? null : (System.Int32?)reader["ToContactorId"];
                    c.VATTax = (reader.IsDBNull(reader.GetOrdinal("VATTax"))) ? null : (System.Double?)reader["VATTax"];
                    c.PITTax = (reader.IsDBNull(reader.GetOrdinal("PITTax"))) ? null : (System.Double?)reader["PITTax"];
                    c.CITTax = (reader.IsDBNull(reader.GetOrdinal("CITTax"))) ? null : (System.Double?)reader["CITTax"];
                    c.Other = (reader.IsDBNull(reader.GetOrdinal("Other"))) ? null : (System.Decimal?)reader["Other"];
                    c.CreationUserId = (reader.IsDBNull(reader.GetOrdinal("CreationUserId"))) ? null : (System.Int32?)reader["CreationUserId"];
                    c.CreationDate = (reader.IsDBNull(reader.GetOrdinal("CreationDate"))) ? null : (System.DateTime?)reader["CreationDate"];
                    c.LastModificationUserId = (reader.IsDBNull(reader.GetOrdinal("LastModificationUserId"))) ? null : (System.Int32?)reader["LastModificationUserId"];
                    c.LastModificationDate = (reader.IsDBNull(reader.GetOrdinal("LastModificationDate"))) ? null : (System.DateTime?)reader["LastModificationDate"];
                    c.ExchangeRate = (reader.IsDBNull(reader.GetOrdinal("ExchangeRate"))) ? null : (System.Int32?)reader["ExchangeRate"];
                    c.EntityTrackingKey = key;
                    c.AcceptChanges();
                    c.SuppressEntityEvents = false;
                }
                rows.Add(c);
            }
            return rows;
        }
	} // end class
} // end namespace
