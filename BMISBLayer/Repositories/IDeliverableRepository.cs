using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IDeliverableRepository
    {
        void DeleteDeliverable(int DeliverableId);
        void EditDeliverable(Deliverable p);
        List<Deliverable> GetAllDeliverables();
        List<ProjectPhase> GetAllProjectPhases(int projectId);
        Deliverable GetDeliverable(int DeliverableId);
        void InsertDeliverable(Deliverable Deliverable);
        Project GetProject(int projectId);
        ProjectPhase GetProjectPhase(int ProjectPhaseId);

        List<Deliverable> GetAllDeliverables1(String s);
    }
}
