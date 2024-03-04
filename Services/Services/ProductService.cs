using DatabaseContext;
using DatabaseContext.Repository;
using DatabaseServices.Interfaces;
using Models;


namespace DatabaseServices.Services
{
    public class ProductService : IProductService
    {
        private readonly CommerceDbContext _context;
        private readonly ProductRepository _repository;
        public ProductService(CommerceDbContext context)
        {
            _context = context;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }
    }
}
