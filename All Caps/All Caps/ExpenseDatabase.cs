using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace All_Caps
{
    public class ExpenseDatabase
    {
        private string connectionString;

        public ExpenseDatabase(string connectionString)        {
            this.connectionString = connectionString;
        }

        public bool InsertExpense(Expense expense)
        {
            string query = "INSERT INTO Expenses (ExpenseType, Amount, ExpenseDate, Description) " +
                "VALUES (@ExpenseType, @Amount, @ExpenseDate, @Description)";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExpenseType", expense.ExpenseType);
                        cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                        cmd.Parameters.AddWithValue("@Description", expense.Description);
                        cmd.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate);

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
                MessageBox.Show("Errpr: " + ex.Message);
                return false;
            }

        }
    }
}
