namespace MvcWithDapper.Models;

public class CreditCard : Payment
{
    public string? CardNumber { get; set; }
    public DateTime CardExpiration { get; set; }
    public string? CardSecurityCode { get; set; }
}