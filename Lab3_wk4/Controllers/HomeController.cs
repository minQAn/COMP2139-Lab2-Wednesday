using Microsoft.AspNetCore.Mvc;

using Lab3_wk4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab3_wk4.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;      // view 에 보여줄 데이터모델 불러오기
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts
                          .Include(c => c.Category)
                          .OrderBy(c => c.FirstName).ToList();

            return View(contacts);
        }
    }
}
