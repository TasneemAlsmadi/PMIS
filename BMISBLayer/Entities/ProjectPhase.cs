
using System;
using System.Collections.Generic;
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
        public string ProjectPhaseName { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate{get; set; }
        public List<Deliverable> Deliverables { get; set; }
    }
}
