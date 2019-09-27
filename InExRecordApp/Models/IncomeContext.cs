using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InExRecordApp.Models
{
    public class IncomeContext: DbContext
    {
        public IncomeContext(DbContextOptions<IncomeContext> options): base(options)
        {
        }
        public DbSet<Income> Incomes { get; set; }
    }
}
