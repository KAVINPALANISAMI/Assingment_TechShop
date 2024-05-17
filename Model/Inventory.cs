using System.Diagnostics;

namespace TechShop.Model
{
    internal class Inventory:Products
    {
        public int  InventoryID {get;set;}
        Products product { get;set;}
        public int QuantityInStock { get;set;}
        public DateTime LastStockUpdate { get;set;}

        public override string ToString()
        {
            return $"InventoryID::{InventoryID}\t ProductID::{product.ProductID}\t QuantityInStock::{QuantityInStock}\tLastStockUpdate::{LastStockUpdate} ";
        }
    }

   
}
 