using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace All_Caps
{
    using System.Data.SqlClient;
    public class ProductDatabase
    {
        private string connectionString;

        public ProductDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool InsertProduct(Product product)
        {
            string query = "INSERT INTO Products (ProductName, Price, QuantityInStock, Supplier, DateAdded) " +
                           "VALUES (@ProductName, @Price, @QuantityInStock, @Supplier, @DateAdded)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    conn.Open();
                  
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                        cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
                        cmd.Parameters.AddWithValue("@DateAdded", product.DateAdded);

                        cmd.ExecuteNonQuery();
                        return true; 
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
