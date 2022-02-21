using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Music : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Music.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}