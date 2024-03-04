using Models;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceServices.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<Product>> GetProductCategories(Categories categories);
        Task<List<Product>> GetProductCategoriesById(Categories categories);
        ProductDto ToProductDto(Product product);
    }
}
