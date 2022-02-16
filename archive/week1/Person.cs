using System;

namespace week1
{
    public partial class Exercises
    {
        public class Person
        {
            private readonly string _name;

            public Person()
            {
                _name = SetName();
            }

            public void PrintName()
            {
                Printer.Print("---- Exercise 1.1 ----");
                Printer.Print(_name);
            }

            private string SetName()
            {
                Printer.Print("What is your name? ");
                return Console.ReadLine();
            }
        }
    }
}