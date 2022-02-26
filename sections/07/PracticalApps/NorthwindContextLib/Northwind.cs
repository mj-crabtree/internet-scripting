using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Crabtree.Shared
{
    public partial class Northwind : DbContext
    {
        public Northwind()
        {
        }

        public Northwind(DbContextOptions<Northwind> options) : base(options)
        {
        }

        // entities begin

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        // entities end

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=../northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderID, e.ProductID });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasConversion<double>();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
