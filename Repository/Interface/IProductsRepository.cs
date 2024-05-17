using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository.Interface
{
    internal interface IProductsRepository
    {
        List<Products> GetProductDetails();
        int UpdateProductInfo(Products product);
        int ProductInStock(int id);
        List<Products> ProductSearch(string categories);
    }
}
