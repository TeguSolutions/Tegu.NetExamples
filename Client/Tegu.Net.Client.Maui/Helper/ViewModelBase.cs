using CommunityToolkit.Mvvm.ComponentModel;

namespace Tegu.Net.Client.Maui.Helper;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    //[AlsoNotifyChangeFor(nameof(IsNotBusy))]
    private bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    private string title;
}
