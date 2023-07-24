using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Data.Entities;

namespace ShoeStore.Data.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.NameNormalization)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.Slug)
            .HasMaxLength(500);
    }
}