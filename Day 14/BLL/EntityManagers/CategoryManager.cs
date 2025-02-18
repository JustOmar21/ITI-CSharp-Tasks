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
    public class CategoryManager
    {
        static DBManager manager = new();

        public static CategoryList SelectALLCategories()
        {
            CategoryList Cats = new();
            try
            {
                return DataTableToCategoryList(manager.ExecuteDataTable("GetAllCategories"));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Cats;
        }

        #region Mapping Function
        internal static CategoryList DataTableToCategoryList(DataTable Dt)
        {
            CategoryList Cats = new();
            try
            {
                for (int i = 0; i < Dt?.Rows?.Count; i++)
                    Cats.Add(DataRowToCategory(Dt.Rows[i]));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Cats;
        }
        internal static Category DataRowToCategory(DataRow Dr)
        {
            Category C = new() { CategoryName = ""};
            try
            {
                C.CategoryID = Dr.Field<int>("CategoryID");

                C.CategoryName = Dr.Field<string>("CategoryName") ?? "NA";
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return C;

        }

        #endregion
    }
}
