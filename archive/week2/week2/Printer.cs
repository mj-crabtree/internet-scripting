using System;

namespace week2
{
    public static class Printer
    {
        public static void Print(string message)
        {
            Console.Out.WriteLine(message);
        }

        public static void PrintGreeting(Person person)
        {
            Console.Out.WriteLine($"Hello {person.Name}. Have a nice day.");
        }

        public static void PrintAge(Person person)
        {
            Console.Out.WriteLine($"You are {person.Age} years old.");
        }
    }
}