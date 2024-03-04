using CommerceServices.Interfaces;
using DatabaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace SolidCommerceAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound($"Category {id} doesn't exist!!");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(string categoryType)
        {
            Categories category = new() { Type = categoryType };
            _categoryService.CreateCategory(category);
            return Ok(category);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Categories categoryType)
        {
            var c = _categoryService.CategoriesExist(id);
            if (!c)
            {
                return NotFound($"Category Id {categoryType.Id} doesn't exist!!");
            }
            var category = _categoryService.UpdateCategory(categoryType);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            var c = _categoryService.CategoriesExist(id);
            if (!c)
            {
                return NotFound($"Category Id {id} doesn't exist!!");
            }
            _categoryService.DeleteCategory(id);
            return Ok();
        }


    }
}
