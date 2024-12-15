using SM.Shared.Entities.Orders;

namespace SM.CustomerConsumer.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<Customer> DeleteCustomerAsync(Customer customer);
    Task<Customer> GetCustomerByIdAsync(Customer customer);
    Task<List<Customer>> GetCustomersAsync();
    Task<bool>CustomerExistsAsync(string customerId, string email, string cpf = null);
}