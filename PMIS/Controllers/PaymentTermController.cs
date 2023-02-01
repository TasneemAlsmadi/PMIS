using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BMISBLayer.Entities;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMIS.Controllers
{
    [Authorize]
    public class PaymentTermController : Controller
    {
       
         private readonly IPaymentTermRepository PaymentTermRepo;
        private readonly IMapper mapper;
        public PaymentTermController(IPaymentTermRepository PaymentTermRepo, IMapper mapper)
        {
            this.PaymentTermRepo = PaymentTermRepo;
            this.mapper = mapper;
        }
        public IActionResult Index(int DeliverableId)
        {
            try
            {
                TempData["DeliverableId"] = DeliverableId;
                TempData.Keep();
                ViewBag.Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);
                ViewBag.PaymentTerm = PaymentTermRepo.GetAllPaymentTerm();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Index1()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.PaymentTerm = PaymentTermRepo.GetAllPaymentTerm1(userId);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult NewPaymentTerm()
        {
            try
            {
                int DeliverableId = (int)TempData["DeliverableId"];
                TempData.Keep();
                ViewBag.Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);


                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult InsertPaymentTerm(PaymentTerm PaymentTerm)
        {
            try
            {
                int DeliverableId = (int)TempData["DeliverableId"];
                ViewBag.Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);
                TempData.Keep();
                PaymentTerm.DeliverableId = DeliverableId;
                var Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);
                if (PaymentTerm.PaymentTermAmount > Deliverable.ProjectPhase.Project.ContractAmount)
                {
                    ViewBag.error = false;
                    return View();
                }



                PaymentTermRepo.InsertPaymentTerm(PaymentTerm);

                return RedirectToAction("Index", new { DeliverableId = DeliverableId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult EditPaymentTerm(int PaymentTermId)
        {
            try
            {
                int DeliverableId = (int)TempData["DeliverableId"];
                TempData.Keep();
                PaymentTerm PaymentTerm = new PaymentTerm();
                PaymentTerm = PaymentTermRepo.GetPaymentTerm(PaymentTermId);
                ViewBag.Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);
                return View(PaymentTerm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdatePaymentTerm(PaymentTerm PaymentTerm)
        {
            try
            {
                int DeliverableId = (int)TempData["DeliverableId"];
                TempData.Keep();

                var Deliverable = PaymentTermRepo.GetDeliverable(DeliverableId);
                if (PaymentTerm.PaymentTermAmount > Deliverable.ProjectPhase.Project.ContractAmount)
                {
                    ViewBag.error = false;
                    return View(PaymentTerm);
                }


                PaymentTermRepo.EditPaymentTerm(PaymentTerm);

                return RedirectToAction("Index", new { DeliverableId = DeliverableId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult DeletePaymentTerm(int PaymentTermId)
        {
            try
            {
                int DeliverableId = (int)TempData["DeliverableId"];
                TempData.Keep();
                PaymentTermRepo.DeletePaymentTerm(PaymentTermId);

                return RedirectToAction("Index", new { DeliverableId = DeliverableId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}