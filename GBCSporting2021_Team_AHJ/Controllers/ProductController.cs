using GBCSporting2021_Team_AHJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GBCSporting2021_Team_AHJ.Controllers
{
    public class ProductController : Controller
    {
        private IncidentContext context { get; set; }

        public ProductController(IncidentContext ctx)
        {
            this.context = ctx;
        }


        [HttpGet]
        public ViewResult Index()
        {           
            var products = context.Products                      
                .OrderBy(i => i.ReleaseDate).ToList();

            return View(products);  // return to View Page!
        }

        //[HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";            

            return View("Edit", new Product()); // to Edit View page! not control
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);

            return View(product);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);

            return View(product);
        }

        
        // -- Post --
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if(action == "Add")
                {                   
                    context.Products.Add(product);                   
                }
                else
                {
                    context.Products.Update(product);                    
                }
                context.SaveChanges();
                TempData["message"] = $"{product.Name} was {action.ToLower()}ed.";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = action;
                TempData["message"] = "Error.. ModelState is Invalid.";
                return View(product);
            }            
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            TempData["message"] = $"{product.Name} was deleted.";
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");   // action , controller
        }
    }
}
