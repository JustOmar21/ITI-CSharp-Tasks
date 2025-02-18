using Microsoft.Data.SqlClient;
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
using static Day_13.ConnectionManager;

namespace Day_13
{
    public partial class GridForm : Form
    {
        SqlCommand sqlCmdSelectAllPrd;
        DataTable dt;
        DataTable categoriesDT;
        DataTable suppliersDT;
        SqlDataAdapter DA;
        SqlDataAdapter catAdapter;
        SqlDataAdapter supAdapter;
        Form super;
        public GridForm(Form super)
        {
            InitializeComponent();
            sqlCmdSelectAllPrd = new SqlCommand(@"
            select p.productID, p.productName, p.categoryID, p.supplierID, c.categoryName, s.companyName
            from products p
            join categories c ON p.categoryID = c.categoryID
            join suppliers s ON s.supplierID = p.supplierID", SqlCN);

            dt = new DataTable();
            categoriesDT = new DataTable();
            suppliersDT = new DataTable();

            DA = new SqlDataAdapter("select * from products", SqlCN);
            catAdapter = new SqlDataAdapter("SELECT categoryID, categoryName FROM Categories", SqlCN);
            supAdapter = new SqlDataAdapter("select supplierID, companyName from suppliers", SqlCN);


            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(DA);
            DA.UpdateCommand = commandBuilder.GetUpdateCommand();
            DA.InsertCommand = commandBuilder.GetInsertCommand();
            DA.DeleteCommand = commandBuilder.GetDeleteCommand();

            this.super = super;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            categoriesDT.Clear();
            suppliersDT.Clear();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;

            catAdapter.Fill(categoriesDT);

            supAdapter.Fill(suppliersDT);

            dataGridView1.Columns["ProductID"].ReadOnly = true;


            int index = dataGridView1.Columns["CategoryID"].Index;
            dataGridView1.Columns.Remove("CategoryID");

            DataGridViewComboBoxColumn categoryCombo = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "categoryID",
                HeaderText = "Category",
                Name = "CategoryID",
                DataSource = categoriesDT,
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
                DataSource = suppliersDT,
                DisplayMember = "companyName",
                ValueMember = "supplierID"
            };
            dataGridView1.Columns.Insert(index, supplierCombo);
        }

        private void GridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            super.Show();
        }

        private void commitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine($"{row.RowState}");
            }
            dataGridView1.EndEdit();
            DA.Update(dt);
        }
    }
}
