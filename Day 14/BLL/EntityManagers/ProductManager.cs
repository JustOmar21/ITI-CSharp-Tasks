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
    public static class ProductManager
    {
        static DBManager manager = new();

        public static ProductList SelectALLProducts()
        {
            ProductList Prds = new();
            try
            {
                return DataTableToProductList(manager.ExecuteDataTable("GetAllProducts"));
            }
            catch(Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Prds;
        }

        public static bool UpdateProductPrice(int ProductID , decimal UnitPrice)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["ProductID"] = ProductID,
                    ["UnitPrice"] = UnitPrice
                };


                return manager.ExecuteNonQuery("UpdateProductPrice" , Parameters) > 0;
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return false;
        }

        public static int InsertProduct(Product Prd)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["@ProductName"] = Prd.ProductName,
                    ["@SupplierID"] = Prd.SupplierID,
                    ["@CategoryID"] = Prd.CategoryID,
                    ["@QuantityPerUnit"] = Prd.QuantityPerUnit,
                    ["@UnitPrice"] = Prd.UnitPrice,
                    ["@UnitsInStock"] = Prd.UnitsInStock,
                    ["@UnitsOnOrder"] = Prd.UnitsOnOrder,
                    ["@ReorderLevel"] = Prd.ReorderLevel,
                    ["@Discontinued"] = false
                };
                Prd.State = EntityState.UnChanged;
                return manager.ExecuteNonQuery("InsertProduct",Parameters);

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return -1;
        } //After Insert Update State to UnChanged
        public static int UpdateProduct(Product Prd)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["@ProductID"] = Prd.ProductID,
                    ["@ProductName"] = Prd.ProductName,
                    ["@SupplierID"] = Prd.SupplierID,
                    ["@CategoryID"] = Prd.CategoryID,
                    ["@QuantityPerUnit"] = Prd.QuantityPerUnit,
                    ["@UnitPrice"] = Prd.UnitPrice,
                    ["@UnitsInStock"] = Prd.UnitsInStock,
                    ["@UnitsOnOrder"] = Prd.UnitsOnOrder,
                    ["@ReorderLevel"] = Prd.ReorderLevel,
                    ["@Discontinued"] = Prd.Discontinued
                };
                Prd.State = EntityState.UnChanged;
                return manager.ExecuteNonQuery("UpdateProduct", Parameters);

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return -1;
        }//After Update, Update State to UnChanged

        public static int DeleteProduct(Product Prd)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["@ProductID"] = Prd.ProductID,
                };
                Prd.State = EntityState.Deleted;
                return manager.ExecuteNonQuery("DeleteProduct", Parameters);

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return -1;
        }

        #region Mapping Function
        internal static ProductList DataTableToProductList (DataTable Dt)
        {
            ProductList Prds = new();
            try
            {
                for (int i=0; i < Dt?.Rows?.Count; i++)
                    Prds.Add(DataRowToProduct(Dt.Rows[i]));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Prds;
        }
        internal static Product DataRowToProduct(DataRow Dr)
        {
            Product P = new() { ProductName="NA" };
            try
            {
                P.ProductID = Dr.Field<int>("ProductID");

                P.ProductName = Dr.Field<string>("ProductName")??"NA";

                if (int.TryParse(Dr["SupplierID"]?.ToString() ?? "-1", out int TempInt))
                    P.SupplierID = TempInt;

                if (int.TryParse(Dr["CategoryID"]?.ToString() ?? "-1", out TempInt))
                    P.CategoryID = TempInt;

                P.QuantityPerUnit = Dr.Field<string>("QuantityPerUnit");

                if (decimal.TryParse(Dr["UnitPrice"]?.ToString() ?? "-1", out decimal TempMoney))
                    P.UnitPrice = TempMoney;

                if (short.TryParse(Dr["UnitsInStock"]?.ToString() ?? "-1", out short TempShort))
                    P.UnitsInStock = TempShort;

                if (short.TryParse(Dr["UnitsOnOrder"]?.ToString() ?? "-1", out  TempShort))
                    P.UnitsOnOrder = TempShort;

                if (short.TryParse(Dr["ReorderLevel"]?.ToString() ?? "-1", out  TempShort))
                    P.ReorderLevel = TempShort;

                P.Discontinued = Dr.Field<bool>("Discontinued");

                P.State = EntityState.UnChanged;
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return P;

        }

        #endregion
    }
}
