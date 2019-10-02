using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InExRecordApp.Controllers
{
    public class IncomeController : Controller
    {
        private readonly DataContext dataContext;
        public IncomeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Store()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(Income income)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    income.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
                    dataContext.Incomes.Add(income);
                    dataContext.SaveChanges();
                   
                    return Json(new {success = true, redirecturl = Url.Action("Show", "Income"), message = "Data Submited"});
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = e.Message });
                }
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult Show()
        {
            return View();
        }
    }
}