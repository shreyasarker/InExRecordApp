using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InExRecordApp.Controllers
{
    public class ReportController : Controller
    {
        private AppDbContext _context;
        public ReportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ViewMonthlyIncome(string month = "", string year = "")
        {
            if (string.IsNullOrEmpty(month) && string.IsNullOrEmpty(year))
            {
                month = DateTime.Now.ToString("MMMM");
                year = DateTime.Now.ToString("yyyy");
            }
           
            List<Income> incomes = _context.Incomes.Where(i => i.IsApproved)
                .Where(i => i.Date.ToString("MMMM") == month &&
                    i.Date.ToString("yyyy") == year).ToList();
            return View(incomes);
        }

        [HttpGet]
        public IActionResult ViewMonthlyExpense(string month = "", string year = "")
        {
            if (string.IsNullOrEmpty(month) && string.IsNullOrEmpty(year))
            {
                month = DateTime.Now.ToString("MMMM");
                year = DateTime.Now.ToString("yyyy");
            }
            List<Expense> expenses = _context.Expenses
                .Where(i => i.IsApproved)
                .Where(i => i.Date.ToString("MMMM") == month &&
                            i.Date.ToString("yyyy") == year).ToList();
            ViewBag.Month = month;
            ViewBag.Year = year;
            return View(expenses);
        }

        public IActionResult ViewYearlyProfit()
        {
            //var incomes = context.Incomes.Select(k => new { k.Date.Month, k.Amount }).GroupBy(x => new { x.Month }, (key, group) => new
            //{
            //    month = key.Month,
            //    income = group.Sum(k => k.Amount)
            //}).ToList();

            //var expenses = context.Expenses.Select(k => new { k.Date.Month, k.Amount }).GroupBy(x => new { x.Month }, (key, group) => new
            //{
            //    month = key.Month,
            //    income = group.Sum(k => k.Amount)
            //}).ToList();

            ////var data = from i in context.Incomes
            ////    join e in context.Expenses
            ////        on i.Date equals e.Date
            ////        group i by 
            //var monthsToDate = Enumerable.Range(1, 12)
            //    .Select(m => new DateTime(DateTime.Today.Year, m, 1))
            //    .ToList();


            var q1 = _context.Incomes
                .GroupBy(r => r.Date.Month)
                .Select(a => new
                {
                    Month = a.Key,
                    Amount = a.Sum(r => r.Amount)
                }).ToList();


            var q2 = _context.Expenses
                .GroupBy(r => r.Date.Month)
                .Select(a => new
                {
                    Month = a.Key,
                    Amount = a.Sum(r => r.Amount)
                }).ToList();
            List<YearlyData> yearlyDatas = new List<YearlyData>();
            //foreach (var a in q1)
            //{
            //    yearl
            //}
            var data = (from i in q1
                join e in q2 on i.Month equals e.Month
                group new {i, e} by e.Month into v
                    select new
                    {
                        Month = v.Key,
                        incomeAmount = v.Max(x => x.i.Amount),
                        expenseAmount = v.Max(x => x.e.Amount),
                    });
            return Json(new {data = data});
        }
    }
}