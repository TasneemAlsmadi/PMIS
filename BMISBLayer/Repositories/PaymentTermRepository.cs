using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext context;
        public PaymentTermRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeletePaymentTerm(int PaymentTermId)
        {
            var p = context.PaymentTerm.SingleOrDefault(x => x.PaymentTermId == PaymentTermId);
            context.Remove(p);
            context.SaveChanges();
        }

        public void EditPaymentTerm(PaymentTerm p)
        {
            context.PaymentTerm.Update(p);
            context.SaveChanges();
        }

        public List<PaymentTerm> GetAllPaymentTerm()
        {
            return context.PaymentTerm.Include(y=>y.Deliverable).Include(o=>o.Deliverable.ProjectPhase).Include(o=>o.Deliverable.ProjectPhase.Project).Include(o => o.Deliverable.ProjectPhase.Phase).ToList();
        }


        //public List<Deliverable> GetAllProjectPhases(int projectId)
        //{
        //    return context.ProjectPhase.Where(s => s.ProjectId == projectId).Include(x => x.Project).Include(y => y.Phase).ToList();
        //}
        public List<Deliverable> GetAllDeliverable(int ProjectPhaseId)
        {
            return context.Deliverable.Where(s => s.ProjectPhaseId == ProjectPhaseId).Include(x => x.ProjectPhaseId).Include(y => y.PaymentTerms).ToList();
        }
        public PaymentTerm GetPaymentTerm(int PaymentTermId)
        {
            return context.PaymentTerm.SingleOrDefault(x => x.PaymentTermId == PaymentTermId);

        }
        public Deliverable GetDeliverable(int DeliverableId) {
            return context.Deliverable.Include(v=>v.ProjectPhase).Include(c=>c.ProjectPhase.Project).Include(b=>b.ProjectPhase.Phase).SingleOrDefault(x => x.DeliverableId == DeliverableId);
        }
        public void InsertPaymentTerm(PaymentTerm PaymentTerm)
        {
            context.PaymentTerm.Add(PaymentTerm);
            context.SaveChanges();
        }
        public Project GetProject(int projectId)
        {
            return context.Project.SingleOrDefault(x => x.ProjectId == projectId);
        }
        public List<PaymentTerm> GetAllPaymentTerm1(string s)
        {
            return context.PaymentTerm.Include(y => y.Deliverable).Include(o => o.Deliverable.ProjectPhase).Include(o => o.Deliverable.ProjectPhase.Project).Include(o => o.Deliverable.ProjectPhase.Phase).Where(d=>d.Deliverable.ProjectPhase.Project.ProjectManagerId==s).ToList();
        }

    }
}
