using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
