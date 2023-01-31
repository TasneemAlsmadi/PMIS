using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class DeliverableRepository: IDeliverableRepository
    {
        private readonly ApplicationDbContext context;
        public DeliverableRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteDeliverable(int DeliverableId)
        {
            var p = context.Deliverable.Include(z=>z.ProjectPhase).Include(y=>y.PaymentTerms).SingleOrDefault(x => x.DeliverableId == DeliverableId);
            context.Remove(p);
            context.SaveChanges();
        }

        public void EditDeliverable(Deliverable p)
        {
            context.Deliverable.Update(p);
            context.SaveChanges();
        }

        public List<Deliverable> GetAllDeliverables()
        {
            return context.Deliverable.Include(y=>y.ProjectPhase).Include(b=>b.ProjectPhase.Project).Include(a=>a.ProjectPhase.Phase).ToList();
        }

        
        public List<ProjectPhase> GetAllProjectPhases(int projectId)
        {
            return context.ProjectPhase.Where(s=>s.ProjectId==projectId).Include(x=>x.Project).Include(y=>y.Phase).ToList();
        }

        public Deliverable GetDeliverable(int DeliverableId)
        {
            return context.Deliverable.Include(y=>y.ProjectPhase).SingleOrDefault(x => x.DeliverableId == DeliverableId);

        }

        public void InsertDeliverable(Deliverable Deliverable)
        {
            context.Deliverable.Add(Deliverable);
            context.SaveChanges();
        }
        public Project GetProject(int projectId)
        {
            return context.Project.SingleOrDefault(x => x.ProjectId == projectId);
        }

        public ProjectPhase GetProjectPhase(int ProjectPhaseId)
        {
            return context.ProjectPhase.Include(e => e.Phase).SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
        }

        public List<Deliverable> GetAllDeliverables1( String s)
        {
            return context.Deliverable.Include(y => y.ProjectPhase).Include(b => b.ProjectPhase.Project).Include(a => a.ProjectPhase.Phase).Where(z=>z.ProjectPhase.Project.ProjectManagerId ==s).ToList();
        }
    }
}
