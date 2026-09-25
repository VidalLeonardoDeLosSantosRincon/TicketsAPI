using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Users;

public class User
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Active { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? LastLoginAt { get; set; }

    //foreignKeys
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public Role? Role { get; set; }
}
