using Models;


namespace DatabaseServices.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id);
        bool ProductExists(int productId);
    }
}
