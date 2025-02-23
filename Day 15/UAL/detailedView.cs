using BLL.Models;
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
            catBOX.DisplayMember = "CategoryName";
            catAdd.DisplayMember = "CategoryName";
            catBOX.ValueMember = "CategoryId";
            catAdd.ValueMember = "CategoryId";
            supBOX.DataSource = SupplierManager.SelectAllSuppliers();
            supADD.DataSource = SupplierManager.SelectAllSuppliers();
            supBOX.DisplayMember = "companyName";
            supADD.DisplayMember = "companyName";
            supBOX.ValueMember = "SupplierId";
            supADD.ValueMember = "SupplierId";

            PrdbindingSource = new BindingSource(ProductManager.SelectALLProducts().ToBindingList(),"");
            listBox1.DataSource = PrdbindingSource;
            listBox1.DisplayMember = "ProductName";
            listBox1.ValueMember = "ProductID";

            ///Simple Data Binding
            prodID.DataBindings.Add("Value", PrdbindingSource, "ProductID");
            nameTXT.DataBindings.Add("Text", PrdbindingSource, "ProductName");
            catBOX.DataBindings.Add("SelectedValue", PrdbindingSource, "CategoryId");
            supBOX.DataBindings.Add("SelectedValue", PrdbindingSource, "SupplierId");

            BindingNavigator bindingNavigator = new BindingNavigator(PrdbindingSource);
            PrdbindingSource.AddingNew += (sender, e) =>
            {
                e.NewObject = false;
                addBTN.PerformClick();
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
            ProductManager.Commit();
        }

        private void addBTN_Click(object sender, EventArgs e)
        {

            Product newRow = new Product()
            {
                ProductId = 0,
                ProductName = nameAdd.Text,
                CategoryId = (int)catAdd.SelectedValue,
                SupplierId = (int)supADD.SelectedValue,
            };

            PrdbindingSource.Add(newRow);




            nameAdd.Clear();
            catAdd.SelectedIndex = 0;
            supADD.SelectedIndex = 0;


        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            


        }

        private void prodID_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
