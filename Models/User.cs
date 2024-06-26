using System.ComponentModel.DataAnnotations;
using APP2EFCore.Enums;

namespace APP2EFCore;

public class User
{

    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required UserTypes Type { get; set; }

    public virtual List<Sale> Sales { get; set; }
}