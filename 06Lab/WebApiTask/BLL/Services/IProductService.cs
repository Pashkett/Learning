using BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync(ProductDTO productDTO);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task RemoveProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDtoToUpdate, ProductDTO productDTO);
    }
}