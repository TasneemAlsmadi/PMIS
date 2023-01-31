using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IPaymentTermRepository
    {
        void DeletePaymentTerm(int PaymentTermId);

        void EditPaymentTerm(PaymentTerm p);
        List<PaymentTerm> GetAllPaymentTerm();
        List<Deliverable> GetAllDeliverable(int ProjectPhaseId);
        PaymentTerm GetPaymentTerm(int PaymentTermId);
        void InsertPaymentTerm(PaymentTerm PaymentTerm);
        Project GetProject(int projectId);
        Deliverable GetDeliverable(int DeliverableId);
        List<PaymentTerm> GetAllPaymentTerm1(string s);

    }


}
