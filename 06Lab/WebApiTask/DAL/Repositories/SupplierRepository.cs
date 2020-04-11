using System.Linq;
using System.Collections.Generic;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProductsContext context) : base(context) { }

        private ProductsContext productsContext => context as ProductsContext;

        public IEnumerable<Supplier> GetSuppliersByCategory(string productCategory)
        {
            return productsContext.Suppliers
                            .Where(supplier => supplier.Products
                                .Any(product => product.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory)))
                            .OrderBy(supplier => supplier.SupplierName)
                            .ToList();
        }
    }
}
