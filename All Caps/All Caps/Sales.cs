using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_Caps
{
    public partial class Sales : Form
    {
        private string connectionString = "Data Source=DESKTOP-33UQUOB\\SQLEXPRESS;Initial Catalog=All Caps;Integrated Security=True;";
        private getProductID ProdID;
        public Sales()
        {
            InitializeComponent();
            ProdID = new getProductID(connectionString);
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim(); // Get product name from input
            DataTable productsTable = ProdID.GetProductsByName(productName); // Call the method to search for products

            // Check if any products were found
            if (productsTable.Rows.Count > 0)
            {
                dataGridView1.DataSource = productsTable; // Bind the DataTable to the DataGridView
            }
            else
            {
                MessageBox.Show("No products found with that name.");
                dataGridView1.DataSource = null; // Clear DataGridView if no products found
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                ProductID = Convert.ToInt32(ProductID.Text),
                QuantitySold = Convert.ToInt32(Qty.Text),
                SalePrice = Convert.ToDouble(Price.Text),
                SaleDate = guna2DateTimePicker1.Value,
                CustomerName = CustName.Text.Trim(),
                PaymentMethod = paymentmethod.Text.Trim()
            };

            // Create a SalesManager instance
            SalesManager salesManager = new SalesManager(connectionString); // Replace with your actual connection string

            // Attempt to insert the sale
            bool success = salesManager.InsertSale(sale);

            if (success)
            {
                MessageBox.Show("Sale recorded successfully and stock updated.");
                ProductID.Text = "";
                Qty.Text = "";
                CustName.Text = "";
                Price.Text = "";
                paymentmethod.Text = "";
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
