using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using DAL.Models;

namespace DAL.SeedingDataExtension
{
    public static class ProductsContextExtension
    {
        public static void SeedData(this ProductsContext productsContext)
        {
            
            if(productsContext.Suppliers.Count() == 0
                && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Suppliers.json")))
            {
                    string file = File.ReadAllText("Suppliers.json");

                    var data = JsonSerializer.Deserialize<List<Supplier>>(file);
                    productsContext.AddRange(data);

                    productsContext.SaveChanges();
            }

            if (productsContext.Categories.Count() == 0 
                && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Categories.json")))
            {
                
                string file = File.ReadAllText("Categories.json");

                var data = JsonSerializer.Deserialize<List<Category>>(file);
                productsContext.AddRange(data);
                productsContext.SaveChanges();
            }

            if (productsContext.Products.Count() == 0
                && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Products.json")))
            {
                string file = System.IO.File.ReadAllText("Products.json");
                var data = JsonSerializer.Deserialize<List<Product>>(file);
                productsContext.AddRange(data);
                productsContext.SaveChanges();
            }

            if (productsContext.ProductCategories.Count() == 0
                && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ProductCategories.json")))
            {
                string file = System.IO.File.ReadAllText("ProductCategories.json");
                var data = JsonSerializer.Deserialize<List<ProductCategory>>(file);
                productsContext.AddRange(data);
                productsContext.SaveChanges();
            }
        }
    }
}
