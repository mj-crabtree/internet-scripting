using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace exercises
{
    public class Northwind : DbContext
    {
        public Northwind()
        {
        }

        public Northwind(DbContextOptions<Northwind> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Filename=Northwind.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => { entity.Property(e => e.EmployeeId).ValueGeneratedNever(); });

            modelBuilder.Entity<Shipper>(entity => { entity.Property(e => e.ShipperId).ValueGeneratedNever(); });

            // OnModelCreatingPartial(modelBuilder);
        }

        // private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        // {
        //     throw new NotImplementedException();
        // }
    }
}