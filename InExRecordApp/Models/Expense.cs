using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace InExRecordApp.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Expense Type is required")]
        public string ExpenseType { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Amount is required")]
        [DataType(DataType.Currency, ErrorMessage = "Amount must be numeric")]
        public double Amount { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ChequeNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string BankName { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Particular is required")]
        public string Particular { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Date format is invalid")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool IsApproved { get; set; }

        public Expense()
        {
            IsApproved = false;
        }
    }
}
