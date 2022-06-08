using Tegu.Net.Shared.Domains.User.Dtos;

namespace Tegu.Net.Shared.Domains.Tegu.Dtos;

public class OwnedTeguDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public TeguTypeDto TeguType { get; set; }

    public UserDto Owner { get; set; }
}