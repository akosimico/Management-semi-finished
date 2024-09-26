using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_Caps
{
    public partial class ProductForm : Form
    {
        private ProductDatabase PD;
        public ProductForm()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-33UQUOB\\SQLEXPRESS;Initial Catalog=All Caps;Integrated Security=True;";
            PD = new ProductDatabase(connectionString);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Product product = new Product
            {
                ProductName = ProductName.Text,
                Price = Convert.ToDouble(Price.Text),
                QuantityInStock = Convert.ToInt32(Quantity.Text),
                Supplier = Supplier.Text,
                DateAdded = guna2DateTimePicker1.Value
            };
            MessageBox.Show($"Product Name: {product.ProductName}\nPrice: {product.Price}\nQuantity: {product.QuantityInStock}");

            bool success = PD.InsertProduct(product);

            if (success)
            {
                MessageBox.Show("Product added successfully");
                ProductName.Text = "";
                Price.Text = "";
                Quantity.Text = "";
                Supplier.Text = "";
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
