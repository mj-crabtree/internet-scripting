using System;
using System.Linq;
using Crabtree.Shared;
using Microsoft.EntityFrameworkCore;

namespace Crabtree.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayCustomersOrders();
        }

        static void NorthwindEmployeeLocations()
        {
            // grouping employees by their locations

            using (var db = new Northwind())
            {
                var query = db.Employees
                    .AsEnumerable()
                    .OrderBy(e => e.Country)
                    .ThenBy(e => e.LastName)
                    .GroupBy(e => e.Country);

                foreach (var country in query)
                {
                    System.Console.WriteLine(country.Key);
                    foreach (var employee in country)
                    {
                        System.Console.WriteLine($"\t{employee.FirstName} {employee.LastName}");
                    }
                }
            }
        }

        static void DisplayCustomersOrders()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("Northwind Customers");
                var groupCusts = db.Customers.Join(db.Orders, c => c.CustomerId, o => o.CustomerId,
                    (c, o) => new { c.CompanyName, o.OrderId }).OrderBy(c => c.CompanyName).ToList()
                    .GroupBy(c => c.CompanyName).Select(c => new { key = c.Key, count = c.Count() });
                foreach (var item in groupCusts)
                {
                    Console.WriteLine($"{item.key} has placed {item.count} orders.");
                }
            }
        }

        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var result = db.Products
                    .Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductId,
                        product.ProductName,
                        product.UnitPrice
                    });

                System.Console.WriteLine("Products which cost less than $10:");
                foreach (var item in result)
                {
                    System.Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    item.ProductId, item.ProductName, item.UnitPrice);
                }
                System.Console.WriteLine();
            }
        }

        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryJoin = db.Categories
                    .Join(
                        inner: db.Products,
                        outerKeySelector: category => category.CategoryID,
                        innerKeySelector: product => product.CategoryId,
                        resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId })
                    .OrderBy(cp => cp.CategoryName);

                foreach (var item in queryJoin)
                {
                    System.Console.WriteLine("{0}: {1} is in {2}.",
                        arg0: item.ProductId,
                        arg1: item.ProductName,
                        arg2: item.CategoryName);
                }
            }
        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryGroup = db.Categories
                    // we need this to convert from queryable to enumerable, two steps:
                    // 1. linq -> efCore bringing data into the application
                    // 2. linq -> objects processing in memory
                    .AsEnumerable()
                    .GroupJoin(
                        inner: db.Products,
                        outerKeySelector: category => category.CategoryID,
                        innerKeySelector: product => product.CategoryId,
                        resultSelector: (c, matchingProducts) => new
                        {
                            c.CategoryName,
                            Products = matchingProducts.OrderBy(p => p.ProductName)
                        }
                    );

                foreach (var item in queryGroup)
                {
                    Console.WriteLine("{0} has {1} products.",
                    arg0: item.CategoryName,
                    arg1: item.Products.Count());
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

        static void AggregateProducts()
        {
            // printing out the details of products, categories, basically inventory stats
            using (var db = new Northwind())
            {
                System.Console.WriteLine("{0,-25} {1,10}",
                    arg0: "Product count:",
                    arg1: db.Products.Count());

                System.Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Highest product price:",
                    arg1: db.Products.Max(p => p.UnitPrice));

                System.Console.WriteLine("{0,-25} {1,10:N0}",
                    arg0: "Sum of units in stock:",
                    arg1: db.Products.Sum(p => p.UnitsInStock));

                System.Console.WriteLine("{0,-25} {1,10:N0}",
                    arg0: "Sum of units on order:",
                    arg1: db.Products.Sum(p => p.UnitsOnOrder));

                System.Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Average unit price:",
                    arg1: db.Products.Average(p => p.UnitPrice));

                System.Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Value of units in stock:",
                    arg1: db.Products.AsEnumerable().Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }

        static void LinqSyntacticSugar()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

            // this Linq extension method query ...
            var query = names
                .Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);

            System.Console.WriteLine("extension method results:");
            foreach (var name in query)
            {
                System.Console.WriteLine(name);
            }

            // ... is equivalent to this comprehension syntax query        
            var comprehensionSyntaxQuery =
                from name in names
                where name.Length > 4
                orderby name.Length, name
                select name;

            System.Console.WriteLine("comprehension syntax results:");
            foreach (var name in comprehensionSyntaxQuery)
            {
                System.Console.WriteLine(name);
            }
        }
    }
}