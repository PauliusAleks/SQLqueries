using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd
{
    /// <summary>
    /// Class for completing actions and testing the methods in the repositories with methods that invoke the methods from the repository.
    /// </summary>
    public class ActionManager
    {
        /// <summary>
        /// Method that displays all the customers based on a Customer repository
        /// </summary>
        /// <param name="customerRepository">repository to display</param>
        public static void DisplayAllCustomers(ICustomerRepository customerRepository)
        {
            PrintCustomers(customerRepository.GetAll().ToList());
        }
        /// <summary>
        /// Method for displaying a specific set of customers based on a Customer repository
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayPageOfCustomer(ICustomerRepository customerRepository)
        {
            PrintCustomers(customerRepository.GetPageOfCustomers(10, 10).ToList());
        }
        /// <summary>
        /// Method for displaying a customer by Id based on a Customer repository
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayCustomerById(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetById(10));
        }
        /// <summary>
        /// Method for displaying a customer based on their FirstName and LastName
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayCustomerByFirstNameAndLastName(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetCustomerByName("Kara", "Nielsen"));
        }
        /// <summary>
        /// Method for inserting a customer into a database based on the Customer repository
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void insertCustomer(ICustomerRepository customerRepository)
        {
            Customer customer = new Customer()
            {
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            if (customerRepository.Add(customer) == true)
            {
                Console.WriteLine("Customer added!");
                PrintCustomer(customer);
            }
            else
            {
                Console.WriteLine("Customer was not added!");
            }
        }
        /// <summary>
        /// Method for updating a already existing customer in a database
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void updateCustomer(ICustomerRepository customerRepository)
        {
            Customer customerToUpdate = new Customer()
            {
                CustomerId = 1,
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            if (customerRepository.Update(customerToUpdate) == true)
            {
                Console.WriteLine("Customer was updated!");
            }
            else
            {
                Console.WriteLine("Customer was not updated!");
            }
        }
        /// <summary>
        /// Method for deleting a customer from a database based on their Id
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void deleteCustomer(ICustomerRepository customerRepository)
        {
            Customer customerToDelete = new Customer()
            {
                CustomerId = 64,
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            if (customerRepository.Delete(customerToDelete) == true)
            {
                Console.WriteLine("Customer was deleted!");
            }
            else
            {
                Console.WriteLine("Customer was not deleted!");
            }
        }
        /// <summary>
        /// Method for displaying the countries in a Customer table and number of instances of the specific country
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayCountriesAndNumberOfCustomers(ICustomerRepository customerRepository)
        {
            List<CustomerCountry> listOfCountriesAndNumberOfCustomers = customerRepository.GetCountriesWithNumberOfCustomers().ToList();
            Console.WriteLine("List of countries and number of customers.");
            listOfCountriesAndNumberOfCustomers
                .ForEach(item => Console.WriteLine($"{item.Country} : {item.NumberOfCustomers}"));
        }
        /// <summary>
        /// Method for displaying customers and their total amount of spendings 
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayCustomersAndTheirInvoiceTotal(ICustomerRepository customerRepository)
        {
            List<CustomerSpender> listOfCustomersAndTheirInvoiceTotal = customerRepository.GetHighestSpenders().ToList();
            Console.WriteLine("List of customers and their invoice total:");
            listOfCustomersAndTheirInvoiceTotal
                .ForEach(item => Console.WriteLine(
                    $"ID({item.Customer.CustomerId})," +
                    $"First name ({item.Customer.FirstName}) : {item.Total}"));
        }
        /// <summary>
        /// Method for displaying a list of a customers favorite genres 
        /// </summary>
        /// <param name="customerRepository">Repository</param>
        public static void DisplayListOfFavoriteCustomerGenres(ICustomerRepository customerRepository)
        {
            Customer customerToFindGenres = new Customer()
            {
                CustomerId = 12,
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            List<CustomerGenre> customerGenre = customerRepository.GetFavoriteGenre(customerToFindGenres).ToList();

            if (customerGenre[0].QuanitityFavoriteGenreRecordsBought == customerGenre[1].QuanitityFavoriteGenreRecordsBought)
            {
                Console.WriteLine(customerGenre[0].GenreName);
                Console.WriteLine(customerGenre[1].GenreName);
            }
            else
            {
                Console.WriteLine(customerGenre[0].GenreName);
            }
        }
        /// <summary>
        /// Common method for printing several customers
        /// </summary>
        /// <param name="customers">Customer list to print</param>
        public static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(customer => { PrintCustomer(customer); });
        }
        /// <summary>
        /// Common method for printing a customer based on properties of the model Customer
        /// </summary>
        /// <param name="customer">Model customer is inserted</param>
        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"Customer id: {customer.CustomerId}");
            Console.WriteLine($"First name: {customer.FirstName}");
            Console.WriteLine($"Last name: {customer.LastName}");
            Console.WriteLine($"Phone number: {customer.Phone}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Country: {customer.Country}");
            Console.WriteLine($"Postal code: {customer.PostalCode}");
            Console.WriteLine("##################################################");
        }
    }
}
