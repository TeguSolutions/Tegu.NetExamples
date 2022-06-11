using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.Shared.DataLayer;

public interface IAuthRepository
{
    Task<Result> AddRefreshToken(RefreshToken refreshToken);
    Task<Result<RefreshToken>> GetRefreshToken(Guid refreshTokenId);
    Task<Result> DeleteRefreshToken(RefreshToken refreshToken);
}