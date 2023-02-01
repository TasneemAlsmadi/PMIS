using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BMISBLayer.Entities;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PMIS.Controllers
{
    public class ProjectPhasesController : Controller
    {
        private readonly IProjectPhaseRepository projectPhaseRepo;
        private readonly IMapper mapper;
        public ProjectPhasesController(IProjectPhaseRepository projectPhaseRepo, IMapper mapper)
        {
            this.projectPhaseRepo = projectPhaseRepo;
            this.mapper = mapper;
        }
        public IActionResult Index(int ProjectId)
        {
            try
            {

                TempData["projectId"] = ProjectId;
                TempData.Keep();
                ViewBag.Project = projectPhaseRepo.GetProject(ProjectId);
                ViewBag.projectphases = projectPhaseRepo.GetAllProjectPhases();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult NewProjectPhase() {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                ViewBag.Project = projectPhaseRepo.GetProject(ProjectId);
                ViewBag.Phases = projectPhaseRepo.GetAllPhases();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IActionResult InsertProjectPhase(ProjectPhase projectPhase)
        {
            try
            {
                ViewBag.Phases = projectPhaseRepo.GetAllPhases();
                Project project = new Project();
                int ProjectId = (int)TempData["projectId"];
                ViewBag.Project = projectPhaseRepo.GetProject(ProjectId);
                projectPhase.ProjectId = ProjectId;
                TempData.Keep();
                
                var Proj= projectPhaseRepo.GetProject(ProjectId);
                if (Proj.StartDate > projectPhase.StartDate)
                {
                    ViewBag.error = false;
                    return View();
                }
                if (Proj.EndDate < projectPhase.EndDate) {
                    ViewBag.error1 = false;
                    return View();
                }
                projectPhaseRepo.InsertProjectPhase(projectPhase);
                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult EditProjectPhase(int ProjectPhaseId)
        {
            try
            {
                ProjectPhase projectPhase = new ProjectPhase();
                projectPhase = projectPhaseRepo.GetProjectPhase(ProjectPhaseId);
                ViewBag.Phase = projectPhaseRepo.GetAllPhases();
                return View(projectPhase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdateProjectPhase(ProjectPhase projectPhase)
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                ViewBag.Phase = projectPhaseRepo.GetAllPhases();


                var P = projectPhaseRepo.GetProjectPhase(projectPhase.ProjectPhaseId);
                P.StartDate = projectPhase.StartDate;
                P.EndDate = projectPhase.EndDate;
                P.PhaseId = projectPhase.PhaseId;
                
                
                var Proj = projectPhaseRepo.GetProject(ProjectId);

                if (Proj.StartDate > projectPhase.StartDate)
                {
                    ViewBag.error = false;
                    return View(projectPhase);
                }
                if (Proj.EndDate < projectPhase.EndDate)
                {
                    ViewBag.error1 = false;
                    return View(projectPhase);
                }

                projectPhaseRepo.EditProjectPhase(P);

                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult DeleteProjectPhase(int projectPhaseId)
        {
            try
            {
                int ProjectId = (int)TempData["projectId"];
                TempData.Keep();
                projectPhaseRepo.DeleteProjectPhase(projectPhaseId);
                return RedirectToAction("Index", new { ProjectId = ProjectId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}