using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Invoice 
    {
        public int InvoiceId { get; set; }
        [Required]
        public string InvoiceTitle { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
      
        public Project Project { get; set; }
        public int? ProjectId { get; set; }


}
}
