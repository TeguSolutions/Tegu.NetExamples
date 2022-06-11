namespace Tegu.Net.Shared.Domains.Authentication.Requests;

public class AuthenticateRequest
{
    public AuthenticateRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}