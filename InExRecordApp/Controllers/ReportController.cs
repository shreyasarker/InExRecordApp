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
        private DataContext dataContext;
        public ReportController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult ViewMonthlyIncome()
        {
            List<Income> incomes = dataContext.Incomes.Where(i => i.IsApproved).ToList();
            return View(incomes);
        }
        public IActionResult ViewMonthlyExpense()
        {
            List<Expense> expenses = dataContext.Expenses.Where(i => i.IsApproved).ToList();
            return View(expenses);
        }

        public IActionResult ViewYearlyProfit()
        {
            //var incomes = dataContext.Incomes.Select(k => new { k.Date.Month, k.Amount }).GroupBy(x => new { x.Month }, (key, group) => new
            //{
            //    month = key.Month,
            //    income = group.Sum(k => k.Amount)
            //}).ToList();

            //var expenses = dataContext.Expenses.Select(k => new { k.Date.Month, k.Amount }).GroupBy(x => new { x.Month }, (key, group) => new
            //{
            //    month = key.Month,
            //    income = group.Sum(k => k.Amount)
            //}).ToList();

            ////var data = from i in dataContext.Incomes
            ////    join e in dataContext.Expenses
            ////        on i.Date equals e.Date
            ////        group i by 
            //var monthsToDate = Enumerable.Range(1, 12)
            //    .Select(m => new DateTime(DateTime.Today.Year, m, 1))
            //    .ToList();


            var q1 = dataContext.Incomes
                .GroupBy(r => r.Date.Month)
                .Select(a => new
                {
                    Month = a.Key,
                    Amount = a.Sum(r => r.Amount)
                }).ToList();


            var q2 = dataContext.Expenses
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