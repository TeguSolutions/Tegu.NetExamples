using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Helper;

namespace Tegu.Net.Backend.Shared.DataLayer;

public interface IUserRepository
{
    Task<Result<User>> GetById(Guid id, bool? roles = null);
    Task<Result<User>> GetByEmail(string email, bool? roles = null);
}