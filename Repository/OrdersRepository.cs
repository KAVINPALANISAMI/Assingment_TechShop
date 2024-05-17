using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using TechShop.Model;
using TechShop.Repository.Interface;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class OrdersRepository : IOrdersRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public OrdersRepository()
        {
            //sqlConnection = new SqlConnection("Server=KING;Database=Ass_TechShop_C#;Trusted_Connection=True");
             sqlConnection = new SqlConnection(DBPropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        

        public decimal CalculateTotalAmount(int orderid)
        {
            #region
            decimal totalAmount = 0;
            decimal proprice=0;
            int quantity=0;
            string proname;
            cmd.CommandText = "select p.Price,p.ProductName,od.Quantity " +
                "from Products p join OrderDetails od on p.ProductID=od.ProductID where od.OrderID =@orderid";
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) 
            {
                proname = (string)reader["ProductName"];
                proprice = (decimal)reader["Price"];
                quantity = (int)reader["Quantity"];
            }
            Console.WriteLine(proprice);
            Console.WriteLine(quantity);
            sqlConnection.Close();
            return proprice*quantity;
            #endregion
        }

        public int CancelOrder(int orderid)
        {
            cmd.CommandText = "delete from Orders where OrderId=@orid";
            cmd.Parameters.AddWithValue("@orid", orderid);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;

        }

        public Orders GetOrderDetails(int orderid)
        {
            #region
            OrderDetails orderdetails = new OrderDetails();
            Products products = new Products();
            cmd.CommandText = "select p.ProductID,p.ProductName,od.Quantity from Products p join OrderDetails  od on p.ProductID=od.ProductID where OrderID=@orderid\r\n";
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()) 
            {
                orderdetails.ProductName = (string)reader["ProductName"];
                orderdetails.ProductID = (int)reader["ProductID"];
                orderdetails.Quantity = (int)reader["Quantity"];
            }
            sqlConnection.Close();
            return orderdetails;
            #endregion
        }

        public int PlacingCustomerOrders(int customerid, int productid, DateTime date, int quantity, string status,int orderdeteilid, decimal price)
        {
            cmd.CommandText = "insert into orders values(@id,@date,@price,@status)";
            cmd.CommandText = "insert into Orderdetails values(@ordeid,@orderid,@productid,@quantity)";
            cmd.CommandText = "update inventory set quantityinstock=quantityinstock-@quantity where productid=@productid";
            cmd.Parameters.AddWithValue("@id", customerid );
            cmd.Parameters.AddWithValue("@date",  date);
            cmd.Parameters.AddWithValue("@price",  price);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productid", productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
           int orderstatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return orderstatus;
        }

        public string TrackingOrderStatus(int orderid)
        {
            string sts="";
            cmd.CommandText = "select status as [sts] from Orders where OrderId=@id";
            cmd.Parameters.AddWithValue("id", orderid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read ()) { sts = (string)reader["sts"];  }
            return sts;


        }

        //public   List<int> GetOrderDetailsforcancelOrders(int orderid)
        //{

        //    List<int> ordetail = new List<int>();
        //    cmd.CommandText = "select p.ProductID,od.Quantity from Products p join OrderDetails  od on p.ProductID=od.ProductID where OrderID=@orderid";
        //    cmd.Parameters.AddWithValue("@orderid", orderid);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {

        //        ordetail[0] = (int)reader["ProductID"];
        //        ordetail[1] = (int)reader["Quantity"];
        //    }
        //    sqlConnection.Close();

        //}

        public int UpdateOrderStatus(int orderid)
        {
            cmd.CommandText = "Select * from Orders update Orders " +
                "set [Status]='Shipped'where OrderId= @orid";
            cmd.Parameters.AddWithValue("@orid", orderid);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close() ;
            return updateStatus;

        }
    }
}
