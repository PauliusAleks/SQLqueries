using Assignment2_BackEnd.Models.CustomerModel;
using Assignment2_BackEnd.Models.GenreModel;
using Assignment2_BackEnd.Models.InvoiceLineModel;
using Assignment2_BackEnd.Models.InvoiceModel;
using Assignment2_BackEnd.Models.TrackModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Models
{
    internal class CustomerGenre : ICustomer, IInvoice, IInvoiceLine, ITrack, IGenre
    {
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceLineId { get; set; }
        public int TrackId { get; set; }
        public int GenreId { get; set; }
    }
}
