using System.Linq;
using System;

namespace LinqWithObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }

        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

            // using syntactic sugar to avoid the explicit delegate instantiation - roslyn will do it for us!
            // var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            // we don't have to use implicit delegates either, we can get away with using lambda expressions
            // var query = names.Where(NameLongerThanFour);

            // System.Linq means we can start doing all this cool shit with something as simple as a string array 
            var query = names
                .Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);

            foreach (var item in query)
            {
                System.Console.WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };
            
            var numberErrors = errors.OfType<ArithmeticException>();
            
            foreach (var error in numberErrors)
            {
                System.Console.WriteLine(error);
            }
        }
    }
}
