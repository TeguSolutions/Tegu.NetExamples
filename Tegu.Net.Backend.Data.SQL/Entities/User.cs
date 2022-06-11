namespace Tegu.Net.Backend.Data.SQL.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string LastName { get; set; }

    [EmailAddress]
    [Required(AllowEmptyStrings = false)]
    [StringLength(50)]
    public string Email { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string PasswordHash { get; set; }

    #region Navigation - UserRole

    [InverseProperty(nameof(UserRole.User))]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    #endregion

    #region Navigation - RefreshTokens

    [InverseProperty(nameof(RefreshToken.User))]
    public ICollection<RefreshToken> RefreshTokens { get; set; }

    #endregion

    #region Navigation - Tegus

    [InverseProperty(nameof(OwnedTegu.Owner))]
    public virtual ICollection<OwnedTegu> OwnedTegus { get; set; }

    #endregion
}