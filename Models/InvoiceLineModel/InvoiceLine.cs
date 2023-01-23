using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2_BackEnd.Models.InvoiceModel;
using Assignment2_BackEnd.Models.TrackModel;

namespace Assignment2_BackEnd.Models.InvoiceLineModel
{
    internal class InvoiceLine : IInvoiceLine, ITrack, IInvoice
    {
        public int InvoiceLineId { get; set; }
        public int TrackId { get; set; }
        public int InvoiceId { get; set; }

        public InvoiceLine(int invoiceLineId, int trackId, int invoiceId)
        {
            InvoiceLineId = invoiceLineId;
            TrackId = trackId;
            InvoiceId = invoiceId;
        }

    }
}
