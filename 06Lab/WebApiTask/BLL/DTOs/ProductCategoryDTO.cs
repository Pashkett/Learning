using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ProductCategoryDTO
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}
