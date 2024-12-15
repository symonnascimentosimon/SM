using MassTransit;
using SM.CustomerProducer.Application.Interfaces;
using SM.Shared.DTOs;
using SM.Shared.DTOs.Customer;

namespace SM.CustomerProducer.Application.Services;

public class BusService(IPublishEndpoint publishEndpoint) : IBusService
{
    public Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        return publishEndpoint.Publish<RequestCustomerDTO>(message, ctx =>
        {
           ctx.SetRoutingKey("Sales");
        }, cancellationToken);
    }

    public Task CreateCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        return publishEndpoint.Publish<RequestCustomerDTO>(message, ctx =>
        {
            ctx.Headers.Set("Action", "Create");
            ctx.Headers.Set("Service", "CustomerService");
            ctx.SetRoutingKey("Sales");
        }, cancellationToken);
    }

    public Task UpdateCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }

    public Task GetCustomerByIdAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }

    public Task GetCustomersAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        throw new NotImplementedException();
    }
}