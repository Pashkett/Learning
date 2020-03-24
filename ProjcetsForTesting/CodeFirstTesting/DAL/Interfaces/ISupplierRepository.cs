using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetSuppliersByCategory(string productCategory);
    }
}
