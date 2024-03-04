using DatabaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using CommerceServices.Interfaces;

namespace SolidCommerceAPI.Controllers
{
    [Route("api/productController")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService, ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var categories = _categoryService.GetCategories();
            var products = new List<Product>();

            foreach (var category in categories)
            {
                var categoryProductCategories = await _productCategoryService.GetProductCategories(category);
                products.AddRange(categoryProductCategories.Select(product => new Product
                {
                    Id = product.Id,
                    Name = product.Name
                }));
            } 
            
            var productsDto = products.Select(p => _productCategoryService.ToProductDto(p)).ToList();

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoriesById(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound($"Category Id {id} doesn't exist");
            }
            else
            {
                var categoryProductCategories = await _productCategoryService.GetProductCategories(category);
                if (categoryProductCategories.Count == 0)
                {
                    return NotFound($"Product Id {id} doesn't exist!!");
                }
                var productsDto = categoryProductCategories.Select(p => _productCategoryService.ToProductDto(p)).ToList();
                return Ok(productsDto);
            }
        }



    }
}
