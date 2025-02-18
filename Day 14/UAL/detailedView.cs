using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAL
{
    public partial class detailedView : Form
    {
        ProductList Prds = new();
        BindingSource PrdbindingSource;
        Form super;
        public detailedView(Form super)
        {
            InitializeComponent();

            catBOX.DataSource = CategoryManager.SelectALLCategories();
            catAdd.DataSource = CategoryManager.SelectALLCategories();
            catBOX.DisplayMember = "categoryName";
            catAdd.DisplayMember = "categoryName";
            catBOX.ValueMember = "categoryID";
            catAdd.ValueMember = "categoryID";
            supBOX.DataSource = SupplierManager.SelectAllSuppliers();
            supADD.DataSource = SupplierManager.SelectAllSuppliers();
            supBOX.DisplayMember = "companyName";
            supADD.DisplayMember = "companyName";
            supBOX.ValueMember = "supplierID";
            supADD.ValueMember = "supplierID";

            Prds = ProductManager.SelectALLProducts();
            PrdbindingSource = new BindingSource(Prds, "");
            listBox1.DataSource = PrdbindingSource;
            listBox1.DisplayMember = "ProductName";
            listBox1.ValueMember = "ProductID";

            ///Simple Data Binding
            prodID.DataBindings.Add("Value", PrdbindingSource, "ProductID");
            nameTXT.DataBindings.Add("Text", PrdbindingSource, "ProductName");
            catBOX.DataBindings.Add("SelectedValue", PrdbindingSource, "CategoryID");
            supBOX.DataBindings.Add("SelectedValue", PrdbindingSource, "SupplierID");

            BindingNavigator bindingNavigator = new BindingNavigator(PrdbindingSource);
            PrdbindingSource.AddingNew += (sender, e) =>
            {
                addBTN.PerformClick();
            };

            bindingNavigator.DeleteItem = null;

            this.Controls.Add(bindingNavigator);
            this.super = super;


        }

        private void detailedView_FormClosed(object sender, FormClosedEventArgs e)
        {
            super.Show();
        }

        private void commitBTN_Click(object sender, EventArgs e)
        {
            var PrdsToInsert = Prds.Where(P => P.State == EntityState.Added).ToList();
            var PrdsToUpdate = Prds.Where(P => P.State == EntityState.Modified).ToList();
            var PRdsToDelete = Prds.Where(P => P.State == EntityState.Deleted).ToList();

            foreach (Product Prd in PrdsToInsert)
            {
                if (ProductManager.InsertProduct(Prd) == -1)
                {
                    MessageBox.Show($"An Error With Product {Prd.ProductName}'s insertion has occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (Product Prd in PrdsToUpdate)
            {
                if (ProductManager.UpdateProduct(Prd) == -1)
                {
                    MessageBox.Show($"An Error With Product {Prd.ProductID}||{Prd.ProductName}'s update has occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (Product Prd in PRdsToDelete)
            {
                if (ProductManager.DeleteProduct(Prd) == -1)
                {
                    MessageBox.Show($"An Error With Product {Prd.ProductID}||{Prd.ProductName}'s deletion has occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            Product newRow = new Product()
            {
                ProductID = 0,
                ProductName = nameAdd.Text,
                CategoryID = (int)catAdd.SelectedValue,
                SupplierID = (int)supADD.SelectedValue,
                State = EntityState.Added
            };

            PrdbindingSource.Add(newRow);




            nameAdd.Clear();
            catAdd.SelectedIndex = 0;
            supADD.SelectedIndex = 0;
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            var prod = Prds.SingleOrDefault(prd => prd.ProductID == prodID.Value);
            prod.State = EntityState.Deleted;


        }

        private void prodID_ValueChanged(object sender, EventArgs e)
        {
            if(prodID.Value == 0)
            {
                deleteBTN.Enabled = false;
            }
            else
            {
                deleteBTN.Enabled=true;
            }
        }
    }
}
