using DAL.Models;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DAL;
using System.Linq;

namespace BLL.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProductsContext context) : base(context) { }

        private ProductsContext productsContext => context as ProductsContext;

        public IEnumerable<Supplier> GetSuppliersByCategory(string productCategory)
        {
            return productsContext.Suppliers
                            .AsNoTracking()
                            .Where(supplier => supplier.Products
                                .Any(product => product.ProductCategories
                                .Any(prodCategory => prodCategory.Category.Name == productCategory)))
                            .OrderBy(supplier => supplier.SupplierName)
                            .ToList();
        }
    }
}
