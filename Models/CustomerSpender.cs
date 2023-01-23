using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    public class CustomerSpender
    {
        //public int InvoiceId { get; set; }
        public Customer Customer { get; set; }
        public double Total { get; set; }
        public CustomerSpender(Customer customer, double total)
        {
            Customer = customer;
            Total = total;
        }
    }
}

