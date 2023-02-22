using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [DisplayName("Project name")]
        [Required]
        public string ProjectName { get; set; }
        public int? ProjectTypeId { get; set; }
        public  ProjectType ProjectType{ get; set; }
        [DisplayName("Project type")]
        public string ProjectTypeName { get; set; }
        [DisplayName("Start date")]
        [Required]
        public DateTime StartDate { get; set; }
        [DisplayName("End date")]
        [Required]
        public DateTime EndDate { get; set; }
        public int? ProjectStatusId { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        [DisplayName("Project status")]
        public string ProjectStatusName { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="Amount must be greater than 0!")]
        public decimal ContractAmount { get; set; }
        [DisplayName("File name")]
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
