namespace Tegu.Net.Shared.BackendClassic;

public static class ApiRoutes
{
    private static string baseUri;

    public static void Initialize(string apiBaseUri)
    {
        baseUri = apiBaseUri;
    }

    public static class AuthenticationTest
    {
        public const string ControllerRouteTemplate = "api/authtest";
        public static string ControllerUri => "api/authtest/";

        #region AuthBase

        public const string AuthBase = "authbase";
        public static Uri AuthBaseUri => new(baseUri + ControllerUri + AuthBase);

        #endregion

        #region AuthRoleTegu

        public const string AuthRoleTegu = "authroletegu";
        public static Uri AuthRoleTeguUri => new(baseUri + ControllerUri + AuthRoleTegu);

        #endregion

        #region AuthRoleClient

        public const string AuthRoleClient = "authroleclient";
        public static Uri AuthRoleClientUri => new(baseUri + ControllerUri + AuthRoleClient);

        #endregion

        #region AuthRoleAny

        public const string AuthRoleAny = "authroleany";
        public static Uri AuthRoleAnyUri => new(baseUri + ControllerUri + AuthRoleAny);

        #endregion

        #region AuthAnonymous

        public const string AuthAnonymous = "authanonymous";
        public static Uri AuthAnonymousUri => new(baseUri + ControllerUri + AuthAnonymous);

        #endregion
    }

    public static class Authentication
    {
        public const string ControllerRouteTemplate = "api/auth";
        public static string ControllerUri => "api/auth/";

        #region Login

        public const string Login = "login";
        public static Uri LoginUri => new(baseUri + ControllerUri + Login);

        #endregion

        #region RefreshToken

        public const string RefreshToken = "refreshtoken";
        public static Uri RefreshTokenUri => new(baseUri + ControllerUri + RefreshToken);

        #endregion
    }

    public static class User
    {
        public const string ControllerRouteTemplate = "api/user";
        public static string ControllerUri => "api/user/";
    }

    public static class Tegu
    {
        public const string ControllerRouteTemplate = "api/tegu";
        public static string ControllerUri => "api/tegu/";


    }
}