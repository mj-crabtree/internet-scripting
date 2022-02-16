using System;

namespace week1
{
    public partial class Exercises
    {
        public class FunkyConsole
        {
            public FunkyConsole()
            {
                Selection = GetSelection();
            }

            private char Selection { get; }

            public void SetColor()
            {
                Printer.Print("---- Exercise 1.3 ----");
                switch (Selection)
                {
                    case 'r':
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Printer.Print("Hello World");
                        break;
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Printer.Print("Hello World");
                        break;
                    case 'g':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Printer.Print("Hello World");
                        break;
                    case 'n':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Printer.Print("Knock, knock, Neo.");
                        break;
                }

                Console.ResetColor();
            }

            private static char GetSelection()
            {
                var input = ' ';
                var c = "";
                do
                {
                    Printer.Print("Select a console background colour: (r)ed, (b)lue, (g)reen, blac(k)");
                    input = Console.ReadKey().KeyChar;
                    c = input.ToString();
                } while (c != "r" && c != "b" && c != "g" && c != "k" && c != "n");

                return input;
            }
        }
    }
}