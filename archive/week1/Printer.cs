using System;

namespace week1
{
    public partial class Exercises
    {
        private abstract class Printer
        {
            public static void Print(string data)
            {
                Console.WriteLine($"\n{data}");
            }
        }
    }
}