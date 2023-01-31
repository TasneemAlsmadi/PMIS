using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS.DTOs
{
    public class ViewDTO
    {

        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        public List <int> PaymentTermId { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerm { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

        public decimal Total { get; set; }
        public Deliverable deliverable { get; set; }

    }
}

