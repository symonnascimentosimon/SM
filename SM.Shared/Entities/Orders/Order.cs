namespace SM.Shared.Entities.Orders;

public class Order
{
    public string OrderId { get; init; } 
    public string CustomerId { get; init; } 
    public double TotalAmount { get; set; }
    public string Status { get; set; } 
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    public Customer Customer { get; set; } = new Customer();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}