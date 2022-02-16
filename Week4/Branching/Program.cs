using System;

namespace Branching
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] characters = { "Homer", "Marge", "Bart", "Lisa", "Maggie" };
            Random rnd = new Random();
            int rndInt = rnd.Next(0, 4);
            string rndChar = characters[rndInt];
            Console.WriteLine($"My favourite Simpsons character is {rndChar}!");

            /* if (rndChar == "Homer")
            {
                Console.WriteLine("Homer is a buffoon!");
            }
            else if (rndChar == "Marge")
            {
                Console.WriteLine("Marge is the matriarch!");
            }
            else if (rndChar == "Bart")
            {
                Console.WriteLine("Bart is the prankster!");
            }
            else if (rndChar == "Lisa")
            {
                Console.WriteLine("Lisa is the activist!");
            }
            else if (rndChar == "Maggie")
            {
                Console.WriteLine("Maggie is the baby!");
            }
            else
            {
                Console.WriteLine("I'm not playing anymore!!!");
            } */
            switch (rndChar)
            {
                case "Homer":
                    Console.WriteLine("Homer is a buffoon!");
                    break;
                case "Marge":
                    Console.WriteLine("Marge is the matriarch!");
                    break;
                case "Bart":
                    Console.WriteLine("Bart is the prankster!");
                    break;
                case "Lisa":
                    Console.WriteLine("Lisa is the activist!");
                    break;
                case "Maggie":
                    Console.WriteLine("Maggie is the baby!");
                    break;
                default:
                    Console.WriteLine("I'm not playing anymore!!!");
                    break;
            }
        }
    }
}
