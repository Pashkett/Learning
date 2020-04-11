using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.DTOs;

namespace API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliersAsync()
        {
            var suppliers = await supplierService.GetAllSuppliersAsync();

            if (suppliers == null)
                return NoContent();

            return Ok(suppliers);
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplierAsync(int id)
        {
            var supplier = await supplierService.GetSupplierByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // GET: api/Suppliers/5/products
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsbyCategoryAsync(int id)
        {
            var products = await supplierService.GetProductsBySupplierIdAsync(id);

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        // PUT: api/Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierAsync(int id, [FromBody]SupplierDTO supplier)
        {
            if (id != supplier.SupplierId)
                return BadRequest();

            var supplierToUpdate = await supplierService.GetSupplierByIdAsync(id);

            if (supplierToUpdate == null)
                return NotFound();

            await supplierService.UpdateSupplierAsync(supplierToUpdate, supplier);

            return Ok();
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplierAsync([FromBody]SupplierDTO supplier)
        {
            var supplierCreated = await supplierService.CreateSupplierAsync(supplier);

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, supplier);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDTO>> DeleteSupplierAsync(int id)
        {
            var supplier = await supplierService.GetSupplierByIdAsync(id);
           
            if (supplier == null)
                return NotFound();

            await supplierService.RemoveSupplierAsync(supplier);

            return supplier;
        }
    }
}