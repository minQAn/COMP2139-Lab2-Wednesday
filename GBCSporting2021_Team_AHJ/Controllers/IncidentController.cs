using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext context;

        private IEnumerable<Customer> customers;            // List and IEnu
        private List<Product> products;
        private List<Technician> technicians;

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
    }
}
