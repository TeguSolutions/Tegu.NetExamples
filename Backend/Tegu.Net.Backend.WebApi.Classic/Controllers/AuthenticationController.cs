using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Shared.BackendClassic;

namespace Tegu.Net.Backend.WebApi.Classic.Controllers;

[ApiController]
[Route(ApiRoutes.Authentication.ControllerRouteTemplate)]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


}