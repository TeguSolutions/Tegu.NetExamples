﻿using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Backend.Shared.Helpers;
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

    public async Task<Result<AuthLoginResponse>> Authenticate(AuthLoginRequest request)
    {
        try
        {
            // Step 1: Get the user
            var userResult = await _userRepo.GetByEmail(request.Email, true);
            if (!userResult.IsSuccess())
                return Result<AuthLoginResponse>.FailMessage("User was not found!");

            var user = userResult.Data;

            // Step 2: Validate the password
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Result<AuthLoginResponse>.FailMessage("Username or password is incorrect!");

            // Step 3: Generate new Jwt and Refresh tokens
            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);

            var refreshTokenAddResult = await _authRepo.AddRefreshToken(refreshToken);
            if (!refreshTokenAddResult.IsSuccess())
                return Result<AuthLoginResponse>.FailMessage("Server error...");

            return Result<AuthLoginResponse>.OkData(new AuthLoginResponse(jwtToken, refreshToken.Token));
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<AuthLoginResponse>.FailMessage("Server error...");
        }
    }

    public async Task<Result<AuthRefreshTokenResponse>> RefreshToken(SecurityContext context, AuthRefreshTokenRequest request)
    {
        try
        {
            // Step 1: Get the user
            var userResult = await _userRepo.GetById(context.UserId, true);
            if (!userResult.IsSuccess())
                return Result<AuthRefreshTokenResponse>.FailMessage("User was not found!");

            var user = userResult.Data;

            // Step 2: Get the Refresh Token
            var refreshTokenResult = await _authRepo.GetRefreshTokenByToken(request.RefreshToken);
            if (!refreshTokenResult.IsSuccess())
                return Result<AuthRefreshTokenResponse>.FailMessage("Refresh Token was not found!");

            var oldRefreshToken = refreshTokenResult.Data;

            // Step 3: Generate the new Jwt / Refresh Tokens
            var newRefreshToken = _tokenService.GenerateRefreshToken(user.Id);
            var jwtToken = _tokenService.GenerateJwtToken(user);

            // Step 4: Delete the old, add the new Refresh Token
            var removeRefreshTokenResult = await _authRepo.DeleteRefreshToken(oldRefreshToken.Id);
            if (!removeRefreshTokenResult.IsSuccess())
            {
                // Ignore this case..
            }
            var addNewRefreshTokenResult = await _authRepo.AddRefreshToken(newRefreshToken);
            if (!addNewRefreshTokenResult.IsSuccess())
                return Result<AuthRefreshTokenResponse>.FailMessage("Server error...");

            return Result<AuthRefreshTokenResponse>.OkData(new AuthRefreshTokenResponse(jwtToken, newRefreshToken.Token));
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<AuthRefreshTokenResponse>.FailMessage("Server error...");
        }
    }
}