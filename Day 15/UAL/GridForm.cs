using BLL.Models;
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ProductManager.SelectALLProducts().ToBindingList();

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
            ProductManager.Commit();
            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
        }
    }
}
