using Microsoft.AspNetCore.Mvc;
using ModellenBureau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PersonViewModel model = new PersonViewModel
            {
                Id = 1,
                FirstName = "Doutzen",
                LastName = "Kroes",
                DirtySecrets = "Victoria",
                BirthDay = new DateTime(1985, 1, 23)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Post(PersonViewModel model)
        {
           if (!ModelState.IsValid)
            {
                ModelState.AddModelError("x", "Ooops");
                return View("Index", model);
            }
            return View(model);
        }
    }
}
