using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Entities
{
    public class Supplier : IEntity
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
