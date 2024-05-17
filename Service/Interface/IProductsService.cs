using TechShop.Repository.Interface;
using TechShop.Repository;

namespace TechShop.Service.Interface
{
    internal interface IProductsService
    {
        void GetProductDetails();
        void UpdateProductInfo();
        void IsProductInStock();
        void ProductSearch();
    }
}
