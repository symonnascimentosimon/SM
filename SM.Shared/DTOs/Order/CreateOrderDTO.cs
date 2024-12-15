namespace SM.Shared.DTOs;

public class CreateOrderDTO
{
    public string CustomerId { get; set; } = string.Empty;
    public List<CreateOrderItemDTO> OrderItems { get; set; } = new List<CreateOrderItemDTO>();
}