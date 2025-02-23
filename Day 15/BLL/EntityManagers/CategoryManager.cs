using BLL.EntityLists;
using BLL.Models;
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
        static NortheastContext context = new();

        public static CategoryList SelectALLCategories()
        {
            CategoryList Cats = new();
            try
            {
                CategoryList cats = new CategoryList();
                cats.AddRange(context.Categories.ToList());
                return cats;
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Cats;
        }

       
    }
}
