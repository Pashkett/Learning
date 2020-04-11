using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public interface ISupplierService
    {
        Task<SupplierDTO> CreateSupplierAsync(SupplierDTO supplierDTO);
        Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync();
        Task<SupplierDTO> GetSupplierByIdAsync(int id);
        Task RemoveSupplierAsync(SupplierDTO supplierDTO);
        Task UpdateSupplierAsync(SupplierDTO supplierDtoToUpdate, SupplierDTO supplierDTO);
        Task<IEnumerable<ProductDTO>> GetProductsBySupplierIdAsync(int id);
    }
}
