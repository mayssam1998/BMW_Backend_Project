using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            entity.ToTable("REGION");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);
        }
    }
}