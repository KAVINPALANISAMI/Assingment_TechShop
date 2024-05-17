using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository.Interface
{
    internal interface IInventoryRepository
    {
        public List<Inventory> GetProduct();
        public List<Inventory> GetQuantityInStock();
        public int AddToInventory(int productid,int  quantity);
        public int RemoveFromInventory(int productid,int quantity);
        public int UpdateStockQuantity(int productid, int quantity);
        public bool IsProductAvailable(int productid, int quantity);
        public List<int> ListLowStockProducts(int threshold);
        public List<int> ListOutOfStockProducts();
        public decimal GetInventoryValue();
        public List<Inventory> ListAllProducts();
         int AddproductToInventory(int proid, string proname, string prodes, decimal proprice, string procat, int inid, int inquantity, DateTime date);
        int RemoveproductfromInventory(int productid);
        List<OrderDetails> SalesReporting();
    }
}
