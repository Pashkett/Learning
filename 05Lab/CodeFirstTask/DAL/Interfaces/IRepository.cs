using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
