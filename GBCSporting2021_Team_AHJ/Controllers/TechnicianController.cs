using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class TechnicianController : Controller
    {
        private IncidentContext context { get; set; }

        public TechnicianController(IncidentContext ctx)
        {
            this.context = ctx;
        }


        public IActionResult Index()
        {
            var technicians = context.Technicians
                .OrderBy(t => t.Name).ToList();

            return View(technicians);
        }


        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var technician = context.Technicians.Find(id);

            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianId == id);

            return View(technician);
        }


        // Post
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Technicians.Add(technician);
                }
                else
                {
                    context.Technicians.Update(technician);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Technician");
            }
            else
            {
                ViewBag.Action = action;               
                return View(technician);
            }                     

        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();

            return RedirectToAction("Index", "Technician");
        }


    }
}
