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
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
