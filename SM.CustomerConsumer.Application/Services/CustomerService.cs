using AutoMapper;
using SM.CustomerConsumer.Application.Interfaces;
using SM.CustomerConsumer.Domain.Interfaces;
using SM.Shared.DTOs.Customer;
using SM.Shared.Entities.Orders;

namespace SM.CustomerConsumer.Application.Services;

public class CustomerService(ICustomerRepository cusromerRepository, IMapper mapper) : ICustomerService
{
    public async Task<ResponseCustomerDTO> CreateCustomerAsync(RequestCustomerDTO requestCustomer)
    {
        try
        {
            var customer = mapper.Map<Customer>(requestCustomer);
            var response = await cusromerRepository.CreateCustomerAsync(customer);

            return mapper.Map<ResponseCustomerDTO>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Task<ResponseCustomerDTO> UpdateCustomerAsync(RequestCustomerDTO requestCustomer)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseCustomerDTO> DeleteCustomerAsync(RequestCustomerDTO requestCustomer)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseCustomerDTO> GetCustomerByIdAsync(RequestCustomerDTO requestCustomer)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResponseCustomerDTO>> GetCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CustomerExistsAsync(string customerId, string email, string cpf)
    {
        if (string.IsNullOrEmpty(customerId))
            throw new ArgumentNullException($"{nameof(customerId)} cannot be null or empty.");
        
        return cusromerRepository.CustomerExistsAsync(customerId, email, cpf);
    }

    public async Task<dynamic> Switch<T>(dynamic requestCustomer, string action)
    {
        try
        {
            switch (action)
            {
                case "Create":
                    return await CreateCustomerAsync(requestCustomer);
                case "Update":
                    //   await UpdateCustomerAsync(context);
                    break;
                case "Delete":
                    //     await DeleteCustomerAsync(context);
                    break;
                case "GetById":
                    //      await GetCustomerByIdAsync(context);
                    break;
                case "GetAll":
                    //     await GetCustomersAsync(context);
                    break;
                default:
                    throw new InvalidOperationException($"Ação desconhecida: {action}");
            }
            return "Error";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}