using System.Data;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Persistence
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private const string getAllProductCategories = "GetAllProductCategories";
        private const string getProductCategoryById = "GetProductCategoryById";
        private const string insertProductCategory = "InsertCategory";
        private const string deleteProductCategoryById = "DeleteCategoryById";

        private readonly AdoNetContext context;

        public ProductCategoryRepository(AdoNetContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getAllProductCategories;

                return ToList(command).ToList();
            }
        }

        public ProductCategory GetById(int id)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getProductCategoryById;

                command.AddParameter("ProductCategoryId", id);

                return ToList(command).FirstOrDefault();
            }
        }

        public void Create(ProductCategory record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = insertProductCategory;

                command.AddParameter("ProductId", record.ProductId);
                command.AddParameter("CategoryId", record.CategoryId);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(ProductCategory record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = deleteProductCategoryById;

                command.AddParameter("ProductCategoryId", record.ProductCategoryId);

                command.ExecuteNonQuery();
            }
        }

        protected override void Map(IDataRecord record, ProductCategory item)
        {
            item.ProductCategoryId = (int)record["ProductCategoryId"];
            item.ProductId = (int)record["ProductId"];
            item.CategoryId = (int)record["CategoryId"];
        }
    }
}
