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
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string ExpenseType { get; set; }
        [Column(TypeName = "float(20)")]
        [Required]
        public decimal Amount { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string ChequeNo { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string BankName { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Particular { get; set; }
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int IsApproved { get; set; }
    }
}
