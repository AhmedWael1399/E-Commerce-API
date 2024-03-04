using Models;

namespace DatabaseContext.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProduct(int id);
        bool ProductExists(int productId);
    }
}
