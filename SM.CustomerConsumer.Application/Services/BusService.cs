using MassTransit;
using SM.CustomerConsumer.Application.Interfaces;
using SM.Shared.DTOs.Customer;


namespace SM.CustomerConsumer.Application.Services;

public class BusService(ICustomerService customerService) : IConsumer<RequestCustomerDTO>
{
    public async Task Consume(ConsumeContext<RequestCustomerDTO> context)
    {
        try
        {
            var action = context.Headers.Get<string>("Action");
            var message = context.Message;
            
            var response =  await customerService.Switch<RequestCustomerDTO>(message, action);
            
            if (string.IsNullOrEmpty(response.CustomerId))
                await context.ConsumeCompleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
        }
    }
}