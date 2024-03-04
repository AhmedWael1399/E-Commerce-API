using CommerceServices.InterfacesMapper;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace SolidCommerceAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound($"Product {id} doesn't exist!!");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(string productName)
        {
            Product product = new() { Name = productName };
            _productService.CreateProduct(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product productName)
        {
            var p = _productService.ProductExists(id);
            if (!p)
            {
                return NotFound($"Product Id {productName.Id} doesn't exist!!");
            }
            var product = _productService.UpdateProduct(productName);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var p = _productService.ProductExists(id);
            if (!p)
            {
                return NotFound($"Product Id {id} doesn't exist!!");
            }
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
