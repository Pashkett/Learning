using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public virtual SupplierDTO Supplier { get; set; }
        public virtual ICollection<ProductCategoryDTO> ProductCategories { get; set; }
    }
}
