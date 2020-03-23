using System;
using System.Collections.Generic;
using DAL.Models;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL;
using System.Linq;

namespace BLL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext context) : base(context) { }

        public IEnumerable<Product> GetProductsByCategory(string productCategory)
        {
            return productsContext.Products
                            .AsNoTracking()
                            .Where(products => products.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory))
                            .OrderBy(product => product.Name)
                            .ToList();
        }

        public IEnumerable<Product> GetProductsBySupplier(string supplierName)
        {
            return productsContext.Products
                            .AsNoTracking()
                            .Where(product => product.Supplier.SupplierName == supplierName)
                            .OrderBy(product => product.Name)
                            .ToList();
        }

        private ProductsContext productsContext => context as ProductsContext;
    }
}
