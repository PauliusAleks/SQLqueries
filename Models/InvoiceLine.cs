using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    internal class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int TrackId { get; set; }
        public int InvoiceId { get; set; }
    }
}
