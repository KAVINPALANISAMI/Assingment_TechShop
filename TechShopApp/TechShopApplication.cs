using TechShop.Repository;
using TechShop.Repository.Interface;
using TechShop.Service;
using TechShop.Service.Interface;

namespace TechShop.TechShopApp
{
    internal class TechShopApplication
    {
        readonly ICustomersService _icustomersService;
        readonly IProductsService _productsService;
        readonly IOrdersService _ordersService;
        readonly IOrderDetailsService _orderDetailsService;
        readonly IInventoryService _inventoryService;

        public TechShopApplication()
        {
            _icustomersService = new CustomersService();
            _productsService = new ProductsService();
         
         _ordersService = new OrdersService();
            _orderDetailsService = new OrderDetailsService();
            _inventoryService =new InventoryService();
        }

        public void run()
        {
            Console.WriteLine("Welcome to Tech Shop");
            Console.WriteLine("1.New Registeration\n2. Product Catalog Management\n3.Place order\n4.Tracking order\n5.Inventory Management\n6.Sales Reporting\n7. Updates  Account  Details t" +
                "\n8.Product Search and Recommendations\n9.Sub menue");
            int opt = int.Parse(Console.ReadLine());
            switch(opt) 
            {
                case 1:
                    {
                        _icustomersService.CustomerRegistration();
                        break;
                    }
                case 2: 
                    {
                        Console.WriteLine("Product Catalog Management");
                        Console.WriteLine("1.View products\n2.UpdateProductInfo\n3.IsProductInStock");
                        int productopt = int.Parse(Console.ReadLine());
                        switch(productopt) 
                        {
                            case 1:
                                {
                                    _productsService.GetProductDetails();
                                    break;
                                }
                            case 2:
                                {
                                    _productsService.UpdateProductInfo();
                                    break;
                                }
                            case 3:
                                {
                                    _productsService.IsProductInStock();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("The Value is not valid");
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        _ordersService.PlacingCustomerOrders();
                        break;
                    }
                case 4:
                    {
                        _ordersService.TrackingOrderStatus();
                        break;
                    }
                case 5:
                    {

                        Console.WriteLine("welcome to Inventory");
                        Console.WriteLine("1.Add product\n2.Update product\n3.remove product\n4.GetProduct\n" +
                            "5.GetQuantityInStock\n6.AddToInventory\n7.RemoveFromInventory\n8.UpdateStockQuantity\n" +
                            "9.IsProductAvailable\n10.ListLowStockProducts\n11.ListOutOfStockProducts\n" +
                            "12.GetInventoryValue\n13.ListAllProducts");
                        int inventoryopt=int.Parse(Console.ReadLine());
  
                        switch (inventoryopt)
                        {
                            case 1:
                                {

                                    _inventoryService.AddproductToInventory();
                                    break;
                                }
                            case 2:
                                {
                                    _inventoryService.UpdateStockQuantity();
                                    break;
                                }
                            case 3:
                                {
                                    _inventoryService.RemoveproductfromInventory();
                                    break;
                                }
                            case 4:
                                {
                                    _inventoryService.GetProduct();
                                    break;

                                }
                            case 5:
                                { _inventoryService.GetQuantityInStock(); 
                                    break;
                                }
                            case 6:
                                {
                                    _inventoryService.AddToInventory();
                                    break;
                                }
                            case 7:
                                {
                                    _inventoryService.RemoveFromInventory();
                                    break;
                                }
                            case 8:
                                {
                                    _inventoryService.UpdateStockQuantity();
                                    break;
                                }
                            case 9:
                                {
                                    _inventoryService.IsProductAvailable();
                                    break;
                                }
                            case 10:
                                {
                                    _inventoryService.ListLowStockProducts();
                                    break;
                                }
                            case 11:
                                {

                                    _inventoryService.ListOutOfStockProducts();
                                    break ;
                                }
                            case 12:
                                {

                                    _inventoryService.GetInventoryValue();
                                    break;
                                }
                            case 13:
                                {

                                    _inventoryService.ListAllProducts();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Enter value is wrong");
                                    break;
                                }

                        }    
                        break;
                    }
                case 6: 
                    {
                        _inventoryService.SalesReporting();
                        break;
                    }
                case 7: 
                    {
                        _icustomersService.UpdateCustomerInfo();
                        break;
                    }
                case 8: 
                    {
                        _productsService.ProductSearch();
                        break;
                    }
                case 9: 
                    {
                        Console.WriteLine("Sub Menue");
                        Console.WriteLine("1.GetCustomerDetails\n2.CalculateTotalOrders\n3.CalculateTotalAmount\n" +
                            "4.GetOrderDetails\n5.UpdateOrderStatus\n6.CancelOrder\n7.GetOrderDetailInfo\n" +
                            "8.UpdateQuantity\n9.AddDiscount");
                        int option=int.Parse(Console.ReadLine());                
                        switch (option)
                        {
                            case 1:
                                {
                                    _icustomersService.GetCustomerDetails();
                                    break;
                                }
                            case 2: 
                                {
                                    _icustomersService.CalculateTotalOrders();
                                    break;
                                }
                            case 3:
                                {
                                    _ordersService.CalculateTotalAmount();
                                    break;
                                }
                            case 4:
                                {
                                    _ordersService.GetOrderDetails();
                                    break;
                                }
                            case 5:
                                {
                                    _ordersService.UpdateOrderStatus();
                                    break;
                                }
                            case 6:
                                {
                                    _ordersService.CancelOrder();
                                    break; 
                                }
                            case 7: 
                                { _orderDetailsService.GetOrderDetailInfo();
                                    break; 
                                }
                            case 8: 
                                {
                                    _orderDetailsService.UpdateQuantity();  
                                    break; 
                                }
                            case 9: 
                                {

                                    _orderDetailsService.AddDiscount();
                                    break;
                                }
                            default: 
                                { 
                                    Console.WriteLine("Enter value is wrong");
                                    break; 
                                }

                        }
                        break;
                    }



            }

           
           
          
           
          
           
        }

    }
}
