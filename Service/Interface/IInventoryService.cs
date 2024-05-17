using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Service.Interface
{
    internal interface IInventoryService
    {
        void GetProduct();
        void GetQuantityInStock();
        void AddToInventory();
        void RemoveFromInventory();
        void UpdateStockQuantity();
        void IsProductAvailable();
        void ListLowStockProducts();
        void ListOutOfStockProducts();
        void GetInventoryValue();
        void ListAllProducts();
        void AddproductToInventory();
        void RemoveproductfromInventory();
        void SalesReporting();

    }
}
