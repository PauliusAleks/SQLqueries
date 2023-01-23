using Assignment2_BackEnd;
using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories.CustomerCountryRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerGenreRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerRepositoryFolder;
using Assignment2_BackEnd.Repositories.CustomerSpenderRepositoryFolder;
using System;
class Program
{
    static public void Main(string[] args)
    {
        ActionManager actionManager = new ActionManager();
        ICustomerRepository customerRepository = new CustomerRepository();
        ICustomerCountryRepository customerCountryRepository = new CustomerCountryRepository();
        ICustomerSpenderRepository customerSpenderRepository = new CustomerSpenderRepository();
        ICustomerGenreRepository customerGenreRepository = new CustomerGenreRepository();
        ActionManager.printCustomersAndTheirInvoiceTotal(customerSpenderRepository);
    }
}