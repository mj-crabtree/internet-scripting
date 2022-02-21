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
            // manipulating data with ef core
            // QueryingCategories();
            // FilteredIncludes();
            // QueryingProducts();
            // QueryingWithLike();

            // if (AddProduct(6, "Bob's Burgers", 500M))
            // {
            //     System.Console.WriteLine("Add product successful");
            // }
			
			if (IncreaseProductPrice("Bob", 20M))
			{
				System.Console.WriteLine("Price Updated");
			}

            ListProducts();
			
			ReadKey();
			
			DeleteProduct("Bob");
				
            ListProducts();
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

                IQueryable<Category> categories;

                db.ChangeTracker.LazyLoadingEnabled = false;
                Write("Enable eager loading? Y/N: ");
                bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitLoading = false;

                if (eagerLoading)
                {
                    categories = db.Categories.Include(c => c.Products);
                }
                else
                {
                    categories = db.Categories;
                    Write("Explicit loading enabled? Y/N: ");
                    explicitLoading = (ReadKey().Key == ConsoleKey.Y);
                    WriteLine();
                }

                foreach (var c in categories)
                {
                    if (explicitLoading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? Y/N: ");
                        var key = ReadKey();
                        WriteLine();

                        if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded) products.Load();
                        }
                    }
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

        static bool AddProduct(int categoriyID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var product = new Product()
                {
                    CategoryID = categoriyID,
                    ProductName = productName,
                    Cost = price
                };
                db.Products.Add(product);
                var affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
                    "ID", "Product Name", "Cost", "Stock", "Disc.");

                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        item.ProductID, item.ProductName, item.Cost,
                        item.Stock, item.Discontinued);
                }
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                var updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
				updateProduct.Cost+= amount;
				int affected = db.SaveChanges();
				return (affected == 1);
            }
        }
		
		static bool DeleteProduct(string name)
		{
			using (var db = new Northwind())
			{
				var deletedProduct = db.Products.Where(p => p.ProductName.StartsWith(name));
				db.Products.RemoveRange(deletedProduct);
				int affected = db.SaveChanges();
				return (affected == 1);
				
			}
		}
    }
}
