using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Veilig.Models;

namespace Veilig.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string ReturnUrl)
        {
            LoginModel model = new LoginModel { RedirectUrl = ReturnUrl };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                View(model);
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Actor, "Clown")
            };

            ClaimsIdentity idenity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal prin = new ClaimsPrincipal(idenity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prin, new AuthenticationProperties { IsPersistent = model.RememberMe });
            return Redirect(model.RedirectUrl);
        }
    }
}
