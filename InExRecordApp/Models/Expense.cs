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
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string ExpenseType { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public double Amount { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ChequeNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string BankName { get; set; }

        [Column(TypeName = "text")]
        public string Particular { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime Date { get; set; }
    }
}
