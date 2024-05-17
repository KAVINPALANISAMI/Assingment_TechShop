using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Service.Interface
{
    internal interface IOrderDetailsService
    {
        void GetOrderDetailInfo();
        void UpdateQuantity();
        void AddDiscount();

    }
}
