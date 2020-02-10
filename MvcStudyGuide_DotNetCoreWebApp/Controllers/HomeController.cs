using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcStudyGuide_DotNetCoreWebApp.Models;

namespace MvcStudyGuide_DotNetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Repository().Products);
        }
    }
}