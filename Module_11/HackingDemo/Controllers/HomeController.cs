using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hacking.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inject(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }

       //[ValidateAntiForgeryToken]
        public ActionResult NoCSRF()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Pay(int amount)
        {
            Console.WriteLine($"Overgemaakt: {amount}");
            return "Hoi! 500 Euries";
        }
        public ActionResult SqlInject(string msg)
        {
            ViewBag.Statement = "SELECT * FROM users WHERE name = '" + msg + "' and pass = '" + msg +"';";
            return View();
        }
    }
}
