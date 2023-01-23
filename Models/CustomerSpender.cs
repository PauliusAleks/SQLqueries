﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models.CustomerModel;
using Assignment2_BackEnd.Models.InvoiceModel;

namespace Assignment2_BackEnd.Models
{
    public class CustomerSpender
    {
        //public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public double Total { get; set; }

        public CustomerSpender(int customerId, double total)
        {
            CustomerId = customerId;
            Total = total;
        }

    }
}

