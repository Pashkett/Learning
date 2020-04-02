using System.Data;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Persistence
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        
        private const string getAllSuppliers = "GetAllSuppliers";
        private const string getSupplierById = "GetSupplierById";
        private const string getSupplierByName = "GetSupplierByName";
        private const string insertSupplier = "InsertSupplier";
        private const string deleteSupplierById = "DeleteSupplierById";

        private readonly AdoNetContext context;

        public SupplierRepository(AdoNetContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getAllSuppliers;

                return ToList(command).ToList();
            }
        }

        public Supplier GetById(int id)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getSupplierById;

                command.AddParameter("SupplierId", id);

                return ToList(command).FirstOrDefault();
            }
        }

        public IEnumerable<Supplier> GetByName(string name)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = getSupplierByName;

                command.AddParameter("SupplierName", name);

                return ToList(command).ToList();
            }
        }

        public void Create(Supplier record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = insertSupplier;

                command.AddParameter("SupplierName", record.SupplierName);
                command.AddParameter("City", record.City);
                command.AddParameter("Country", record.Country);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(Supplier record)
        {
            using (var command = context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = deleteSupplierById;

                command.AddParameter("SupplierId", record.SupplierId);

                command.ExecuteNonQuery();
            }
        }

        protected override void Map(IDataRecord record, Supplier item)
        {
            item.SupplierId = (int)record["SupplierId"];
            item.SupplierName = (string)record["SupplierName"];
            item.City = (string)record["City"];
            item.Country = (string)record["Country"];
        }
    }
}
