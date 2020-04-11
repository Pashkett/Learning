using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.DTOs;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesAsync()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            
            if (categories == null)
                return NoContent();

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsync(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // GET: api/Categories/5/products
        [HttpGet("{id}/products")]
        [Route("api/categories/{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsbyCategoryAsync(int id)
        {
            var products = await categoryService.GetProductsByCategoryIdAsync(id);

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryAsync(int id, [FromBody]CategoryDTO category)
        {
            if (id != category.CategoryId)
                return BadRequest();

            var categoryToUpdate = await categoryService.GetCategoryByIdAsync(id);

            if (categoryToUpdate == null)
                return NotFound();

            await categoryService.UpdateCategoryAsync(categoryToUpdate, category);

            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategoryAsync([FromBody]CategoryDTO category)
        {
            await categoryService.CreateCategoryAsync(category);

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategoryAsync(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            await categoryService.RemoveCategoryAsync(category);

            return category;
        }
    }
}
