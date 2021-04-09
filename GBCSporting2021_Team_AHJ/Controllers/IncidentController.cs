using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext context;

        //private IEnumerable<Customer> customers;            // List and IEnu
        //private List<Product> products;
        //private List<Technician> technicians;

        public IncidentController(IncidentContext ctx)
        {
            this.context = ctx;
            //this.customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            //this.products = context.Products.OrderBy(p => p.Name).ToList();
            //this.technicians = context.Technicians.OrderBy(t => t.Name).ToList();
        }


        public IActionResult Index(string filter = "all")
        {
            var model = new IncidentListViewModel
            {
                Filter = filter
            };

            IQueryable<Incident> query = context.Incidents;  // 이렇게 해도 되고 안해도 되고
            DateTime defaultDate = new DateTime();  //Default value of DateTime is (1,1,1,0,0,0) year month date, hour, min, second

            if (model.Filter == "unassigned")
            {
                model.Incidents = context.Incidents.Where(i => i.Technician == null).ToList();
            }
            else if (model.Filter == "open")
            {
                model.Incidents = context.Incidents
                    .Where(i => i.DateOpened.CompareTo(defaultDate) != 0 && i.DateOpened <= DateTime.Today && i.DateClosed > DateTime.Today || i.DateClosed.CompareTo(defaultDate) == 0)                    
                    .ToList();
            }
            else // all
            {
                model.Incidents = query.OrderBy(i => i.DateOpened).ToList();
            }

            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();

            return View(model);
        }


        public IActionResult Add()
        {            
            var model = new IncidentViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.Name).ToList(),
                CurrentIncident = new Incident(),
                Operation = "Add"
            };          

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {           
            var model = new IncidentViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.Name).ToList(),
                CurrentIncident = context.Incidents
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .Include(i => i.Technician)
                    .FirstOrDefault(i => i.IncidentId == id),
                Operation = "Edit"
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);

            return View(incident);
        }


        [HttpPost]
        public IActionResult Edit(IncidentViewModel model)
        {            
            if (ModelState.IsValid)
            {
                if(model.Operation == "Add")
                {
                    context.Incidents.Add(model.CurrentIncident);
                }
                else  // Edit
                {
                    context.Incidents.Update(model.CurrentIncident);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Incident");
            }
            else
            {                
                ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
                //ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();

                return View(model);
            }

        }
        

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();

            return RedirectToAction("Index", "Incident");
        }

    }
}
