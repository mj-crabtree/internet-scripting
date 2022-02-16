using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbApp
{
    public class Simpsons : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Simpsons.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
    public class Character
    {
        public int CharacterId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello World!"); */
            /* int characterId = 1;
            string firstname = "Homer";
            string lastname = "Simpson"; */
            // Character character = new Character() { CharacterId = 1, Firstname = "Homer", Lastname = "Simpson"};
            /* character.CharacterId = 1;
            character.Firstname = "Homer";
            character.Lastname = "Simpson"; */
            // Console.WriteLine($"{character.CharacterId}. {character.Firstname} {character.Lastname}");
            /* IQueryable<Character> characters = new List<Character>() {
                new Character() { CharacterId = 1, Firstname = "Homer", Lastname = "Simpson" },
                new Character() { CharacterId = 2, Firstname = "Ned", Lastname = "Flanders" },
                new Character() { CharacterId = 3, Firstname = "Nelson", Lastname = "Muntz" },
                new Character() { CharacterId = 4, Firstname = "Barney", Lastname = "Gumble" },
                new Character() { CharacterId = 5, Firstname = "Ralph", Lastname = "Wiggum" },
            }.AsQueryable(); */
            Simpsons simpsons = new Simpsons();
            IQueryable<Character> characters = simpsons.Characters;
            foreach (Character c in characters)
            {
                Console.WriteLine($"{c.CharacterId}. {c.Firstname} {c.Lastname}");
            }
        }
    }
}
