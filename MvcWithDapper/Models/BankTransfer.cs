namespace MvcWithDapper.Models;

public class BankTransfer : Payment
{
    public string? AccountNumber { get; set; }
    public Guid BankId { get; set; }
    public Bank? Bank { get; set; }
}