using AdaptiveLINQ;
using AdaptiveLINQDemo.Data;
using MarkdownLog;
using System;
using System.Linq;

namespace AdaptiveLINQDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AdapitveLINQ Demo (AdventureWorks sales analysis)");
            Console.WriteLine("-----------------");
            Console.WriteLine();
            using (var dbContext = new AdventureWorksEntities())
            {
                Console.WriteLine("Top 5 customers:");
                Console.WriteLine();
                var topFiveCustomers = dbContext.SalesOrderDetails
                    .QueryByCube(new SalesCubeDefinition())
                    .Select(x => new
                    {
                        Customer = x.Customer,
                        TotalSales = x.TotalSales
                    })
                    .OrderByDescending(x => x.TotalSales)
                    .Take(5);
                Console.WriteLine(topFiveCustomers.ToMarkdownTable());
                Console.WriteLine();
                Console.WriteLine("Sales and quantity by category:");
                Console.WriteLine();
                var byCategory = dbContext.SalesOrderDetails
                    .QueryByCube(new SalesCubeDefinition())
                    .Select(x => new
                    {
                        Category = x.ProductCategory,
                        TotalSales = x.TotalSales,
                        TotalQty = x.TotalQty
                    })
                    .OrderBy(x => x.Category);
                Console.WriteLine(byCategory.ToMarkdownTable());
                Console.WriteLine();
                Console.WriteLine("Sales and quantity by category and country:");
                Console.WriteLine();
                var byCategoryAndCountry = dbContext.SalesOrderDetails
                    .QueryByCube(new SalesCubeDefinition())
                    .Select(x => new
                    {
                        Category = x.ProductCategory,
                        Country = x.Country,
                        TotalSales = x.TotalSales,
                        TotalQty = x.TotalQty
                    })
                    .OrderBy(x => x.Category)
                    .ThenBy(x => x.Country);
                Console.WriteLine(byCategoryAndCountry.ToMarkdownTable());
                Console.ReadKey();
            }
        }
    }
}
