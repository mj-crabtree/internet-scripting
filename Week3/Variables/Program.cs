using System;

namespace Varaiables
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello World!"); */
            Console.Write("What is your firstname? ");
            string firstname = Console.ReadLine();
            Console.Write("What is your lastname? ");
            string lastname = Console.ReadLine();
            Console.WriteLine($"Hello {firstname} {lastname}!");
            Console.Write("What is your date of birth? ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            /* Console.WriteLine($"Your date of birth is {dob}"); */
            Console.WriteLine($"You were born on a {dob:dddd}!");
        }
    }
}
