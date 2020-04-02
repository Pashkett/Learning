using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Persistence.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetByName(string name);
    }
}
