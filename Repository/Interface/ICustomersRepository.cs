using TechShop.Model;

namespace TechShop.Repository.Interface
{
    internal interface ICustomersRepository
    {

        //• CalculateTotalOrders() : Calculates the total number of orders placed by this customer.
        //• GetCustomerDetails() : Retrieves and displays detailed information about the customer.
        //• UpdateCustomerInfo(): Allows the customer to update their information (e.g., email, phone, or
        //address).

         int  CalculateTotalOrders(int a);
         List<Customers> GetCustomerDetails();
         int UpdateCustomerInfo(Customers customer);
        int CustomerRegistration(int id, string fname, string lname, string pno, string email, string address);

    }
}
