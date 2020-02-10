using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcStudyGuide_NinjectDI.Models;
using MvcStudyGuide_NinjectDI.Modules;
using Ninject;

namespace MvcStudyGuide_NinjectDI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //// creates a Standard kernel whose job is to provide me the object of Samurai class using the .Get() method in the second code line.
            //var kernel = new StandardKernel(new WarriorModule());
            //var samurai = kernel.Get<Samurai>();

            //// call the Strike() method of the Samurai class.
            //string message = samurai.Strike();

            //ViewData["someAction"] = message;
            ViewData["someAction"] = "click on those links";
            return View();
        }

        public ActionResult Sword()
        {
            var kernel = new StandardKernel(new WarriorModule("Sword"));
            var samurai = kernel.Get<Samurai>();

            string message = samurai.Strike();
            return View("Index", (object)message);
        }

        public ActionResult Arrow()
        {
            var kernel = new StandardKernel(new WarriorModule("Arrow"));
            var samurai = kernel.Get<Samurai>();

            string message = samurai.Strike();
            return View("Index", (object)message);
        }

        public ActionResult Gun()
        {
            var kernel = new StandardKernel(new WarriorModule("Gun"));
            var samurai = kernel.Get<Samurai>();

            string message = samurai.Strike();
            return View("Index", (object)message);
        }
    }
}