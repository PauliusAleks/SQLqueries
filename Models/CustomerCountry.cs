using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models
{
    /// <summary>
    /// Model for the datastructure used when returning the number of customers in a country
    /// </summary>
    public class CustomerCountry
    {
        public string Country { get; set; }
        public int NumberOfCustomers { get; set; }
    }
}
