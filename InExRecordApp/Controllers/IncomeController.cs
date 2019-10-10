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
        private readonly AppDbContext _context;
        public IncomeController(AppDbContext context)
        {
            _context = context;
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
                    income.UserId = HttpContext.Session.GetInt32("userId").ToString();
                    _context.Incomes.Add(income);
                    _context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        redirecturl = Url.Action("Show", "Income"),
                        message = "Data Submited!"
                    });
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
            List<Income> incomes = _context.Incomes.Where(i => i.IsApproved == false).ToList();
            return View(incomes);
        }

        [HttpPost]
        public IActionResult Approve(int[] ids)
        {
            try
            {
                var entity = _context.Incomes.Where(i => ids.Contains(i.Id));

                foreach (var e in entity)
                {
                    e.IsApproved = true;
                    _context.Incomes.Update(e);
                }
                _context.SaveChanges();

                return Json(new { success = true, redirecturl = Url.Action("Show", "Income"), message = "Data approved!" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }
    }
}