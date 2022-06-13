using CommunityToolkit.Maui;
using Tegu.Net.Client.Maui.Pages;
using Tegu.Net.Client.Maui.Services;

namespace Tegu.Net.Client.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var s = builder.Services;

            #region Page and VM Registrations

            s.AddTransient<MainPage>();
            s.AddTransient<MainVM>();

            s.AddTransient<ControlsPage>();
            s.AddTransient<ControlsVM>();

            s.AddTransient<MVVMOnePage>();
            s.AddTransient<MVVMOneVM>();

            s.AddTransient<MVVMTwoPage>();
            s.AddTransient<MVVMTwoVM>();

            s.AddTransient<NavigationAbsolutePage>();
            s.AddTransient<NavigationAbsoluteVM>();

            #endregion

            #region Services

            s.AddTransient<DataService>();

            #endregion

            return builder.Build();
        }
    }
}