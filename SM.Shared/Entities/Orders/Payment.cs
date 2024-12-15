namespace SM.Shared.Entities.Orders;

public class Payment
{
    public string PaymentId { get; init; } = string.Empty;
    public string OrderId { get; init; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public Order Order { get; set; } = new Order();
}