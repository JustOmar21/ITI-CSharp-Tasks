
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
    public class SupplierManager
    {
        static NortheastContext context = new();

        public static SupplierList SelectAllSuppliers()
        {
            SupplierList Sups = new();
            try
            {
                var sup = new SupplierList();
                sup.AddRange(context.Suppliers.ToList());
                return sup;
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return Sups;
        }

    }


}
