using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Entities
{
    public class ProductCategory : IEntity
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
