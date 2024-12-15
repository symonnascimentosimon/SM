using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.CustomerProducer.Application.Interfaces;
using SM.CustomerProducer.Application.Services;
using SM.Shared.DTOs;
using SM.Shared.DTOs.Customer;


namespace SM.CustomerProducer.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection BusConnectionService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((ctx, config) =>
            {
                var busUri = configuration.GetSection("BusConnection")["Uri"];
                var exchangeName = configuration.GetSection("BusExchange")["ExchangeName"];
                var exchangeType = configuration.GetSection("BusExchange")["ExchangeType"];
                var queueName = configuration.GetSection("BusExchange")["QueueName"];

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


                Console.WriteLine($"Bus connection string: {busUri}");
                Console.WriteLine($"Exchange name: {exchangeName}");
                Console.WriteLine($"Exchange type: {exchangeType}");
                Console.WriteLine($"Queue name: {queueName}");
                
                config.Host(new Uri(busUri));
                config.Message<RequestCustomerDTO>(e => { e.SetEntityName(exchangeName); });

                //OrderCreate
                config.Publish<RequestCustomerDTO>(l => { l.ExchangeType = exchangeType; });
               // config.ConfigureEndpoints(ctx);
            });
            services.AddTransient<IBusService, BusService>();
            services.AddMassTransitHostedService();
        });
        return services;
    }
}