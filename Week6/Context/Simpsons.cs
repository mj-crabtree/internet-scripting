using System;
using Microsoft.EntityFrameworkCore;

namespace McRobbie.Com
{
    public class Simpsons : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Simpsons.db"); */
            string currentDirectory = System.Environment.CurrentDirectory;
            string parentDirectory = System.IO.Directory.GetParent(currentDirectory).FullName;
            string path = System.IO.Path.Combine(parentDirectory, "Simpsons.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
