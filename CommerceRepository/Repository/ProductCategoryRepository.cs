using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using DbFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;


namespace DatabaseContext.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly CommerceDbContext commerceContext;
        public ProductCategoryRepository(IDbUow unitOfWork)
        {
            commerceContext = unitOfWork.GetCommerceDbContext();
        }
        public async Task<List<Product>> GetProductCategories(Categories categories)
        {
            var productCategories = await commerceContext.ProductCategories.Where(c => c.CategoryId == categories.Id)
                .Select(product => new Product
                {
                    Id = product.ProductId,
                    Name = product.Product.Name

                }).ToListAsync();

            return productCategories;
        }
        public async Task<List<Product>> GetProductCategoriesById(Categories categories)
        {
            var productCategories = await commerceContext.ProductCategories
                .Where(pc => pc.CategoryId == categories.Id)
                .Select(product => new Product
                {
                    Id = product.Product.Id,
                    Name = product.Product.Name
                })
                .ToListAsync();

            return productCategories;
        }
    }
}
