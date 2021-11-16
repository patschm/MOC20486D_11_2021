using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Areas.ACME.Controllers
{
    [Area("ACME")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<string> items = new List<string> { "Hallo", "World", "Allemaal" };
            ViewBag.Items = items;
            ViewBag.ShowContent = true;
            return View();
        }
        public IActionResult Index2(int id)
        {
            List<string> items = new List<string> { "Hallo", "World", "Allemaal" };
            ViewBag.Items = items;
            ViewBag.ShowContent = true;
            return View();
        }
    }
}
