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

        public JsonResult ViewYearlyProfit()
        {
            List<Income> incomes = new List<Income>();

            //var data = incomes.Select(k => new {k.Date.Month, k.Amount})
            //    .GroupBy(x => new { x.Month}, (key, group) => new
            //    {
            //        monthName = key.Month,
            //        totalAmount = group.Sum(k => k.Amount)
            //    }).ToList();

            IEnumerable<IncomeResult> data = from c in incomes
                group c by new
                {
                    c.UserId,
                } into grp
                select new IncomeResult()
                {
                    Month = new DateTime(grp.Key.UserId),
                    Sum = grp.Sum(s => s.Amount)
                };

            return new JsonResult(data);
        }
    }
}