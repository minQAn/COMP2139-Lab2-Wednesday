using Lab3_wk4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Lab3_wk4.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx)
        {
            context = ctx;      // view 에 보여줄 데이터모델 불러오기
        }

        [HttpGet]
        public IActionResult Details(int id)    // primary key
        {
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);

            return View(contact);   //should create contact directory in view
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();

            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();

            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);

            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts
               .Include(c => c.Category)
               .FirstOrDefault(c => c.ContactId == id);

            return View(contact);
        }

        //----------------------------------
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactId == 0) ? "Add" : "Edit";     //if condition

            if (ModelState.IsValid)
            {
                ViewBag.Action = action;
                if(action == "Add")
                {
                    contact.SetDateAdded(DateTime.Now);
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();
                return View(contact);
            }
 
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
