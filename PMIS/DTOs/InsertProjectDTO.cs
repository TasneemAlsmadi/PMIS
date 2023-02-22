using BMISBLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS.DTOs
{
    public class InsertProjectDTO
    {
        public int ProjectId { get; set; }
        [DisplayName("Project name")]
        [Required]
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectStatusId { get; set; }
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        [DisplayName("Start date")]
        [Required]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        [DisplayName("End date")]
        [Required]
        public DateTime EndDate { get; set; }
        [DisplayName("Project status")]
        public string Status { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        [DisplayName("Project type")]
        public string ProjectTypeName{ get; set; }
        [DisplayName("Project amount")]
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="amount must be greater than 0!")]
        public decimal ContractAmount { get; set; }
        public IFormFile ContractFile { get; set; }
        public int ClientId { get; set; }
        public List<ProjectPhase> ProjectPhases { get; set; }
        //data annotation custome validation

    }
}
