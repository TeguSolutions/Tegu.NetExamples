using Tegu.Net.Shared.Domains.Role.Dtos;

namespace Tegu.Net.Shared.Domains.User.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public List<RoleDto> Roles { get; set; }
}