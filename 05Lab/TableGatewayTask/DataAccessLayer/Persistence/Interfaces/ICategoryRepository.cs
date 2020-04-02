using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Persistence.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetByName(string name);
    }
}
