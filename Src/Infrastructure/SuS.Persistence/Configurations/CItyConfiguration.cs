using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class CItyConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("CITY");

            entity.HasIndex(e => e.Name)
                .HasName("city_name_uindex")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.HasOne(d => d.Country)
                .WithMany(p => p.City)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_CITY_COUNTRY");
        }
    }
}