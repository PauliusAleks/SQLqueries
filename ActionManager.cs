using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories;
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
            PrintCustomers(customerRepository.GetAll().ToList());
        }
        public static void PrintPageOfCustomer(ICustomerRepository customerRepository)
        {
            PrintCustomers(customerRepository.GetPageOfCustomers(10, 10).ToList());
        }
        public static void PrintCustomerById(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetById(10));
        }
        public static void PrintCustomerByFirstNameAndLastName(ICustomerRepository customerRepository)
        {
            PrintCustomer(customerRepository.GetCustomerByName("Kara", "Nielsen"));
        }
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
        public static void printCountriesAndNumberOfCustomers(ICustomerRepository customerRepository)
        {
            List<CustomerCountry> listOfCountriesAndNumberOfCustomers = customerRepository.GetCountriesWithNumberOfCustomers().ToList();
            Console.WriteLine("List of countries and number of customers.");
            listOfCountriesAndNumberOfCustomers
                .ForEach(item => Console.WriteLine($"{item.Country} : {item.NumberOfCustomers}"));

        }
        public static void printCustomersAndTheirInvoiceTotal(ICustomerRepository customerRepository)
        {
            List<CustomerSpender> listOfCustomersAndTheirInvoiceTotal = customerRepository.GetHighestSpenders().ToList();
            Console.WriteLine("List of customers and their invoice total:");
            listOfCustomersAndTheirInvoiceTotal
                .ForEach(item => Console.WriteLine(
                    $"ID({item.Customer.CustomerId})," +
                    $"First name ({item.Customer.FirstName}) : {item.Total}"));
        }
        public static void printListOfFavoriteCustomerGenres(ICustomerRepository customerRepository)
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
