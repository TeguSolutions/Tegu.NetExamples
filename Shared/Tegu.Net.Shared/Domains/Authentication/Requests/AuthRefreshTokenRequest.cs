namespace Tegu.Net.Shared.Domains.Authentication.Requests;

public class AuthRefreshTokenRequest
{
    public AuthRefreshTokenRequest(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public string RefreshToken { get; }
}
