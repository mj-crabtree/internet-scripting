using static System.Console;
using Crabtree.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Crabtree.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
            // FilteredIncludes();
            // QueryingProducts();
            // QueryingWithLike();
        }

        static void QueryingCategories()
        {
            // querying EF Core models
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categories, and how many products they have:");

                // A query which fetches all categories, products in each
                // using Include() == eager loading (loads categories & products)
                // IQueryable<Category> categories =
                //     db.Categories.Include(c => c.Products);

                // lazy loading
                IQueryable<Category> categories = db.Categories;

                foreach (var c in categories)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                }
            }
        }

        static void FilteredIncludes()
        {
            // filtering included entities
            using (var db = new Northwind())
            {
                Write("Enter a minimum for units in stock: ");
                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);

                IQueryable<Category> categories =
                    db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock));

                WriteLine($"To query string: {categories.ToQueryString()}");

                foreach (var c in categories)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

                    foreach (var p in c.Products)
                    {
                        WriteLine($"    {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            // filtering and sorting products
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products which cost more than a given price, highest at the top.");
                string input;
                decimal price;

                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> products = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.ProductID);

                foreach (var item in products)
                {
                    WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                        item.ProductID, item.ProductName, item.Cost, item.Stock);
                }
            }
        }

        static void QueryingWithLike()
        {
            // Pattern matching with like
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> products = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (var item in products)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued? {2}",
                            item.ProductName, item.Stock, item.Discontinued);
                }
            }
        }
    }
}
