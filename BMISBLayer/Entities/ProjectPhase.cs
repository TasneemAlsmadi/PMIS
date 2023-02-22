
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMISBLayer.Entities
{
    public class ProjectPhase
    {
        public int? ProjectId { get; set; }
       // public string ProjectName { get; set; }
        public Project Project { get; set; }
      
        public int? PhaseId { get; set; }
        public Phase Phase { get; set; }
        public int ProjectPhaseId { get; set; }
        [DisplayName("Phase name")]
        public string ProjectPhaseName { get; set; }
        [DisplayName("Start date")]
        [Required]
        public DateTime StartDate { get; set; }
        [DisplayName("End date")]
        [Required]
        public DateTime EndDate{get; set; }
        public List<Deliverable> Deliverables { get; set; }
    }
}
