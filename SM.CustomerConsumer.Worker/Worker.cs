using MassTransit;

namespace SM.CustomerConsumer.Worker;

public class Worker(IBusControl busControl, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Starting RabbitMQ service");

        await Task.Delay(-1, stoppingToken);
        
        logger.LogInformation("Stopping RabbitMQ service");
        await busControl.StopAsync(stoppingToken);
    }
}