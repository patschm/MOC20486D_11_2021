using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _factory;

        public HomeController(IHttpClientFactory factor, ILogger<HomeController> logger)
        {
            _logger = logger;
            _factory = factor;
        }

        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var result = await client.GetAsync("people");
            if (result.IsSuccessStatusCode)
            {
                _logger.LogInformation("Gelukt");
                var str = await result.Content.ReadAsStringAsync();
                ViewBag.Data = str;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
