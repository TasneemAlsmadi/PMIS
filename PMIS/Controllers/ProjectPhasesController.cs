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
                //if (TempData.ContainsKey("projectId"))
                //    ViewBag.Project = projectPhaseRepo.GetProject((int)TempData["projectId"]);
                //TempData.Keep();
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
                //if (TempData.ContainsKey("projectId"))
                //    ViewBag.Project = projectPhaseRepo.GetProject((int)TempData["projectId"]);
                //TempData.Keep();
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
                // projectPhase.ProjectPhaseId = projectPhase.PhaseId;
                //if (TempData.ContainsKey("projectId"))
                //{
                //    projectPhase.ProjectId = (int)TempData["projectId"];
                //}
                //TempData.Keep();
                Project project = new Project();
                int ProjectId = (int)TempData["projectId"];
                ViewBag.Project = projectPhaseRepo.GetProject(ProjectId);
                projectPhase.ProjectId = ProjectId;
                TempData.Keep();
                //project = projectPhaseRepo.GetProject(ProjectId);
                //if (projectPhase.StartDate < project.StartDate)
                //{
                //    return ValidationProblem("error");
                //}
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
                projectPhaseRepo.EditProjectPhase(projectPhase);

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