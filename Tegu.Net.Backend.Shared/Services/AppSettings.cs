namespace Tegu.Net.Backend.Shared.Services;

public class AppSettings
{
    public string Secret { get; set; }

    // JwtToken Time to Live (in minutes)
    public int JwtTokenTTL { get; set; }

    // RefreshToken Time to Live (in days)
    public int RefreshTokenTTL { get; set; }
}
