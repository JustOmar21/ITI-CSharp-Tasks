
using BLL.EntityLists;
using BLL.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        static NortheastContext context = new();

        public static LocalView<Product> SelectALLProducts()
        {
            context.Products.Load();
            return context.Products.Local;
        }

        public static int Commit()
        {
            return context.SaveChanges();
        }

        public static int InsertProduct(Product Prd)
        {
            try
            {
                context.Products.Add(Prd);
                return 1;
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
                

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return -1;
        }

      
    }
}
