using System.Linq;
using System.Collections.Generic;
using DAL.Models;
using DAL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int id)
        {
            return await productsContext.Products
                            .Where(products => products.ProductCategories
                                .Any(prodCategory => prodCategory.Category.CategoryId == id))
                            .OrderBy(product => product.Name)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(int id)
        {
            return await productsContext.Products
                            .Where(product => product.Supplier.SupplierId == id)
                            .OrderBy(product => product.Name)
                            .ToListAsync();
        }

        private ProductsContext productsContext => context as ProductsContext;
    }
}
