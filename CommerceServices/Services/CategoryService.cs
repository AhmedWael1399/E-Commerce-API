using CommerceServices.Interfaces;
using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using Models;

namespace CommerceServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDbUow _unitOfWork;
        public CategoryService(IDbUow unitOfWork, ICategoryRepository repository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = repository;
        }

        public bool CategoriesExist(int categoryId)
        {
            return _categoryRepository.CategoriesExist(categoryId);
        }

        public void CreateCategory(Categories category)
        {
            _categoryRepository.CreateCategory(category);
            _unitOfWork.SaveChanges();
        }

        public Categories UpdateCategory(Categories category)
        {
            _categoryRepository.UpdateCategory(category);
            _unitOfWork.SaveChanges();
            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
            _unitOfWork.SaveChanges();
        }

        public ICollection<Categories> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public Categories GetCategory(int categoryId)
        {
            return _categoryRepository.GetCategory(categoryId);
        }

       
    }
}
