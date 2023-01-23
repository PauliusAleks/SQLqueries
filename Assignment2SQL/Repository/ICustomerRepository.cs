using Assignment2SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2SQL.Repository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers(); //To get all the Customers
        public Customer GetCustomerById(int id); // Get one Customer by id
        public Customer GetCustomerByName(string name); // Get one customer by name
        public List<Customer> GetLimitedCustomers(int limit, int offset); //Get a specific set of customers
        public bool AddNewCustomer(Customer customer); //Adds new Customer
        public bool UpdateCustomer(Customer customer); //Updates a customer
    }
}
