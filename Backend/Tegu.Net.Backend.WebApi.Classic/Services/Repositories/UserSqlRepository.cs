using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

public class UserSqlRepository : IUserRepository
{
    private readonly ILogger<UserSqlRepository> _logger;
    private readonly IDbContextFactory<TeguSqlContext> _dbFactory;

    public UserSqlRepository(ILogger<UserSqlRepository> logger, IDbContextFactory<TeguSqlContext> dbFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
    }

    public async Task<Result<User>> GetById(Guid userId, bool? roles = null)
    {
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            var user = await dbContext.Users
                .If(roles is true, 
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
        try
        {
            var dbContext = await _dbFactory.CreateDbContextAsync();

            var user = await dbContext.Users
                .If(roles is true, 
                    q => q.Include(u => u.UserRoles)
                        .ThenInclude(ur => ur.Role))
                .SingleOrDefaultAsync(q => q.Email.ToLower() == email.ToLower());
            return Result<User>.OkData(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e);
            return Result<User>.Fail();
        }
    }
}