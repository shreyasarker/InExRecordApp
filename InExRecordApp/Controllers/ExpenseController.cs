using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InExRecordApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _context;

        public ExpenseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Store()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    expense.UserId = HttpContext.Session.GetInt32("userId").ToString();
                    _context.Expenses.Add(expense);
                    _context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        redirecturl = Url.Action("Show", "Expense"),
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
            List<Expense> expenses = _context.Expenses.Where(e => e.IsApproved == false).ToList();
            return View(expenses);
        }

        [HttpPost]
        public IActionResult Approve(int[] ids)
        {
            try
            {
                var entity = _context.Expenses.Where(i => ids.Contains(i.Id));

                foreach (var e in entity)
                {
                    e.IsApproved = true;
                    _context.Expenses.Update(e);
                }
                _context.SaveChanges();

                return Json(new { success = true, redirecturl = Url.Action("Show", "Expense"), message = "Data approved!" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
           
        }
    }
}