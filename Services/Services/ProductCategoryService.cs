using DatabaseContext;
using DatabaseServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServices.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly CommerceDbContext _context;
        public ProductCategoryService(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductCategoriesById(Categories categories)
        {
            var productCategories = await _context.ProductCategories
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
