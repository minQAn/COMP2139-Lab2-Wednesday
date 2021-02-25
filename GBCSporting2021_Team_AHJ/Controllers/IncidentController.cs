using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Index()
        {
            var incidents = context.Incidents
                .OrderBy(i => i.DateOpened).ToList();

            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();

            return View(incidents);
        }


        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();

            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);

            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();            
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();          

            return View(incident);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);

            return View(incident);
        }


        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Incident");
            }
            else
            {
                ViewBag.Action = action;

                ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();

                return View(incident);
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
