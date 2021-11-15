using Basics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _uow;

        public HomeController(IUnitOfWork unit)
        {
            _uow = unit;
        }
        public IActionResult Index()
        {
            _uow.CreateBlaBla().Increment();
            return View();
        }
    }
}
