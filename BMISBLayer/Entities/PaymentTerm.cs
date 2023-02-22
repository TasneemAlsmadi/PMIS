using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMISBLayer.Entities
{
    public class PaymentTerm 
    {
        public int PaymentTermId { get; set; }
        [Required]
        public string PaymentTermTitle { get; set; }
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="the amount must be greater than 0!")]
        public decimal PaymentTermAmount { get; set; }
        public int? DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
       
        public string DeliverableName { get; set; }
        [Required]
        public DateTime PaymentTermDate { get; set; }
        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
    }
}
