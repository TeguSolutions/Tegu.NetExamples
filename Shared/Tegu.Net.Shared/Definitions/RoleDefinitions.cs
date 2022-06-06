using System.Collections.ObjectModel;
using Tegu.Net.Shared.Domains.Role.Dtos;

namespace Tegu.Net.Shared.Definitions;

public static class RoleDefinitions
{
    static RoleDefinitions()
    {
        Collection = new ObservableCollection<RoleDto>
        {
            Tegu,
            Client
        };
    }

    public static ObservableCollection<RoleDto> Collection { get; }

    public static RoleDto Tegu { get; } = new() { Id = 1, Name = "Tegu" };
    public static RoleDto Client { get; } = new() { Id = 2, Name = "Client" };
}