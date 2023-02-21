using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сongratulator.Models;
using Microsoft.EntityFrameworkCore;


namespace Сongratulator.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Birthday> Birthdays { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;" +
                "Port=5432;" +
                "Database=birthdays_db;" +
                "Username=postgres;" +
                "Password=admin;"
                );
        }
    }
}
