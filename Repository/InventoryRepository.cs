using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Repository.Interface;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class InventoryRepository : IInventoryRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public InventoryRepository()
        {
            //sqlConnection = new SqlConnection("Server=KING;Database=Ass_TechShop_C#;Trusted_Connection=True");
             sqlConnection = new SqlConnection(DBPropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public int AddToInventory(int productid, int quantity)
        {
            cmd.CommandText = "update Inventory set QuantityInStock=QuantityInStock+@quantity " +
                "where ProductID=@productid";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;
        }

        public int RemoveFromInventory(int productid, int quantity)
        {
            cmd.CommandText = "update Inventory set QuantityInStock=QuantityInStock-@quantity " +
                 "where ProductID=@productid";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;
        }

        public List<Inventory> GetProduct()
        {
            List<Inventory> inventorylist = new List<Inventory>();
            cmd.CommandText = "select p.ProductName,p.Price,i.QuantityInStock," +
                "i.LastStockUpdate from Products p join Inventory i " +
                "on p.ProductID=i.ProductID ";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Inventory inventory = new Inventory();
                inventory.ProductName = (string)reader["ProductName"];
                inventory.Price = (decimal)reader["Price"];
                inventory.QuantityInStock = (int)reader["QuantityInStock"];
                inventory.LastStockUpdate = (DateTime)reader["LastStockUpdate"];
                inventorylist.Add(inventory);
            }
            sqlConnection.Close();
            return inventorylist;
        }

        public List<Inventory> GetQuantityInStock()
        {
            List<Inventory > inventorylist = new List<Inventory>();
            cmd.CommandText = "select ProductID,QuantityInStock from Inventory ";

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Inventory inventory = new Inventory();
                inventory.ProductID = (int)reader["ProductID"];
                inventory.QuantityInStock = (int)reader["QuantityInStock"];
                inventorylist.Add(inventory);
            }
            sqlConnection.Close();
            return inventorylist;
        }

        public int UpdateStockQuantity(int productid, int quantity)
        {
            cmd.CommandText = "update Inventory set QuantityInStock=@quantity " +
                  "where ProductID=@productid";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;
        }

        public bool IsProductAvailable(int productid, int quantity)
        {
            int quantityofstock = 0;
            cmd.CommandText = "select QuantityInStock from Inventory" +
                " where ProductID=@productid";
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Connection= sqlConnection;
            sqlConnection.Open();
            SqlDataReader  reader = cmd.ExecuteReader();
            if(reader.Read()) 
            {
                quantityofstock = (int)reader["QuantityInStock"];
            }
            if(quantityofstock > 0) { return true; }
            else { return false; }
        }

        public List<int> ListLowStockProducts(int threshold)
        {
           List<int> listofProducts=new List<int>();
            int productid = 0;
            int quantity = 0;
            cmd.CommandText = "select ProductID,QuantityInStock from Inventory ";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productid = (int)reader["ProductID"];
                quantity = (int)reader["QuantityInStock"];
                if(quantity < threshold) { listofProducts.Add(productid); }              
            }
            sqlConnection.Close();
            return listofProducts;
        }

        public List<int> ListOutOfStockProducts()
        {
            List<int> listofProducts = new List<int>();
            int productid = 0;
            int quantity = 0;
            cmd.CommandText = "select ProductID,QuantityInStock from Inventory ";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productid = (int)reader["ProductID"];
                quantity = (int)reader["QuantityInStock"];
                if (quantity ==0) { listofProducts.Add(productid); }
            }
            sqlConnection.Close();
            return listofProducts;
        }

        public decimal GetInventoryValue()
        {
            decimal totalValue = 0;
            cmd.CommandText = "select sum(p.Price*i.QuantityInStock) as TotalValue " +
                "from Products p join Inventory i on p.ProductID=i.ProductID";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) { totalValue = (decimal)reader["TotalValue"]; }
            sqlConnection.Close ();
            return totalValue;
        }

        public List<Inventory> ListAllProducts()
        {
            List<Inventory> productslist = new List<Inventory>();
            cmd.CommandText = "Select * from Inventory";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Inventory product = new Inventory();
                product.ProductID = (int)reader["ProductID"];
                //product.ProductName = (string)reader["ProductName"];
                product.QuantityInStock = (int)reader["QuantityInStock"]; 
                productslist.Add(product);
            }
            sqlConnection.Close();
            return productslist;
        }

        public int AddproductToInventory(int proid, string proname, string prodes, decimal proprice, string procat, int inid, int inquantity, DateTime date)
        {
            cmd.CommandText = "insert into Products values(@id,@name,@des,@price,@cat)";         
            cmd.Parameters.AddWithValue("@id", proid);
            cmd.Parameters.AddWithValue("@name", proname);
            cmd.Parameters.AddWithValue("@des", prodes);
            cmd.Parameters.AddWithValue("@price", proprice);
            cmd.Parameters.AddWithValue("@cat", procat);
            cmd.Parameters.AddWithValue("@iid", inid);
            cmd.Parameters.AddWithValue("@quantity", inquantity);
            cmd.Parameters.AddWithValue("@date",date);
            cmd.Connection=sqlConnection;
            sqlConnection.Open();
            int status= cmd.ExecuteNonQuery();

            cmd.CommandText = "insert into Inventory values(@iid,@id,@quantity,@date)";
            int status1=cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status+status1;

        }

        public int RemoveproductfromInventory(int productid)
        {
            cmd.CommandText = "delete from Inventory where ProductID=@proid ";           
            cmd.Parameters.AddWithValue("@proid", productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int status=cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from Products where ProductID=@proid";
            int status1=cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status1+status1;
        }

        public List<OrderDetails> SalesReporting()
        {
           List<OrderDetails> details = new List<OrderDetails>();
            cmd.CommandText = "select ProductID, sum(Quantity) as [Quantity] from OrderDetails group by ProductID";
            cmd.Connection= sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            { 
                OrderDetails ord=new OrderDetails();
                ord.ProductID = (int)reader["ProductID"];
                ord.Quantity = (int)reader["Quantity"];
                details.Add(ord);
            }
            sqlConnection.Close();
            return details;
        }
    }
}
