using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class PaymentTerm 
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public decimal PaymentTermAmount { get; set; }
        public int? DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public string DeliverableName { get; set; }
        public DateTime PaymentTermDate { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
    }
}
