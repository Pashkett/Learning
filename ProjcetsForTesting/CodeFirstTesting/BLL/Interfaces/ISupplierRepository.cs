using DAL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetSuppliersByCategory(string productCategory);
    }
}
