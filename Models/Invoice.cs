using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    /// <summary>
    /// Model for the Invoice table in the ChinookDB
    /// </summary>
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
