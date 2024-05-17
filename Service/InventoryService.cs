using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Repository;
using TechShop.Repository.Interface;
using TechShop.Service.Interface;

namespace TechShop.Service
{
    internal class InventoryService: IInventoryService
    {
        readonly IInventoryRepository _inventoryRepository;

        public InventoryService()
        {
            _inventoryRepository =new InventoryRepository();
        }

        public void AddToInventory()
        {
            Console.WriteLine("Enter ProductId");
            int productid=int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Quantity of stocks to be added");
            int quantity=int.Parse(Console.ReadLine());
            int Status = _inventoryRepository.AddToInventory(productid, quantity);
            if (Status > 0)
            {
                Console.WriteLine("Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Update Canceled");
                Console.WriteLine("ReTry After Some Time");
            }
        }

        public void RemoveFromInventory()
        {
            Console.WriteLine("Enter ProductId");
            int productid = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Quantity of stocks to be Removed");
            int quantity = int.Parse(Console.ReadLine());
            int Status = _inventoryRepository.RemoveFromInventory(productid, quantity);
            if (Status > 0)
            {
                Console.WriteLine("Product Removed Sucessfully");
            }
            else
            {
                Console.WriteLine("Update Canceled");
                Console.WriteLine("ReTry After Some Time");
            }
        }

        public void GetProduct()
        {
            List<Inventory> inventory = _inventoryRepository.GetProduct();
            foreach (Inventory inventory1 in inventory) 
            { Console.WriteLine($"Product Name:{inventory1.ProductName}\t " +
                $"Price:{inventory1.Price}\t Qutntity in Stock :" +
                $"{inventory1.QuantityInStock}\t Last Stack update :" +
                $"{inventory1.LastStockUpdate}"); 
            }
        }

        public void GetQuantityInStock()
        {
            List<Inventory> quantityinstock = _inventoryRepository.GetQuantityInStock();
            foreach (Inventory inventory in quantityinstock)
            { Console.WriteLine($"ProductId:{inventory.ProductID}\t " +
                $"In Stock:{inventory.QuantityInStock}"); }

        }

        public void UpdateStockQuantity()
        {
            Console.WriteLine("Enter ProductId");
            int productid = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Quantity of stocks to update");
            int quantity = int.Parse(Console.ReadLine());
            int Status = _inventoryRepository.UpdateStockQuantity(productid, quantity);
            if (Status > 0)
            {
                Console.WriteLine("Product Removed Sucessfully");
            }
            else
            {
                Console.WriteLine("Update Canceled");
                Console.WriteLine("ReTry After Some Time");
            }
        }

        public void IsProductAvailable()
        {
            Console.WriteLine("Enter ProductId");
            int productid = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Quantity of stocks that need to be checked");
            int quantity = int.Parse(Console.ReadLine());
            bool instack = _inventoryRepository.IsProductAvailable(productid, quantity);
            if (instack)
            {
                Console.WriteLine("Product is in stock");
            }
            else
            {
                Console.WriteLine("Product is out of stock");               
            }
        }

        public void ListLowStockProducts()
        {
            Console.WriteLine(" Enter threshold value of stocks ");
            int threshold = int.Parse(Console.ReadLine());
            List<int> listlowinstock =_inventoryRepository.ListLowStockProducts(threshold);
            if(listlowinstock!=null)
            {              
                for(int i=0;i<listlowinstock.Count;i++) 
                { Console.WriteLine(listlowinstock[i]); }
            }
        }

        public void ListOutOfStockProducts()
        {
            List<int> listlowinstock = _inventoryRepository.ListOutOfStockProducts();
            if (listlowinstock != null)
            {
                for (int i = 0; i < listlowinstock.Count; i++)
                { Console.WriteLine(listlowinstock[i]); }
            }
        }

        public void GetInventoryValue()
        {
            decimal totalValue = _inventoryRepository.GetInventoryValue();
            Console.WriteLine($"The Total Value of the Inventory is:{totalValue}");
        }

        public void ListAllProducts()
        {
            List<Inventory> listofProducts = _inventoryRepository.ListAllProducts();
            foreach (Inventory product in listofProducts)
            { Console.WriteLine($"Prodict Id::{product.ProductID}\t " +
                $"QuantityInStock::{product.QuantityInStock}"); }
        }
        public void AddproductToInventory()
        {
            Console.WriteLine("Add product to Inventory");
            Console.WriteLine("Enter Product Id");
            int proid = int.Parse(Console.ReadLine());
            Console.WriteLine("Product Name");
            string proname = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string prodes = Console.ReadLine();
            Console.WriteLine("Enter product Price");
            decimal proprice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter catigories ");
            Console.WriteLine("Lap or Mobile or Acesserys");
            string procat = Console.ReadLine();
            Console.WriteLine("Enter Inventory Id");
            int inid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter added Quantity");
            int inquantity = int.Parse(Console.ReadLine());
            DateTime date = DateTime.Now;

            int status = _inventoryRepository.AddproductToInventory(proid, proname, prodes, proprice, procat, inid, inquantity, date);
            if (status > 0) { Console.WriteLine("Inventory Updated"); }
            else { Console.WriteLine("Inventory Not updated"); }

        }

        public void RemoveproductfromInventory()
        {
            Console.WriteLine("Remove product from Inventory");
            Console.WriteLine("Enter product id ");
            int proid=int.Parse(Console.ReadLine());
            int status = _inventoryRepository.RemoveproductfromInventory(proid);
            if(status>=2) { Console.WriteLine("Product deletef from Inventory"); }
            else { Console.WriteLine("Product not deletef"); }
        }

        public void SalesReporting()
        {
            List<OrderDetails> salsereport= _inventoryRepository.SalesReporting();
            foreach (OrderDetails item in salsereport) 
            { Console.WriteLine($"ProductId::{item.ProductID}\t Quantoty::{item.Quantity}"); }
            
        }
    }

}
