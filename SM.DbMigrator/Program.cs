using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SM.DbMigrator;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<SmDbcontext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("SM")));
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SmDbcontext>();
    context.Database.Migrate();
    Console.WriteLine("Migrações aplicadas com sucesso!");
}

host.Run();