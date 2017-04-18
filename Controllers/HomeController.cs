using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Task(basic_html_css.Models.ViewModels.TaskViewModel model)
        {
            model.List = context.Tasks;
            model.Id = 4;
            return View(model);
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var item = context.Tasks.FirstOrDefault(n => n.Id == id);
            var model = new basic_html_css.Models.ViewModels.TaskViewModel();
            model.List = context.Tasks;

            System.Console.WriteLine(item.Name);
            model.Deskripsi = item.Deskripsi;
            model.EffortTask = item.EffortTask;
            model.JenisTask = item.JenisTask;
            model.Name = item.Name;
            model.Publish = item.Publish;
            model.Id = id;
            Debug.WriteLine("ASdasdasdas");
            model.Message = HttpContext.Request.Query["id"];
            return View("Task", model);
        }

        public IActionResult DeleteTask(int id)
        {
            var item = context.Tasks.FirstOrDefault(n => n.Id == id);
            var model = new basic_html_css.Models.ViewModels.TaskViewModel();
            context.Tasks.Remove(item);
            model.Message = "Data berhasil di hapus";
            return View("Task", model);
        }
        [HttpPost]
        public IActionResult TaskPost(basic_html_css.Models.ViewModels.TaskViewModel task)
        {
            var taskLocal = new basic_html_css.Models.Task();
            if (task.Id != 0)
                taskLocal = context.Tasks.FirstOrDefault(n => n.Id == task.Id);
            taskLocal.Deskripsi = task.Deskripsi;
            taskLocal.EffortTask = task.EffortTask;
            taskLocal.JenisTask = task.JenisTask;
            taskLocal.Name = task.Name;
            taskLocal.Publish = task.Publish;
            if (task.Id == 0)
                context.Tasks.Add(taskLocal);
            context.SaveChanges();
            task.Message = "Data berhasil di simpan";
            task.List = context.Tasks;
            return View("Task",task);
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
        public IActionResult Contact(int data)
        {
            ViewData["Message"] = data;

            return View("Contact", data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
