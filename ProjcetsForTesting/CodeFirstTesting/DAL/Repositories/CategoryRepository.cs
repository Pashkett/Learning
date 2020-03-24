using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
