using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Repository;
using TechShop.Repository.Interface;
using TechShop.Service.Interface;

namespace TechShop.Service
{
    internal class OrderDetailsService : IOrderDetailsService
    {
        readonly IOrderDetailsRepository _OrderDetailsRepository;
        public OrderDetailsService()
        {
            _OrderDetailsRepository = new OrderDetailsRepository();
        }

        public void AddDiscount()
        {
            Console.WriteLine("Enter orderID");
            int orderid=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Discount Percent");
            int dis=int.Parse(Console.ReadLine());
            int updateStatus = _OrderDetailsRepository.AddDiscount(orderid,dis);
            if (updateStatus > 0)
            {
                Console.WriteLine("Discount Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Update Canceled");
                Console.WriteLine("ReTry After Some Time");
            }


        }

        public void GetOrderDetailInfo()
        {
            List<OrderDetails> listOrderdetails = _OrderDetailsRepository.GetOrderDetailInfo();
            foreach (OrderDetails item in  listOrderdetails)
            { Console.WriteLine($"Product name:{item.ProductName}\tQuantity :" +
                $"{item.Quantity}\t TotalAmount:{item.TotalAmount}"); 
            }


        }

        public void UpdateQuantity()
        {
            Console.WriteLine("Enter odrer id" );
            int orid=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter update Quantity");
            int qantity=int.Parse(Console.ReadLine());
            int status = _OrderDetailsRepository.UpdateQuantity(orid,qantity);
            if (status > 0)
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
