using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.Shared.DataLayer;

public interface IAuthRepository
{
    Task<Result> AddRefreshToken(RefreshToken refreshtoken);
    Task<Result<RefreshToken>> GetRefreshToken(Guid id);
    Task<Result> DeleteRefreshToken(RefreshToken refreshtoken);
}