using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UMSDatabaseContext>
{
    public UMSDatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UMSDatabaseContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=UniversityManagement;Trusted_Connection=True");

        return new UMSDatabaseContext(optionsBuilder.Options);
    }
}