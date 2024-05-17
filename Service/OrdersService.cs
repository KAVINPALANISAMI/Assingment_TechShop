using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exception;
using TechShop.Model;
using TechShop.Repository;
using TechShop.Repository.Interface;
using TechShop.Service.Interface;

namespace TechShop.Service
{
    internal class OrdersService : IOrdersService
    {
        readonly IOrdersRepository _ordersRepository;
        public OrdersService()
        {
            _ordersRepository = new OrdersRepository();
        }


        public void CalculateTotalAmount()
        {
            int orderid;
            Console.WriteLine("Enter the orderId to calculate the total amount");
            orderid=int.Parse(Console.ReadLine());
            Console.WriteLine("Total amount for the Order is ::");
            Console.WriteLine(_ordersRepository.CalculateTotalAmount(orderid));
        }

        public void CancelOrder()
        {
            int orderid = 0;
            Console.WriteLine("Enter the Orderid to cancel");
            orderid = int.Parse(Console.ReadLine());
            int cancelStatus = _ordersRepository.CancelOrder(orderid);
            if (cancelStatus > 0)
            {
                Console.WriteLine("Order canceled Sucessfully");
            }
            else
            {
                Console.WriteLine("Order not Canceled");
                Console.WriteLine("ReTry After Some Time");
            }



        }

        public void GetOrderDetails()
        {
            int orderid;
            Console.WriteLine("Enter the orderId ");
            orderid = int.Parse(Console.ReadLine());
            Orders orderdetail = _ordersRepository.GetOrderDetails(orderid);
            Console.WriteLine($"ProductId::{orderdetail.ProductID}\t ProductName::{orderdetail.ProductName}" +
                $" Quantity::");
        }

        public void PlacingCustomerOrders()
        {
            Console.WriteLine("Enter customer id:");
            int customerid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter productid");
            int productid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter order date in YYYY/MM/DD:");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order Detail Id");
            int orderdetailid=int.Parse(Console.ReadLine());            
            Console.WriteLine("Enter quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter status of order:");
            string status = Console.ReadLine();
            int orderstatus = _ordersRepository.PlacingCustomerOrders(customerid, productid, date, quantity, status,orderdetailid,price);
            if (orderstatus > 0)
            {
                Console.WriteLine("Order is placed");
            }
            else { Console.WriteLine("Order not placed"); }
        }

        public void TrackingOrderStatus()
        {
            Console.WriteLine("Traking Order");
            Console.WriteLine("Enter Orderid");
            int orderid = int.Parse(Console.ReadLine());
            string status = _ordersRepository.TrackingOrderStatus(orderid);
            Console.WriteLine($"Status of the order is ::{status}");


        }

        public void UpdateOrderStatus()
        {
            Console.WriteLine("Enter the OrderId");
            int orderid=int.Parse( Console.ReadLine());
            int updateStatus = _ordersRepository.UpdateOrderStatus(orderid);
            if (updateStatus > 0)
            {
                Console.WriteLine("Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Update Canceled");
                Console.WriteLine("ReTry After Some Time");
            }

        }
    }
}
