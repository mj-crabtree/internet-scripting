using System;

namespace week1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // classCode();
            Ex1_1();
            Ex1_2();
            Ex1_3();
        }

        private static void Ex1_1()
        {
            // create a console application that displays your name
            var person = Factory.Person();
            person.PrintName();
        }

        private static void Ex1_2()
        {
            // create a console application that displays today’s date in a long format
            var dateTime = Factory.Date();
            dateTime.PrintDate();
        }

        private static void Ex1_3()
        {
            // create a console application that displays the text "Hello World!" on a colored background
            var console = Factory.FunkyConsole();
            console.SetColor();
        }

        /**
         * Refresher lesson, re-introduction to C#
         * - variables
         * - capturing input
         * - displaying output
         */
        private static void ClassCode()
        {
            Console.WriteLine("What's your name? ");
            var firstName = Console.ReadLine();
            var now = DateTime.Now;
            Console.WriteLine($"Hello {firstName}, have a nice day. The day is {now:dddd}");
        }
    }
}