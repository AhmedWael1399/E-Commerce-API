using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<Product>> GetProductCategories(Categories categories);
        Task<List<Product>> GetProductCategoriesById(Categories categories);
    }
}
