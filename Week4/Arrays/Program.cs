using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello World!"); */
            /* string[] characters = new string[5];
            characters[0] = "Homer";
            characters[1] = "Madge";
            characters[2] = "Bart";
            characters[3] = "Lisa";
            characters[4] = "Maggie"; */
            /* string[] characters = new string[] { "Homer", "Madge", "Bart", "Lisa", "Maggie" }; */
            string[] characters = { "Homer", "Madge", "Bart", "Lisa", "Maggie" };
            /* Console.WriteLine($"{characters[0]}");
            Console.WriteLine($"{characters[1]}");
            Console.WriteLine($"{characters[2]}");
            Console.WriteLine($"{characters[3]}");
            Console.WriteLine($"{characters[4]}"); */

            Random rnd = new Random();
            int rndInt = rnd.Next(0, 4);
            /* Console.WriteLine($"Random Number: {rndInt}"); */
            Console.WriteLine($"My favourite Simpsons character is {characters[rndInt]}!");
        }
    }
}
