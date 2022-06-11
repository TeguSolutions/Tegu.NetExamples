using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Shared.DataLayer;

namespace Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

public class TeguSqlRepository : ITeguRepository
{
    private readonly ILogger<TeguSqlRepository> _logger;
    private readonly IDbContextFactory<TeguSqlContext> _factory;

    public TeguSqlRepository(ILogger<TeguSqlRepository> logger, IDbContextFactory<TeguSqlContext> factory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }
}