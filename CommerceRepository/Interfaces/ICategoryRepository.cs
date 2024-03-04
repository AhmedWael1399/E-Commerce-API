using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Categories> GetCategories();
        void CreateCategory(Categories category);
        Categories UpdateCategory(Categories category);
        void DeleteCategory(int categoryId);
        Categories GetCategory(int categoryId);
        bool CategoriesExist(int categoryId);
    }
}
