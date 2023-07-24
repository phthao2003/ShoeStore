using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Data.Entities;

namespace ShoeStore.Data.Configurations;

public class PromotionImageEntityTypeConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Path)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductImages)
            .HasForeignKey(x => x.ProductId);
    }
}