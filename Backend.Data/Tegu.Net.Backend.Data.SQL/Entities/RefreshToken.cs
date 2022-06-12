namespace Tegu.Net.Backend.Data.SQL.Entities;

public class RefreshToken
{
    [Key]
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    [Required]
    public string Token { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(Entities.User.RefreshTokens))]
    public virtual User User { get; set; }

    [NotMapped]
    public bool IsExpired => DateTimeOffset.UtcNow >= ExpiresAt;
}