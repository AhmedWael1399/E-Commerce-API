using DatabaseContext;
using DbFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbFactory.DbContextFactory
{
    public class CommerceDbContextFactory : IDbFactory
    {
        private CommerceDbContext commerceInstance;

        public CommerceDbContext CreateCommerceDbContext(string connectionString)
        {
            if (commerceInstance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CommerceDbContext>();
                var serviceVersion = new MySqlServerVersion(new Version(8, 0, 36));
                optionsBuilder.UseMySql(connectionString, serviceVersion);
                commerceInstance = new CommerceDbContext(optionsBuilder.Options);
            }
            return commerceInstance;
        }
    }
}
