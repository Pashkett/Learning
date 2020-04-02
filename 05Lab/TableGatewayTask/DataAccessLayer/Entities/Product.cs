using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Entities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
    }
}
