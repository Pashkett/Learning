using System.Collections.Generic;

namespace DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
