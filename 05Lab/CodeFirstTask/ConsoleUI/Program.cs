using System;
using DAL.Repositories;

namespace CodeFirstTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork())
            {
                Console.WriteLine("GetProductsByCategory\n");
                var productsByCategory = uow.Products.GetProductsByCategory("commodo");
                foreach (var product in productsByCategory)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine(new string('=', 12));

                Console.WriteLine("GetSuppliersByCategory\n");
                var suppliersByCategory = uow.Suppliers.GetSuppliersByCategory("commodo");
                foreach (var supplier in suppliersByCategory)
                {
                    Console.WriteLine(supplier.SupplierName);
                }
                Console.WriteLine(new string('=', 12));

                Console.WriteLine("GetProductsBySupplier\n");
                var productsBySupplier = uow.Products.GetProductsBySupplier("ZILLANET");
                foreach (var product in productsBySupplier)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine(new string('=', 12));

                Console.WriteLine("GetSuppliersByCountry\n");
                var suppliersByCountry = uow.Suppliers.Find(supplier => supplier.Country == "Angola");
                foreach (var supplier in suppliersByCountry)
                {
                    Console.WriteLine(supplier.SupplierName);
                }
                Console.WriteLine(new string('=', 12));
            }
        }
    }
}
