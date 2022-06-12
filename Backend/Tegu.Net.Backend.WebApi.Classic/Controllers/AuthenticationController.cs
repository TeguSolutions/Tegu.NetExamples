using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tegu.Net.Backend.WebApi.Classic.Managers;
using Tegu.Net.Backend.WebApi.Classic.Services;
using Tegu.Net.Shared.BackendClassic;
using Tegu.Net.Shared.Domains.Authentication.Requests;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Controllers;

[Authorize]
[ApiController]
[Route(ApiRoutes.Authentication.ControllerRouteTemplate)]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly SecurityContextService _securityContextService;
    private readonly AuthenticationManager _authenticationManager;

    public AuthenticationController(ILogger<AuthenticationController> logger,
        SecurityContextService securityContextService, AuthenticationManager authenticationManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _securityContextService =
            securityContextService ?? throw new ArgumentNullException(nameof(securityContextService));
        _authenticationManager =
            authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Authentication.Login)]
    public async Task<IActionResult> Login(AuthLoginRequest request)
    {
        var result = await _authenticationManager.Authenticate(request);
        return result.IsSuccess() ? Ok(result) : BadRequest(result);
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.Authentication.RefreshToken)]
    public async Task<IActionResult> RefreshToken(AuthRefreshTokenRequest request)
    {
        var securityContext = _securityContextService.GetSecurityContext(Request);
        var result = await _authenticationManager.RefreshToken(securityContext, request);
        return result.IsSuccess() ? Ok(result) : BadRequest(result);
    }
}