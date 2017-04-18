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
        public IActionResult Task(basic_html_css.Models.ViewModels.TaskViewModel task)
        {
            var taskLocal = new basic_html_css.Models.Task();
            taskLocal.Deskripsi = task.Deskripsi;
            taskLocal.EffortTask=task.EffortTask;
            taskLocal.JenisTask=task.JenisTask;
            taskLocal.Name= task.Name;
            taskLocal.Publish = task.Publish;
            context.Tasks.Add(taskLocal);
            context.SaveChanges();            
            task.Message ="Data berhasil di simpan";
            return View(task);
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
