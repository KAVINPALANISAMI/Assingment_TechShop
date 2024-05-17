using TechShop.Model;
using TechShop.Repository.Interface;
using TechShop.Service.Interface;
using TechShop.Repository;
using TechShop.Exception;




namespace TechShop.Service
{
    internal class CustomersService : ICustomersService
    {
        readonly ICustomersRepository _customersRepository;
        public CustomersService()
        {
            _customersRepository = new CustomersRepository();
        }
        public void CalculateTotalOrders()
        {
            Console.WriteLine("Enter the Customer ID ");
            int cusID =int.Parse(Console.ReadLine());
            int ordercount=_customersRepository.CalculateTotalOrders(cusID);
            Console.WriteLine($"The Total number of orders placed by the customer is :{ordercount}");
        }

        public void CustomerRegistration()
        {
            customer:
            try
            {
                Console.WriteLine("----Registration------");
                Console.WriteLine("Enter customer id::");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter firstname::");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter lastname::");
                string lname = Console.ReadLine();
                Console.WriteLine("Enter address::");
                string address = Console.ReadLine();
                Console.WriteLine("Enter email::");
                string email = Console.ReadLine();
                Console.WriteLine("Enter phone number::");
                string phone = Console.ReadLine();
                if (phone.Count()==10)
                {
                    if ((email.Contains("gmail.com"))&& (!email.Contains(" ")))
                    {
                        if (address!=" ")
                        {

                        }
                        else
                        {
                            throw new InvalidDataException("address");
                        }
                    }
                    else
                    {
                        throw new InvalidDataException("email");
                    }

                }
                else
                {
                    throw new System.IO.InvalidDataException("Phone is not valid");
                }
                int status = _customersRepository.CustomerRegistration(id, fname, lname, phone, email, address);
                if (status > 0)
                {
                    Console.WriteLine("Registration successfully");
                }
                else
                {
                    Console.WriteLine("Not Registered");
                }
            }
             catch (InvalidDataException e)
            {
                Console.WriteLine(e.Message);
                goto customer;
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.Message);
                goto customer;
            }



        }

        public void GetCustomerDetails()
        {
            List<Customers> customerdetails = new List<Customers>();
            customerdetails = _customersRepository.GetCustomerDetails();
            foreach (Customers customerdeatil in customerdetails)
                { Console.WriteLine(customerdeatil); }  
        }

        public void UpdateCustomerInfo()
        {
            #region
            Customers customer = new Customers();
            Console.WriteLine("Enter updated details");
            Console.WriteLine("Enter Customer Id");
            customer.CustomerID = int.Parse( Console.ReadLine());
            Console.WriteLine("Enter mail");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            customer.Phone = Console.ReadLine();
            Console.WriteLine("Enter Address");
            customer.Address = Console.ReadLine();
            int updateStatus = _customersRepository.UpdateCustomerInfo(customer);
            if(updateStatus>0)
            {
                Console.WriteLine("Updated Sucessfully");
            }
            else 
            {
                Console.WriteLine("Could not update");
                Console.WriteLine("Retry After Some Time"); 
            }
            #endregion
        }
    }
}
