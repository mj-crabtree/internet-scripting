using System;

namespace week1
{
    public partial class Exercises
    {
        public class Date
        {
            private static DateTime _longDate;

            public Date()
            {
                _longDate = DateTime.Now;
            }

            public void PrintDate()
            {
                Printer.Print("---- Exercise 1.2 ----");
                Printer.Print(VerboseDate());
            }

            private static string VerboseDate()
            {
                return $"{_longDate:D}";
            }
        }
    }
}