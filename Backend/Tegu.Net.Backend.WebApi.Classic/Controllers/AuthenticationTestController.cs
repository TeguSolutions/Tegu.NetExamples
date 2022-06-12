using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tegu.Net.Shared.BackendClassic;

namespace Tegu.Net.Backend.WebApi.Classic.Controllers;

[Authorize]
[ApiController]
[Route(ApiRoutes.AuthenticationTest.ControllerRouteTemplate)]
public class AuthenticationTestController : ControllerBase
{
    [HttpPost(ApiRoutes.AuthenticationTest.AuthBase)]
    public IActionResult AuthBase(AuthTestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
            return BadRequest("Invalid model?");

        return Ok("Base Authentication was successfull!");
    }

    [Authorize(Roles = "Tegu")]
    [HttpPost(ApiRoutes.AuthenticationTest.AuthRoleTegu)]
    public IActionResult AuthRoleTegu(AuthTestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
            return BadRequest("Invalid model?");

        return Ok("Role Based Authentication as Tegu was successfull!");
    }

    [Authorize(Roles = "Client")]
    [HttpPost(ApiRoutes.AuthenticationTest.AuthRoleClient)]
    public IActionResult AuthRoleClient(AuthTestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
            return BadRequest("Invalid model?");

        return Ok("Role Based Authentication as Client was successfull!");
    }

    [Authorize(Roles = "Tegu,Client")]
    [HttpPost(ApiRoutes.AuthenticationTest.AuthRoleAny)]
    public IActionResult AuthRoleAny(AuthTestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
            return BadRequest("Invalid model?");

        return Ok("Role Based Authentication was successfull!");
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.AuthenticationTest.AuthAnonymous)]
    public IActionResult AuthAnonymous(AuthTestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
            return BadRequest("Invalid model?");

        return Ok("Anonymous check was successfull!");
    }
}



#region Helper Classes

public class AuthTestRequest
{
    public AuthTestRequest(string message)
    {
        Message = message;
    }

    public string Message { get; }
}

#endregion