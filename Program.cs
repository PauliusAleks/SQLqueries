using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Models.CustomerModel;
using Assignment2_BackEnd.Repositories.CustomerCountryRepository;
using Assignment2_BackEnd.Repositories.CustomerGenreRepository;
using Assignment2_BackEnd.Repositories.CustomerRepository;
using Assignment2_BackEnd.Repositories.CustomerSpenderRepository;
using System;

class Program
{
    static public void Main(string[] args)
    {
        ICustomer customer = new Customer()
        {
            CustomerId = 62,
            FirstName = "Kimberly",
            LastName = "Colaste",
            Country = "Norway",
            PostalCode = "1111",
            Phone = "12345678",
            Email = "kimberly@gmail.com"
        };
        ICustomerRepository customerRepository = new CustomerRepository();
        ICustomerCountryRepository customerCountryRepository = new CustomerCountryRepository();
        ICustomerSpenderRepository customerSpenderRepository = new CustomerSpenderRepository();
        ICustomerGenreRepository customerGenreRepository = new CustomerGenreRepository();
        //PrintAllRecords(customerRepository);
        //PrintRecord(customerRepository, 62);
        //PrintCustomer(customerRepository.GetCustomerByName("da", "pee"));
        //PrintCustomers(customerRepository.GetPageOfCustomers(5, 10));
        //insertRecord(customerRepository);
        //customerRepository.UpdateCustomer(customer);
        //customerRepository.DeleteCustomer(62);
        /*
        List<CustomerCountry> list = customerCountryRepository.GetCountryNames();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.Country} : {item.NumberOfCustomers}");
        }
        */

        List<CustomerSpender> customerSpenders = customerSpenderRepository.GetHighestSpenders();
        List<CustomerSpender> list = customerSpenderRepository.GetHighestSpenders();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.CustomerId} : {item.Total}");
        }


        /*
        customerGenreRepository.GetFavoriteGenre(new Customer()
        {
            CustomerId = 5
        }).ForEach(s => Console.WriteLine(s));
        */




    }
    static void insertRecord(ICustomerRepository customerRepository)
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

    static void PrintAllRecords(ICustomerRepository customerRepository)
    {
        PrintCustomers(customerRepository.GetAllCustomers());
    }

    static void PrintRecord(ICustomerRepository customerRepository, int customerId)
    {
        PrintCustomer(customerRepository.GetCustomerById(customerId));
    }
    static void PrintCustomers(List<Customer> customers)
    {
        customers.ForEach(customer => { PrintCustomer(customer); });
    }

    static void PrintCustomer(Customer customer)
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


