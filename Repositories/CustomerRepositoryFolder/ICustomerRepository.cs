using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerRepositoryFolder
{
    internal interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByName(string firstName, string lastName);
        public List<Customer> GetPageOfCustomers(int limit, int offset);
        public bool AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(Customer customer);
    }
}
