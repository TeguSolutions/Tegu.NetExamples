using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.Shared.DataLayer;

public interface IAuthRepository
{
    Task<Result> AddRefreshToken(RefreshToken refreshToken);
    Task<Result<RefreshToken>> GetRefreshTokenById(Guid refreshTokenId);
    Task<Result<RefreshToken>> GetRefreshTokenByToken(string refreshToken);
    Task<Result> DeleteRefreshToken(Guid refreshTokenId);
}