using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.DbMigrator;
using SM.CustomerConsumer.Application.EntitiesMapping;
using SM.CustomerConsumer.Application.Interfaces;
using SM.CustomerConsumer.Application.Services;
using SM.CustomerConsumer.Domain.Interfaces;
using SM.CustomerConsumer.Infra.Data.Repositories;

namespace SM.CustomerConsumer.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection BusConnectionService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<BusService>();
            busConfigurator.UsingRabbitMq((ctx, config) =>
            {
                var busUri = configuration.GetSection("BusConnection")["Uri"];
                var exchangeName = configuration.GetSection("BusExchange")["ExchangeName"];
                var exchangeType = configuration.GetSection("BusExchange")["ExchangeType"];
                var queueName = configuration.GetSection("BusExchange")["QueueName"];

                Console.WriteLine($"Bus connection string: {busUri}");
                Console.WriteLine($"Exchange name: {exchangeName}");
                Console.WriteLine($"Exchange type: {exchangeType}");
                Console.WriteLine($"Queue name: {queueName}");

                if (string.IsNullOrEmpty(busUri))
                    throw new InvalidOperationException(
                        "Invalid configuration: 'BusConnection:Uri' is missing in the configuration file.");

                if (string.IsNullOrEmpty(exchangeName))
                    throw new InvalidOperationException(
                        "Invalid configuration: 'BusExchange:ExchangeName' is missing in the configuration file.");

                if (string.IsNullOrEmpty(exchangeType))
                    throw new InvalidOperationException(
                        "Invalid configuration: 'BusExchange:ExchangeType' is missing in the configuration file.");

                if (string.IsNullOrEmpty(queueName))
                    throw new InvalidOperationException(
                        "Invalid configuration: 'BusExchange:QueueName' is missing in the configuration file.");

                if (!Uri.TryCreate(busUri, UriKind.Absolute, out var validatedUri))
                    throw new InvalidOperationException($"Invalid configuration: '{busUri}' is not a valid URI.");

                config.Host(new Uri(busUri));
                config.ReceiveEndpoint(queueName, e =>
                {
                    e.ConfigureConsumeTopology = false;
                    e.UseMessageRetry(r => r.Interval(5, TimeSpan.FromSeconds(10)));
                    e.Bind(exchangeName, binding =>
                    {
                        binding.ExchangeType = exchangeType;
                        binding.RoutingKey = "Consumer";


                        e.ConfigureConsumer<BusService>(ctx);
                    });
                });
            });
            
            services.AddDbContext<SmDbcontext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("SM"));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMassTransitHostedService();
        });
        return services;
    }
}