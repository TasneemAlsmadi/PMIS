using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Deliverable> GetAllDeliverables()
        {
            return context.Deliverable.ToList();
        }

        public List<Invoice> GetAllInvoices()
        {
            return context.Invoice.ToList();
        }

        
        public List<Phase> GetAllPhases()
        {
            return context.Phase.Include(c=>c.ProjectPhases).ToList();
        }

        public List<ProjectPhase> GetAllProjectPhases()
        {
            return context.ProjectPhase.Include(x => x.Project).ToList();
        }

        public List<Project> GetAllProjects() {
            return context.Project.Include(y=>y.Client.ClientName).Include(x => x.ProjectType).ToList();
        
        }

        public List<ProjectStatus> GetAllProjectStatuses()
        {
            return context.ProjectStatus.ToList();
        }

        public List<ProjectType> GetAllProjectTypes() {
            return context.ProjectType.ToList();
        }

        public Project GetProject(int projectId)
        {
            return context.Project.SingleOrDefault(x => x.ProjectId ==projectId);
        }

        public List<Project> GetProjectManagerProjects(string projectManagerId)
        {
            return context.Project.Include(c=>c.Client).Include(s =>s.ProjectStatus).Include(t =>t.ProjectType).Include(ps=>ps.ProjectPhases).Where(x =>x.ProjectManagerId == projectManagerId).ToList();
        
        }

        public void InsertProject(Project project)
        {
            context.Project.Add(project);
            context.SaveChanges();
        }
        public void DeleteProject(int projectId)
        {
            var p= context.Project.Include(s=>s.ProjectPhases).SingleOrDefault(x => x.ProjectId == projectId);
            context.Remove(p);
            context.SaveChanges();
        }
        public void EditProject(Project p)
        {
            //Project p = context.Project.SingleOrDefault(x => x.ProjectId == projectId);
            context.Project.Update(p);
            context.SaveChanges();
        }
        public List<Client> GetAllClients()
        {
            return context.Clients.ToList();
        }

    }
}
