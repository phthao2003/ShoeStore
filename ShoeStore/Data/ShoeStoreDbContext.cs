using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.Entities;

namespace ShoeStore.Data;

public class ShoeStoreDbContext : DbContext
{
    public ShoeStoreDbContext(DbContextOptions<ShoeStoreDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        base.OnConfiguring(optionsBuilder);
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("ShoeStoreContext");
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoeStoreDbContext).Assembly);
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
}