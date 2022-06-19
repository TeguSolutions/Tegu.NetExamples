using Tegu.Net.Client.Maui.Helper;
using Tegu.Net.Client.Maui.Services;

namespace Tegu.Net.Client.Maui.Pages.Public;

public partial class MainVM : ViewModelBase
{
    private ThemeService _themeService;

    public MainVM(ThemeService themeService)
    {
        _themeService = themeService;
    }

    [RelayCommand]
    public void ToggleTheme()
    {
        _themeService.ToggleTheme();
    }


    [RelayCommand]
    public async void NavigateToControls()
    {
        await Shell.Current.GoToAsync(nameof(ControlsPage), true);
    }

    [RelayCommand]
    public async void NavigateToMVVM()
    {
        await Shell.Current.GoToAsync($"//{nameof(MVVMOnePage)}", true);
    }
}