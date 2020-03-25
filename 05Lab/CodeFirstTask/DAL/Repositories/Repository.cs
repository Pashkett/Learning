using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;


namespace DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => 
            context.Set<TEntity>().Where(predicate);
    }
}
