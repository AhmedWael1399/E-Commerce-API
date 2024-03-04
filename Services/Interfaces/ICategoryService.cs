using Models;

namespace DatabaseServices.Interfaces
{
    public interface ICategoryService
    {
        Categories GetCategory(int categoryId);
        bool CategoriesExist(int categoryId);
    }
}
