using BLL.Entities;
using BLL.EntityLists;
using BLL.EntityManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAL
{
    public partial class GridForm : Form
    {
        Form super;
        public GridForm(Form super)
        {
            InitializeComponent();

            this.super = super;
        }
        ProductList Prds = new ProductList();
        BindingSource PrdBindingSource = new BindingSource();
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prds = ProductManager.SelectALLProducts();

            PrdBindingSource = new BindingSource(Prds, "");
            dataGridView1.DataSource = PrdBindingSource;

            dataGridView1.Columns["ProductID"].ReadOnly = true;


            int index = dataGridView1.Columns["CategoryID"].Index;
            dataGridView1.Columns.Remove("CategoryID");

            DataGridViewComboBoxColumn categoryCombo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "categoryID",
                HeaderText = "Category",
                Name = "CategoryID",
                DataSource = CategoryManager.SelectALLCategories(),
                DisplayMember = "categoryName",
                ValueMember = "categoryID"
            };
            dataGridView1.Columns.Insert(index, categoryCombo);

            index = dataGridView1.Columns["SupplierID"].Index;
            dataGridView1.Columns.Remove("SupplierID");

            DataGridViewComboBoxColumn supplierCombo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "supplierID",
                HeaderText = "Supplier",
                Name = "SupplierID",
                DataSource = SupplierManager.SelectAllSuppliers(),
                DisplayMember = "CompanyName",
                ValueMember = "SupplierID"
            };
            dataGridView1.Columns.Insert(index, supplierCombo);
        }

        private void GridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            super.Show();
        }

        private void commitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.EndEdit();
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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
            e.Row.Visible = true;
            e.Row.Cells["State"].Value = EntityState.Deleted;
            Debug.WriteLine(e.Row.Visible);
        }
    }
}
