using TechShop.Model;
using TechShop.Repository;
using TechShop.Repository.Interface;
using TechShop.Service.Interface;

namespace TechShop.Service
{
    internal class ProductsService : IProductsService
    {
        readonly IProductsRepository _productsRepository;
        public ProductsService()
        {
            _productsRepository = new ProductsRepository();
        }

        public void GetProductDetails()
        {
            List<Products> listofProducts = _productsRepository.GetProductDetails();
            foreach (Products product in listofProducts) 
            { Console.WriteLine(product); }
        }

        public void IsProductInStock()
        {
            Console.WriteLine("Enter the PerductId which stock is needed");
            int productId=int.Parse(Console.ReadLine());
            int productInStock = _productsRepository.ProductInStock(productId);
            if(productInStock > 0)
            {
                Console.WriteLine($"Prduct in stock \nQuantity is ::{productInStock}");
            }
            else
            { Console.WriteLine("Product Not in Stock"); }


        }

        public void ProductSearch()
        {
            Console.WriteLine("Enter Product Category");
            Console.WriteLine("Lap / Mobile / Acesserys");
            string category=Console.ReadLine();
            List<Products> products = _productsRepository.ProductSearch(category);
            foreach (Products product in products)
            { Console.WriteLine(product); }
        }

        public void UpdateProductInfo()
        {
            Products product = new Products();
            Console.WriteLine("Updating panel \nEnter update details");
            Console.WriteLine("Enter Product Id");
            product.ProductID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description");
            product.Description = Console.ReadLine();
            Console.WriteLine("Enter Price");
            product.Price=Decimal.Parse( Console.ReadLine());

            int updateStatus = _productsRepository.UpdateProductInfo(product);
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
