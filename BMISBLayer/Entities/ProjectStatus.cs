using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class ProjectStatus
    {
        public int ProjectStatusId { get; set; }
        public string Status { get; set; }
        public List<Project> Projects { get; set; }
    }
}
