using Microsoft.EntityFrameworkCore;
using SuS.Persistence.Infrastructure;

namespace SuS.Persistence
{
    public class SupplierDbContextFactory : DesignTimeDbContextFactoryBase<SupplierDbContext>
    {
        protected override SupplierDbContext CreateNewInstance(DbContextOptions<SupplierDbContext> options)
        {
            return new SupplierDbContext(options);
        }
    }
}
