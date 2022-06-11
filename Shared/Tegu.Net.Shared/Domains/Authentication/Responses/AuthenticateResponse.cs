namespace Tegu.Net.Shared.Domains.Authentication.Responses;

public class AuthenticateResponse
{
    public AuthenticateResponse(string jwtToken, string refreshToken)
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }

    public string JwtToken { get; }
    public string RefreshToken { get; }
}