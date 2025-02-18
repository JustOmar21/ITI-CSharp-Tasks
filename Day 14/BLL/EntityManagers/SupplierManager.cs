using BLL.Entities;
using BLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManagers
{
    public class SupplierManager
    {
        static DBManager manager = new();

        public static SupplierList SelectAllSuppliers()
        {
            SupplierList Sups = new();
            try
            {
                return DataTableToSupplierList(manager.ExecuteDataTable("GetAllSuppliers"));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Sups;
        }
        #region Mapping Function
        internal static SupplierList DataTableToSupplierList(DataTable Dt)
        {
            SupplierList Sups = new();
            try
            {
                for (int i = 0; i < Dt?.Rows?.Count; i++)
                    Sups.Add(DataRowToSupplier(Dt.Rows[i]));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Sups;
        }
        internal static Supplier DataRowToSupplier(DataRow Dr)
        {
            Supplier S = new() { CompanyName = "" };
            try
            {
                S.SupplierID = Dr.Field<int>("SupplierID");

                S.CompanyName = Dr.Field<string>("CompanyName") ?? "NA";
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return S;

        }

        #endregion
    }


}
