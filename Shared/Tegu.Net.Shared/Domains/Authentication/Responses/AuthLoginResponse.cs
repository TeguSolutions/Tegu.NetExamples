﻿namespace Tegu.Net.Shared.Domains.Authentication.Responses;

public class AuthLoginResponse
{
    public AuthLoginResponse(string jwtToken, string refreshToken)
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }

    public string JwtToken { get; }
    public string RefreshToken { get; }
}