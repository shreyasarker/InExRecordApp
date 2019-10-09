using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InExRecordApp.Models
{
    public class YearlyDataModelView
    {
        public int MonthId { get; set; }
        public double IncomeAmount { get; set; }
        public double ExpenseAmount { get; set; }
        public double Profit { get; set; }
    }
}
