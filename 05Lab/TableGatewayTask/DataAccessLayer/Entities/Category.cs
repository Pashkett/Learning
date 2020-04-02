using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
