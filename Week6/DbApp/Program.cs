using System;
using System.Collections.Generic;
using System.Linq;
// using Microsoft.EntityFrameworkCore;
using McRobbie.Com;

namespace DbApp
{
    /* public class Simpsons : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Simpsons.db");
            string currentDirectory = System.Environment.CurrentDirectory;
            string parentDirectory = System.IO.Directory.GetParent(currentDirectory).FullName;
            string path = System.IO.Path.Combine(parentDirectory, "Simpsons.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    } */
    /* public class Character
    {
        public int CharacterId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    } */
    class Program
    {
        static void Main(string[] args)
        {
            Simpsons db = new Simpsons();
            IQueryable<Character> characters = db.Characters;
            foreach (Character c in characters)
            {
                Console.WriteLine($"{c.CharacterId}. {c.Firstname} {c.Lastname}");
            }
        }
    }
}
