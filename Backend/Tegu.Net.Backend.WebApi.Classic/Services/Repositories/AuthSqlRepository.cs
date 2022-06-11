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

    public async Task<Result> AddRefreshToken(RefreshToken refreshtoken)
    {
        
    }

    public async Task<Result<RefreshToken>> GetRefreshToken(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteRefreshToken(RefreshToken refreshtoken)
    {
        throw new NotImplementedException();
    }
}