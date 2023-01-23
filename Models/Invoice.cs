using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public double Total { get; set; }

        public Invoice() { }
        public Invoice(int invoiceId, int customerId, double total)
        {
            InvoiceId = invoiceId;
            CustomerId = customerId;
            Total = total;
        }
    }
}
