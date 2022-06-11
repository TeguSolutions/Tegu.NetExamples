using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Backend.Shared.Services.Authorization;
using Tegu.Net.Shared.Domains.Authentication.Requests;
using Tegu.Net.Shared.Domains.Authentication.Responses;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Managers;

public class AuthenticationManager
{
    private readonly ILogger<AuthenticationManager> _logger;
    private readonly IAuthRepository _authRepo;
    private readonly IUserRepository _userRepo;
    private readonly TokenService _tokenService;


    public AuthenticationManager(ILogger<AuthenticationManager> logger, IAuthRepository authRepo,
        IUserRepository userRepo, TokenService tokenService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _authRepo = authRepo ?? throw new ArgumentNullException(nameof(authRepo));
        _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    public async Task<Result<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
    {
        // Step 1: Get the user
        var userResult = await _userRepo.GetByEmail(request.Email, true);
        if (!userResult.IsSuccess())
            return Result<AuthenticateResponse>.FailMessage("User was not found!");

        var user = userResult.Data;

        // Step 2: Validate the password
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Result<AuthenticateResponse>.FailMessage("Username or password is incorrect!");

        // Step 3: Generate new Jwt and Refresh tokens
        var jwtToken = _tokenService.GenerateJwtToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken(user.Id);

        var refreshTokenAddResult = await _authRepo.AddRefreshToken(refreshToken);
        if (!refreshTokenAddResult.IsSuccess())
            return Result<AuthenticateResponse>.FailMessage("Server error...");

        return Result<AuthenticateResponse>.OkData(new AuthenticateResponse(jwtToken, refreshToken.Token));
    }

    public async Task<Result<AuthRefreshTokenResponse>> RefreshToken(AuthRefreshTokenRequest request)
    {
        return Result<AuthRefreshTokenResponse>.Fail();
    }
}