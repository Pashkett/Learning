using System.Data;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Persistence
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private const string getAllCategories = "GetAllCategories";
        private const string getCategoryById = "GetCategoryById";
        private const string getCategoryByName = "GetCategoryByName";
        private const string insertCategory = "InsertCategory";
        private const string deleteCategoryById = "DeleteCategoryById";

        private readonly AdoNetContext context;

        public CategoryRepository(AdoNetContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getAllCategories;

                return ToList(command).ToList();
            }
        }

        public Category GetById(int id)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getCategoryById;

                command.AddParameter("CategoryId", id);

                return ToList(command).FirstOrDefault();
            }
        }

        public IEnumerable<Category> GetByName(string name)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getCategoryByName;

                command.AddParameter("CategoryName", name);

                return ToList(command);
            }
        }

        public void Create(Category record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = insertCategory;

                command.AddParameter("Name", record.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(Category record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = deleteCategoryById;

                command.AddParameter("CategoryId", record.Name);

                command.ExecuteNonQuery();
            }
        }

        protected override void Map(IDataRecord record, Category item)
        {
            item.CategoryId = (int)record["CategoryId"];
            item.Name = (string)record["Name"];
        }
    }
}
