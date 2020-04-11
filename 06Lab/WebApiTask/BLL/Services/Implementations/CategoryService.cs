using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await unitOfWork.Categories.GetAllAsync();
            var categoriesDTO = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            return categoriesDTO;
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(id);
            var categoryDto = mapper.Map<Category, CategoryDTO>(category);

            return categoryDto;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var categoryToCreate = mapper.Map<CategoryDTO, Category>(categoryDTO);
            await unitOfWork.Categories.AddAsync(categoryToCreate);
            await unitOfWork.CompleteAsync();

            return categoryDTO;
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDtoToUpdate, CategoryDTO categoryDTO)
        {
            var categoryToUpdate = mapper.Map<CategoryDTO, Category>(categoryDtoToUpdate);
            var category = mapper.Map<CategoryDTO, Category>(categoryDTO);

            categoryToUpdate.Name = category.Name;

            await unitOfWork.CompleteAsync();
        }

        public async Task RemoveCategoryAsync(CategoryDTO categoryDTO)
        {
            var categoryToDelete = mapper.Map<CategoryDTO, Category>(categoryDTO);
            unitOfWork.Categories.Remove(categoryToDelete);

            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int id)
        {
            var products = await unitOfWork.Products.GetProductsByCategoryIdAsync(id);
            var productsDto = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return productsDto;
        }
    }
}
