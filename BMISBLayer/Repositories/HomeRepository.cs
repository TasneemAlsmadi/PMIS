using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext context;
        public HomeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Project> GetAllProjects(string s)
        {
            return context.Project.Where(x=>x.ProjectManagerId==s).ToList();

        }
    }
}
