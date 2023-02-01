using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IInvoiceRepository
    {
        List<InvoicePaymentTerm> GetInvoicePaymentTerm(int InvoiceId);
        decimal GetPTAmount(int p);
        void InsertInvoicePaymentTerm(InvoicePaymentTerm InvoicePaymentTerm);
        void DeleteInvoice(int InvoiceId);
        void EditInvoice(Invoice p);
        void InsertInvoice(Invoice Invoice);
        Project GetProject(int projectId);
        Invoice GetInvoice(int InvoiceId);
        List<Project> GetAllProjects(string projectManagerId);
        List<Invoice> GetAllInvoices(string projectManagerId);
        List<PaymentTerm> GetAllPaymentTerms(int ProjectId);
        List<InvoicePaymentTerm> GetAllInvoicePaymentTerm(int ProjectId);
        String GetProjectName(int projectId);
        PaymentTerm GetAPaymentTerm(int PaymentTermId);
        Deliverable GetADel(int DeliverableId);
        void DeleteInvoicePaymentTerm(int i, int j);
    }
}