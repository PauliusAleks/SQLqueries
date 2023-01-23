using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories.CustomerCountryRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerGenreRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerSpenderRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd
{
    public class ActionManager
    {
        public static void PrintAllCustomers(ICustomerRepository customerRepository)
        {
            PrintCustomers(customerRepository.GetAllCustomers());
        }
        public static void PrintPageOfCustomer(ICustomerRepository customerRepository)
        {
            PrintCustomers(customerRepository.GetPageOfCustomers(10, 10));
        }
        public static void PrintCustomerById(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetCustomerById(10));
            PrintCustomer(customerRepository.GetCustomerByName("Kara", "Nielsen"));
        }
        public static void PrintCustomerByFirstNameAndLastName(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetCustomerByName("Kara", "Nielsen"));
        }
        public static void insertCustomer(ICustomerRepository customerRepository)
        {
            Customer customer = new Customer()
            {
                FirstName = "Kimberly",
                LastName = "Colaste",
                Country = "Norway",
                PostalCode = "1111",
                Phone = "99878991",
                Email = "kimberly@gmail.com"
            };
            if (customerRepository.AddCustomer(customer))
            {
                Console.WriteLine("Customer added!");
                PrintCustomer(customer);
            }
            else
            {
                Console.WriteLine("Customer was not added!");
            }
        }
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
            customerRepository.UpdateCustomer(customerToUpdate);
        }
        public static void deleteCustomer(ICustomerRepository customerRepository)
        {
            Customer customerToDelete = new Customer()
            {
                CustomerId = 1,
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            customerRepository.DeleteCustomer(customerToDelete);
        }
        public static void printCountriesAndNumberOfCustomers(ICustomerCountryRepository customerCountryRepository)
        {
            List<CustomerCountry> listOfCountriesAndNumberOfCustomers = customerCountryRepository.GetCountryNames();
            Console.WriteLine("List of countries and number of customers.");
            listOfCountriesAndNumberOfCustomers
                .ForEach(item => Console.WriteLine($"{item.Country} : {item.NumberOfCustomers}"));

        }
        public static void printCustomersAndTheirInvoiceTotal(ICustomerSpenderRepository customerSpenderRepository)
        {
            List<CustomerSpender> listOfCustomersAndTheirInvoiceTotal = customerSpenderRepository.GetHighestSpenders();
            Console.WriteLine("List of customers and their invoice total:");
            listOfCustomersAndTheirInvoiceTotal
                .ForEach(item => Console.WriteLine($"ID({item.Customer.CustomerId}),First name ({item.Customer.FirstName}) : {item.Total}"));
        }
        public static void printListOfFavoriteCustomerGenres(ICustomerGenreRepository customerGenreRepository)
        {
            Customer customerToFindGenres = new Customer()
            {
                CustomerId = 1,
                FirstName = "",
                LastName = "",
                Country = "",
                PostalCode = "",
                Phone = "",
                Email = ""
            };
            customerGenreRepository.GetFavoriteGenre(customerToFindGenres)
                .ForEach(s => Console.WriteLine(s.GenreName));
        }
        public static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(customer => { PrintCustomer(customer); });
        }
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
