using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SM.DbMigrator;

public class ContextFactory : IDesignTimeDbContextFactory<SmDbcontext>
{
    public SmDbcontext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SmDbcontext>();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SM"), o => o.EnableRetryOnFailure());

        return new SmDbcontext(optionsBuilder.Options);
    }
}