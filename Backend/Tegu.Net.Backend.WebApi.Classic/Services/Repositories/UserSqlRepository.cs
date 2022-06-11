using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

public class UserSqlRepository : IUserRepository
{
    private readonly ILogger<UserSqlRepository> _logger;
    private readonly IDbContextFactory<TeguSqlContext> _factory;

    public UserSqlRepository(ILogger<UserSqlRepository> logger, IDbContextFactory<TeguSqlContext> factory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public async Task<Result<User>> GetById(Guid userId, bool? includeRoles = null)
    {
        try
        {
            var context = await _factory.CreateDbContextAsync();

            var user = await context.Users
                .If(includeRoles is true, 
                    q => q.Include(u => u.UserRoles)
                                                    .ThenInclude(ur => ur.Role))
                .SingleOrDefaultAsync(q => q.Id == userId);
            return Result<User>.OkData(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<User>.Fail();
        }
    }

    public async Task<Result<User>> GetByEmail(string email, bool? roles = null)
    {
        throw new NotImplementedException();
    }
}