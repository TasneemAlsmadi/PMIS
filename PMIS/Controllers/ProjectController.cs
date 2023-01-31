using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BMISBLayer.Entities;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.DTOs;

namespace PMIS.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IMapper mapper;
        public ProjectController(IProjectRepository projectRepo, IMapper mapper) {
            this.projectRepo = projectRepo;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var project = projectRepo.GetProjectManagerProjects(userId).ToList();
                ViewBag.projects = project;
                //ViewBag.ProjectPhases = projectRepo.GetAllProjectPhases();
                //ViewBag.Phases = projectRepo.GetAllPhases();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult NewProject() {
            try
            {
                ViewBag.projectType = projectRepo.GetAllProjectTypes();
                ViewBag.ProjectStatus = projectRepo.GetAllProjectStatuses();
                ViewBag.Phases = projectRepo.GetAllPhases();
                ViewBag.Client = projectRepo.GetAllClients();



                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult InsertProject(InsertProjectDTO projectDTO)
        {
            try
            {

                //Project project = new Project();
                var project = mapper.Map<Project>(projectDTO);
                //project.ProjectName = projectDTO.ProjectName;
                //project.StartDate = projectDTO.StartDate;
                //project.EndDate = projectDTO.StartDate;
                //project.ContractAmount = projectDTO.ContractAmount;
                //project.ProjectStatusId = projectDTO.ProjectStatusId;
                //project.ProjectTypeId = projectDTO.ProjectTypeId;

                //project.ProjectStatusName = projectDTO.Status;
                //project.ProjectTypeName = projectDTO.ProjectTypeName;


                //File
                project.ContractFileName = projectDTO.ContractFile.FileName;
                project.ContractFileType = projectDTO.ContractFile.ContentType;
                project.ProjectManagerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                if (projectDTO.ContractFile.Length > 0)
                {
                    Stream st = projectDTO.ContractFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);
                        project.ContractFile = byteFile;
                        projectRepo.InsertProject(project);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FileStreamResult ViewContract(int ProjectId)
        {
            var project = projectRepo.GetProject(ProjectId);
            Stream stream = new MemoryStream(project.ContractFile);
            return new FileStreamResult(stream, project.ContractFileType);
        }

        public IActionResult EditProject(int ProjectId) {
            try
            {
                Project project = new Project();
                project = projectRepo.GetProject(ProjectId);


                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.projects = projectRepo.GetProjectManagerProjects(userId).ToList();

                ViewBag.projectType = projectRepo.GetAllProjectTypes();
                ViewBag.ProjectStatus = projectRepo.GetAllProjectStatuses();
                ViewBag.Client = projectRepo.GetAllClients();
                //ViewBag.Phases = projectRepo.GetAllPhases();
                //ViewBag.ProjectPhases= projectRepo.GetAllProjectPhases();


                return View(project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdateProject(InsertProjectDTO projectDTO)
        {
            try
            {
                var project = mapper.Map<Project>(projectDTO);
                project.ContractFileName = projectDTO.ContractFile.FileName;
                project.ContractFileType = projectDTO.ContractFile.ContentType;
                project.ProjectManagerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                if (projectDTO.ContractFile.Length > 0)
                {
                    Stream st = projectDTO.ContractFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);
                        project.ContractFile = byteFile;
                        projectRepo.EditProject(project);
                    }
                }


                //project = new Project();
                //project = projectRepo.GetProject(project.ProjectId);


                //Project project = new Project();
                //var project = mapper.Map<Project>(projectDTO);
                //project.ProjectName = projectDTO.ProjectName;
                //project.StartDate = projectDTO.StartDate;
                //project.EndDate = projectDTO.StartDate;
                //project.ContractAmount = projectDTO.ContractAmount;
                //project.ProjectStatusName = projectDTO.Status;
                //project.ProjectTypeName = projectDTO.ProjectTypeName;


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult DeleteProject(int projectId)
        {
            try {
                projectRepo.DeleteProject(projectId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }

}