using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Entities
{
    public class ProjectType
    {
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public List<Project> Projects { get; set; }

    }
}
