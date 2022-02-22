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
            FilterAndSort();
        }

        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                .Where(product => product.UnitPrice < 10M)
                .OrderByDescending(product => product.UnitPrice);

                System.Console.WriteLine("Products which cost less than $10:");

                foreach (var item in query)
                {
                    System.Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
                    item.ProductID, item.ProductName, item.UnitPrice);
                }
                System.Console.WriteLine();
            }
        }
    }
}
