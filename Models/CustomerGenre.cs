using Assignment2_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models
{
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceLineId { get; set; }
        public int TrackId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}
