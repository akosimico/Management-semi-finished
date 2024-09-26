using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Caps
{
    public class Expense
    {
        public string ExpenseType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public DateTime ExpenseDate { get; set; }    
    }
}
