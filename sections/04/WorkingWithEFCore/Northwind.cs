using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Crabtree.Shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "northwind.db");

            // configuring the application to leverage lazy loading
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // using the fluent API instead of properties to attributes on properties
            // limiting the category name to 15 characters
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();

            // global filter to remove discontinued products
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        }
    }
}

/* 
Now, every time the loop enumerates, and an attempt is made to read the Products property, the lazy loading
proxy will check if they are loaded. If not, it will load them for us "lazily" by executing a SELECT statement to load
just that set of products for the current category, and then the correct count would be returned to the output.
 */