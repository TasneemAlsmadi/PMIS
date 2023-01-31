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
    public class DeliverableController : Controller
    {
        private readonly IDeliverableRepository DeliverableRepo;
        private readonly IMapper mapper;
        public DeliverableController(IDeliverableRepository DeliverableRepo, IMapper mapper)
        {
            this.DeliverableRepo = DeliverableRepo;
            this.mapper = mapper;
        }
        public IActionResult Index(int ProjectId)
        {
            try
            {
                //    TempData["projectId"] = ProjectId;
                //    TempData.Keep();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Deliverables = DeliverableRepo.GetAllDeliverables1(userId);
                ViewBag.Project = DeliverableRepo.GetProject(ProjectId);
                //ViewBag.projectphase = DeliverableRepo.GetProjectPhase(ProjectPhaseId);
                return View();
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }
        public IActionResult Index1()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Deliverables = DeliverableRepo.GetAllDeliverables1(userId);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IActionResult NewDeliverable()
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                ViewBag.Project = DeliverableRepo.GetProject(ProjectId);

                ViewBag.ProjectPhases = DeliverableRepo.GetAllProjectPhases(ProjectId);


                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult InsertDeliverable(Deliverable Deliverable)
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                ViewBag.Project = DeliverableRepo.GetProject(ProjectId);
                TempData.Keep();
                DeliverableRepo.InsertDeliverable(Deliverable);

                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IActionResult EditDeliverable(int DeliverableId)

        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                Deliverable Deliverable = new Deliverable();
                Deliverable = DeliverableRepo.GetDeliverable(DeliverableId);
                ViewBag.ProjectPhase = DeliverableRepo.GetAllProjectPhases(ProjectId);
                return View(Deliverable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdateDeliverable(Deliverable Deliverable)
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                DeliverableRepo.EditDeliverable(Deliverable);

                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IActionResult DeleteDeliverable(int DeliverableId)
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                DeliverableRepo.DeleteDeliverable(DeliverableId);
                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}