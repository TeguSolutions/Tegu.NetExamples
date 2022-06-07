namespace Tegu.Net.Backend.Data.SQL.Entities;

public class UserRole
{
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    
    public int RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; }
}