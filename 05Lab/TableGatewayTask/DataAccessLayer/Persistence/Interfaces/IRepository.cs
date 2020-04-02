using System.Collections.Generic;

namespace DataAccessLayer.Persistence.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T record);
        void Remove(T record);
    }
}
