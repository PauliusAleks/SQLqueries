using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer GetCustomerByName(string firstName, string lastName);
        public IEnumerable<Customer> GetPageOfCustomers(int limit, int offset);
        public IEnumerable<CustomerCountry> GetCountriesWithNumberOfCustomers();
        public IEnumerable<CustomerGenre> GetFavoriteGenre(Customer customer);
        public IEnumerable<CustomerSpender> GetHighestSpenders();
    }
}
