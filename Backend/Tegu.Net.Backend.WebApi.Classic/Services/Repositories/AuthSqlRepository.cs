using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

public class AuthSqlRepository : IAuthRepository
{
    private readonly ILogger<AuthSqlRepository> _logger;
    private readonly IDbContextFactory<TeguSqlContext> _dbFactory;

    public AuthSqlRepository(ILogger<AuthSqlRepository> logger, IDbContextFactory<TeguSqlContext> dbFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
    }

    public async Task<Result> AddRefreshToken(RefreshToken refreshToken)
    {
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            await dbContext.RefreshTokens.AddAsync(refreshToken);
            await dbContext.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result.Fail();
        }
    }

    public async Task<Result<RefreshToken>> GetRefreshTokenById(Guid refreshTokenId)
    {
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            var refreshToken = await dbContext.RefreshTokens.FirstAsync(q => q.Id == refreshTokenId);
            return Result<RefreshToken>.OkData(refreshToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<RefreshToken>.Fail();
        }
    }

    public async Task<Result<RefreshToken>> GetRefreshTokenByToken(string refreshToken)
    {
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            var dbRefreshToken = await dbContext.RefreshTokens.FirstAsync(q => q.Token == refreshToken);
            return Result<RefreshToken>.OkData(dbRefreshToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<RefreshToken>.Fail();
        }
    }

    public async Task<Result> DeleteRefreshToken(RefreshToken refreshToken)
    {
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            // Todo: ?? probably not good
            //var refreshToken = await dbContext.RefreshTokens.FirstOrDefaultAsync()
            dbContext.RefreshTokens.Remove(refreshToken);
            await dbContext.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result.Fail();
        }
    }
}