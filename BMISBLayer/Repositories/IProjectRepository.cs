using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IProjectRepository
    {
         List<Project> GetAllProjects();
        List<Project> GetProjectManagerProjects(string projectManagerId);
        List<ProjectType> GetAllProjectTypes();
        List<ProjectStatus> GetAllProjectStatuses();
        List<Phase> GetAllPhases();
        void InsertProject(Project project);
        Project GetProject(int projectId);
        List<ProjectPhase> GetAllProjectPhases();
        List<Deliverable> GetAllDeliverables();
       
        List<Invoice> GetAllInvoices();
        void DeleteProject(int projectId);
        void EditProject(Project p);
        List<Client> GetAllClients();
    }
}
