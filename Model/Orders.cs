using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class Orders:Products
    {
        public int OrderID { get; set; }
        public Customers customers { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
       
        public string OrderStatus { get; set; }

        public Orders()
        {
            customers = new Customers();
        }

        public override string ToString()
        {
            return $"OrderID::{OrderID}\t CustomerId::{customers.CustomerID}\t " +
                $"Orderdate::{OrderDate}\t TotalAmount::{TotalAmount}\t Status{OrderStatus}";
        }

    }
}
