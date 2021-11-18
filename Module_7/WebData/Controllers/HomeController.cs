using EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork ctx;
        private ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork ct, ILogger<HomeController> logger)
        {
            ctx = ct;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Begin Index()");
            var people = ctx.People.GetAll().Take(10).ToList();

           await  ctx.SaveAsync();
            _logger.LogInformation("End Index()");
            return View(people);
        }
    }
}
