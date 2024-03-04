using CommerceUnitOfWork.Interfaces;
using DatabaseContext;
using DbFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Tls;
using System.Configuration;

namespace CommerceUnitOfWork
{
    public class DbUoW : IDbUow
    {
        private readonly IDbFactory _context;
        private readonly IConfiguration _configuration;
        public DbUoW(IDbFactory context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public CommerceDbContext GetCommerceDbContext()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return _context.CreateCommerceDbContext(connectionString);
        }

        public void SaveChanges()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            _context.CreateCommerceDbContext(connectionString).SaveChanges();
        }
    }
}
