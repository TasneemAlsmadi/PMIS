using BMISBLayer.Entities;

using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectPhaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteProjectPhase(int ProjectPhaseId)
        {
            var p = context.ProjectPhase.SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
            context.Remove(p);
            context.SaveChanges();
        }

        public void EditProjectPhase(ProjectPhase p)
        {
            context.ProjectPhase.Update(p);
            context.SaveChanges();
        }

        public List<Deliverable> GetAllDeliverables()
        {
            return context.Deliverable.Include(x => x.ProjectPhase).ToList();
        }

        public List<Phase> GetAllPhases()
        {
            return context.Phase.Include(x => x.ProjectPhases).ToList();
        }

        public List<ProjectPhase> GetAllProjectPhases()
        {
            return context.ProjectPhase.Include(s=>s.Phase).Include(x => x.Project).ToList();
        }
        public List<ProjectPhase> GetAllProjectPhase(int ProjectId)
        {
            return context.ProjectPhase.Include(s => s.Phase).Include(x => x.Project).Where(b => b.Project.ProjectId == ProjectId).ToList();
        }

        public ProjectPhase GetProjectPhase(int projectPhaseId)
        {
            return context.ProjectPhase.Include(x => x.Project).SingleOrDefault(x => x.ProjectPhaseId == projectPhaseId);

        }

        public void InsertProjectPhase(ProjectPhase projectPhase)
        {
            context.ProjectPhase.Add(projectPhase);
            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProjectPhase ON;");
            context.SaveChanges();
        }
        public Project GetProject(int projectId) { 
        return context.Project.Include(x => x.ProjectPhases).SingleOrDefault(x => x.ProjectId == projectId);
        }
       


    }
}
