using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InExRecordApp.Controllers
{
    [Authorize]
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
            if (User.IsInRole("SrAccountant"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Store(Income income)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Incomes.Add(income);
                    _context.SaveChanges();

                    TempData["success"] = "Data Submited!";
                    return RedirectToAction("Show", "Income");
                }
                catch (Exception e)
                {
                    TempData["error"] = e.Message;
                    return View();
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

                TempData["success"] = "Data approved!";

                return Json(new { success = true, redirecturl = Url.Action("Show", "Income") });
            }
            catch (Exception e)
            {
                TempData["success"] = e.Message;
                return Json(new { success = false, message = e.Message });
            }
        }
    }
}