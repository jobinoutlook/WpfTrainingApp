using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp.Mvvm.Model;

namespace WpfCoreApp.EF
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = AppConfig.Configuration.GetConnectionString("MyDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If MyKeylessEntity exists, ensure it's imported and defined.
            // Otherwise, remove or replace this block.
            // Example:
            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasNoKey();
            });
        }

        //DbSets
        public DbSet<Preference> Preferences { get; set; }
    }
}
