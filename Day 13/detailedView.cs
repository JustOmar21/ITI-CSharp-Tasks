using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Day_13.ConnectionManager;

namespace Day_13
{
    public partial class detailedView : Form
    {
        SqlCommand sqlCmdSelectAllPrds;
        SqlDataAdapter DAPrds;
        SqlDataAdapter DAcats;
        SqlDataAdapter DAsups;
        DataTable dtPrds;
        DataTable dtCats;
        DataTable dtCats2;
        DataTable dtSups;
        DataTable dtSups2;
        BindingSource PrdbindingSource;
        Form super;
        public detailedView(Form super)
        {
            InitializeComponent();
            sqlCmdSelectAllPrds = new SqlCommand("Select * from Products", SqlCN);
            dtPrds = new();
            dtCats = new();
            dtCats2 = new();
            dtSups = new();
            dtSups2 = new();
            DAPrds = new SqlDataAdapter(sqlCmdSelectAllPrds);

            DAcats = new SqlDataAdapter("select categoryID, categoryName from categories", SqlCN);
            DAcats.Fill(dtCats);
            DAcats.Fill(dtCats2);

            DAsups = new SqlDataAdapter("select supplierID, companyName from suppliers", SqlCN);
            DAsups.Fill(dtSups);
            DAsups.Fill(dtSups2);

            catBOX.DataSource = dtCats;
            catAdd.DataSource = dtCats2;
            catBOX.DisplayMember = "categoryName";
            catAdd.DisplayMember = "categoryName";
            catBOX.ValueMember = "categoryID";
            catAdd.ValueMember = "categoryID";
            supBOX.DataSource = dtSups;
            supADD.DataSource = dtSups2;
            supBOX.DisplayMember = "companyName";
            supADD.DisplayMember = "companyName";
            supBOX.ValueMember = "supplierID";
            supADD.ValueMember = "supplierID";

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(DAPrds);
            DAPrds.UpdateCommand = commandBuilder.GetUpdateCommand();
            DAPrds.InsertCommand = commandBuilder.GetInsertCommand();
            DAPrds.DeleteCommand = commandBuilder.GetDeleteCommand();


            DAPrds.Fill(dtPrds);
            PrdbindingSource = new BindingSource(dtPrds, "");
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

            };
            this.Controls.Add(bindingNavigator);
            this.super = super;


        }

        private void detailedView_FormClosed(object sender, FormClosedEventArgs e)
        {
            super.Show();
        }

        private void commitBTN_Click(object sender, EventArgs e)
        {
            DAPrds.Update(dtPrds);
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtPrds.NewRow();

            newRow["ProductID"] = DBNull.Value;
            newRow["ProductName"] = nameAdd.Text;
            newRow["CategoryID"] = catAdd.SelectedValue;
            newRow["SupplierID"] = supADD.SelectedValue;

            dtPrds.Rows.Add(newRow);



            nameAdd.Clear();
            catAdd.SelectedIndex = 0;
            supADD.SelectedIndex = 0;

            DAPrds.Update(dtPrds);
            dtPrds.Clear();
            DAPrds.Fill(dtPrds);
        }
    }
}
