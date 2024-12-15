using AutoMapper;
using SM.Shared.DTOs.Customer;
using SM.Shared.Entities.Orders;

namespace SM.CustomerConsumer.Application.EntitiesMapping;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Customer, RequestCustomerDTO>().ReverseMap();
        CreateMap<Customer, ResponseCustomerDTO>().ReverseMap();
    }
}