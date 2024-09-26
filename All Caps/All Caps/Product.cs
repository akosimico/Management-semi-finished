using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Caps
{
    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public string Supplier { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
