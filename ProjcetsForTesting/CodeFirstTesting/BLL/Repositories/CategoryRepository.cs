using DAL.Models;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BLL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
