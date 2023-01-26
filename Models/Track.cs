using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models;

namespace Assignment2_BackEnd.Models
{
    /// <summary>
    /// Model for the Track table in the ChinookDB
    /// </summary>
    public class Track
    {
        public int TrackId { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
