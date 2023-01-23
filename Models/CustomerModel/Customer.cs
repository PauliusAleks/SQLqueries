using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models.CustomerModel
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }

        public Customer() { }
        public Customer(int customerId, string firstName, string lastName, string? country, string? postalCode, string? phone, string email)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Email = email;
        }


        //public string? Company { get; set; }
        //public string? Address { get; set; }
        //public string? City { get; set; }
        //public string? State { get; set; }
        //public string? Fax { get; set; }
        //public int? SupportRepId { get; set; }

    }
}
