using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Helper.Extensions;

namespace Tegu.Net.Backend.Shared.Services.Authorization;

public class TokenService
{
    private readonly ILogger<TokenService> _logger;
    private readonly JwtSettings _jwtSettings;

    public TokenService(ILogger<TokenService> logger, IOptions<JwtSettings> appSettings)
    {
        _logger = logger;
        _jwtSettings = appSettings.Value;
    }

    public string GenerateJwtToken(User user)
    {
        try
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            });

            foreach (var usr in user.UserRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, usr.Role.Name));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,

                // No whitespaces!!
                Issuer = "TeguDotNetExamplesBackend",
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.JwtTokenTTLMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            throw new Exception(e.Message);
        }
    }

    public (bool isValid, Guid? userId) ValidateJwtToken(string token)
    {
        if (token == null)
            return (false, null);

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return (true, userId);
        }
        catch (Exception e)
        {
            // return null if validation fails
            _logger.LogError(e);
            return (false, null);
        }
    }

    public RefreshToken GenerateRefreshToken(Guid userId)
    {
        // generate token that is valid for 7 days
        var secureRandomNumberGenerator =  RandomNumberGenerator.Create();
        var randomBytes = new byte[64];
        secureRandomNumberGenerator.GetBytes(randomBytes);
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(randomBytes),
            ExpiresAt = DateTimeOffset.UtcNow.AddDays(_jwtSettings.RefreshTokenTTLDays),
            CreatedAt = DateTimeOffset.UtcNow,
            UserId = userId
        };

        return refreshToken;
    }
}
