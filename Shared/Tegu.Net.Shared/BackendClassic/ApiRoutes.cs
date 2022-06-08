namespace Tegu.Net.Shared.BackendClassic;

public static class ApiRoutes
{
    public static class Authentication
    {
        public const string ControllerRouteTemplate = "api/authorization";
        public static string ControllerUri { get; } = "api/authorization/";
    }
}