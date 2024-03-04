using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DbFactory.Interfaces
{
    public interface IDbFactory
    {
        CommerceDbContext CreateCommerceDbContext(string connectionString);
    }
}
