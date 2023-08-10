namespace MvcWithDapper.Models;

public class CreditCard : Payment
{
    public string? CardNumber { get; set; }
    public DateTime Expiration { get; set; }
    public string? SecurityCode { get; set; }
}