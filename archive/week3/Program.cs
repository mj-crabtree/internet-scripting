using System;

namespace week3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Ex3_1();
            Ex3_2();
            Ex3_3();
        }

        private static void Ex3_3()
        {
            var timer = Factory.Timer(1000);
            timer.Elapsed += Utils.TimerElapsed;
            timer.Start();
            while (true)
            {
            }
        }

        private static void Ex3_2()
        {
            var success = false;
            while (!success)
            {
                Printer.Print("What is your email address?");
                success = Utils.EmailChecker(Console.ReadLine());
            }
        }

        private static void Ex3_1()
        {
            var answer = Factory.Calculator().Addition(5, 3);
            var correct = false;

            while (!correct)
            {
                Printer.Print("What is 5 + 3? ");

                if (!int.TryParse(Console.ReadLine(), out var result)) continue;
                if (result == answer)
                {
                    Printer.Print("Correct!");
                    correct = true;
                }
                else
                {
                    Printer.Print("Try again");
                }
            }
        }
    }
}