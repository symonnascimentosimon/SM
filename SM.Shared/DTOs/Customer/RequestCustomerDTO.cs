using System.Text.Json.Serialization;

namespace SM.Shared.DTOs.Customer;

public class RequestCustomerDTO
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf  { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}