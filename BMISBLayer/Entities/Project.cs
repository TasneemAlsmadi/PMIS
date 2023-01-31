using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? ProjectTypeId { get; set; }
        public  ProjectType ProjectType{ get; set; }
        public string ProjectTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string ProjectStatusName { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
        public decimal ContractAmount { get; set; }
        public String ContractFileName{ get; set; }
        public String ContractFileType { get; set; }
        public byte[] ContractFile { get; set; }
       
        public string ProjectManagerId { get; set; }
        public  ProjectManager ProjectManager { get; set; }
        public List<Invoice> Invoice { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }



    }
}
