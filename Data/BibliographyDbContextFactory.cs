using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BibliographyGenerationApp.Data;

public class BibliographyDbContextFactory : IDesignTimeDbContextFactory<BibliographyDbContext>
{
    public BibliographyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        var optionsBuilder = new DbContextOptionsBuilder<BibliographyDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new BibliographyDbContext(optionsBuilder.Options);
    }
}
