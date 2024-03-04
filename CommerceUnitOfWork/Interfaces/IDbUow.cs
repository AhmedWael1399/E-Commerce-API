using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CommerceUnitOfWork.Interfaces
{
    public interface IDbUow
    {
        CommerceDbContext GetCommerceDbContext();
        void SaveChanges();
    }
}
