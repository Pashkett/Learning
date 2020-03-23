using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using DAL.SeedingDataExtension;
using System.Collections;
using System.Collections.Generic;


namespace CodeFirstTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _db = new ProductsContext())
            {
                _db.SeedData(_db.Suppliers, "Suppliers.json");
                _db.SeedData(_db.Categories, "Categories.json");
                _db.SeedData(_db.Products, "Products.json");
                _db.SeedData(_db.ProductCategories, "ProductCategories.json");

                Console.WriteLine($"\n{nameof(GetProductsByCategory)}\n");
                var products = GetProductsByCategory(_db, "cream");
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }

                Console.WriteLine($"\n{nameof(GetSuppliersByCategory)}\n");
                var suppliers = GetSuppliersByCategory(_db, "cream");
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine(supplier.SupplierName);
                }

                Console.WriteLine($"\n{nameof(GetProductsBySupplier)}\n");
                var productsBySuppliers = GetProductsBySupplier(_db, "TWIIST");
                foreach (var product in productsBySuppliers)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }

        private static IEnumerable<Product> GetProductsByCategory(ProductsContext productsContext,
            string productCategory)
        {
            var result = productsContext.Products
                            .AsNoTracking()
                            .Where(products => products.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory))
                            .OrderBy(product => product.Name)
                            .ToList();

            return result;
        }

        private static IEnumerable<Supplier> GetSuppliersByCategory(ProductsContext productsContext, 
            string productCategory)
        {

            var result = productsContext.Suppliers
                            .AsNoTracking()
                            .Where(supplier => supplier.Products
                                .Any(product => product.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory)))
                            .OrderBy(supplier => supplier.SupplierName)
                            .ToList();

            return result;
        }

        private static IEnumerable<Product> GetProductsBySupplier(ProductsContext productsContext, 
            string supplierName)
        {
            var result = productsContext.Products
                            .AsNoTracking()
                            .Where(product => product.Supplier.SupplierName == supplierName)
                            .OrderBy(product => product.Name)
                            .ToList();
            
            return result;
        }
    }
}
