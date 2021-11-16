using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controleurs
{
    [Route("thuis")]
    public class HomeController : Controller
    {
        // Action
        [Route("kamer/{id?}")]
        [HttpGet]
        [MyActionFilter]
        public IActionResult Index(int id)
        {
            var data = RouteData.Values["controller"];
            Console.WriteLine(data); 
            ViewBag.Bla = $"Eigenlijk ook old school {id}";
            ViewData["Bla"] = $"Old School {id}";
           
            return View("Index", "Hallo");
        }
        [HttpDelete]
        public IActionResult Index(string id)
        {
            var data = RouteData.Values["controller"];
            Console.WriteLine(data);
            ViewBag.Bla = $"Eigenlijk ook old school {id}";
            ViewData["Bla"] = $"Old School {id}";

            return View("Index", "Hallo");
        }
    }
}
