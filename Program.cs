using Assignment2_BackEnd;
using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories;
using System;
class Program
{
    static public void Main(string[] args)
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        //ActionManager.PrintAllCustomers(customerRepository);
        //ActionManager.PrintPageOfCustomer(customerRepository);
        //ActionManager.PrintCustomerById(customerRepository);
        //ActionManager.PrintCustomerByFirstNameAndLastName(customerRepository);
        //ActionManager.insertCustomer(customerRepository);
        //ActionManager.updateCustomer(customerRepository);
        //ActionManager.deleteCustomer(customerRepository);
        //ActionManager.printCountriesAndNumberOfCustomers(customerRepository);
        //ActionManager.printCustomersAndTheirInvoiceTotal(customerRepository);
        ActionManager.printListOfFavoriteCustomerGenres(customerRepository);
    }
}