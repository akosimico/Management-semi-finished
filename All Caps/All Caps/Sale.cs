using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Caps
{
    public class Sale
    {
        public int ProductID { get; set; }
        public int QuantitySold { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
    }
}
