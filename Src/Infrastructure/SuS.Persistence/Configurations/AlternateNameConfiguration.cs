using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class AlternateNameConfiguration : IEntityTypeConfiguration<AlternateName>
    {
        public void Configure(EntityTypeBuilder<AlternateName> entity
        )
        {
            entity.ToTable("ALTERNATE_NAME");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.Property(e => e.SupplierId).HasColumnName("SUPPLIER_ID");

            entity.HasOne(d => d.Supplier)
                .WithMany(p => p.AlternateName)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("fk_ALTERNATE_NAME_SUPPLIER");
        }
    }
}
