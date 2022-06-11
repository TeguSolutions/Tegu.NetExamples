using Microsoft.AspNetCore.Mvc;
using Tegu.Net.Backend.WebApi.Classic.Managers;
using Tegu.Net.Shared.BackendClassic;
using Tegu.Net.Shared.Domains.Authentication.Requests;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Controllers;

[ApiController]
[Route(ApiRoutes.Authentication.ControllerRouteTemplate)]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly AuthenticationManager _authenticationManager;

    public AuthenticationController(ILogger<AuthenticationController> logger, AuthenticationManager authenticationManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var result = await _authenticationManager.Authenticate(request);
        return result.IsSuccess() ? Ok(result) : BadRequest(result);
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken(AuthRefreshTokenRequest request)
    {
        var result = await _authenticationManager.RefreshToken(request);
        return result.IsSuccess() ? Ok(result) : BadRequest(result);
    }
}