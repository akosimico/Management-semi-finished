using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace All_Caps
{
    public class SalesManager
    {
        private string connectionString;

        public SalesManager(string connString)
        {
            connectionString = connString;
        }

        public bool InsertSale(Sale sale)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                BEGIN TRANSACTION;
                INSERT INTO Sales (ProductID, QuantitySold, SalePrice, SaleDate, CustomerName, PaymentMethod)
                VALUES (@ProductID, @QuantitySold, @SalePrice, @SaleDate, @CustomerName, @PaymentMethod);
                UPDATE Products
                SET QuantityInStock = QuantityInStock - @QuantitySold
                WHERE ProductID = @ProductID;
                COMMIT TRANSACTION;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", sale.ProductID);
                    cmd.Parameters.AddWithValue("@QuantitySold", sale.QuantitySold);
                    cmd.Parameters.AddWithValue("@SalePrice", sale.SalePrice);
                    cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    cmd.Parameters.AddWithValue("@CustomerName", sale.CustomerName);
                    cmd.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; // Sale recorded successfully
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"SQL Error: {ex.Message}");
                        return false; // Indicate failure
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        return false; // Indicate failure
                    }
                }
            }
        }
    }
}
