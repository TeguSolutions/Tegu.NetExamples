using Tegu.Net.Shared.Definitions;

namespace Tegu.Net.Backend.Shared.Helpers;

public class SecurityContext
{
    /// <summary>
    /// Empty
    /// </summary>
    public SecurityContext()
    {
        Roles = new List<string>();
    }

    /// <summary>
    /// For Web Api Client
    /// </summary>
    /// <param name="userId"></param>
    public SecurityContext(Guid userId)
    {
        UserId = userId;
        Roles = new List<string>();
    }

    /// <summary>
    /// For Web Api MediatR
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roles"></param>
    public SecurityContext(Guid userId, List<string> roles)
    {
        UserId = userId;
        Roles = roles;
    }

    public Guid UserId { get; set; }
    public List<string> Roles { get; set; }

    public bool IsTegu => Roles.Contains(RoleDefinitions.Tegu.Name) ;
    public bool IsClient => Roles.Contains(RoleDefinitions.Client.Name) ;

    public bool IsAuthenticated => Roles.Count != 0;

    public static SecurityContext Empty => new();
}