using CommerceServices.InterfacesMapper;
using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using Models;

namespace CommerceServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDbUow _unitOfWork;
        public ProductService(IDbUow unitOfWork, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
            _unitOfWork.SaveChanges();
        }

        public Product UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            _unitOfWork.SaveChanges();
            return product;
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
            _unitOfWork.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public ICollection<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public bool ProductExists(int productId)
        {
            return _productRepository.ProductExists(productId);
        }
    }
}
