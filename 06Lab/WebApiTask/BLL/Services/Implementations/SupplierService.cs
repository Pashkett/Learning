using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync()
        {
            var suppliers = await unitOfWork.Suppliers.GetAllAsync();
            var suppliersDTO = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(suppliers);

            return suppliersDTO;
        }

        public async Task<SupplierDTO> GetSupplierByIdAsync(int id)
        {
            var supplier = await unitOfWork.Suppliers.GetByIdAsync(id);
            var supplierDto = mapper.Map<Supplier, SupplierDTO>(supplier);

            return supplierDto;
        }

        public async Task<SupplierDTO> CreateSupplierAsync(SupplierDTO supplierDTO)
        {
            var supplierToCreate = mapper.Map<SupplierDTO, Supplier>(supplierDTO);
            await unitOfWork.Suppliers.AddAsync(supplierToCreate);
            await unitOfWork.CompleteAsync();

            return supplierDTO;
        }

        public async Task UpdateSupplierAsync(SupplierDTO supplierDtoToUpdate, SupplierDTO supplierDTO)
        {
            var supplierToUpdate = mapper.Map<SupplierDTO, Supplier>(supplierDtoToUpdate);
            var supplier = mapper.Map<SupplierDTO, Supplier>(supplierDTO);

            supplierToUpdate.SupplierName = supplier.SupplierName;
            supplierToUpdate.Country = supplier.Country;
            supplierToUpdate.City = supplier.City;            

            await unitOfWork.CompleteAsync();
        }

        public async Task RemoveSupplierAsync(SupplierDTO supplierDTO)
        {
            var supplierToDelete = mapper.Map<SupplierDTO, Supplier>(supplierDTO);
            unitOfWork.Suppliers.Remove(supplierToDelete);

            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsBySupplierIdAsync(int id)
        {
            var products = await unitOfWork.Products.GetProductsBySupplierIdAsync(id);
            var productsDto = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return productsDto;
        }
    }
}
