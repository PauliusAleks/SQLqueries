using Assignment2_BackEnd;
using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.DataAccess;
using System;
class Program
{
    ///<Summary>
    /// Main method to run methods from ActionManager and see the results.
    ///</Summary>
    static public void Main(string[] args)
    {

        ICustomerRepository customerRepository = new CustomerRepository();
        //ActionManager.DisplayAllCustomers(customerRepository);
        //ActionManager.DisplayPageOfCustomer(customerRepository);
        //ActionManager.DisplayCustomerById(customerRepository);
        //ActionManager.DisplayCustomerByFirstNameAndLastName(customerRepository);
        //ActionManager.insertCustomer(customerRepository);
        //ActionManager.updateCustomer(customerRepository);
        //ActionManager.deleteCustomer(customerRepository);
        //ActionManager.DisplayCountriesAndNumberOfCustomers(customerRepository);
        //ActionManager.DisplayCustomersAndTheirInvoiceTotal(customerRepository);
        //ActionManager.DisplayListOfFavoriteCustomerGenres(customerRepository);
    }
}