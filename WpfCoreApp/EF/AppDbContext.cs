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

            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Alice", Department = "HR", Age = 34, IsActive = true },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Age = 40, IsActive = true },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Age = 60, IsActive = true }
            );

            modelBuilder.Entity<Citizen>().HasData(
                new Citizen
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Photo = new byte[0], // empty photo
                    DateOfBirth = new DateTime(1990, 5, 12)
                },
                new Citizen
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Photo = new byte[0], // empty photo
                    DateOfBirth = new DateTime(1985, 11, 23)
                },
                new Citizen
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Brown",
                    Photo = new byte[0], // empty photo
                    DateOfBirth = new DateTime(2000, 1, 5)
                }
            );

        }

        //DbSets
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
    }
}
