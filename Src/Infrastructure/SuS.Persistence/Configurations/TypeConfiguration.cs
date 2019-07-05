using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Persistence.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> entity)
        {
            entity.ToTable("TYPE");

            entity.HasIndex(e => e.Name)
                .HasName("type_name_uindex")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(255);
        }
    }
}