using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.ToTable("COUNTRY");

            entity.HasIndex(e => e.Iso2)
                .HasName("country_iso2_uindex")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Iso2)
                .HasColumnName("ISO2")
                .HasMaxLength(255);

            entity.Property(e => e.Iso3)
                .HasColumnName("ISO3")
                .HasMaxLength(255);

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

            entity.HasOne(d => d.Region)
                .WithMany(p => p.Country)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("fk_COUNTRY_REGION");
        }
    }
}