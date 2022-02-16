using System;

namespace week2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Ex3_12();
            Ex3_3();
        }

        private static void Ex3_12()
        {
            var matt = Factory.Person();
            matt.PrintThings();
        }

        private static void Ex3_3()
        {
            Printer.Print("Counting Enter presses. hit X to quit.");

            var counter = 0;
            var esc = false;

            while (!esc)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    ++counter;
                    Printer.Print($"You've pressed the enter key {counter} times");
                }
                esc = (key == ConsoleKey.X);
            }
        }
    }
}