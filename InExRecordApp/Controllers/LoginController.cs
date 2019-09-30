using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InExRecordApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext dataContext;

        public LoginController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User aUser)
        {
            if (!ModelState.IsValid)
            {
                return View(aUser);
            }
            var user = CheckLogin(aUser.Email, aUser.Password);
            if (user == null)
            {
                ViewBag.Error = "Email or password is invalid";
                return View(aUser);
            }
            HttpContext.Session.SetInt32("userId", user.Id);
            return RedirectToAction("Index", "LandingPage");
        }

        private User CheckLogin(string email, string password)
        {
            var user = dataContext.Users.SingleOrDefault(u => u.Email.Equals(email));
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}