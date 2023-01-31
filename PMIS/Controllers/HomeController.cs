using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BMISBLayer.Entities;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMIS.Models;

namespace PMIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository HomeRepository;

        public HomeController(IHomeRepository HomeRepository)
        {
            this.HomeRepository = HomeRepository;

        }

        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.projects = HomeRepository.GetAllProjects(userId);
                int j = 0;
                foreach (var i in (List<Project>)ViewBag.projects)
                {
                    if (i.ProjectStatusId == 1)
                        j++;
                }
                ViewBag.j = j;

                int k = 0;
                foreach (var i in (List<Project>)ViewBag.projects)
                {
                    if (i.ProjectStatusId == 2)
                        k++;
                }
                ViewBag.k = k;

                int l = 0;
                foreach (var i in (List<Project>)ViewBag.projects)
                {
                    if (i.ProjectStatusId == 3)
                        l++;
                }
                ViewBag.l = l;


                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
