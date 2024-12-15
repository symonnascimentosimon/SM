namespace SM.Shared.Entities.Orders;

public class Customer
{
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf  { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}