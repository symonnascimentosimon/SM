namespace SM.CustomerProducer.Application.Interfaces;

public interface IBusService
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    Task CreateCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    Task UpdateCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    Task DeleteCustomerAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    Task GetCustomerByIdAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    Task GetCustomersAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
}