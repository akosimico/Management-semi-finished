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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace All_Caps
{
    public partial class InventoryFrm : Form
    {
        private string connectionString = "Data Source=DESKTOP-33UQUOB\\SQLEXPRESS;Initial Catalog=All Caps;Integrated Security=True;";
        public InventoryFrm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            LoadOutOfStockProductsIntoDataGridView();
            DisplayTotalQuantityInStock();

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                // Create the SQL query to retrieve all columns and rows from a table
                string query = "SELECT * FROM Products WHERE QuantityInStock > 0";  

                // Establish the SQL connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    // Create a SqlDataAdapter to execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();  // Create a DataTable to hold the query result
                        adapter.Fill(dataTable);  // Fill the DataTable with the result from the query

                        // Set the DataSource property of the DataGridView to the DataTable
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (SqlException ex)
            {
                 // Handle SQL errors
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general errors
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
        private void LoadOutOfStockProductsIntoDataGridView()
        {
            try
            {
                // SQL query to show only out-of-stock products (QuantityInStock <= 0)
                string query = @"
            SELECT ProductID, ProductName, Price, QuantityInStock , Supplier, DateAdded
            FROM Products 
            WHERE QuantityInStock <= 0
            ORDER BY QuantityInStock";

                // Establish the SQL connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    // Create a SqlDataAdapter to execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();  // Create a DataTable to hold the query result
                        adapter.Fill(dataTable);  // Fill the DataTable with the result from the query

                        // Set the DataSource property of the DataGridView to the DataTable
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL errors
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general errors
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void DisplayTotalQuantityInStock()
        {
            try
            {
                // SQL query to get the sum of QuantityInStock
                string query = "SELECT SUM(QuantityInStock) AS TotalQuantityInStock FROM Products";

                // Establish the SQL connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute the query and get the total sum
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null and display the total in a label
                        if (result != DBNull.Value)
                        {
                            int totalQuantityInStock = Convert.ToInt32(result);
                            Total.Text = $"{totalQuantityInStock}";
                        }
                        else
                        {
                            // If no products are found, set the label to zero
                            Total.Text = "0";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL errors
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle general errors
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


    }
}
