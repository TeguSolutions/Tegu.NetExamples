namespace Tegu.Net.Shared.Domains.Authentication.Requests;

public class AuthRefreshTokenRequest
{
    public AuthRefreshTokenRequest(Guid userId, string refreshToken)
    {
        UserId = userId;
        RefreshToken = refreshToken;
    }

    public Guid UserId { get; }
    public string RefreshToken { get; }
}
