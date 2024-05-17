using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository.Interface
{
    internal interface IOrdersRepository
    {
        decimal CalculateTotalAmount(int orderid);
        Orders GetOrderDetails(int orderid);
        int UpdateOrderStatus(int orderid);
        int CancelOrder(int orderid);
        int PlacingCustomerOrders(int customerid,int productid,DateTime date,int quantity,string status,int orderdetailid,decimal price);
        string TrackingOrderStatus(int orderid);
        
    }
}
