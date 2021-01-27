using COMP2139_Lab2_Wednesday.Models;       //quick intelligence 로 해결

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Lab2_Wednesday.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]   //이걸해야함
        public IActionResult Index()
        {
            ViewBag.Fifteen = 0;
            ViewBag.Twenty = 0;
            ViewBag.TwentyFive = 0;
            return View();
        }

        [HttpPost] //Post
        public IActionResult Index(TipCalculator tip) //using 으로 Model 불러와야함 
        {
            if (ModelState.IsValid)
            {
                ViewBag.Fifteen = tip.CalculateTip(0.15);
                ViewBag.Twenty = tip.CalculateTip(0.20);
                ViewBag.TwentyFive = tip.CalculateTip(0.25);

            }
            else
            {
                ViewBag.Fifteen = 0;
                ViewBag.Twenty = 0;
                ViewBag.TwentyFive = 0;
            }

            return View(tip);
        }

    }
}
