using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Caps
{
    using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class getProductID
{
    private string connectionString;

    public getProductID(string connString)
    {
        connectionString = connString; // Store the connection string
    }

    public DataTable GetProductsByName(string productName)
    {
        DataTable productsTable = new DataTable();

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open the connection
                string query = "SELECT ProductID, ProductName, Price, QuantityInStock, Supplier, DateAdded FROM Products WHERE ProductName LIKE @ProductName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", "%" + productName + "%"); // Parameterize the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(productsTable); // Fill the DataTable with the result
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"SQL Error: {ex.Message}"); // Display any SQL errors
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}"); // Display general errors
        }

        return productsTable; // Return the DataTable with found products
    }
}

}
