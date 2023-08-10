namespace MvcWithDapper.Models;

public class Payment : Entity
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}