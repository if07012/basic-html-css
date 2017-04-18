using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_html_css.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_html_css.Controllers
{
    public class HomeController : Controller
    {
        Context context;
        public HomeController(Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Task()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Task(basic_html_css.Models.Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult List()
        {

            return Json(context.Tasks);
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
