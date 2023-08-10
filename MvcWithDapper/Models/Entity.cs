namespace MvcWithDapper.Models;

public class Entity
{
    protected Guid Id { get; set; } = Guid.NewGuid();
}