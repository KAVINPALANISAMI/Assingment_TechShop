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
    internal class OrderDetailsRepository : IOrderDetailsRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public OrderDetailsRepository()
        {
           // sqlConnection = new SqlConnection("Server=KING;Database=Ass_TechShop_C#;Trusted_Connection=True");
            sqlConnection = new SqlConnection(DBPropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public int AddDiscount(int orderid, int dis)
        {
            cmd.CommandText = "update Orders set TotalAmount=(TotalAmount*@dis)/100" +
                " where OrderId=@orid";
            cmd.Parameters.AddWithValue("@dis", 100-dis);
            cmd.Parameters.AddWithValue("@orid", orderid);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;

        }

        public List<OrderDetails> GetOrderDetailInfo()
        {
            List<OrderDetails> ordetaillist= new List<OrderDetails>();
            cmd.CommandText = "select p.ProductName,od.Quantity,r.TotalAmount from Products p " +
                "join OrderDetails od on p.ProductID=od.ProductID join Orders r " +
                "on r.OrderId=od.OrderID";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customers cust = new Customers();
                OrderDetails ordet = new OrderDetails();
                ordet.ProductName = (string)reader["ProductName"];
                ordet.Quantity = (int)reader["Quantity"];
                ordet.TotalAmount = (decimal)reader["TotalAmount"];
                ordetaillist.Add(ordet);
                
            }
            sqlConnection.Close();
            return ordetaillist;
        }

        public int UpdateQuantity(int orid, int quantity)
        {
            cmd.CommandText = "update OrderDetails set Quantity=@quantity " +
                "where OrderID=@orid";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@orid", orid);
            cmd.Connection=sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            Console.WriteLine(updateStatus);
            sqlConnection.Close();
            return updateStatus;


        }
    }
}
