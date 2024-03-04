using CommerceUnitOfWork.Interfaces;
using DatabaseContext.Interfaces;
using DbFactory.Interfaces;
using Models;


namespace DatabaseContext.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CommerceDbContext commerceContext;
        public ProductRepository(IDbUow unitOfWork)
        {
            commerceContext = unitOfWork.GetCommerceDbContext();
        }
        public Product CreateProduct(Product product)
        {
            commerceContext.Products.Add(product);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            commerceContext.Products.Update(product);
            return product;
        }

        public void DeleteProduct(int productId)
        {
            var product = commerceContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                commerceContext.Products.Remove(product);
            }
        }

        public ICollection<Product> GetProducts()
        {
            return commerceContext.Products.ToList();
        }


        public Product GetProduct(int id)
        {
            return commerceContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool ProductExists(int productId)
        {
            return commerceContext.Products.Any(p => p.Id == productId);
        }
    }
}


