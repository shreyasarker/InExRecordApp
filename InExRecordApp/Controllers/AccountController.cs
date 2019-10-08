using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InExRecordApp.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User aUser)
        {
            if (ModelState.IsValid)
            {
                //ClaimsIdentity identity = null;
                //bool isAuthenticated = false;
                var user = CheckLogin(aUser.Email, aUser.Password);
                if (user == null)
                {
                    TempData["Error"] = "Email or password is invalid";
                    return View(aUser);
                }
                //identity = new ClaimsIdentity(new[] {
                //    new Claim(ClaimTypes.Email, user.Email),
                //    new Claim(ClaimTypes.Role, user.Designation)
                //}, CookieAuthenticationDefaults.AuthenticationScheme);

                //isAuthenticated = true;
                //if (isAuthenticated)
                //{
                //    var principal = new ClaimsPrincipal(identity);

                //   /* HttpContext.SignInAsync(C*/ookieAuthenticationDefaults.AuthenticationScheme, principal);
                //    HttpContext.Session.SetInt32("userId", user.Id);

                //    return RedirectToAction("Index", "Dashboard");
                //}
                HttpContext.Session.SetInt32("userId", user.Id);

                return RedirectToAction("Index", "Dashboard");
            }
            
            return View(aUser);
        }
        private User CheckLogin(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email.Equals(email));
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
        //[HttpPost]
        //public IActionResult Logout()
        //{
        //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login");
        //}
    }
}