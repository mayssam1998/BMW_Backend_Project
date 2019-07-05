using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity
        )
        {
            entity.ToTable("BRANCH");

            entity.HasIndex(e => new { e.Number, e.SupplierId })
                .HasName("UQ_NR_ZA")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.Property(e => e.Number)
                .HasColumnName("NUMBER")
                .HasMaxLength(255);

            entity.Property(e => e.PostCode)
                .HasColumnName("POST_CODE")
                .HasMaxLength(255);

            entity.Property(e => e.StreetId).HasColumnName("STREET_ID");

            entity.Property(e => e.SupplierId).HasColumnName("SUPPLIER_ID");

            entity.HasOne(d => d.Street)
                .WithMany(p => p.Branch)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("fk_BRANCH_STREET");

            entity.HasOne(d => d.Supplier)
                .WithMany(p => p.Branch)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("fk_BRANCH_SUPPLIER");
        }
    }
}