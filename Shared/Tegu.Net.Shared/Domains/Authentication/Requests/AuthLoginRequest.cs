namespace Tegu.Net.Shared.Domains.Authentication.Requests;

public class AuthLoginRequest
{
    public AuthLoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}