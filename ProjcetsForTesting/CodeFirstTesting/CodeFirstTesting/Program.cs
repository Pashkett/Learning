using DAL;
using DAL.Models;
using DAL.SeedingDataExtension;
using System;
using System.Linq;

namespace CodeFirstTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _db  = new ProductsContext())
            {
                _db.SeedData();
                Console.WriteLine(_db.Suppliers.Count());
                Console.WriteLine(_db.Products.Count());
                Console.WriteLine(_db.ProductCategories.Count());
                Console.WriteLine(_db.Categories.Count());
            }
        }
    }
}
