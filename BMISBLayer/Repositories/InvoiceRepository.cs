using BMISBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMISBLayer.Repositories
{
    public class InvoiceRepository: IInvoiceRepository
    {
        
        private readonly ApplicationDbContext context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public decimal GetPTAmount(int p) {
            return context.PaymentTerm.SingleOrDefault(x => x.PaymentTermId == p).PaymentTermAmount;
        }
        public void DeleteInvoice(int InvoiceId)
        {
            var p = context.Invoice.SingleOrDefault(x => x.InvoiceId == InvoiceId);
            context.Remove(p);
            context.SaveChanges();
        }
        public PaymentTerm GetAPaymentTerm(int PaymentTermId) {
            return context.PaymentTerm.SingleOrDefault(x => x.PaymentTermId == PaymentTermId);
        }

        public void EditInvoice(Invoice p)
        {
            
            context.Invoice.Update(p);
            context.SaveChanges();
        }
        public void InsertInvoicePaymentTerm(InvoicePaymentTerm InvoicePaymentTerm)
        {
            context.InvoicePaymentTerm.Add(InvoicePaymentTerm);
            context.SaveChanges();
        }
        public void InsertInvoice(Invoice Invoice)
        {
            context.Invoice.Add(Invoice);
            context.SaveChanges();
        }
        public Project GetProject(int projectId)
        {
            return context.Project.Include(x => x.ProjectManager).Include(x=>x.ProjectPhases).SingleOrDefault(x => x.ProjectId == projectId);
        }
      
        public String GetProjectName(int projectId)
        {
            return context.Project.SingleOrDefault(x => x.ProjectId == projectId).ProjectName;
        }

        public Invoice GetInvoice(int InvoiceId)
        {
            return context.Invoice.Include(o=>o.Project).Include(y=>y.Project.Client).Include(x=>x.InvoicePaymentTerms).SingleOrDefault(x => x.InvoiceId == InvoiceId);
        }
        public List<Project> GetAllProjects(string projectManagerId)
        {
            return context.Project.Where(x => x.ProjectManagerId == projectManagerId).ToList();

        }
        public List<Invoice> GetAllInvoices(string projectManagerId) {
            return context.Invoice.Include(x=>x.Project).Include(x=>x.InvoicePaymentTerms).Where(x => x.Project.ProjectManagerId == projectManagerId).ToList();
        }
        
        public List<PaymentTerm> GetAllPaymentTerms(int ProjectId)
        {
            return context.PaymentTerm.Include(x=>x.InvoicePaymentTerms).Include(y=>y.Deliverable.ProjectPhase.Project).Where(y=>y.Deliverable.ProjectPhase.ProjectId==ProjectId).ToList();

        }
        public List<InvoicePaymentTerm> GetAllInvoicePaymentTerm(int ProjectId)
        {
            return context.InvoicePaymentTerm.Include(z=>z.PaymentTerm).Include(b=>b.Invoice).Include(z=>z.Invoice.Project).Where(y => y.Invoice.Project.ProjectId == ProjectId ).ToList();

        }
       

        public List<InvoicePaymentTerm> GetInvoicePaymentTerm(int InvoiceId)
        {
            return context.InvoicePaymentTerm.Include(z => z.PaymentTerm).Where(y => y.InvoiceId == InvoiceId).ToList();

        }
        public Deliverable GetADel(int DeliverableId)
        {
            return context.Deliverable.SingleOrDefault(x => x.DeliverableId == DeliverableId);
        }

    }
}
