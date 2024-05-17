using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechShop.Model
{
    internal class Customers
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int NoORders { get; set; }


        public Customers() 
        {

        }

        public override string ToString()
        {
            return $"Id::{CustomerID}\t Name::{FirstName} {LastName}\t" +
                $" Email::{Email}\t Phonenumber{Phone}\t Address::{Address}";
        }
    }
}
