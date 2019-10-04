using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InExRecordApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            return View();
        }
        public IActionResult UserProfile()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            return View();
        }
    }
}