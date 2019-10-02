using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InExRecordApp.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Expense Type is required")]
        public string ExpenseType { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ChequeNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string BankName { get; set; }

        [Column(TypeName = "text")]
        public string Particular { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool IsApproved { get; set; }

        public Expense()
        {
            IsApproved = false;
        }
    }
}
