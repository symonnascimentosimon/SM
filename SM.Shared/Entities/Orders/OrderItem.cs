namespace SM.Shared.Entities.Orders;

public class OrderItem
{
    public string OrderItemId { get; init; } 
    public string ProductId { get; init; } 
    public string OrderId { get; init; } 
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public decimal TotalPrice => UnitPrice * Quantity;

    
    public Order Order { get; set; } = new Order();
    public Product Product { get; set; } = new Product();
}