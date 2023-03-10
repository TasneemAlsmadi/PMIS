using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BMISBLayer.Entities;
using PMISBLayer.Data;
using BMISBLayer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace PMIS.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestFormLimitsPolicy ClientRepositry;
        private readonly IClientRepository clientRepo;
        public ClientController(ApplicationDbContext context, IClientRepository ClientRepo)
        {
            _context = context;
            clientRepo = ClientRepo;
        }

       
        public IActionResult Index()
        {
            var client = clientRepo.GetAllClient();
            return View(client);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Client client)
        {
            if (ModelState.IsValid)
            {
                clientRepo.InsertClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

       
        public IActionResult Edit(int id)
        {
            

            var client = clientRepo.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Client client)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    clientRepo.EditClient(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

       
        public IActionResult Delete(int id)
        {
            

             var client = clientRepo.GetClient(id);
               
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            clientRepo.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
