
using Tegu.Net.Client.Maui.Helper;

namespace Tegu.Net.Client.Maui.Pages;

public partial class MainVM : ViewModelBase
{
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