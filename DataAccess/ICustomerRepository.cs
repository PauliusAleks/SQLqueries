using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    /// <summary>
    /// ICustomerRepository implements base IRepository<T> and sets its generic type to "Customer".
    /// This Interface defines other methods that are used in CustomerRepository.
    /// These methods use other models to get/edit data from the Database
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer GetCustomerByName(string firstName, string lastName); //!!!!
        public IEnumerable<Customer> GetPageOfCustomers(int limit, int offset);
        public IEnumerable<CustomerCountry> GetCountriesWithNumberOfCustomers();
        public IEnumerable<CustomerSpender> GetHighestSpenders();
        public IEnumerable<CustomerGenre> GetFavoriteGenre(Customer customer);
    }
}
