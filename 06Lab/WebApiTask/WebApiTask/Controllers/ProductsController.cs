using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var products = await productService.GetAllProductsAsync();

            if (products == null)
                return NoContent();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAsync(int id, [FromBody]ProductDTO product)
        {
            if (id != product.ProductId)
                return BadRequest();

            var productToUpdate = await productService.GetProductByIdAsync(id);
            
            if (productToUpdate == null)
                return NotFound();

            await productService.UpdateProductAsync(productToUpdate, product);

            return Ok();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProductAsync([FromBody]ProductDTO product)
        {
            var productCreated = await productService.CreateProductAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> DeleteProductAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            await productService.RemoveProductAsync(product);

            return product;
        }
    }
}