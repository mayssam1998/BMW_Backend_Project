using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> entity)
        {
            entity.ToTable("STREET");

            entity.HasIndex(e => e.Name)
                .HasName("street_name_uindex")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CityId).HasColumnName("CITY_ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);

            entity.HasOne(d => d.City)
                .WithMany(p => p.Street)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("fk_STREET_CITY");
        }
    }
}