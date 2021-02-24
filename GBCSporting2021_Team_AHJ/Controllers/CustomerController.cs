using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class CustomerController : Controller
    {
        private IncidentContext context { get; set; }

        public CustomerController(IncidentContext ctx)
        {
            this.context = ctx;
        }

        public IActionResult Index()
        {
            var customers = context.Customers.OrderBy(c => c.FirstName).ToList();

            return View(customers);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();

            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            //    여긴 이렇게 안해도 되는듯 
            //    .Include(c => c.Country)
            //    .FirstOrDefault(c => c.CustomerID == id);


            return View(customer);
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            var action = (customer.CustomerId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = action;

                //아무값도 입력안하고 세이브 누를시 이걸 안하면 에러가 뜸
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();

                return View(customer);
            }

        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }





    }

}
