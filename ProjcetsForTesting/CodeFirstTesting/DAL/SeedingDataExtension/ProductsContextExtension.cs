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
    public static class ProductsContextExtensionSeed
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