using System.Data.SqlClient;
using TechShop.Model;
using TechShop.Repository.Interface;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class ProductsRepository : IProductsRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public ProductsRepository()
        {
          //  sqlConnection = new SqlConnection("Server=KING;Database=Ass_TechShop_C#;Trusted_Connection=True");
             sqlConnection = new SqlConnection(DBPropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Products> GetProductDetails()
        {
            List<Products> productslist = new List<Products>();
            cmd.CommandText = "Select * from Products";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            { 
                Products product = new Products();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = (string)reader["ProductName"];
                product.Description= (string)reader["Description"];
                product.Price = (Decimal)reader["Price"];
                productslist.Add(product);
            }
            sqlConnection.Close();
            return productslist;
        }

        public int ProductInStock(int id)
        {
            int productinStock = 0;
            cmd.CommandText = "select QuantityInStock from Inventory where ProductID=@productid";
            cmd.Parameters.AddWithValue("@productid", id);
            cmd.Connection=sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                productinStock = (int)reader[0];
            }
            return productinStock;
        }

        public List<Products> ProductSearch(string categories)
        {
            List<Products> productslist = new List<Products>();
            cmd.CommandText = "Select * from Products where Category=@cat ";
            cmd.Parameters.AddWithValue("@cat",categories);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products product = new Products();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = (string)reader["ProductName"];
                product.Description = (string)reader["Description"];
                product.Price = (Decimal)reader["Price"];
                productslist.Add(product);
            }
            sqlConnection.Close();
            return productslist;
        }

        public int UpdateProductInfo(Products product)
        {
            cmd.CommandText = "update Products set Price=@price,Description=@description " +
                "where ProductId=@productid";
            cmd.Parameters.AddWithValue("@productid", product.ProductID);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@price",product.Price);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;
            
        }
    }
}
