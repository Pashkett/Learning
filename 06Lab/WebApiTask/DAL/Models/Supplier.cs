using System.Collections.Generic;

namespace DAL.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
