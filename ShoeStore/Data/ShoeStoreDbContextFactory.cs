using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoeStore.Data;

public class ShoeStoreDbContextFactory : IDesignTimeDbContextFactory<ShoeStoreDbContext>
{
    public ShoeStoreDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ShoeStoreContext");
        var optionsBuilder = new DbContextOptionsBuilder<ShoeStoreDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new ShoeStoreDbContext(optionsBuilder.Options);
    }
}