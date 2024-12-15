namespace SM.Shared.DTOs;

public class CreateOrderItemDTO
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}