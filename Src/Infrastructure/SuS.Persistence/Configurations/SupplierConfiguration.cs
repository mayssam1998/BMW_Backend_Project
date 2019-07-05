using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.ToTable("SUPPLIER");

            entity.HasIndex(e => e.Number)
                .HasName("supplier_number_uindex")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.Property(e => e.Number)
                .HasColumnName("NUMBER")
                .HasMaxLength(255);

            entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Supplier)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("supplier_type_id_fk");
        }
    }
}