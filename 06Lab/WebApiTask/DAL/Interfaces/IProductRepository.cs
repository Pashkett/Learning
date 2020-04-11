using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(int id);
    }
}