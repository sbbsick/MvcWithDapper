using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWithDapper.Models;

[Table("Bank")]
public class Bank : Entity
{
    public string? Name { get; set; }
}