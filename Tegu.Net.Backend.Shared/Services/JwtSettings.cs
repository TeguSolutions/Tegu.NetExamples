namespace Tegu.Net.Backend.Shared.Services;

public class JwtSettings
{
    public string Secret { get; set; }

    // JwtToken Time to Live (in minutes)
    public int JwtTokenTTLMinutes { get; set; }

    // RefreshToken Time to Live (in days)
    public int RefreshTokenTTLDays { get; set; }
}
