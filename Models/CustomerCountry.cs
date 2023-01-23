using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models.CustomerModel;

namespace Assignment2_BackEnd.Models
{
    public class CustomerCountry : Customer
    {
        public int NumberOfCustomers { get; set; }
        public CustomerCountry(string country, int numberOfCustomers)
        {
            Country = country;
            NumberOfCustomers = numberOfCustomers;
        }
    }
}
