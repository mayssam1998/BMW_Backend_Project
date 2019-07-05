using Microsoft.EntityFrameworkCore;
using SuS.Domain.Entities.SuSModels;
using SuS.Persistence.Extensions;
using Type = SuS.Domain.Entities.SuSModels.Type;

namespace SuS.Persistence
{
    public partial class SupplierDbContext : DbContext
    {
        public SupplierDbContext()
        {
        }

        public SupplierDbContext(DbContextOptions<SupplierDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlternateName> AlternateName { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseNpgsql("Host=deeplearning04.muc;Port=5431;Database=SUPPLIER_SERVICE_DB;Username=postgres;Password=postgres");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
