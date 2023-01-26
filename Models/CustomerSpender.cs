using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    /// <summary>
    /// Model for the datastructure used when finding the customers who are the highest spenders
    /// </summary>
    public class CustomerSpender
    {
        public Customer Customer { get; set; }
        public double Total { get; set; }

    }
}

