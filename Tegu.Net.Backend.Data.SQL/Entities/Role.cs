using System.ComponentModel.DataAnnotations.Schema;

namespace Tegu.Net.Backend.Data.SQL.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    #region Navigation - UserRoles

    [InverseProperty(nameof(UserRole.Role))]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    #endregion
}