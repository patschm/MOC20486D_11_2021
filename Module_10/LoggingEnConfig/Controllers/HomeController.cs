using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingEnConfig.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[ErrorHandler]
       // [ExceptionFilter()]
        public IActionResult Index()
        {
            _logger.LogTrace("Trees");
            _logger.LogInformation("Info");
            _logger.LogError("Error");
            _logger.LogCritical("'Kritiek");
            return View();
        }
    }
}
