using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Product:EntityBase
	{
        public int? ProductID { get; set; }
        private string productName;
        public required string ProductName
        {
            get => productName;
            set
            {
                if (value != productName)
                {
                    productName = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private int? supplierID;
        public int? SupplierID
        {
            get => supplierID;
            set
            {
                if (value != supplierID)
                {
                    supplierID = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private int? categoryID;
        public int? CategoryID
        {
            get => categoryID;
            set
            {
                if (value != categoryID)
                {
                    categoryID = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private string? quantityPerUnit;
        public string? QuantityPerUnit
        {
            get => quantityPerUnit;
            set
            {
                if (value != quantityPerUnit)
                {
                    quantityPerUnit = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private decimal? unitPrice;
        public decimal? UnitPrice
        {
            get => unitPrice;
            set
            {
                if (value != unitPrice)
                {
                    unitPrice = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private short? unitsInStock;
        public short? UnitsInStock
        {
            get => unitsInStock;
            set
            {
                if (value != unitsInStock)
                {
                    unitsInStock = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private short? unitsOnOrder;
        public short? UnitsOnOrder
        {
            get => unitsOnOrder;
            set
            {
                if (value != unitsOnOrder)
                {
                    unitsOnOrder = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private short? reorderLevel;
        public short? ReorderLevel
        {
            get => reorderLevel;
            set
            {
                if (value != reorderLevel)
                {
                    reorderLevel = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        private bool discontinued;
        public bool Discontinued
        {
            get => discontinued;
            set
            {
                if (value != discontinued)
                {
                    discontinued = value;
                    if (State != EntityState.Added)
                        State = EntityState.Modified;
                }
            }
        }

        public EntityState State { get; set; } = EntityState.Added;
    }
}
