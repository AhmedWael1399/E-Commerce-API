using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using DbFactory.Interfaces;
using Models;


namespace DatabaseContext.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CommerceDbContext commerceContext;
        public CategoryRepository(IDbUow unitOfWork)
        {
            commerceContext = unitOfWork.GetCommerceDbContext();
        }
        public void CreateCategory(Categories category)
        {
            commerceContext.Categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = commerceContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                commerceContext.Categories.Remove(category);
            }
        }

        public ICollection<Categories> GetCategories()
        {
            return commerceContext.Categories.ToList();
        }
        public bool CategoriesExist(int categoryId)
        {
            return commerceContext.Categories.Any(c => c.Id == categoryId);
        }

        public Categories GetCategory(int categoryId)
        {
            return commerceContext.Categories.FirstOrDefault(c => c.Id == categoryId);
        }
        public Categories UpdateCategory(Categories category)
        {
            commerceContext.Categories.Update(category);
            return category;
        }
    }
}
