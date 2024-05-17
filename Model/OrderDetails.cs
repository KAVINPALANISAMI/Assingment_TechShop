using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Model
{
    internal class OrderDetails:Orders
    {
        public int OrderDetailID { get; set; }
        Orders order { get; set; }
        Products product {  get; set; }
        //public int quantity { get; set; }
        int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { if (value > 0) quantity = value; }
        }

        public override string ToString()
        {
            return $"OrderDetilsID::{OrderDetailID}\t OrderID::{order.OrderID}\t PRoductID::{product.ProductID}\t Quantity::{Quantity}";
        }
    }
}
