using DAL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(string productCategory);
        IEnumerable<Product> GetProductsBySupplier(string supplierName);
    }
}
