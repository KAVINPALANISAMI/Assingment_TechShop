using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository.Interface
{
    internal interface IOrderDetailsRepository
    {
        List<OrderDetails> GetOrderDetailInfo();
        int UpdateQuantity(int orid,int quantity);
        int AddDiscount(int orderid, int dis);
    }
}
