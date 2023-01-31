using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BMISBLayer.Entities;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;
using PMIS.DTOs;


namespace PMIS.Controllers
{

    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository InvoiceRepo;
        private readonly IMapper mapper;
        public InvoiceController( IInvoiceRepository  InvoiceRepo, IMapper mapper)
        {
            this. InvoiceRepo =  InvoiceRepo;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public JsonResult GetTotal() {
        //    var invoiceid = TempData["Total"];
        //    var Iid =InvoiceRepo.GetInvoicePaymentTerm(invoiceid);
        //    var total = 0;

        //    foreach (var i in Iid) {
        //        var d = i.PaymentTermId == null ? default(int) :(int) i.PaymentTermId;
        //        var s = InvoiceRepo.GetAPaymentTerm(d);
        //        var t =s.PaymentTermAmount;
        //        total =total +(int)t;

        //    }

        //    return new JsonResult(total);
        //}

        [HttpGet]
        public JsonResult GetPaymentTermsByProjectId(int ProjectId)
        {

            var PI11 = InvoiceRepo.GetAllInvoicePaymentTerm(ProjectId);
            var PI1= new List<PaymentTerm>();
            foreach (var pq in PI11)
            {
                var PI = new PaymentTerm();
                var x = pq.PaymentTermId == null ? default(int) : pq.PaymentTermId.Value;
                PI.PaymentTermId = x;
                PI=InvoiceRepo.GetAPaymentTerm(x);
              //  PI.PaymentTermTitle = pq.PaymentTermTitle;
                PI1.Add(PI);

            }

            var PI2 = InvoiceRepo.GetAllPaymentTerms(ProjectId);
            List<PaymentTerm> PaymentTerms = new List<PaymentTerm>();

            if (PI1.Any<PaymentTerm>())
            {
                if (PI1.Count != PI2.Count)
                {
                    foreach (var p2 in PI2)
                    {
                        if (!PI1.Contains(p2))
                        {
                            var PI = new PaymentTerm();
                            PI.PaymentTermId = p2.PaymentTermId;
                            PI.PaymentTermTitle = p2.PaymentTermTitle;
                            PaymentTerms.Add(PI);
                        }
                    }
                

            
      

                    //foreach (var p2 in PI2)//p2.contain(p1)
                    //{

                    //   // int i = 0;
                    //    foreach (var p1 in PI1)
                    //    {
                    //        if (p1.PaymentTermId == p2.PaymentTermId) {
                    //            break;
                    //        }
                    //        var PI = new PaymentTerm();
                    //        PI.PaymentTermId = p2.PaymentTermId;
                    //        PI.PaymentTermTitle = p2.PaymentTermTitle;
                    //        PaymentTerms.Add(PI);

                    //        //if (p1.PaymentTermId != p2.PaymentTermId)
                    //        //{
                    //        //    //i=i+1;
                    //        //    //if (i == PI2.Count) { 
                    //        //    var PI = new PaymentTerm();
                    //        //    PI.PaymentTermId = p2.PaymentTermId;
                    //        //    PI.PaymentTermTitle = p2.PaymentTermTitle;
                    //        //    PaymentTerms.Add(PI);


                    //        //}
                    //    }
                    //}
                }
                else { PaymentTerms = null; }
            }

            else
            {
                PaymentTerms = PI2;
            }

            return new JsonResult(PaymentTerms);
    }
       // [HttpGet]
        //public JsonResult GetPaymentTermsByProjectIdEdit(int ProjectId)
        //{
        //    var uu = TempData["InvoiceId"];
        //    TempData.Keep();
        //    var s = InvoiceRepo.GetInvoice((int)uu);
        //    var ss = s.ProjectId;
            
          
            
        //    var PI1 = InvoiceRepo.GetAllInvoicePaymentTerm(ProjectId);
        //    var PI2 = InvoiceRepo.GetAllPaymentTerms(ProjectId);
        //    List<PaymentTerm> PaymentTerms = new List<PaymentTerm>();
        //    if (ss == ProjectId) {
        //        PaymentTerms = PI2;
        //        return new JsonResult(PaymentTerms);

        //    }
            //foreach (var u in PI3)
            //{
            //    PaymentTerm paymentTerm = new PaymentTerm();
            //    var ii = 0;
            //    ii = u.PaymentTermId == null ? default(int) : (int)u.PaymentTermId;
            //    paymentTerm = InvoiceRepo.GetAPaymentTerm(ii);
            //    PaymentTerms.Add(paymentTerm);
            //}





        //    if (PI1.Any<InvoicePaymentTerm>())
        //    {
        //        if (PI1.Count != PI2.Count)
        //        {
        //            foreach (var p2 in PI2)
        //            {
        //                // int i = 0;
        //                foreach (var p1 in PI1)
        //                {


        //                    if (p1.PaymentTermId != p2.PaymentTermId)
        //                    {
        //                        //i=i+1;
        //                        //if (i == PI2.Count) { 
        //                        var PI = new PaymentTerm();
        //                        PI.PaymentTermId = p2.PaymentTermId;
        //                        PI.PaymentTermTitle = p2.PaymentTermTitle;
        //                        PaymentTerms.Add(PI);


        //                    }
        //                }
        //            }
                   
        //        }
        //        else { PaymentTerms = null; }
        //    }

        //    else
        //    {
        //        PaymentTerms = PI2;
        //    }
            
        //    return new JsonResult(PaymentTerms);
        //}

        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //TempData.Keep();
                //TempData["total"] = TempData["total"];
                //TempData.Keep();
                //var project = projectRepo.GetProjectManagerProjects(userId).ToList();
                ViewBag.Invoice = InvoiceRepo.GetAllInvoices(userId);
                ViewBag.Project = InvoiceRepo.GetAllProjects(userId);

                //ViewBag.PaymentTerm = InvoiceRepo.GetAllPaymentTerms();
                //ViewBag.InvoicePaymentTerm = InvoiceRepo.GetAllInvoicePaymentTerm();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Index1(int InvoiceId)
        {
            try
            {

                Invoice Invoice = new Invoice();
                Invoice = InvoiceRepo.GetInvoice(InvoiceId);
                int ii;
                ii = Invoice.ProjectId == null ? default(int) : Invoice.ProjectId.Value;

                ViewDTO editProjectDTO = new ViewDTO();
                editProjectDTO.InvoiceId = InvoiceId;
                editProjectDTO.InvoiceTitle = Invoice.InvoiceTitle;
                editProjectDTO.ProjectId = ii;
                editProjectDTO.Project = InvoiceRepo.GetProject(ii);
                editProjectDTO.InvoicePaymentTerm = Invoice.InvoicePaymentTerms;
                List<int> p = new List<int>();
                editProjectDTO.PaymentTermId = p;
                editProjectDTO.Total = 0;

                foreach (var e in InvoiceRepo.GetInvoicePaymentTerm(InvoiceId))
                {
                    int i;
                    i = e.PaymentTermId == null ? default(int) : e.PaymentTermId.Value;
                    editProjectDTO.PaymentTermId.Add(i);

                    decimal d = e.PaymentTerm.PaymentTermAmount;
                    editProjectDTO.Total = editProjectDTO.Total + d;
                    PaymentTerm pay = new PaymentTerm();
                    pay = InvoiceRepo.GetAPaymentTerm(i);

                    int delId;
                    delId = pay.DeliverableId == null ? default(int) : pay.DeliverableId.Value;
                    Deliverable del = new Deliverable();
                    del = InvoiceRepo.GetADel(delId);
                    editProjectDTO.deliverable = del;

                }

                ViewBag.Invoice = editProjectDTO;


                return View(editProjectDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IActionResult NewInvoice()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.Project = InvoiceRepo.GetAllProjects(userId);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult InsertInvoice(InsertInvoiceDTO InvoiceDTO )
        {
            try
            {

                var Invoice = mapper.Map<Invoice>(InvoiceDTO);
                InvoiceRepo.InsertInvoice(Invoice);
                int i = 0;

                foreach (var p in InvoiceDTO.PaymentTermId)
                {
                    //PaymentTerm paymentTerm = new PaymentTerm();
                    InvoicePaymentTerm p1 = new InvoicePaymentTerm { Invoice = Invoice, InvoiceId = Invoice.InvoiceId, PaymentTermId = p };
                    //p1.InvoiceId = Invoice.InvoiceId;
                    //p1.PaymentTermId = p;

                    //p1.PaymentTerm = paymentTerm;
                    ////p1.PaymentTerm.PaymentTermId = p;
                    //p1.PaymentTerm.PaymentTermAmount = InvoiceRepo.GetPTAmount(p);
                    //total = total + InvoiceRepo.GetPTAmount(p);
                    p1.Invoice.ProjectId = Invoice.ProjectId;

                    InvoiceRepo.InsertInvoicePaymentTerm(p1);
                    Invoice.InvoicePaymentTerms[i] = p1;
                    i++;

                }

                int ii;
                ii = Invoice.ProjectId == null ? default(int) : Invoice.ProjectId.Value;
                ViewBag.InvoicePaymentTerm = InvoiceRepo.GetAllInvoicePaymentTerm(ii);
                //TempData["ii"] = ii;
                //TempData.Keep();
                TempData["Total"] = Invoice.InvoiceId;
                TempData.Keep();
                ViewBag.Invoice = InvoiceRepo.GetInvoice(Invoice.InvoiceId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult EditInvoice(int InvoiceId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Project = InvoiceRepo.GetAllProjects(userId);

                ViewBag.Invoice = InvoiceRepo.GetInvoice(InvoiceId);
                TempData["InvoiceId"] = InvoiceId;
                TempData.Keep();
                Invoice Invoice = new Invoice();
                Invoice = InvoiceRepo.GetInvoice(InvoiceId);
                int ii;
                ii = Invoice.ProjectId == null ? default(int) : Invoice.ProjectId.Value;
                EditProjectDTO editProjectDTO = new EditProjectDTO();
                editProjectDTO.InvoiceId = InvoiceId;
                editProjectDTO.InvoiceTitle = Invoice.InvoiceTitle;
                editProjectDTO.ProjectId = ii;
                editProjectDTO.InvoicePaymentTerm = Invoice.InvoicePaymentTerms;
                List<PaymentTerm> PaymentTerms = new List<PaymentTerm>();
                PaymentTerms = InvoiceRepo.GetAllPaymentTerms(ii);
                List<PaymentTerm> pt = new List<PaymentTerm>();
                var s = InvoiceRepo.GetInvoicePaymentTerm(InvoiceId);
                var ss = InvoiceRepo.GetAllInvoicePaymentTerm(ii);
                List<PaymentTerm> sss = new List<PaymentTerm>();
                foreach (var d in ss)
                {

                    var PI = new PaymentTerm();
                    var d1 = d.PaymentTermId == null ? default(int) : (int)d.PaymentTermId;
                    PI.PaymentTermId = d1;
                    PI = InvoiceRepo.GetAPaymentTerm(d1);
                    sss.Add(PI);
                }
                foreach (var pq in PaymentTerms)
                {

                    //var PI = new PaymentTerm();
                    //int x = pq.PaymentTermId == null ? default(int) : pq.PaymentTermId.Value;

                    //PI = InvoiceRepo.GetAPaymentTerm(x);

                    if (!sss.Contains(pq))
                    {
                        pt.Add(pq);
                    }




                }
                foreach (var d in s)
                {

                    var PI = new PaymentTerm();
                    var d1 = d.PaymentTermId == null ? default(int) : (int)d.PaymentTermId;
                    PI.PaymentTermId = d1;
                    PI = InvoiceRepo.GetAPaymentTerm(d1);
                    pt.Add(PI);
                }
                editProjectDTO.PaymentTerms = pt;


                List<PaymentTerm> p = new List<PaymentTerm>();
                foreach (var d in editProjectDTO.InvoicePaymentTerm)
                {

                    var PI = new PaymentTerm();
                    var d1 = d.PaymentTermId == null ? default(int) : (int)d.PaymentTermId;
                    PI.PaymentTermId = d1;
                    PI = InvoiceRepo.GetAPaymentTerm(d1);
                    p.Add(PI);

                }
                ViewBag.pp = p;


                return View(editProjectDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdateInvoice(EditProjectDTO InvoiceDTO)
        {
          
            var Invoice = mapper.Map<Invoice>(InvoiceDTO);
            //var d11 = Invoice.ProjectId == null ? default(int) : (int)Invoice.ProjectId;
            List<InvoicePaymentTerm> ip = InvoiceRepo.GetInvoicePaymentTerm(Invoice.InvoiceId);
            //int i = 0;
            List<InvoicePaymentTerm> pp = new List<InvoicePaymentTerm>();
            List<PaymentTerm> p2 = new List<PaymentTerm>();
            foreach (var d in ip)
            {

                var PI = new PaymentTerm();
                var d1 = d.PaymentTermId == null ? default(int) : (int)d.PaymentTermId;
                PI.PaymentTermId = d1;
                PI = InvoiceRepo.GetAPaymentTerm(d1);
                p2.Add(PI);

            }
            foreach(var p in InvoiceDTO.PaymentTermId)
            {
                var PI = new PaymentTerm();
                PI = InvoiceRepo.GetAPaymentTerm(p);
                //PaymentTerm paymentTerm = new PaymentTerm();
                InvoicePaymentTerm p1 = new InvoicePaymentTerm { Invoice = Invoice, InvoiceId = Invoice.InvoiceId, PaymentTermId = p,PaymentTerm=PI };
                //p1.InvoiceId = Invoice.InvoiceId;
                //p1.PaymentTermId = p;

                //p1.PaymentTerm = paymentTerm;
                ////p1.PaymentTerm.PaymentTermId = p;
                //p1.PaymentTerm.PaymentTermAmount = InvoiceRepo.GetPTAmount(p);
                //total = total + InvoiceRepo.GetPTAmount(p);
                p1.Invoice.ProjectId = Invoice.ProjectId;
                if (p2.Contains(PI))
                {
                   
                   pp.Add(p1);
                   
                   
                }
                else {
                    InvoiceRepo.InsertInvoicePaymentTerm(p1);
                    pp.Add(p1);
                   
                    
                }
                
            }
            Invoice.InvoicePaymentTerms = pp;

            //int ii;
            //ii = Invoice.ProjectId == null ? default(int) : Invoice.ProjectId.Value;
            //ViewBag.InvoicePaymentTerm = InvoiceRepo.GetAllInvoicePaymentTerm(ii);
            //TempData["ii"] = ii;
            //TempData.Keep();
            //TempData["Total"] = Invoice.InvoiceId;
            //TempData.Keep();
            //ViewBag.Invoice = InvoiceRepo.GetInvoice(Invoice.InvoiceId);

            InvoiceRepo.EditInvoice(Invoice);

            return RedirectToAction("Index");

        }
        public IActionResult DeleteInvoice(int InvoiceId)
        {
            InvoiceRepo.DeleteInvoice(InvoiceId);
            return RedirectToAction("Index");

        }
    }
}