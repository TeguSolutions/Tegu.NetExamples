namespace Tegu.Net.Client.Maui.Services;

public class ThemeService
{
    public const string Theme = "theme";

    public void ToggleTheme()
    {
        if (Application.Current is null)
            return;

        if (Application.Current.UserAppTheme == AppTheme.Light)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else if (Application.Current.UserAppTheme == AppTheme.Dark)
            Application.Current.UserAppTheme = AppTheme.Light;
        else if (Application.Current.UserAppTheme == AppTheme.Unspecified)
            Application.Current.UserAppTheme = AppTheme.Light;

        Preferences.Set(Theme, Application.Current.UserAppTheme.ToString());
    }
}