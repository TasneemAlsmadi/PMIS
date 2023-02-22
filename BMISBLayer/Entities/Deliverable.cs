using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Deliverable 
    {
        public int DeliverableId { get; set; }
        [Required]
        public String DeliverableDescription { get; set; }
        [Required]
        public String DeliverableName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int? ProjectPhaseId { get; set; }
        
        public string ProjectPhaseName { get; set; }
        public ProjectPhase ProjectPhase { get; set; }
        public List<PaymentTerm> PaymentTerms { get; set; }
    }
}
