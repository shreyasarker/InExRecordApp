using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InExRecordApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ExpenseType { get; set; }
        public double Amount { get; set; }
        public string ChecqueNo { get; set; }
        public string BankName { get; set; }
        public string Particular { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
    }
}
