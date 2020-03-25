using System.Linq;
using System.Collections.Generic;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext context) : base(context) { }

        public IEnumerable<Product> GetProductsByCategory(string productCategory)
        {
            return productsContext.Products
                            .Where(products => products.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory))
                            .OrderBy(product => product.Name)
                            .ToList();
        }

        public IEnumerable<Product> GetProductsBySupplier(string supplierName)
        {
            return productsContext.Products
                            .Where(product => product.Supplier.SupplierName == supplierName)
                            .OrderBy(product => product.Name)
                            .ToList();
        }

        private ProductsContext productsContext => context as ProductsContext;
    }
}
