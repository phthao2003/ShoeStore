using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Data.Entities;

namespace ShoeStore.Data.Configurations;

public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => new {x.ProductId, x.CategoryId});

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductCategories)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ProductCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}