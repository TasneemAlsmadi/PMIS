using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IProjectPhaseRepository
    {
        List<ProjectPhase> GetAllProjectPhases();
        List<Phase> GetAllPhases();
        void InsertProjectPhase(ProjectPhase projectPhase);
        ProjectPhase GetProjectPhase(int projectPhaseId);
        List<Deliverable> GetAllDeliverables();
        void DeleteProjectPhase(int projectPhaseId);
        void EditProjectPhase(ProjectPhase p);
       Project GetProject(int projectId);
        List<ProjectPhase> GetAllProjectPhase(int ProjectId);
    }
}
