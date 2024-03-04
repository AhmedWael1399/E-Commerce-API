using CommerceServices.Interfaces;
using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using Models;
using Models.Dtos;

namespace CommerceServices.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public Task<List<Product>> GetProductCategories(Categories categories)
        {
            return _productCategoryRepository.GetProductCategories(categories);
        }

        public Task<List<Product>> GetProductCategoriesById(Categories categories)
        {
            return _productCategoryRepository.GetProductCategoriesById(categories);
        }

        public ProductDto ToProductDto(Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name
            };
        }
    }
}
