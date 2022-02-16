using System;

namespace SimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Console.WriteLine("What is your name? ");
            string firstname = Console.ReadLine();
            DateTime today = DateTime.Now;
            Console.WriteLine($"Hello {firstname}. Have a nice day! Today is {today:dddd d MMMM}");
            Console.ReadKey();
        }
    }
}
