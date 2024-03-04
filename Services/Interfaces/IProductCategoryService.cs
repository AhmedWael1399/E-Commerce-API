using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServices.Interfaces
{
     public interface IProductCategoryService
    {
        Task<List<Product>> GetProductCategoriesById(Categories categories);
    }
}
