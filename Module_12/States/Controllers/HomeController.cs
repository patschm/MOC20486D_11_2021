using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _cache;
        private IDistributedCache    _cache2;

        public HomeController(IMemoryCache cache, IDistributedCache cache2)
        {
            _cache = cache;
            _cache2 = cache2;
        }
        public IActionResult Index(string val = "")
        {
            List<string> list;
            if (HttpContext.Session.TryGetValue("list", out byte[] data))
            {
                var str = Encoding.UTF8.GetString(data);
               list = JsonConvert.DeserializeObject(str, typeof(List<string>)) as List<string>;
            }
            else
            {
                list  = new List<string>();
            }
          
            list.Add(val);



            string strs = JsonConvert.SerializeObject(list);
            HttpContext.Session.Set("list", Encoding.UTF8.GetBytes(strs));
            return View(list);
        }

        public IActionResult Koekjes()
        {          
            if (HttpContext.Request.Cookies.Count == 0)
            {
                ViewBag.Nu = DateTime.Now.ToLongTimeString();
                HttpContext.Response.Cookies.Append("key1", ViewBag.Nu , new CookieOptions { Expires = DateTimeOffset.Now.AddSeconds(30) });
            }
            else
            {
                var cookie = HttpContext.Request.Cookies.FirstOrDefault();
                ViewBag.Nu = cookie.Value;
            }
                return View();
        }
        public IActionResult Cache()
        {
            string nu;
            if (_cache.TryGetValue("nu", out object d))
            {
                nu = d.ToString();
            }
            else
            {
                Task.Delay(10000).Wait();
                nu = DateTime.Now.ToLongTimeString();
               
                _cache.Set("nu", nu, DateTimeOffset.Now.AddSeconds(10));
            }
            ViewBag.Nuuu = nu;
            return View();
        }
    }
}
