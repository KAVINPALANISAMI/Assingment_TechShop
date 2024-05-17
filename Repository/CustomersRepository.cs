using System.Data;
using System.Data.SqlClient;
using TechShop.Model;
using TechShop.Repository.Interface;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class CustomersRepository : ICustomersRepository
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public CustomersRepository()
        {
           // sqlConnection = new SqlConnection("Server=KING;Database=Ass_TechShop_C#;Trusted_Connection=True");
                sqlConnection = new SqlConnection(DBPropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public int CalculateTotalOrders(int id)
        {
            #region
            int noOrders =0;
            cmd.CommandText = "select count(OrderId) as orr from Orders " +
                "group by CustomerId Having CustomerId=@CuatomerID";
            cmd.Parameters.AddWithValue("@CuatomerID", id);
            cmd.Connection= sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                noOrders = (int)reader["orr"];
            }
            return noOrders;
            #endregion
        }

        public int CustomerRegistration(int id, string fname, string lname, string phone, string email, string address)
        {
            cmd.CommandText = "insert into customers values(@id,@fname,@lname,@email,@pno,@address,@count)";
            cmd.Parameters.AddWithValue("@id", id);              
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@pno", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@count", 0);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int CustomerRegistrationstatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return CustomerRegistrationstatus;
        }

        public List<Customers> GetCustomerDetails()
        {
            #region
            List<Customers> customerDetail = new List<Customers>();
            cmd.CommandText = "select * from Customers";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customers cust = new Customers();
                cust.CustomerID = (int)reader["CustomerID"];
                cust.FirstName = (string)reader["FirstName"];
                cust.LastName = (string)reader["LastName"];
                cust.Email = (string)reader["Email"];
                cust.Phone = (string)reader["Phone"];
                cust.Address = (string)reader["Adress"];
                //cust.NoORders = (int)reader["No.Orders"];
                customerDetail.Add(cust);
            }
            sqlConnection.Close();
            return customerDetail;
            
            #endregion
        }

        public int UpdateCustomerInfo(Customers customer)
        {
            #region
            cmd.CommandText = "update Customers set Email=@email,Phone=@phone," +
                "Adress=@address where customerID=@customerid";
            cmd.Parameters.AddWithValue("@customerid", customer.CustomerID);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@phone",customer.Phone);
            cmd.Parameters.AddWithValue("@address",customer.Address);  

            cmd.Connection=sqlConnection;
            sqlConnection.Open();
            int updateStatus=cmd.ExecuteNonQuery();
            sqlConnection.Close() ;
            return updateStatus ;
            #endregion
        }

    }   
}
