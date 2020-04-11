using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await unitOfWork.Products.GetAllAsync();
            var productsDTO = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return productsDTO;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.Products.GetByIdAsync(id);
            var productDto = mapper.Map<Product, ProductDTO>(product);

            return productDto;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDTO)
        {
            var productToCreate = mapper.Map<ProductDTO, Product>(productDTO);
            await unitOfWork.Products.AddAsync(productToCreate);
            await unitOfWork.CompleteAsync();

            return productDTO;
        }

        public async Task UpdateProductAsync(ProductDTO productDtoToUpdate, ProductDTO productDTO)
        {
            var productToUpdate = mapper.Map<ProductDTO, Product>(productDtoToUpdate);
            var product = mapper.Map<ProductDTO, Product>(productDTO);

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Supplier = product.Supplier;
            productToUpdate.SupplierId = product.SupplierId;

            await unitOfWork.CompleteAsync();
        }

        public async Task RemoveProductAsync(ProductDTO productDTO)
        {
            var productToDelete = mapper.Map<ProductDTO, Product>(productDTO);
            unitOfWork.Products.Remove(productToDelete);

            await unitOfWork.CompleteAsync();
        }
    }
}
