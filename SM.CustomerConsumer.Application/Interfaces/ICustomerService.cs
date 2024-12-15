using SM.Shared.DTOs.Customer;

namespace SM.CustomerConsumer.Application.Interfaces;

public interface ICustomerService
{
    Task<ResponseCustomerDTO> CreateCustomerAsync(RequestCustomerDTO requestCustomer);
    Task<ResponseCustomerDTO> UpdateCustomerAsync(RequestCustomerDTO requestCustomer);
    Task<ResponseCustomerDTO> DeleteCustomerAsync(RequestCustomerDTO requestCustomer);
    Task<ResponseCustomerDTO> GetCustomerByIdAsync(RequestCustomerDTO requestCustomer);
    Task<List<ResponseCustomerDTO>> GetCustomersAsync();
    Task<bool>CustomerExistsAsync(string customerId, string email, string cpf);
    Task<dynamic> Switch<T>(dynamic  requestCustomer, string action); 
}