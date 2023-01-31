using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Invoice 
    {
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
      
        public Project Project { get; set; }
        public int? ProjectId { get; set; }


}
}
