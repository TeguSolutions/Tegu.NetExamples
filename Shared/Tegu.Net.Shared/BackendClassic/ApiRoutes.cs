namespace Tegu.Net.Shared.BackendClassic;

public static class ApiRoutes
{
    public static class Authentication
    {
        public const string ControllerRouteTemplate = "api/auth";
        public static string ControllerUri { get; } = "api/auth/";
    }
}