using System.Data.SqlClient;
using TechShop.Model;
using TechShop.Service;
using TechShop.Service.Interface;
using TechShop.TechShopApp;

namespace TechShop
{
    internal class Program
    {
        public Program()
        {
            
        }

        static void Main(string[] args)
        {
       
            TechShopApplication app = new TechShopApplication();   
            app.run();
        }
    }
}
