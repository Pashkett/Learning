using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Persistence
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private const string getAllProducts = "GetAllProducts";
        private const string getProductById = "GetProductById";
        private const string insertProduct = "InsertProduct";
        private const string deleteProductById = "DeleteProductById";

        private readonly AdoNetContext context;

        public ProductRepository(AdoNetContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getAllProducts;

                return ToList(command).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getProductById;

                command.AddParameter("ProductId", id);

                return ToList(command).FirstOrDefault();
            }
        }

        public void Create(Product record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = insertProduct;

                command.AddParameter("Name", record.Name);
                command.AddParameter("Price", record.Price);
                command.AddParameter("SupplierId", record.SupplierId);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(Product record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = deleteProductById;

                command.AddParameter("ProductId", record.ProductId);

                command.ExecuteNonQuery();
            }
        }

        protected override void Map(IDataRecord record, Product item)
        {
            item.ProductId = (int)record["ProductId"];
            item.Name = (string)record["Name"];
            item.Price = (decimal)record["Price"];
            item.SupplierId = (int)record["SupplierId"];
        }
    }
}
