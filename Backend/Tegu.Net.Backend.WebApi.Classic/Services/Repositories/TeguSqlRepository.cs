using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Shared.DataLayer;

namespace Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

public class TeguSqlRepository : ITeguRepository
{
    private readonly ILogger<TeguSqlRepository> _logger;
    private readonly IDbContextFactory<TeguSqlContext> _dbFactory;

    public TeguSqlRepository(ILogger<TeguSqlRepository> logger, IDbContextFactory<TeguSqlContext> dbFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
    }
}