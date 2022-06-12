using System.Diagnostics;
using Tegu.Net.Backend.Shared.Helpers;
using Tegu.Net.Backend.Shared.Services.Authorization;

namespace Tegu.Net.Backend.WebApi.Classic.Services;

public class SecurityContextService
{
    private readonly ILogger<SecurityContextService> _logger;
    private readonly TokenService _tokenService;

    public SecurityContextService(ILogger<SecurityContextService> logger, TokenService tokenService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    public SecurityContext GetSecurityContext(HttpRequest request)
    {
        try
        {
            var bearer = request.Headers.Authorization.FirstOrDefault(q => q.StartsWith("Bearer"));
            if (string.IsNullOrWhiteSpace(bearer))
                return SecurityContext.Empty;

            var jwt = bearer.Split(" ").Last();

            var (isValid, userId) = _tokenService.ValidateJwtToken(jwt);
            if (!isValid)
                return SecurityContext.Empty;

            return new SecurityContext(userId.Value);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return SecurityContext.Empty;
        }

    }
}