using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities;

namespace Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
           // Database.Migrate();
        }

        public DbSet<Entities.Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappingEntity = modelBuilder.Entity<Entities.Employee>();

            mappingEntity.Property(p => p.FirstName).IsRequired();
            mappingEntity.Property(p => p.LastName).IsRequired();

            modelBuilder.Entity<Entities.Employee>().HasMany(e => e.Dependents).WithOne();

     





        }


    }
}
