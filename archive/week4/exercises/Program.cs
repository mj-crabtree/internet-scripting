using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace exercises
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new Northwind();
            ex4_1(context);
            ex4_2(context);
            ex4_3(context);
            ex4_4(context);
        }

        private static void ex4_1(Northwind context)
        {
            // create a console application that displays the full names of all the Northwind Employees.
            WriteLine("---- ex 4.1 ----");
            foreach (var employee in context.Employees) WriteLine($"{employee.FirstName} {employee.LastName}");
        }

        private static void ex4_2(Northwind context)
        {
            // create a console application that displays all the countries where Northwind Customers are based
            WriteLine("---- ex 4.2 ----");
            var countries = context.Customers.Select(customer => customer.Country).Distinct().ToList();
            countries.Sort();

            foreach (var country in countries)
            {
                WriteLine(country);
            }
        }

        private static void ex4_3(Northwind context)
        {
            // create a console application that lets the end user add a new record to the Northwind Shippers' table
            WriteLine("---- ex 4.3 ----");
            
            WriteLine("Shipper ID: ");
            var id = long.Parse(Console.ReadLine());
            WriteLine("Company Name:");
            var companyName = ReadLine();
            WriteLine("Company Phone:");
            var companyPhone = ReadLine();

            context.Shippers.Add(Shipper.NewShipper(id, companyName, companyPhone));
            context.SaveChanges();
        }
        private static void ex4_4(Northwind context)
        {
            // create a console application that displays the entire contents of the Northwind Shippers table
            WriteLine("---- ex 4.4 ----");
            using (context)
            {
                WriteLine("{0,-3} {1,-35} {2,14}", "ID", "Name", "Phone");
                foreach (var shipper in context.Shippers.OrderByDescending(p => p.ShipperId))
                {
                    WriteLine("{0:000} {1,-35} {2,14}",
                        shipper.ShipperId, shipper.CompanyName, shipper.Phone);
                }
            }
        }
    }
}