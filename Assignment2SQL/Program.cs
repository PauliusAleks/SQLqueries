using Assignment2SQL.Model;
using Assignment2SQL.Repository;

namespace Assignment2SQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository customerRep = new CustomerRepository();
            ICustomerCountryRepository customerCountryRep = new CustomerCountryRepository();
            ICustomerSpenderRepository customerSpenderRep = new CustomerSpenderRepository();

            //InsertRecord(rep);
            //PrintAll(rep);
            //PrintOneById(rep);
            //PrintOneByName(rep);
            //PrintLimited(rep);
            //UpdateRecord(rep);
            //PrintAllCountry(customerCountryRep);
            PrintAllSpender(customerSpenderRep);
        }
        /* Customers */
        static void InsertRecord(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 61,
                FirstName = "Erik",
                LastName = "Aardal",
                Country = "Norway",
                PostalCode = "5900",
                Phone = "004789898989",
                Email = "erik@experis.com"
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("Successfully inserted record");
            }
            else
            {
                Console.WriteLine("No records inserted");
            }

        }
        static void UpdateRecord(ICustomerRepository repository)
        {
            Customer customer = new Customer()
            {
                CustomerId = 61,
                FirstName = "Jarand",
                LastName = "Larsen",
                Country = "Norway",
                PostalCode = "5990",
                Phone = "0047888882828",
                Email = "jarand@experis.com"
            };
            if (repository.UpdateCustomer(customer))
            {
                Console.WriteLine("Successfully updated record");
            }
            else
            {
                Console.WriteLine("No updates where done");
            }
        }
        static void PrintAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }
        static void PrintLimited(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetLimitedCustomers(10,10));
        }
        static void PrintOneById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(60));
        }
        static void PrintOneByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Erik"));
        }
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer); //invoke this method and print cw statements
            }
        }
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId}\n" +
                $"{customer.FirstName}\n" +
                $"{customer.LastName}\n" +
                $"{customer.Country}\n" +
                $"{customer.PostalCode}\n" +
                $"{customer.Phone}\n" +
                $"{customer.Email}");
        }

        /* Customer Country */
        static void PrintCustomerCountry(CustomerCountry customer)
        {
            Console.WriteLine(customer.Country);
            Console.WriteLine(customer.NumberOfCostumers);
        }
        static void PrintNumberOfCustomersInCountry(IEnumerable<CustomerCountry> customers)
        {
            foreach (CustomerCountry customer in customers)
            {
                PrintCustomerCountry(customer);
            }
        }
        static void PrintAllCountry(ICustomerCountryRepository repository)
        {
            PrintNumberOfCustomersInCountry(repository.GetCustomersInCountry());
        }
        /* Customer Spender */
        static void PrintCustomerSpender(CustomerSpender customer)
        {
            Console.WriteLine(customer.CustomerFirstName);
            Console.WriteLine(customer.CustomerId);
            Console.WriteLine(customer.Total);
        }
        static void PrintTotalFromCustomerSpender(IEnumerable<CustomerSpender> customers)
        {
            foreach (CustomerSpender customer in customers)
            {
                PrintCustomerSpender(customer);
            }
        }
        static void PrintAllSpender(ICustomerSpenderRepository repository)
        {
            PrintTotalFromCustomerSpender(repository.GetCustomerSpenders());
        }

    }
}