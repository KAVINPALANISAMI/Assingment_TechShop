using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Service.Interface
{
    internal interface IOrdersService
    {
        void CalculateTotalAmount();
        void GetOrderDetails();
        void UpdateOrderStatus();
        void CancelOrder();
        void PlacingCustomerOrders();
        void TrackingOrderStatus();
        
    }
}
