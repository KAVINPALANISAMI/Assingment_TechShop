using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price {  get; set; }

        public override string ToString()
        {
            return $"PriductID::{ProductID}\t ProductName::{ProductName}\t Descripton::{Description}\t Pricr::{Price}";
        }
    }
}
