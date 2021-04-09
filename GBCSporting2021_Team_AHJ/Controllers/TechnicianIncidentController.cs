using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class TechnicianIncidentController : Controller
    {
        private IncidentContext context;

        public TechnicianIncidentController(IncidentContext ctx)
        {
            context = ctx;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var model = new TechnicianIncidentViewModel
            {
                Technicians = context.Technicians.OrderBy(t => t.Name).ToList()
            };

            return View(model);
        }
    }
}
