
using Tegu.Net.Client.Maui.Helper;

namespace Tegu.Net.Client.Maui.Pages;

public partial class MainVM : ViewModelBase
{
    [ICommand]
    public async void NavigateToControls()
    {
        await Shell.Current.GoToAsync(nameof(ControlsPage), true);
    }

    [ICommand]
    public async void NavigateToMVVM()
    {
        //await Shell.Current.GoToAsync(nameof(MVVMOnePage), true);
        //await Shell.Current.GoToAsync("MVVM", true);

        //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
        await Shell.Current.GoToAsync($"//{nameof(MVVMOnePage)}", true);
    }
}