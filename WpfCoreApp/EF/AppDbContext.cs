using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //DbSets
        public DbSet<Preference> Preferences { get; set; }


    }
}
