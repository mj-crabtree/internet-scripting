using Microsoft.EntityFrameworkCore;

namespace Crabtree.Shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.UnitPrice)
                .HasConversion<double>();
        }
    }
}