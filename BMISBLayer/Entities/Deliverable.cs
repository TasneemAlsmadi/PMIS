using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Deliverable 
    {
        public int DeliverableId { get; set; }
        public String DeliverableDescription { get; set; }
        public String DeliverableName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProjectPhaseId { get; set; }
        public string ProjectPhaseName { get; set; }
        public ProjectPhase ProjectPhase { get; set; }
        public List<PaymentTerm> PaymentTerms { get; set; }
    }
}
