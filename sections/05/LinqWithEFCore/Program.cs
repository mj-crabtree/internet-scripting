using System;
using System.Linq;
using Crabtree.Shared;
using Microsoft.EntityFrameworkCore;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupJoinCategoriesAndProducts();
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
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });

                System.Console.WriteLine("Products which cost less than $10:");
                foreach (var item in result)
                {
                    System.Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    item.ProductID, item.ProductName, item.UnitPrice);
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
                        innerKeySelector: product => product.CategoryID,
                        resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                    .OrderBy(cp => cp.CategoryName);

                foreach (var item in queryJoin)
                {
                    System.Console.WriteLine("{0}: {1} is in {2}.",
                        arg0: item.ProductID,
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
                        innerKeySelector: product => product.CategoryID,
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
    }
}