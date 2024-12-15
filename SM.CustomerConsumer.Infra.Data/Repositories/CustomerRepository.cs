using Microsoft.EntityFrameworkCore;
using SM.CustomerConsumer.Domain.Interfaces;
using SM.DbMigrator;
using SM.Shared.Entities.Orders;

namespace SM.CustomerConsumer.Infra.Data.Repositories;

public class CustomerRepository(SmDbcontext context) : ICustomerRepository
{
    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        try
        {
            bool exist = await CustomerExistsAsync(customer.CustomerId, customer.Email, customer.Cpf);

            if (exist)
                throw new InvalidOperationException("O Consumidor já é cadastrado.");
            
            customer.CustomerId = Guid.NewGuid().ToString();
            customer.CreateDate = DateTime.Now;
            
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            
            return customer;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Failed to insert the entity into the repository: {e.Message}");
        }
    }


public Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> DeleteCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetCustomerByIdAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<List<Customer>> GetCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CustomerExistsAsync(string customerId, string email, string cpf = null)
    {
        return await  context.Customers.AnyAsync(c => c.CustomerId == customerId || c.Email == email || c.Cpf == cpf);
    }
}