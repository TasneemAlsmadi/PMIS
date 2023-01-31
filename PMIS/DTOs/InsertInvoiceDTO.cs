using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMISBLayer.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace PMIS.DTOs
{
    public class InsertInvoiceDTO
    {
      
        public int InvoiceId { get; set; }
            public string InvoiceTitle{ get; set; }
            
            [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
            [DataType(DataType.Date)]
            public DateTime InvoiceDate { get; set; }
       
        public List<int> PaymentTermId { get; set; }
    public List<InvoicePaymentTerm> InvoicePaymentTerm { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

    }
}
