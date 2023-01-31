using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class InvoicePaymentTerm
    {
        public int InvoicePaymentTermId { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int? PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm{ get; set; }
    }
}
