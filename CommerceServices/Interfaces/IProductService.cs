using Models;

namespace CommerceServices.InterfacesMapper
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        void CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProduct(int id);
        bool ProductExists(int productId);
    }
}
