using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    /// <summary>
    /// Model for the InvoiceLine table in the ChinookDB
    /// </summary>
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int Quantity { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
