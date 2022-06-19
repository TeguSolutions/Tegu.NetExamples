using Tegu.Net.Client.Maui.Services;

namespace Tegu.Net.Client.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        InitializeTheme();

        MainPage = new AppShell();
    }

    private static void InitializeTheme()
    {
        if (Current is null)
            return;

        var theme = Preferences.Get(ThemeService.Theme, AppTheme.Dark.ToString());
        if (!string.IsNullOrWhiteSpace(theme))
        {
            Current.UserAppTheme = theme == AppTheme.Light.ToString() ? AppTheme.Light : AppTheme.Dark;
            return;
        }

        Current.UserAppTheme = Current.RequestedTheme;
    }
}