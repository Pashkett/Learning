using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.SeedingDataExtension
{
    public static class ProductsContextExtension
    {
        public static void SeedData<T>(this ProductsContext productsContext, DbSet<T> set, string fileName)
            where T : class
        {
            if (set.Count() == 0 && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
            {
                try
                {
                    string file = File.ReadAllText(fileName);
                    var data = JsonSerializer.Deserialize<List<T>>(file);
                    productsContext.AddRange(data);
                    productsContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

            //"Suppliers.json"
            //"Categories.json"
            //"Products.json"
            //"ProductCategories.json"

            //if (productsContext.Suppliers.Count() == 0
            //    && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Suppliers.json")))
            //{
            //    try
            //    {
            //        string file = File.ReadAllText("Suppliers.json");
            //        var data = JsonSerializer.Deserialize<List<Supplier>>(file);
            //        productsContext.AddRange(data);
            //        productsContext.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            //if (productsContext.Categories.Count() == 0
            //    && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Categories.json")))
            //{

            //    try
            //    {
            //        string file = File.ReadAllText("Categories.json");
            //        var data = JsonSerializer.Deserialize<List<Category>>(file);
            //        productsContext.AddRange(data);
            //        productsContext.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //}

            //if (productsContext.ProductCategories.Count() == 0
            //    && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ProductCategories.json")))
            //{
            //    try
            //    {
            //        string file = System.IO.File.ReadAllText("ProductCategories.json");
            //        var data = JsonSerializer.Deserialize<List<ProductCategory>>(file);
            //        productsContext.AddRange(data);
            //        productsContext.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
//        }
//    }
//}
