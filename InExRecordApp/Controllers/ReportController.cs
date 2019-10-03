using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
}