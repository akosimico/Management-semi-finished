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
    public partial class ExpensesFrm : Form
    {
        private ExpenseDatabase ED;
        public ExpensesFrm()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-33UQUOB\\SQLEXPRESS;Initial Catalog=All Caps;Integrated Security=True;";
            ED = new ExpenseDatabase(connectionString);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Expense expense = new Expense
            {
                ExpenseType = ExpenseType.Text,
                Amount = Convert.ToDouble(Price.Text),
                Description = Description.Text,
                ExpenseDate = guna2DateTimePicker1.Value
            };

            bool success = ED.InsertExpense(expense);

            if (success) 
            {
                MessageBox.Show("Expense added successfully");
                ExpenseType.Text = "";
                Price.Text = string.Empty;
                Description.Text = string.Empty ;
                
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
    }
}
