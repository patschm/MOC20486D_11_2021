using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Veilig.IdentityWare;
using Veilig.Models;

namespace Veilig.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyUser> _userMan;
        private SignInManager<MyUser> _signin;

        public AccountController(UserManager<MyUser> uman, SignInManager<MyUser> sman)
        {
            _userMan = uman;
            _signin = sman;
        }

        public IActionResult Register(string ReturnUrl)
        {
            RegisterModel model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            MyUser user = await _userMan.FindByNameAsync(model.Username);
            if (user != null)
            {
                ModelState.AddModelError("unkuser", "Deze gebruiker bestaat al");
                return View(model);
            }
            user = new MyUser { UserName = model.Username, Hobby = "Clown" };
           
            var result = await _userMan.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("unkuser",result.Errors.First().Description);
                return View(model);
            }
            await _userMan.AddClaimAsync(user, new Claim(ClaimTypes.Actor, user.Hobby));

            var siResult = await _signin.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!siResult.Succeeded)
            {
                ModelState.AddModelError("unkuser", "Fout wachtwoord");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

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
                return View(model);
            }
            MyUser user = await _userMan.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError("unkuser", "User bestaat niet");
                return View(model);
            }
            var siResult = await _signin.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!siResult.Succeeded)
            {
                ModelState.AddModelError("unkuser", "Fout wachtwoord");
                return View(model);
            }
            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, model.Username),
            //    new Claim(ClaimTypes.Role, "Admin"),
            //    new Claim(ClaimTypes.Actor, "Clown")
            //};

            //ClaimsIdentity idenity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //ClaimsPrincipal prin = new ClaimsPrincipal(idenity);
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prin, new AuthenticationProperties { IsPersistent = model.RememberMe });
            return Redirect(model.RedirectUrl);
        }
    }
}
