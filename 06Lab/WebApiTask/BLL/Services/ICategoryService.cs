using BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task RemoveCategoryAsync(CategoryDTO categoryDTO);
        Task UpdateCategoryAsync(CategoryDTO categoryDtoToUpdate, CategoryDTO categoryDTO);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int id);
    }
}